﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InfoScript : IDefaultWindow {

	private static InfoScript _instance;
	public static InfoScript Instance {get {return _instance;}}
	
	public Button Back_btn;
	
	// Use this for initialization
	void Start () {
		_instance = this;
		Back_btn.onClick.AddListener (() => {
			WindowsController.OpenSomeWindow (parentWindow);});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
