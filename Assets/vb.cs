using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vb : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject vbBtnObj;
    public Animator cubeAni;

    // Use this for initialization
    void Start()
    {
        vbBtnObj = GameObject.Find("button");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        cubeAni.GetComponent<Animator>();
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        cubeAni.Play("rotation");
        Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        cubeAni.Play("none");
        Debug.Log("Button released");
    }
}

