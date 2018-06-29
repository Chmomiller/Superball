using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgeball : MonoBehaviour {
	public Character target;
	public Vector3 destination;
	public bool hit = false;
	float percent = 0f;

	// Update is called once per frame
	void Update () 
	{
		
		if(this.target != null)
		{
			if(hit)
			{
				percent += .025f;
				this.transform.position = new Vector3 (Mathf.Lerp (this.transform.position.x, target.transform.position.x, percent),
													   Mathf.Lerp(this.transform.position.y, target.transform.position.y, percent), 
													   Mathf.Lerp(this.transform.position.z, target.transform.position.z, percent));//97f);
			}
			else
			{
				if(percent == 0f)
				{
					destination = target.transform.position - this.transform.position;
					destination *= 3.0f;
				}
				percent += .008f;
				this.transform.position = new Vector3 (Mathf.Lerp (this.transform.position.x, destination.x, percent),
													   Mathf.Lerp(this.transform.position.y, destination.y, percent), 
													   Mathf.Lerp(this.transform.position.z, destination.z, percent));
			}

			/*if(Vector3.Distance(this.transform.position, target.transform.position) <= 1f)// && target.dead)
			{
				Destroy (gameObject);
			}
			*/

		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.GetComponentInParent<Character>() == target && hit)
		{
			Destroy (gameObject);
		}
	}
}