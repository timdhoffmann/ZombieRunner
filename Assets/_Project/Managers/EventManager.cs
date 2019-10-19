using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour 
{
    // TODO: When using System.EventHandler, how to handle additional parameters?
    #region Events to subscribe to.
    public static event EventHandler ClearAreaDetected;
    public static event EventHandler BlockedAreaDetected;
    public static event EventHandler HelicopterCalled;
    #endregion

    #region Methods for raising events.
    public static void OnClearAreaDetected()
    {
        // Protect against having no subscribers.
        if (ClearAreaDetected != null)
        {
            // Raise static event without passing sender or data as arguments.

            // VARIANT A: using custom delegate EventHandler
            ClearAreaDetected(null, EventArgs.Empty);
            
            // VARIANT B: using System.EventHandler
            // ClearAreaFound(null, EventArgs.Empty); 
        }
    }

    public static void OnBlockedAreaDetected ()
    {
        // Protect against having no subscribers.
        if (BlockedAreaDetected != null)
        {
            // Raise static event without passing sender or data as arguments.
            // VARIANT A: using custom delegate EventHandler
            BlockedAreaDetected(null, EventArgs.Empty);
        }
    }

    public static void OnHelicopterCalled ()
    {
        // Protect against having no subscribers.
        if (HelicopterCalled != null)
        {
            // Raise static event without passing sender or data as arguments.
            // VARIANT A: using custom delegate EventHandler
            HelicopterCalled(null, EventArgs.Empty);
        }
    }
    #endregion
}
