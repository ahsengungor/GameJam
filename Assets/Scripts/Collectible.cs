using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    public static bool isCollected = false;
    public GameObject redlight;
    public GameObject greenlight;
    public GameObject hedeflight;

    public void Start()
    {
        isCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            gameObject.SetActive(false); 
            redlight.SetActive(false);
            greenlight.SetActive(true);
            hedeflight.SetActive(false);
        }
    }
}

