using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVec;

	private float transition = 0.0f;
	private float animationDuration = 3.0f;
	private Vector3 animationOffset = new Vector3(0,5,5);

	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	

	void Update () {
		moveVec = lookAt.position + startOffset;
		//X
		moveVec.x = 0;
		//Y
		moveVec.y = Mathf.Clamp (moveVec.y,3,5);

		if (transition > 1.0f) {
			transform.position = lookAt.position + startOffset;
		} else {
			//animation at the start of the game
			transform.position = Vector3.Lerp (moveVec + animationOffset, moveVec, transition);
			transition += Time.deltaTime * 1 / animationDuration;
			transform.LookAt (lookAt.position + Vector3.up);
		}
	}
}
