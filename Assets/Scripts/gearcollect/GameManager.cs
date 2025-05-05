using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject finalredlight;
    public GameObject finalgreenlight;

    public int totalCollectibles = 3;
    private int collectedCount = 0;

    public GameObject door; // Kapı objesi
    public Animator doorAnimator; // Eğer animasyonla açılıyorsa

    void Awake()
    {
        collectedCount = 0;
        Instance = this;
    }

    public void CollectObject()
    {
        collectedCount++;
        Debug.Log("Toplanan obje sayısı: " + collectedCount);

        if (collectedCount >= totalCollectibles)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (doorAnimator != null)
        {
            finalgreenlight.SetActive(true);
            finalredlight.SetActive(false);
            doorAnimator.SetTrigger("Slide"); // Animator parametresi varsa
        }
        else if (door != null)
        {
            door.SetActive(false); // Ya da sadece kaybolsun
        }
    }
}

