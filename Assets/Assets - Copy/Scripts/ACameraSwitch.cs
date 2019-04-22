﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACameraSwitch : MonoBehaviour
{
    [SerializeField]
    Camera ThirdCam;
    [SerializeField]
    Camera FirstCam;

    AudioListener ThirdCamAudioLis;
    AudioListener FirstCamAudioLis;
    //public int CamMode;
    private bool switchCam = false;

    // Start is called before the first frame update
    void Start()
    {
        ThirdCam.GetComponent<Camera>().enabled = true;
        FirstCam.GetComponent<Camera>().enabled = false;

        ThirdCamAudioLis = ThirdCam.GetComponent<AudioListener>();
        FirstCamAudioLis = FirstCam.GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            /*if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine (CamChange());*/
            switchCam = !switchCam;
        }

        if (switchCam == true)
        {
            FirstCam.GetComponent<Camera>().enabled = false;
            FirstCamAudioLis.enabled = true;
            ThirdCam.GetComponent<Camera>().enabled = true;
            ThirdCamAudioLis.enabled = true;
        }
        else
        {
            FirstCam.GetComponent<Camera>().enabled = true;
            FirstCamAudioLis.enabled = true;
            ThirdCam.GetComponent<Camera>().enabled = false;
            ThirdCamAudioLis.enabled = false;
        }
    }

    /*IEnumerator CamChange ()
    {
        {
            yield return new WaitForSeconds(0.01f);
            if (CamMode == 0)
            {
                ThirdCam.GetComponent<Camera>().enabled = true;
                FirstCam.GetComponent<Camera>().enabled = false;
            }
            if (CamMode == 1)
            {
                FirstCam.GetComponent<Camera>().enabled = true;
                ThirdCam.GetComponent<Camera>().enabled = false;
            }
        }*/
    //}
}
