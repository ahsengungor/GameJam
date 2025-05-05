using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCursorManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;                   
    }
}
