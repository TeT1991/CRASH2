using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GiftSystem : MonoBehaviour
{
    public int GiftCount;
    public TextMeshProUGUI GiftText;
    public GameObject GiftBox;

    void Start()
    {
        GiftCount = PlayerPrefs.GetInt("Gift");
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        GiftCount -= 1;
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        PlayerPrefs.SetInt("Gift", GiftCount);
        GiftText.text = "" + GiftCount;

        if (GiftCount == 0)
        {
            Wood.instance.WoodCount += 50;
            GiftBox.SetActive(true);
            GiftCount = 70;
        }
    }
}
