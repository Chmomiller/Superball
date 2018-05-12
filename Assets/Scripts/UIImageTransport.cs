using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImageTransport : MonoBehaviour {

	public RectTransform loc;
	public float waitTime;
	public float changeInY;
	public bool transformed;

	// Use this for initialization
	void Start () {
		loc = gameObject.GetComponent<RectTransform> ();
		transformed = false;
	}
	// Update is called once per frame
	void Update () {
		if (Time.time > waitTime && !transformed) {
			transform.Translate (0, -changeInY, 0);
			transformed = true;
		}
	}
}
