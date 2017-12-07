using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {
   #region variables
    InventoryCam IC = new InventoryCam();
	private int delay = 2; 
	private int Def = 10;
	private int Str = 20;
	private int PlayerAtk;

	private int bossStr = 15;
	private int bossDef = 5;
	private int BossAtk;

	bool inBattle;
	bool playerTurn;
	bool enemyTurn;
	int turn;

	private bool camSwitch;

	GameObject player;
	GameObject Enemy;
	GameObject battlePlayer;
	GameObject battleEnemy;
	public GameObject Menu;

	public Camera MainCamera;
	public Camera Camera1;
	public Camera InventoryCam;

	public Animation pAnim;
	public Animation bAnim;

	//player health
	public int maxHealth = 100;
	public int curHealth;
	public int attack;
	public float barLength;
	//boss health
	int bossHP;
#endregion

    // Use this for initialization
    void Start () {

		player = GameObject.FindWithTag ("Player");
		Enemy = GameObject.FindWithTag ("Boss");
		battlePlayer = GameObject.FindWithTag ("PlayerBattle");
		battleEnemy = GameObject.FindWithTag ("BossBattle");
		inBattle = false;
		pAnim = GetComponent<Animation> ();
		turn = turn+1;
		attack = 100;
		bossHP = 100;
		Menu = GameObject.FindWithTag ("Finish");

	}
	


	// Update is called once per frame
	void Update () {

		PlayerAtk = Defence;
        //controls to bring up in game stat menu
		if (Input.GetKeyUp (KeyCode.I)) {
			camSwitch = true;
		}
		if (Input.GetKeyUp (KeyCode.U)) {
			camSwitch = false;
		}
        //reset game if player dies
		if (curHealth < 0) {
			Application.LoadLevel(0);
		}
        //emeny boss death anim
		if (bossHP < 0) {
			bAnim.Play ("Dead");
			Enemy.SetActive(false);
		}

#region Gaining 3d position of in game members
        Vector3 BossPos = new Vector3 (Enemy.transform.position.x, Enemy.transform.position.y, Enemy.transform.position.z);
		Vector3 PlayerPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Vector3 PlayerBattlePos = new Vector3();
		PlayerBattlePos = (player.transform.position - Enemy.transform.position);
        #endregion

#region condition to initiate battle between main player and in game boss
        if (Vector3.Distance (BossPos, PlayerPos) < 2.5f && bossHP > 0) {
			inBattle = true;

		} else 
			inBattle = false;
#endregion

        if (inBattle == true) {
            //This controls the enemy boss rotation so that it views the player
			Enemy.transform.rotation = Quaternion.LookRotation (PlayerBattlePos);
			MainCamera.enabled = false;
			MainCamera.gameObject.SetActive (false);
			Camera1.enabled = true;
			Camera1.gameObject.SetActive (true);
			InventoryCam.enabled = false;
			InventoryCam.gameObject.SetActive (false);
            //toggle players health bar within fight
			barLength = Screen.width / 3;
			curHealth = attack;

#region  Battle AI
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
				bAnim.Play ("Attack");
				turn = turn + 1;
				attack = attack - BossDamage;
			}

		} else 
		if (camSwitch == true) {
			MainCamera.enabled = false;
			MainCamera.gameObject.SetActive (false);
			Camera1.enabled = false;
			Camera1.gameObject.SetActive(false);
			InventoryCam.enabled = true;
			InventoryCam.gameObject.SetActive (true);

		}
	
		else
		{
		
			MainCamera.enabled = true;
			MainCamera.gameObject.SetActive (true);
			Camera1.enabled = false;
			Camera1.gameObject.SetActive(false);
			InventoryCam.enabled = false;
			InventoryCam.gameObject.SetActive (false);	
		}
#endregion

    }
    //developing health GUI within boss battle
	public void OnGUI(){
		GUI.Box (new Rect(10,10, barLength, 20), curHealth + "/" + maxHealth);
		}

#region getters ans setters to control key ingame variables
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
#endregion
}
