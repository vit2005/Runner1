using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PlayerState {
	idle,
	attack,
	defence,
	jump,
	roll
}

public class PlayerScript : MonoBehaviour {

	public static PlayerState CurrentState;

	public Sprite idle;
	public Sprite attack;
	public Sprite defence;
	public Sprite jump;
	public Sprite roll;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (CurrentState) {
		case PlayerState.idle:
			transform.GetComponent<Image>().sprite = idle;
			break;
		case PlayerState.attack:
			transform.GetComponent<Image>().sprite = attack;
			break;
		case PlayerState.defence:
			transform.GetComponent<Image>().sprite = defence;
			break;
		case PlayerState.jump:
			transform.GetComponent<Image>().sprite = jump;
			break;
		case PlayerState.roll:
			transform.GetComponent<Image>().sprite = roll;
			break;
		default:
			break;
		}
	}
}
