using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]

public class Helicopter : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;

    #region EventManager subscriptions
    private void OnEnable()
    {
        EventManager.HelicopterCalled += FlyToRescueZone;
    }

    private void OnDisable()
    {
        EventManager.HelicopterCalled -= FlyToRescueZone;
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Called by HelicopterCalled Event.
    private void FlyToRescueZone(object sender, System.EventArgs e = null)
    {
        Debug.Assert(audioSource);
        audioSource.Play();
        // TODO: Refine targeting, animate landing.
        rb.velocity = new Vector3(50f, 0f, 50f);

    }
}
