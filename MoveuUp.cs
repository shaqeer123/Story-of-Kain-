using UnityEngine;
using System.Collections;

public class MoveuUp : MonoBehaviour {
	//game objects
	GameObject corridor;
	GameObject Sword;
	GameObject player;
	//this bool is to trigget the moving platform
	private bool playerLift;
	//move speed variable
	float Timer = 6f;

	// Use this for initialization
	void Start () {
		Sword = GameObject.FindWithTag ("SwordToggle");
		player = GameObject.FindWithTag ("Player");
		corridor = GameObject.FindWithTag ("CorridorUp");
	}
	
	// Update is called once per frame
	void Update () {
		//these vectors are going to be used to calculate the distance
		//between the player and the sword to trigger the moving platform
		// vector of the player
		Vector3 pPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		// vector of the sword
		Vector3 sPos = new Vector3 (Sword.transform.position.x, Sword.transform.position.y, Sword.transform.position.z);

		// this condition is to see if the distance of the player and the sword is more than7
		// 3 if it is then the playerLift bool is set to true this will make the floor move forward.
		if (Vector3.Distance (pPos, sPos) < 3f) {
			playerLift = true;
		}
		//this if statement makes the floor and the sword move
		if (playerLift == true){
			corridor.transform.Translate (Vector3.right * 3f * Time.deltaTime);
			Sword.transform.Translate (Vector3.right * 3f * Time.deltaTime);

			if (Time.deltaTime >= Timer){
				corridor.transform.Translate(Vector3.back);
			}
		}
	}
}
