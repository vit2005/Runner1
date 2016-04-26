using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public PlayerState DefeatState;
	public bool alive;
	bool kill;

	// Use this for initialization
	void Start () {
		alive = false;
		kill = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (BattlefieldScript.Instance.result_btn.gameObject.activeSelf) {
			gameObject.SetActive (false);
			transform.GetComponent<Animation> ().Stop ();
		}
	}

	public void Init()
	{
		gameObject.SetActive (true);
		alive = true;
		kill = false;
		transform.GetComponent<Animation> ().Play ();
		Debug.Log (transform.GetComponent<Animation> ());
	}

	public void Check () {
		if (kill) {
			BattlefieldScript.Instance.Defeat ();
			alive = false;
			gameObject.SetActive (false);
			return;
		}
		if (PlayerScript.CurrentState == DefeatState) {
			BattlefieldScript.Instance.Kill ();
			alive = false;
			gameObject.SetActive (false);
		} else {
			kill = true;
		}

	}
}
