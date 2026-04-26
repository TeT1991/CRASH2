using UnityEngine;
using UnityEngine.UI;

public class Sens : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}