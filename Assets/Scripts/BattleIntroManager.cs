using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleIntroManager : MonoBehaviour {

	public Transition screen;
	public string sceneName;
	bool screenGoingUp = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 6.5f) {
			screen.screenUp ();
			screenGoingUp = true;
		}
		if (Time.time > 6.8f) {
			SceneManager.LoadScene(sceneName);
		}
	}
}
