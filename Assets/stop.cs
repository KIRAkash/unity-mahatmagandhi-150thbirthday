using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour {
    public GameObject g1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.deltaTime == 10)
        {
            g1.SetActive(false);
        }
        
	}
}
