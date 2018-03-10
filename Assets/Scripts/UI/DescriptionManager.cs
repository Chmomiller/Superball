using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour 
{
	public float x;
	public float y;
	public float z;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, z);
		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;
		//z = gameObject.transform.position.z;

	}
}
