using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour {

	public RectTransform scroll;
	public RectTransform canvas;
	// Use this for initialization
	void Start () {
		scroll = gameObject.GetComponent<RectTransform> ();
		canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
		scroll.sizeDelta = new Vector2 (canvas.rect.width, 5.5f*canvas.rect.width);
		transform.Translate (.03f*canvas.rect.width, -.5f * scroll.rect.height, 0f);

		StartCoroutine ("rollCredits");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 25f) {
			SceneManager.LoadScene("Scenes/MapScreen");
		}
	}

	public IEnumerator rollCredits () {
		bool comp = false;
		while (!comp) {
			if (scroll.position.y > (canvas.rect.height + (scroll.rect.height/2))) {
				comp = true;
			} else {
				transform.Translate (0f, 4f, 0f);
			}
			yield return new WaitForEndOfFrame ();
		}
	}
}
