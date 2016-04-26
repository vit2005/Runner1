using UnityEngine;
using System.Collections.Generic;

public class WindowsController : MonoBehaviour {

	static WindowsController _instance;
	static string currentlyOpenedWindow;

	// Use this for initialization
	void Start () {
		_instance = this;
		OpenMenu ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void OpenMenu()
	{
		MenuScript.Instance.InitWindow (currentlyOpenedWindow);
		_instance.OpenWindow ("Menu");
	}

	public static void OpenBattlefield()
	{
		BattlefieldScript.Instance.InitWindow (currentlyOpenedWindow);
		_instance.OpenWindow ("Battlefield");
	}

	public static void OpenResult()
	{
		ResultScript.Instance.InitWindow (currentlyOpenedWindow);
		_instance.OpenWindow ("Result");
	}

	public static void OpenLadder()
	{
		LadderScript.Instance.InitWindow (currentlyOpenedWindow);
		_instance.OpenWindow ("Ladder");
	}

	public static void OpenOptions()
	{
		OptionsScript.Instance.InitWindow (currentlyOpenedWindow);
		_instance.OpenWindow ("Options");
	}

	public static void OpenInfo()
	{
		InfoScript.Instance.InitWindow (currentlyOpenedWindow);
		_instance.OpenWindow ("Info");
	}

	public static void OpenShop()
	{
		ShopScript.Instance.InitWindow (currentlyOpenedWindow);
		_instance.OpenWindow ("Shop");
	}

	public static void OpenSomeWindow(string title)
	{
		_instance.OpenWindow (title);
	}

	void OpenWindow(string title)
	{
		List<string> windows = new List<string>() { "Menu", "Battlefield", "Result", "Ladder", "Options", "Info", "Shop"};

		foreach (string s in windows) {
			transform.FindChild (s).gameObject.SetActive(s == title);
		}

		currentlyOpenedWindow = title;
	}
}
