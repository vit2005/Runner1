using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class MenuScript : IDefaultWindow {

	private static MenuScript _instance;
	public static MenuScript Instance {get {return _instance;}}

	public Button Play_btn;
	public Button Shop_btn;
	public Button Ladder_btn;
	public Button Options_btn;
	public Button Exit_btn;
	public Button Info_btn;

	// Use this for initialization
	void Start () {
		_instance = this;
		Play_btn.onClick.AddListener (() => {WindowsController.OpenBattlefield();});
		Shop_btn.onClick.AddListener (() => {WindowsController.OpenShop();});
		Ladder_btn.onClick.AddListener (() => {WindowsController.OpenLadder();});
		Options_btn.onClick.AddListener (() => {WindowsController.OpenOptions();});
		Exit_btn.onClick.AddListener (Exit);
		Info_btn.onClick.AddListener (() => {WindowsController.OpenInfo();});

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Exit()
	{
		Application.Quit ();
	}
}
