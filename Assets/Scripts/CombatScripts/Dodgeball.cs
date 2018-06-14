using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgeball : MonoBehaviour {
	public Character target;
	float percent = 0f;

	// Update is called once per frame
	void Update () 
	{
		if(this.target != null)
		{
			percent += .025f;
			this.transform.position = new Vector3 (Mathf.Lerp (this.transform.position.x, target.transform.position.x, percent),
												   Mathf.Lerp(this.transform.position.y, target.transform.position.y, percent), 
												   97f);
			if(Vector3.Distance(this.transform.position, target.transform.position) <= 1f)// && target.dead)
			{
				Destroy (gameObject);
			}
		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}