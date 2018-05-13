using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SpectatorScript : MonoBehaviour {
	public PlayableDirector pDirector;
	public TimelineAsset jump;
	// Use this for initialization
	void Start () {
		StartCoroutine (CrowdMovement());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator CrowdMovement()
	{
		pDirector.Play (jump);
		yield return new WaitForSeconds (Random.Range (12f, 60f));
		StartCoroutine (CrowdMovement());
	}
}
