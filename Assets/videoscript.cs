using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoscript : MonoBehaviour {
    public GameObject g3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time == 10)
        {
            g3.SetActive(true);
        }
	}
}
