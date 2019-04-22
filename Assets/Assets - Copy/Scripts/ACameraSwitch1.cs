using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACameraSwitch1 : MonoBehaviour
{
    [SerializeField]
    public GameObject ThirdCam;
    [SerializeField]
    public GameObject FirstCam;
    //public int CamMode;
    private bool switchCam = false;

    

    // Start is called before the first frame update
    void Start()
    {
        ThirdCam.SetActive(true);
        FirstCam.SetActive(false);
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
            FirstCam.SetActive(false);
            ThirdCam.SetActive(true);
        }
        else
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
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
