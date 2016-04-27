using UnityEngine;
using System.Collections;

public class LoopedAnimation : MonoBehaviour {
	
	public void LoopMe()
	{
		transform.GetComponent<Animation> ().Stop ();
		transform.GetComponent<Animation> ().Play ();
	}
}
