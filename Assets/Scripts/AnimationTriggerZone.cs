using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggerZone : MonoBehaviour
{
    public Animator targetAnimator;
    public string triggerName = "Open";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Collectible.isCollected)
        {
            targetAnimator.SetTrigger(triggerName);
        }
    }
}
