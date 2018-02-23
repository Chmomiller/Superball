using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg: Character
{
	private string[] actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Terrapin", "Skill2", "Skill3", "Rest" }; 
	private string[] actionTypes = new string[]{ "None", "Offense", "Defense", "Defense", "Utility", "Utility", "Utility" };
	private int[] actionCosts = new int[]{ 0, 1, 0, 1, 0, 0, 0 };

    void Start()
    {
        Name = "Greg";
		Damage = 1;
        Catch = 50;
        Capacity = 8;
        Gather = 2;
        Stamina = 14;
        heldBalls = 0;
        Role = "Support";
    }


	// This skill is Greg's Terrapin skill
	// If a hit is successful against Greg and terrapin has been used it rebounds into Trevor's ball pool
	// Is there a cost for this?
	public override void Skill1(Character target)
    {
		actionCooldowns [4] = 4;
		Character Trevor = GameObject.Find ("Trevor").GetComponent<Character> ();
		if(Trevor.heldBalls < Capacity)
		{
			// Currently Doesn't check how many balls are thrown in a move, only redirects one ball
			Trevor.heldBalls ++;
		}
    }
}
