using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public GameObject ShopButton;
    public GameObject Build1;
    public GameObject Build1U1;
    public GameObject Build1U2;
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject Companion1;
    public GameObject Companion2;
    public GameObject Companion3;
    public GameObject Shop1;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject NoobCell;
    public GameObject Cheast1;
    public GameObject ZoneBuild1;
    public GameObject ZoneBuild2;
    public GameObject ZoneBuildPortal;
    public GameObject ZoneBuildPortal2;
    public GameObject ZoneBuildWeapon;
    public GameObject ZoneBuildCompanion;

    public GameObject Job1;
    public GameObject Job2;
    public GameObject Job3;
    public GameObject Job4;
    public GameObject Job5;
    public GameObject Job6;
    public GameObject ZoneJob1;
    public GameObject ZoneJob2;
    public GameObject ZoneJob3;
    public GameObject ZoneJob4;
    public GameObject ZoneJob5;
    public GameObject ZoneJob6;


    public GameObject ZoneNNewZone1;
    public GameObject ZoneNNewZone2;
    public GameObject ZoneNNewZone3;


    public GameObject Hagy;
    public GameObject NoobAura;


public void WoodCutterH()
{
    PlayerPrefs.SetInt("WoodCutterH", 1);
    ZoneBuild1.SetActive(false);
}

public void WoodCutterHL2()
{
    PlayerPrefs.SetInt("WoodCutterH", 2);
}

public void WoodCutterHL3()
{
    PlayerPrefs.SetInt("WoodCutterH", 3);
}

public void ShopH1()
{
    PlayerPrefs.SetInt("ShopH", 1);
        ShopButton.SetActive(true);
}

public void PortalH1()
{
    PlayerPrefs.SetInt("PortalH", 1);
}

    public void WeaponH1()
    {
        PlayerPrefs.SetInt("WeaponH", 1);
    }

    public void WeaponH2()
    {
        PlayerPrefs.SetInt("WeaponH", 2);
    }

    public void WeaponH3()
    {
        PlayerPrefs.SetInt("WeaponH", 3);
    }

    public void CompanionH1()
    {
        PlayerPrefs.SetInt("CompanionH", 1);
    }

    public void CompanionH2()
    {
        PlayerPrefs.SetInt("CompanionH", 2);
    }

    public void CompanionH3()
    {
        PlayerPrefs.SetInt("CompanionH", 3);
    }

    public void Portal3()
    {
        PlayerPrefs.SetInt("Portal3", 3);
    }

    public void NoobCellH1()
    {
        PlayerPrefs.SetInt("NoobCellH1", 3);
    }



    public void Job1H()
    {
        PlayerPrefs.SetInt("Job1H", 3);
    }

    public void Job2H()
    {
        PlayerPrefs.SetInt("Job2H", 3);
    }

    public void Job3H()
    {
        PlayerPrefs.SetInt("Job3H", 3);
    }

    public void Job4H()
    {
        PlayerPrefs.SetInt("Job4H", 3);
    }

    public void Job5H()
    {
        PlayerPrefs.SetInt("Job5H", 3);
    }

    public void Job6H()
    {
        PlayerPrefs.SetInt("Job6H", 3);
    }

    public void ZoneN1()
    {
        PlayerPrefs.SetInt("ZoneN1", 3);
    }

    public void ZoneN2()
    {
        PlayerPrefs.SetInt("ZoneN2", 3);
    }

    public void ZoneN3()
    {
        PlayerPrefs.SetInt("ZoneN3", 3);
    }


    public void CheastH1()
{
    StartCoroutine(ExampleCoroutine());
}



    private void Awake()
    {
        instance = this;
    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("CheastH", 1);
    }


    private void Start()
    {
        if (PlayerPrefs.GetInt("ShopH") == 1)
        {
            ShopButton.SetActive(true);
            Shop1.SetActive(true);
            ZoneBuild2.SetActive(false);
        }
    }

    void Update()
    {
     if (PlayerPrefs.GetInt("WoodCutterH") == 1)
        {
            Build1.SetActive(true);
            ZoneBuild1.SetActive(false);
        }
        
    if (PlayerPrefs.GetInt("WoodCutterH") == 2)
        {
            Build1U1.SetActive(true);
            Build1.SetActive(false);
            ZoneBuild1.SetActive(false);
        }

    if (PlayerPrefs.GetInt("WoodCutterH") == 3)
        {
            Build1U1.SetActive(false);
            Build1U2.SetActive(true);
            ZoneBuild1.SetActive(false);
        }

    if (PlayerPrefs.GetInt("ShopH") == 1)
        {
            Shop1.SetActive(true);
            ZoneBuild2.SetActive(false);
        }

    if (PlayerPrefs.GetInt("PortalH") == 1)
        {
            Portal1.SetActive(true);
            ZoneBuildPortal.SetActive(false);
        }

    if (PlayerPrefs.GetInt("CheastH") == 1)
        {
            Cheast1.SetActive(false);
        }

        if (PlayerPrefs.GetInt("WeaponH") == 1)
        {
            Weapon1.SetActive(true);
            ZoneBuildWeapon.SetActive(false);
        }

        if (PlayerPrefs.GetInt("WeaponH") == 2)
        {
            Weapon2.SetActive(true);
            Weapon1.SetActive(false);
            ZoneBuildWeapon.SetActive(false);
        }

        if (PlayerPrefs.GetInt("WeaponH") == 3)
        {
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
            ZoneBuildWeapon.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CompanionH") == 1)
        {
            Companion1.SetActive(true);
            ZoneBuildCompanion.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CompanionH") == 2)
        {
            Companion2.SetActive(true);
            Companion1.SetActive(false);
            ZoneBuildCompanion.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CompanionH") == 3)
        {
            Companion2.SetActive(false);
            Companion3.SetActive(true);
            ZoneBuildCompanion.SetActive(false);
        }

        if (PlayerPrefs.GetInt("NoobCellH1") == 3)
        {
            NoobCell.SetActive(false);
            Hagy.SetActive(true);
            NoobAura.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Portal3") == 3)
        {
            Portal2.SetActive(true);
            ZoneBuildPortal2.SetActive(false);
        }



        if (PlayerPrefs.GetInt("Job1H") == 3)
        {
            Job1.SetActive(true);
            ZoneJob1.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Job2H") == 3)
        {
            Job2.SetActive(true);
            ZoneJob2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Job3H") == 3)
        {
            Job3.SetActive(true);
            ZoneJob3.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Job4H") == 3)
        {
            Job4.SetActive(true);
            ZoneJob4.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Job5H") == 3)
        {
            Job5.SetActive(true);
            ZoneJob5.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Job6H") == 3)
        {
            Job6.SetActive(true);
            ZoneJob6.SetActive(false);
        }

        if (PlayerPrefs.GetInt("ZoneN1") == 3)
        {
            ZoneNNewZone1.SetActive(false);
        }

        if (PlayerPrefs.GetInt("ZoneN2") == 3)
        {
            ZoneNNewZone2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("ZoneN3") == 3)
        {
            ZoneNNewZone3.SetActive(false);
        }

    }
}
