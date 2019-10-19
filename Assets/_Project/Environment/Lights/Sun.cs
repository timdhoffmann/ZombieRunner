using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour 
{
    [SerializeField, Tooltip("Duration of an in-game day in real world minutes (realtime = 1440).")]
    int gameDayDurationMinutes = 10;
    float degreesPerSecond;

	// Use this for initialization
	void Start() 
	{
        degreesPerSecond = 360f / (gameDayDurationMinutes * 60f);
    }
	
	// Update is called once per frame
	void Update() 
	{
        // Rotate the sun around local X axis. 
        if (gameDayDurationMinutes > 0)
        {
            transform.Rotate(Vector3.right, Time.deltaTime * degreesPerSecond);
        }
	}
}
