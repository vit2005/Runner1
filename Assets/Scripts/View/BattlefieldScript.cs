using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Timers;
using System;

public class BattlefieldScript : IDefaultWindow {

	private static BattlefieldScript _instance;
	public static BattlefieldScript Instance {get {return _instance;}}

	public Button attack_btn;
	public Button defence_btn;
	public Button jump_btn;
	public Button roll_btn;
	public Button start_btn;
	public Button pause_btn;

	public Text score;
	bool onPause;

	int count;

	public List<EnemyScript> enemies;

	float theTime;
	float nextEnemySpawn;
	float timeOfBeginingAnimation;

	// Use this for initialization
	void Start () {
		_instance = this;
		attack_btn.onClick.AddListener (SetAttackState);
		defence_btn.onClick.AddListener (SetDefenceState);
		jump_btn.onClick.AddListener (SetJumpState);
		roll_btn.onClick.AddListener (SetRollState);
		pause_btn.onClick.AddListener (Pause);

		//start_btn.onClick.AddListener (InitTimer);

	}

	public override void InitWindow (string title)
	{
		base.InitWindow (title);
		theTime = Time.time;
		count = 0;
		nextEnemySpawn = 3;
		onPause = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (onPause)
			return;

		score.text = count.ToString();
		if(Time.time - theTime > nextEnemySpawn) {
			theTime = Time.time; 
			CreateEnemy();
		}

		if (PlayerScript.CurrentState == PlayerState.idle)
			timeOfBeginingAnimation = Time.time;
		else {
			if (Time.time - timeOfBeginingAnimation > 0.5)
				PlayerScript.CurrentState = PlayerState.idle;
		}

	}

	void SetAttackState()
	{
		PlayerScript.CurrentState = PlayerState.attack;
	}

	void SetDefenceState()
	{
		PlayerScript.CurrentState = PlayerState.defence;
	}

	void SetJumpState()
	{
		PlayerScript.CurrentState = PlayerState.jump;
	}

	void SetRollState()
	{
		PlayerScript.CurrentState = PlayerState.roll;
	}

	public void Defeat()
	{
		ResultScript.Instance.score.text = string.Format ("Score: {0}",count);
		LadderScript.Instance.AddScore (count);

		count = 0;
		nextEnemySpawn = 3;
		PlayerScript.CurrentState = PlayerState.idle;

		foreach (EnemyScript item in enemies) {
			item.gameObject.SetActive (false);
			item.transform.GetComponent<Animation> ().Stop ();
			item.alive = false;
		}

		WindowsController.OpenResult ();
		Debug.Log ("Defeavgt");
	}

	public void Kill()
	{
		count++;
		Debug.Log ("Defeavgt");
	}

	void CreateEnemy()
	{
		int a;
		bool allAlive = true;

		System.Random rnd = new System.Random ();
		foreach (EnemyScript e in enemies) {
			if (!e.alive)
				allAlive = false;
		}
		if (allAlive)
			return;

		do {
			a = rnd.Next (0, enemies.Count);
		} while (enemies[a].alive);

		enemies [a].Init ();
		//enemies [0].Init ();
		Debug.Log ("Enemy intitialized");
		nextEnemySpawn = 0.5f + (float)rnd.NextDouble ();
	}

	void Pause()
	{
		if (!onPause) {
			//foreach (EnemyScript e in enemies) {
			//	if (e.transform.GetComponent<Animation> ().isPlaying)
			//		e.transform.GetComponent<Animation> ().enabled = false;
			//}
			Time.timeScale = 0f;
			onPause = true;
		} else {
			//foreach (EnemyScript e in enemies) {
			//	if (e.alive)
			//		e.transform.GetComponent<Animation> ().enabled = true;
			//}
			Time.timeScale = 1f;
			onPause = false;
		}
	}
}
