using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timmmer : MonoBehaviour
{

    public static int Timer = 0;
    TextMeshProUGUI TimerText;

    void Start()
    {
        Timer = 0;
        StartCoroutine(ExampleCoroutine());
        TimerText = GetComponent<TextMeshProUGUI>();
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        Timer++;
        StartCoroutine(ExampleCoroutine());
    }

    private void Update()
    {
        TimerText.text = "Вы продержались " + Timer + " сек";
    }

}
