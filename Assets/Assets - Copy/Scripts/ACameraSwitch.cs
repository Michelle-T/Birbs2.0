using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACameraSwitch : MonoBehaviour
{
    [SerializeField]
    //public GameObject ThirdCam;
    Camera ThirdCam;
    [SerializeField]
    Camera FirstCam;
    //public GameObject FirstCam;

    AudioListener ThirdCamAudioLis;
    AudioListener FirstCamAudioLis;

    //public int CamMode;

    public bool switchCam = false;

    // Start is called before the first frame update
    void Start()
    {
        ThirdCam.GetComponent<Camera>().enabled = true;
        FirstCam.GetComponent<Camera>().enabled = false;

        FirstCamAudioLis = FirstCam.GetComponent<AudioListener>();
        ThirdCamAudioLis = ThirdCam.GetComponent<AudioListener>();
        //ThirdCam.SetActive(true);
        //FirstCam.SetActive(false);
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
            FirstCam.GetComponent<Camera>().enabled = true;
            FirstCamAudioLis.enabled = true;
            ThirdCam.GetComponent<Camera>().enabled = false;
            ThirdCamAudioLis.enabled = false;
        }
        else
        {
            FirstCam.GetComponent<Camera>().enabled = false;
            FirstCamAudioLis.enabled = false;
            ThirdCam.GetComponent<Camera>().enabled = true;
            ThirdCamAudioLis.enabled = true;
        }
    }

    /*IEnumerator CamChange ()
    {
        {
            yield return new WaitForSeconds(0.01f);
            if (CamMode == 0)
            {
                ThirdCam.SetActive(true);
                FirstCam.SetActive(false);
            }
            if (CamMode == 1)
            {
                FirstCam.SetActive(true);
                ThirdCam.SetActive(false);
            }
        }
    }*/
}
