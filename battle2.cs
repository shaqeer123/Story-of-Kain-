using UnityEngine;
using System.Collections;

public class battle2 : MonoBehaviour {
	//player stats
	//Defence
	private int Def = 10;
	//Attack
	private int Str = 20;
	private int PlayerAtk;

	//enemy stats
	//attack
	private int bossStr = 11;
	//defence
	private int bossDef = 5;
	private int BossAtk;

	//camera switch
	bool inBattle;

	//turn switch
	bool playerTurn;
	bool enemyTurn;
	//this is used to change whos turn it is
	int turn;
	
	private bool camSwitch;
	
	GameObject player;
	GameObject Enemy;
	GameObject battlePlayer;
	GameObject battleEnemy;
	public GameObject Menu;
	
	public Camera MainCamera;
	public Camera Camera2;
	public Camera InventoryCam;

	//animator for player
	public Animation pAnim;
	//animator for enemy
	public Animator bAnim;

	//player health and GUI infomation
	public int maxHealth = 100;
	public int curHealth;
	public int attack;
	public float barLength;

	//boss health
	int bossHP;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		Enemy = GameObject.FindWithTag ("EditorOnly");
		inBattle = false;
		pAnim = GetComponent<Animation> ();
		turn = turn+1;
		attack = 100;
		bossHP = 40;
		Menu = GameObject.FindWithTag ("Finish");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerAtk = Defence;

		if (bossHP < 0) {

			Enemy.SetActive(false);
			
		}

		//3d vectors to find distance between player and enemy
		Vector3 BossPos = new Vector3 (Enemy.transform.position.x, Enemy.transform.position.y, Enemy.transform.position.z);
		Vector3 PlayerPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Vector3 PlayerBattlePos = new Vector3();
		PlayerBattlePos = (player.transform.position - Enemy.transform.position);
		
		if (Vector3.Distance (BossPos, PlayerPos) < 2.5f && bossHP > 0) {
			inBattle = true;
			
		} else 
			inBattle = false;
		
		if (inBattle == true) {
			Enemy.transform.rotation = Quaternion.LookRotation (PlayerBattlePos);
			MainCamera.enabled = false;
			MainCamera.gameObject.SetActive (false);
			Camera2.enabled = true;
			Camera2.gameObject.SetActive (true);
			InventoryCam.enabled = false;
			InventoryCam.gameObject.SetActive (false);
			barLength = Screen.width / 3;
			curHealth = attack;
			
			if ( turn == 1){
				
				playerTurn = true;
				enemyTurn = false;
				
				if (playerTurn == true) {
					
					if (Input.GetKeyUp (KeyCode.Q)) {
						pAnim.Play ("Attack");
						bossHP = bossHP - PlayerDamage;
						Debug.Log (bossHP);
						turn = turn - 1;
					}
					
					
				}
			}else if(turn == 0){
				playerTurn = false;
				enemyTurn = true;
				turn = turn + 1;
				attack = attack - BossDamage;
				
				
				
			}
			
		} else 
		if (camSwitch == true) {
			MainCamera.enabled = false;
			MainCamera.gameObject.SetActive (false);
			Camera2.enabled = false;
			Camera2.gameObject.SetActive(false);
			InventoryCam.enabled = true;
			InventoryCam.gameObject.SetActive (true);
			
		}
		
		else
		{
			
			MainCamera.enabled = true;
			MainCamera.gameObject.SetActive (true);
			Camera2.enabled = false;
			Camera2.gameObject.SetActive(false);
			InventoryCam.enabled = false;
			InventoryCam.gameObject.SetActive (false);	
		}

	}
	public void OnGUI(){
		}
	
	public int Defence{
		get{ return Def; }
		set{ Def = value; }
	}
	public int Strength{
		get{ return Str; }
		set{ Str = value; }
	}
	public int PlayerDamage{
		get {return Str - bossDef;}
		set { PlayerAtk = PlayerDamage;} 
	}
	public int BossDamage{
		get {return  bossStr - Def;}
		set { BossAtk =  BossDamage;} 
	}
}
