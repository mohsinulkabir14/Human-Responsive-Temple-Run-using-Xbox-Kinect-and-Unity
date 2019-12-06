using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour {
	public CharacterController controller;
	public Animator animator;
	GameObject player;
	private Vector3 moveVector,movement;
	private float speed= 5.0f;

	Rigidbody rb;
	Transform  playerTransform;

	public Text gestureText;
	private float jumpforce = 8f;
	//private float slideforce=-10.0f;
	public float gravity=15.0f;
	public int lane=0;
	uint UserID;
	KinectManager kinectManager;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		 playerTransform = player.transform;
		Vector3 position = playerTransform.position;
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator> ();
		gestureText.text = "Score: ";
		rb = player.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGrounded) {
			
			moveVector=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
			movement = transform.position;
			moveVector = transform.TransformDirection (moveVector);
			moveVector *= speed;
		}




		if (kinectManager == null)
		{
			kinectManager = KinectManager.Instance;
		}
		UserID = kinectManager.GetPlayer1ID ();

		if (kinectManager.GetGestureProgress(UserID,KinectGestures.Gestures.Jump)>0.5) {
		//if (Input.GetKey (KeyCode.UpArrow)) {
			kinectManager.ResetGesture (UserID, KinectGestures.Gestures.Jump);
			controller.height = 2;
			moveVector.y = jumpforce;

		}



		if (kinectManager.GetGestureProgress(UserID,KinectGestures.Gestures.Squat)>0.4) {
		//if(Input.GetKey(KeyCode.DownArrow)){
			controller.height = 1.2f;
			kinectManager.ResetGesture (UserID, KinectGestures.Gestures.Squat);
			Slide ();
		}
		if (kinectManager.GetGestureProgress (UserID, KinectGestures.Gestures.RaiseLeftHand) > 0.5 ){
			//gestureText.text = "Raise Left";
			moveVector.x = -3 * speed;
			kinectManager.ResetGesture (UserID, KinectGestures.Gestures.RaiseLeftHand);

		}
		if (kinectManager.GetGestureProgress (UserID, KinectGestures.Gestures.RaiseRightHand) > 0.5 ){
			//gestureText.text = "Raise Right";

			moveVector.x = 3 * speed;
			kinectManager.ResetGesture (UserID, KinectGestures.Gestures.RaiseRightHand);

		}

		if (playerTransform.position.x < -3.5 ) {
			moveVector.x = 5 * speed;
			
		}

		if (playerTransform.position.x > 3.5 ) {
			moveVector.x = -5 * speed;

		}

		if (playerTransform.position.y > 2 ) {
			
			moveVector.y -= gravity * Time.deltaTime;
			//gravity = gravity * 1.45f;
		
		}

		//gestureText.text = Input.GetAxisRaw ("Horizontal").ToString ();
	



		//moveVector.x = Input.GetAxisRaw ("Horizontal") * speed;

		moveVector.z = speed-3;

		controller.Move (moveVector * Time.deltaTime);



}
void Slide(){
	animator.SetTrigger ("slide");
	Invoke ("stopslide", 0.1f);

}

void stopslide()
{
	animator.SetTrigger ("stopslide");
}

 void stopjump()
{
	animator.SetTrigger ("stopjump");
}

}
