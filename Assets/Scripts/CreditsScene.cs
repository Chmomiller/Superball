using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour {

	public RectTransform scroll;
	public RectTransform canvas;
	// Use this for initialization
	void Start () {
		scroll = gameObject.GetComponent<RectTransform> ();
		canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
		scroll.sizeDelta = new Vector2 (canvas.rect.width, 5.5f*canvas.rect.width);
		transform.Translate (0f, -.5f * scroll.rect.height, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0f, 5f, 0f);
	}

	public IEnumerator rollCredits{
		while (1 == 1){
			yield return new WaitForEndOfFrame ();
		}
	}
}
