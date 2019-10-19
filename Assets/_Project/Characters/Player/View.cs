using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{

    [SerializeField] private float zoomFactor = 1.5f;

    private Camera cam;
    private float defaultFieldOfView;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        defaultFieldOfView = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Zoom"))
        {
            ZoomIn();
        }

        if (Input.GetButtonUp("Zoom"))
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        cam.fieldOfView = defaultFieldOfView / zoomFactor;
    }

    private void ZoomOut()
    {
        cam.fieldOfView = defaultFieldOfView;
    }
}
