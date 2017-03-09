using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveVec;


	public float speed = 5.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 15.0f;

	private float animationDuration = 3.0f;

	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	

	void Update () {
		//time.time means time scene has been running
		//if the time right now is under 3 seconds then we do this:   //if not, we do the rest of update function
		if (Time.time < animationDuration) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVec = Vector3.zero;

		if (controller.isGrounded) {
			verticalVelocity = -0.5f;
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		//calculate X (Left and Right)
		moveVec.x = Input.GetAxisRaw ("Horizontal") * speed;
	
		//calculate Y (Up and Down)
		moveVec.y = verticalVelocity;

		//calculate Z (Forward and Backward)
		moveVec.z = speed;

		controller.Move (moveVec * Time.deltaTime);
	}
}
