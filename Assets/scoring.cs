using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoring : MonoBehaviour {
	private int score;
	public Text scoreText;
	private float secondCount;
	private int check=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "coin") {
			Destroy (hit.gameObject);
			score++;
		}
		else if (hit.gameObject.tag == "obs") {
			if (check == 0) {
				score--;
				check = 1;
			

			}
			secondCount += Time.deltaTime;
			if (secondCount > 20) {
				check = 0;
				secondCount = 0;
			}
			/*secondCount += Time.deltaTime;
			if (secondCount > 1) {
				check = 0;
				secondCount = 0;
			}*/
		}
		scoreText.text = score.ToString ();

		/*if (score < -2) {
			SceneManager.LoadScene ("Menu");
		}*/
	}


}
