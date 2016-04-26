using UnityEngine;
using System.Collections;

public abstract class IDefaultWindow : MonoBehaviour {

	public string parentWindow;
	public virtual void InitWindow(string parentWindowTitle){
		parentWindow = parentWindowTitle;
	}

}
