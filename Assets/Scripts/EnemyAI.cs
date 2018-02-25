using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{

	public Character[] Player;
	public Character[] Enemy;

	void Start () 
	{
		Player = new Character[3];
		Enemy = new Character[3];

		for(int i = 0; i < 3; i++)
		{
			Player [i] = GameObject.Find ("Player" + (i + 1)).GetComponent<Character>();
			Enemy [i] = GameObject.Find ("Enemy" + (i + 1)).GetComponent<Character>();

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
