using UnityEngine;
using System.Collections;

public class PuzzleEnd : MonoBehaviour {
	// game object variables
	//player
	GameObject player;
	//book
	GameObject book;
	//barrier blocking boss
	GameObject Gate;
	//canvas - gui confirming boss is not blocked
	public GameObject finalMessage;
	bool Visable;
	// Use this for initialization
	void Start () {
		book = GameObject.FindWithTag ("PuzzleBook");
		player = GameObject.FindWithTag ("Player");
		Gate = GameObject.FindWithTag ("BossGate");
	}
	
	// Update is called once per frame
	void Update () {
		//3d vectors for player and book
		Vector3 BookPos = new Vector3 (book.transform.position.x, book.transform.position.y, book.transform.position.z);
		Vector3 PlayerPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);

		Debug.Log (Vector3.Distance (BookPos, PlayerPos));

		//checks if player and books added distance is less than 2f
		if (Vector3.Distance (BookPos, PlayerPos) < 2f) {
			//destroys book game object
			Destroy (book);
			Visable = false;

				if(Visable == false){
				Destroy(Gate);
				//sets canvas active
				finalMessage.SetActive(true);
				}
		}

	}
}
