using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectObject(); // GameManager'a haber ver
            Destroy(gameObject); // Obje kaybolur
        }
    }
}
