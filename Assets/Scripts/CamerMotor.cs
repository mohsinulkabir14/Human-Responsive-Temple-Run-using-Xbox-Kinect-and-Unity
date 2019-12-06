using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMotor : MonoBehaviour {
	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + startOffset;
		moveVector.x = 0;
		moveVector.y = Mathf.Clamp (moveVector.y, 1, 3);

		transform.position = moveVector;
	}
}
