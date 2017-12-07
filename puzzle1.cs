using UnityEngine;
using System.Collections;

public class puzzle1 : MonoBehaviour {
	UnityEngine.AI.NavMeshAgent boss;
	GameObject bossPos;
	GameObject player;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		boss = GetComponent<UnityEngine.AI.NavMeshAgent>();
		bossPos = GameObject.FindGameObjectWithTag("Soda");
		player = GameObject.FindGameObjectWithTag("Player");
		moveSpeed = 50.0f;
		}
	
	// Update is called once per frame
	void Update () {
		Vector3 bPos = new Vector3 (bossPos.transform.position.x, bossPos.transform.position.y, bossPos.transform.position.z);
		Vector3 pPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Vector3 reset = new Vector3 (9.0f, 1.0f, 5.0f);
		boss.speed = moveSpeed;
		if(Vector3.Distance(bPos,pPos) < 20)
		{
			Debug.Log ("works");
			boss.SetDestination(pPos);
			if (Vector3.Distance(bPos,pPos) < 3)
			{
				player.transform.Translate(reset);
				Debug.Log("Collision");
			}
		}
		else {
			boss.SetDestination(GameObject.FindWithTag("Food").transform.position);
		}
	}
}
