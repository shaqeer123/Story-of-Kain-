using UnityEngine;
using System.Collections;

public class NPC_Citizen : MonoBehaviour {
	bool chat;
	public Camera MainCamera;
	public Camera NPCCitizen;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//ray can 3d vectr
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		//raycant to see if npc is infront of player 
		//distance is 9
		if (Physics.Raycast (transform.position, fwd, 2, 9)) {
		
			chat = true;
		} else
			chat = false;

		if (chat == true) {
			//switch camera main camera off noc cam on
			MainCamera.gameObject.SetActive (false);
			NPCCitizen.gameObject.SetActive (true);

		} 

		if (chat == false) {
			NPCCitizen.gameObject.SetActive (false);
		}
	}

}
