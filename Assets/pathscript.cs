using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class pathscript : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject mpc,lib,gb,wavy;
    public AudioSource asource1,asourcestopmusic;
    public AudioClip mpcin, mpcout, libin, libout, gin, gout;
    VirtualButtonBehaviour[] vrb2;
    // Use this for initialization
    void Start()
    {
        vrb2 = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vrb2.Length; i++)
        {
            vrb2[i].RegisterEventHandler(this);
        }
        mpc.SetActive(false);
        lib.SetActive(false);
        gb.SetActive(false);
        wavy.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "mpcbutton")
        {
            mpc.SetActive(true);
            lib.SetActive(false);
            gb.SetActive(false);
            wavy.SetActive(false);
            asourcestopmusic.Stop();
            asource1.Stop();
            asource1.PlayOneShot(mpcin);

        }
        if (vb.VirtualButtonName == "librarybutton")
        {

            mpc.SetActive(false);
            lib.SetActive(true);
            gb.SetActive(false);
            wavy.SetActive(false);
            asourcestopmusic.Stop();
            asource1.Stop();
            asource1.PlayOneShot(libin);


        }
        if (vb.VirtualButtonName == "buildingbutton")
        {
            mpc.SetActive(false);
            lib.SetActive(false);
            gb.SetActive(true);
            wavy.SetActive(false);
            asourcestopmusic.Stop();
            asource1.Stop();
            asource1.PlayOneShot(gin);

        }
       
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "mpcbutton")
        {
            asource1.Stop();
            asourcestopmusic.Stop();
            asource1.PlayOneShot(mpcout);

        }
        if (vb.VirtualButtonName == "librarybutton")
        {
            asource1.Stop();
            asourcestopmusic.Stop();
            asource1.PlayOneShot(libout);

        }
        if (vb.VirtualButtonName == "buildingbutton")
        {
            asource1.Stop();
            asourcestopmusic.Stop();
            asource1.PlayOneShot(gout);

        }
        
    }
}
