using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class LandingAreaDetector : MonoBehaviour
{
    private bool hasDetectedClearArea = true;
    private float timeSinceLastBlockingTrigger = 0f;

    void Awake()
    {
        Debug.Assert(GetComponentInParent<Rigidbody>(), "Missing component on GameObject or parent GameObjects: Rigidbody");
    }

    private void Update()
    {
        timeSinceLastBlockingTrigger += Time.deltaTime;

        if (timeSinceLastBlockingTrigger >= 1f && !hasDetectedClearArea)
        {
            hasDetectedClearArea = true;
            // Raise event.
            EventManager.OnClearAreaDetected();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
        {
            // Only raise event when state has changed.
            if (hasDetectedClearArea)
            {
                EventManager.OnBlockedAreaDetected();
            }

            timeSinceLastBlockingTrigger = 0f;
            hasDetectedClearArea = false;
        }
    }
}
