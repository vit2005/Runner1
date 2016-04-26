﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Timers;
using System;

public class BattlefieldScript : MonoBehaviour {

	private static BattlefieldScript _instance;
	public static BattlefieldScript Instance {get {return _instance;}}

	public Button attack_btn;
	public Button defence_btn;
	public Button jump_btn;
	public Button roll_btn;
	public Button start_btn;
	public Button result_btn;
	public Button exit_btn;

	public Text score;

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
		result_btn.onClick.AddListener (() => {
			result_btn.gameObject.SetActive (false);
		});
		exit_btn.onClick.AddListener (Exit);
		//start_btn.onClick.AddListener (InitTimer);
		theTime = Time.time;
		count = 0;
		nextEnemySpawn = 3;
	}


	
	// Update is called once per frame
	void Update () {
		if (result_btn.gameObject.activeSelf)
			return;

		score.text = count.ToString();
		if(Time.time - theTime > nextEnemySpawn) {
			theTime = Time.time; 
			CreateEnemy();
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
		result_btn.transform.FindChild ("Text").GetComponent<Text> ().text = string.Format ("Score: {0}",count);
		result_btn.gameObject.SetActive (true);
		count = 0;
		nextEnemySpawn = 3;
		PlayerScript.CurrentState = PlayerState.idle;
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

	void Exit()
	{
		Application.Quit ();
	}
}
