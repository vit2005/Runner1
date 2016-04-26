using UnityEngine.UI;
using System.Collections;

public class ResultScript : IDefaultWindow {
	
	private static ResultScript _instance;
	public static ResultScript Instance {get {return _instance;}}

	public Text score;
	public Button Return_btn;
	public Button Main_btn;
	public Button Option_btn;

	// Use this for initialization
	void Start () {
		_instance = this;
		Return_btn.onClick.AddListener (() => {WindowsController.OpenBattlefield();});
		Main_btn.onClick.AddListener (() => {WindowsController.OpenMenu();});
		Option_btn.onClick.AddListener (() => {WindowsController.OpenOptions();});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
