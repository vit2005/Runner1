using UnityEngine;
using System.Collections;

public class ResizeScript : MonoBehaviour {
	
	void Start () {
		//SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		gameObject.transform.localScale = new Vector3(1,1,1);
		//float width = sr.sprite.bounds.size.x;
		//float height = sr.sprite.bounds.size.y;
		double worldScreenHeight = Camera.main.orthographicSize * 2.0;
		double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		//Debug.Log ("h="+worldScreenHeight+" w="+worldScreenWidth+" h/w="+worldScreenHeight/worldScreenWidth);
		//if (worldScreenHeight / worldScreenWidth < 1.777f)
		//	worldScreenHeight = 1.777f * worldScreenWidth;
		//else
		//	worldScreenHeight = 1.777f * worldScreenWidth + 2 * worldScreenHeight;
		//Debug.Log ("h="+worldScreenHeight+" w="+worldScreenWidth+" h/w="+worldScreenHeight/worldScreenWidth);
		Transform parent = gameObject.transform.parent;
		if ((parent == null) || (parent.parent == null)) {
			RectTransform rt = gameObject.GetComponent<RectTransform>();
			//rt.localScale = new Vector3( (float)(worldScreenWidth / rt.rect.width), (float)(worldScreenHeight / rt.rect.height), 1);
			float z = rt.sizeDelta.y/rt.sizeDelta.x - (float)(worldScreenHeight/worldScreenWidth);
			if ((float)(worldScreenHeight/worldScreenWidth) > 1.777f)
				rt.sizeDelta = new Vector2(rt.sizeDelta.x - z * rt.sizeDelta.y, rt.sizeDelta.y); 
			else
				rt.sizeDelta = new Vector2(rt.sizeDelta.x + z * rt.sizeDelta.y, rt.sizeDelta.y);

			//rt.localScale = new Vector3( (float)(Screen.width / rt.rect.width), (float)(Screen.height / rt.rect.height), 1);
			rt.localScale = new Vector3( (float)(Screen.height / rt.rect.height), (float)(Screen.height / rt.rect.height), 1);
			return;
		}
		
		//RectTransform mrt = gameObject.GetComponent<RectTransform>();
		//RectTransform prt = parent.GetComponent<RectTransform>();
		//SpriteRenderer psr = parent.GetComponent<SpriteRenderer>();
		//float pwidth = psr.sprite.bounds.size.x;
		//float pheight = psr.sprite.bounds.size.y;

		//mrt.localScale = new Vector3((float)(prt.localScale.x * (pwidth / worldScreenWidth)),
		//                            (float)(prt.localScale.y * (pheight / worldScreenHeight)),
		//                             1);
	}
}
