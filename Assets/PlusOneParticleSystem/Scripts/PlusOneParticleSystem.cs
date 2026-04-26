using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JetSystems
{
    public class PlusOneParticleSystem : MonoBehaviour
    {
        public static PlusOneParticleSystem instance;

        [Header(" Settings ")]
        [SerializeField] private PlusOneParticle particlePrefab;
        [SerializeField] private bool destroyLastParticle;
        private PlusOneParticle lastParticle;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }               

        public void PlayPlusOneParticle(Vector3 particlePosition, string particleText)
        {
            PlayPlusOneParticle(particlePosition, transform, particleText);
        }

        public void PlayPlusOneParticle(Vector3 particlePosition, Transform parent, string particleText)
        {
            if (destroyLastParticle)
                DestroyLastParticle();

            lastParticle = Instantiate(particlePrefab, particlePosition, Quaternion.identity, parent);
            lastParticle.SetParticleText(particleText);
        }

        private void DestroyLastParticle()
        {
            if (lastParticle == null) return;

            Destroy(lastParticle.gameObject);
        }
    }
}