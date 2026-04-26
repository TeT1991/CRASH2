using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillActive;
    public int TimerSkill;
    TextMeshProUGUI TimerText;
    public int RareCounter;
    void Start()
    {

        if (PlayerPrefs.GetInt("SkillSys") == 0)
        {
            if (RareCounter == 0)
            {
                TimerSkill = Random.Range(5, 12);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }

            if (RareCounter == 1)
            {
                TimerSkill = Random.Range(10, 18);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }

            if (RareCounter == 2)
            {
                TimerSkill = Random.Range(15, 25);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }

            if (RareCounter == 3)
            {
                TimerSkill = Random.Range(30, 45);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }
        }

        if (PlayerPrefs.GetInt("SkillSys") == 2)
        {
            if (RareCounter == 0)
            {
                TimerSkill = Random.Range(1, 2);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }

            if (RareCounter == 1)
            {
                TimerSkill = Random.Range(1, 2);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }

            if (RareCounter == 2)
            {
                TimerSkill = Random.Range(1, 2);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }

            if (RareCounter == 3)
            {
                TimerSkill = Random.Range(10, 15);
                StartCoroutine(ExampleCoroutine());
                TimerText = GetComponent<TextMeshProUGUI>();
            }
        }


    }

    public void Attacked()
    {
        if (PlayerPrefs.GetInt("SkillSys") == 0)
        {
            if (RareCounter == 0)
            {
                TimerSkill = Random.Range(5, 12);
            }

            if (RareCounter == 1)
            {
                TimerSkill = Random.Range(10, 18);
            }

            if (RareCounter == 2)
            {
                TimerSkill = Random.Range(15, 25);
            }

            if (RareCounter == 3)
            {
                TimerSkill = Random.Range(30, 45);
            }

        }

        if (PlayerPrefs.GetInt("SkillSys") == 2)
        {
            if (RareCounter == 0)
            {
                TimerSkill = Random.Range(1, 2);
            }

            if (RareCounter == 1)
            {
                TimerSkill = Random.Range(1, 2);
            }

            if (RareCounter == 2)
            {
                TimerSkill = Random.Range(1, 2);
            }

            if (RareCounter == 3)
            {
                TimerSkill = Random.Range(10, 15);
            }

        }

    }

    public void Refresh()
    {
        if (RareCounter == 0)
        {
            TimerSkill = Random.Range(5, 12);
            StartCoroutine(ExampleCoroutine());
            TimerText = GetComponent<TextMeshProUGUI>();
        }

        if (RareCounter == 1)
        {
            TimerSkill = Random.Range(10, 18);
            StartCoroutine(ExampleCoroutine());
            TimerText = GetComponent<TextMeshProUGUI>();
        }

        if (RareCounter == 2)
        {
            TimerSkill = Random.Range(15, 25);
            StartCoroutine(ExampleCoroutine());
            TimerText = GetComponent<TextMeshProUGUI>();
        }

        if (RareCounter == 3)
        {
            TimerSkill = Random.Range(30, 45);
            StartCoroutine(ExampleCoroutine());
            TimerText = GetComponent<TextMeshProUGUI>();
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        TimerSkill--;
        StartCoroutine(ExampleCoroutine());
    }

    private void Update()
    {

        if (TimerSkill >= 1)
        {
            TimerText.text = TimerSkill + " сек";
            SkillActive.SetActive(false);
        }


        if (TimerSkill <= 0)
        {
            TimerText.text ="Готово";
            TimerSkill = 0;
            SkillActive.SetActive(true);
        }
    }
}
