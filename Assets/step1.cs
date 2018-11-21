using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step1 : MonoBehaviour {
    public GameObject vide,videprev,text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        vide.SetActive(true);
        text.SetActive(true);
        videprev.SetActive(false);
	}
}
