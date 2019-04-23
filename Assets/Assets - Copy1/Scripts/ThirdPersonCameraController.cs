﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
	public float RotationSpeed = 1;
	public Transform Target, Player; //problem?
	float mouseX, mouseY;

	//Dealing with Camera Obstructions
	public Transform Obstruction;
	float zoomSpeed = 2f;


    void Start()
    {
		Obstruction = Target;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
   
    }

	void LateUpdate()
	{
		CamControl();
		ViewObstructed ();

	}

	void CamControl()
	{
		mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
		mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
		mouseY = Mathf.Clamp (mouseY, -35, 85);

		transform.LookAt (Target);

		if (Input.GetKey (KeyCode.LeftControl)) {
			Target.rotation = Quaternion.Euler (mouseY, mouseX, 0);
		} else {
			Target.rotation = Quaternion.Euler (mouseY, mouseX, 0);
			Player.rotation = Quaternion.Euler (0, mouseX, 0);
		}
	}

	void ViewObstructed()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
			{
			if(hit.collider.gameObject.tag != "Player") //Makes sure object blocking camera is not the player
				{
					Obstruction = hit.transform;
					Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

					if(Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
					{
						transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
					}
				}

				else
				{
					Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
					if(Vector3.Distance(transform.position, Target.position) <4.5f)
					{
						transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
					}
				}

			}

	}
}
