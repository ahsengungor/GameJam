using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finaltrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // veya kendi karakter tag'ine göre değiştir
        {
            SceneManager.LoadScene("Level_2");
        }
    }
}
