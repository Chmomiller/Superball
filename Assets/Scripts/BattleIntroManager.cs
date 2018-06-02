using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleIntroManager : MonoBehaviour {

	public Transition screen;
	public string sceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 7f) {
			screen.screenUp ();
		}
		if (Time.time > 7.3f) {
			SceneManager.LoadScene(sceneName);
		}
	}
}
