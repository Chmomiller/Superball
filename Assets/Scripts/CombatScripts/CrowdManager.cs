using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour {
	public Sprite[] crowd;
	public GameObject spectator;
	public float hRange;
	public float vRange;

	// Use this for initialization
	void Start () 
	{
		GameObject currentSpectator;

		for(int i = 0; i < 20; i++)
		{
			currentSpectator = Instantiate (spectator, new Vector3(Random.Range(-hRange, hRange),
																   Random.Range(vRange, 5f),
																   99f), Quaternion.identity);
			// Change the spectator sprite
			currentSpectator.GetComponentInChildren<SpriteRenderer>().sprite = crowd[7];//Random.Range(0,crowd.Length)];
			if(Random.Range(0f,100f) < 50f)
			{
				currentSpectator.transform.localScale = new Vector3 (-1f, 1f, 1f);	
			}
		}
	}
}
