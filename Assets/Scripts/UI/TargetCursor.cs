using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCursor : MonoBehaviour {

	public GameObject[] cursors;
	public Character[] players;
	public Character[] enemies;

	void Start()
	{
		cursors = new GameObject[3];
		players = new Character[3];
		enemies = new Character[3];
		for(int i = 0; i < 3; i++)
		{
			cursors [i] = GameObject.Find ("TargetCursor" + i);
			players [i] = GameObject.Find ("Character"+i).GetComponent<Character>();
			enemies [i] = GameObject.Find ("Character"+(i+3)).GetComponent<Character>();
		}
	}

	public void ShowTargets(string team, int targets)
	{
		if ((targets == 1 && team == "Player")
		   || (targets == 2 && team != "Player")) 
		{
			for (int i = 0; i < 3; i++) 
			{
				if (!enemies [i].dead) 
				{
					cursors [i].transform.position = new Vector3 (enemies [i].transform.position.x, enemies [i].transform.position.y + 2f, -5f);
				}
			}
		}
		else if((targets == 2 && team == "Player")
			|| (targets == 1 && team != "Player"))
		{
			for(int i = 0; i < 3; i++)
			{
				if(!players[i].dead)
				{
					cursors [i].transform.position = new Vector3 (players[i].transform.position.x, players[i].transform.position.y + 2f,-5f);
				}
			}
		}
	}

	public void ClearTargets()
	{
		for(int i = 0; i < 3; i++)
		{
			cursors [i].transform.transform.position = new Vector3 (cursors[i].transform.position.x, cursors[i].transform.position.y, 1000f);
		}
	}
}
