using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextScript : MonoBehaviour {
	public float speed;
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3 (this.transform.position.x, 
											   this.transform.position.y + speed,
											   this.transform.position.z);
		this.speed -= .001f;
		if(this.speed <= 0f)
		{
			Destroy (gameObject);
		}
	}
}
