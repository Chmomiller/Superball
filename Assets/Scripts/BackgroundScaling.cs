using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaling : MonoBehaviour {

	RectTransform canvas;
	RectTransform backdrop;

	// Use this for initialization
	void Start () {
		backdrop = gameObject.GetComponent<RectTransform>();
		canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
		backdrop.sizeDelta = new Vector2 (canvas.rect.width + .25f * canvas.rect.width, canvas.rect.height + .15f * canvas.rect.height);
	}

	// Update is called once per frame
	void Update () {

	}
}
