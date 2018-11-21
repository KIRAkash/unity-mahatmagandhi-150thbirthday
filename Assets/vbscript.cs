using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbscript : MonoBehaviour,IVirtualButtonEventHandler {
   public GameObject g3;
    VirtualButtonBehaviour vrb;
	
	void Start () {
        vrb = GetComponentInChildren<VirtualButtonBehaviour> ();
        vrb.RegisterEventHandler(this);
        g3.SetActive(false);

	}
	
	
	void Update () {
		
	}
   public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        g3.SetActive(true);
    }
   public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
}
