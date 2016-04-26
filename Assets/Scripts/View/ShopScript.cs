using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopScript : IDefaultWindow {
	
	private static ShopScript _instance;
	public static ShopScript Instance {get {return _instance;}}
	
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
