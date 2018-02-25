using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkit : MonoBehaviour {

	public Camera mainCAm;
	// Use this for initialization
	void Start () {
		mainCAm = GameObject.FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (""+mainCAm.pixelHeight+", "+ mainCAm.pixelWidth);
	}
}
