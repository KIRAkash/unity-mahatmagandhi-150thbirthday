using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicon : MonoBehaviour {
    public AudioSource as1;
    
     void Start()
    {
        
        
    }
    public void Off()
    {
        as1.Pause();
    } 
    public void onn()
    {
        as1.Play();
    }
}
