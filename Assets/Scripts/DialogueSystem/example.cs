using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class example : MonoBehaviour {

	List<int> intList;
	public Camera cam;
	DialogueManager dm;
	// Use this for initialization
	void Start () {
		intList = new List<int> ();
		intList.Add (5);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("sdsdfd");
		//GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ().fieldOfView = 300;
		//gameObject.transform.localScale = new Color(1f,1f,1f);
	}
}
