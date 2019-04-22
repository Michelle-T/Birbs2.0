using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
	public float Speed;
	public float JumpHeight;
	private int JumpCount=0;
	public GameObject pausePanel;
	bool pause = false;
	bool scoring = true;
    //public Rigidbody rb;

    public float RotationSpeed = 1;
    public Transform Target, Player; //problem?
    float mouseX, mouseY;

    //Dealing with Camera Obstructions
    public Transform Obstruction;
    float zoomSpeed = 2f;


    public GameObject FPC;
    public GameObject TPC;

    void Start() {
		pausePanel.SetActive(false);
		//rb = GetComponent<Rigidbody>();
	}

	void Update() {
	if (Input.GetKeyDown("p"))
	{
		if (pause == true)
		{
			Time.timeScale = 0.0f;
			pausePanel.SetActive(true);
			scoring = false;
			pause = false;
		}
		else
		{
			Time.timeScale = 1.0f;
			pausePanel.SetActive(false);
			scoring = true;
			pause = true;
		}
	}

		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
	}

	void FixedUpdate() {
		
		PlayerMovement ();


//		if (Input.GetKey(KeyCode.W))
//			{
//		rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
//			}

		if (Input.GetKeyDown (KeyCode.Space) && JumpCount < 1 || Input.GetKeyDown("joystick button 0") && JumpCount < 1){
			StartCoroutine(Example());
			GetComponent<Rigidbody>().AddForce (Vector3.up * JumpHeight);
			}

	
	}

    private void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 85);
        if (FPC.activeSelf)
        {
            mouseY = Mathf.Clamp(mouseY, -90, 60);
        }

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    IEnumerator Example()
	{
		JumpCount = 1;
		yield return new WaitForSeconds(2);
		JumpCount = 0;
	}

	void PlayerMovement()
	{
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		Vector3 playerMovement = new Vector3 (hor, 0f, ver) * Speed * Time.deltaTime;
		transform.Translate (playerMovement, Space.Self);

		if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			Speed = 8;
		}
		if (Input.GetKey(KeyCode.Mouse1))
			{
				Speed = 2;
			}


	}
}
