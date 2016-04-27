using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class LadderScript : IDefaultWindow {

	private static LadderScript _instance;
	public static LadderScript Instance {get {return _instance;}}

	public Text ladder;

	public Button Back_btn;
	public List<int> scores;
	
	// Use this for initialization
	void Start () {
		scores = new List<int> ();
		_instance = this;
		Back_btn.onClick.AddListener (() => {
			WindowsController.OpenSomeWindow (parentWindow);
		});
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddScore(int score)
	{
		scores.Add (score);
		scores.Sort ();
		scores.Reverse ();
		if (scores.Count > 10) 
			scores.RemoveAt(10);
		SaveScores ();
	}
	
	void SaveScores() {
		string result = string.Empty;
		foreach (int score in scores) {
			result = string.Format("{0},{1}",result,score);
		}
		result = result.TrimEnd(new char[]{','});
		PlayerPrefs.SetString ("scores",result);
	}
	
	void GetScores() {
		scores = new List<int>();
		if (!PlayerPrefs.HasKey ("scores")) 
			return;
		
		string[] list = PlayerPrefs.GetString("scores").Split(new char[]{','});
		foreach (string item in list) {
			try {
				scores.Add(Convert.ToInt32(item));
			} catch (Exception ex) {
					
			}

		}
	}
	
	public override void InitWindow (string parentWindowTitle)
	{
		base.InitWindow (parentWindowTitle);
		ladder.text = "";
		GetScores ();
		for (int i = 0; i < scores.Count; i++) {
			ladder.text += string.Format("{0}) {1}\n",i+1, scores[i]);
		}
	}
}
