using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class InnerVoice : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float callReplyDelay = 2f;
    [SerializeField] private AudioClip whatHappened;
    [SerializeField] private AudioClip goodArea;
    [SerializeField] private AudioClip callHelicopter;
    [SerializeField] private AudioClip helicopterInitialCallReply;

    private AudioSource audioSource;

    #region EventManager subscriptions
    private void OnEnable()
    {
        EventManager.ClearAreaDetected += IndicateClearArea;
        EventManager.HelicopterCalled += CallHelicopter;
    }

    private void OnDisable()
    {
        EventManager.ClearAreaDetected -= IndicateClearArea;
        EventManager.HelicopterCalled -= CallHelicopter;
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // TODO: Uncomment when done with testing.
        //audioSource.PlayOneShot(whatHappened);
    }

    // Called by Event ClearAreaDetected.
    private void IndicateClearArea(object sender, System.EventArgs e = null)
    {
        audioSource.PlayOneShot(goodArea);
    }

    // Called by Event HelicopterCalled.
    private void CallHelicopter(object sender, System.EventArgs e = null)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(callHelicopter);

        StartCoroutine(ReplyToInitialCall());
    }

    private IEnumerator ReplyToInitialCall()
    {
        //// TODO: Is Invoke as an alternative to Coroutine good practice?
        // eg. Invoke("ReplyToInitialCall", callReplyDelay);
        yield return new WaitForSeconds(callHelicopter.length + callReplyDelay);

        Debug.Assert(helicopterInitialCallReply, "missing sound for helicopterinitialcallreply.");
        audioSource.PlayOneShot(helicopterInitialCallReply);
    }
}
