using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour {
	public Sprite[] crowd;
	public GameObject spectator;
	public float hRange;
	public float vRange;
	public int spawn;

	// Use this for initialization
	void Start () 
	{
		GameObject currentSpectator;

		for(int i = 0; i < spawn; i++)
		{
			currentSpectator = Instantiate (spectator, new Vector3(this.transform.position.x + Random.Range(-hRange, hRange),
																   this.transform.position.y + Random.Range(-vRange, vRange),
																   this.transform.position.z), Quaternion.identity);
			// Change the spectator sprite
			currentSpectator.GetComponentInChildren<SpriteRenderer>().sprite = crowd[7];//Random.Range(0,crowd.Length)];
			if(Random.Range(0f,100f) < 50f)
			{
				currentSpectator.transform.localScale = new Vector3 (-1f, 1f, 1f);	
			}
		}
	}
}
