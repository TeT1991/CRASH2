using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaggyVaggyBoss1 : MonoBehaviour
{
  public void NoCheater()
    {
        PlayerPrefs.SetInt("NoobCellH1", 3);
        PlayerPrefs.SetInt("SkillSys", 2);
        DiamondChkeer.instance.Diamond += 1000;
    }

}
