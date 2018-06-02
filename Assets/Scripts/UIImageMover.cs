using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImageMover : MonoBehaviour {

	public RectTransform canvas;
	public RectTransform loc;
	public float speed;
	public float finalX;
	public float waitTime;
	public float directionMultiplier;

	// Use this for initialization
	void Start () {
		loc = gameObject.GetComponent<RectTransform> ();
		canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
		speed = 10f;
		finalX = canvas.rect.width/2 -directionMultiplier*canvas.rect.width*finalX;
		//transform.Translate (-directionMultiplier * canvas.rect.width / 2 - directionMultiplier * 50, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Time.time > waitTime && loc.position.x != finalX) {
			transform.Translate (speed*directionMultiplier, 0f, 0f);
		}*/
		/*if (Time.time > waitTime) {
			(directionMultiplier > 0) ? ((loc.position.x < finalX) ? transform.Translate (speed*directionMultiplier, 0f, 0f) : ;) : ((loc.position.x > finalX) ? transform.Translate (speed*directionMultiplier, 0f, 0f));
		}*/
		if (Time.time > waitTime) {
			if (directionMultiplier > 0) {
				if (loc.position.x < finalX) {
					transform.Translate (speed * directionMultiplier, 0f, 0f);
				}
			} else {
				if (loc.position.x > finalX) {
					transform.Translate (speed * directionMultiplier, 0f, 0f);
				}
			}
		}
	}
}
