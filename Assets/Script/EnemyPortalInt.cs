using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortalInt : MonoBehaviour
{
    // Start is called before the first frame update
public void EnemyPortalPlus()
{
    ToPortal.instance.ToActivePortal -=1;
}

}
