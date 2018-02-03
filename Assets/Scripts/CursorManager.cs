using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour 
{
	public GameObject[] players;
	public int cursor = 1;
	public GameObject[] enemies;

	void Update () 
	{
		transform.position = new Vector3 (players [cursor].transform.position.x, 
			players [cursor].transform.position.y + 1, 2);
	}
}
