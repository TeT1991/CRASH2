using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JetSystems
{
    public class PlusOneParticle : MonoBehaviour
    {
        [Header(" Settings ")]
        [SerializeField] private TextMeshPro particleText;
        [SerializeField] private float movementMagnitude;
        [SerializeField] private GameObject[] additionalObjects;
        private float initialLocalPositionY;

        private void Start()
        {
            initialLocalPositionY = transform.localPosition.y;
        }

        public void Play(string text)
        {
            FaceCamera();
            
            ChangeAdditionalObjectsState(true);

            LeanTween.cancel(gameObject);
            transform.localPosition = transform.localPosition.With(y: initialLocalPositionY);
            transform.localScale = Vector3.one;

            SetParticleText(text);
            LeanTween.moveLocalY(gameObject, initialLocalPositionY + movementMagnitude, 0.5f).setOnComplete(WaitAndHide);
            LeanTween.scale(gameObject, Vector3.one * 1.1f, 0.5f).setEase(LeanTweenType.punch);
        }

        private void WaitAndHide()
        {
            LeanTween.delayedCall(gameObject, 2, Hide).setOnUpdate(FaceCamera);
        }

        private void FaceCamera(float f = 0)
        {
            transform.forward = Camera.main.transform.forward;
        }

        private void Hide()
        {
            SetParticleText("");
            ChangeAdditionalObjectsState(false);
        }

        public void SetParticleText(string text)
        {
            particleText.text = text;
        }

        private void ChangeAdditionalObjectsState(bool state)
        {
            foreach (GameObject obj in additionalObjects)
                obj.SetActive(state);
        }

        private void DestroyParticle()
        {
            Destroy(gameObject);
        }
    }
}
