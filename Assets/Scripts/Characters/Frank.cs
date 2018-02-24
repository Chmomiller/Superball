using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank : Character
{
	private string[] actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Rumble", "Skill2", "Skill3", "Rest" }; 
	private string[] actionTypes = new string[]{ "None", "Offense", "Defense", "Defense", "Utility", "Utility", "Utility" };
	private int[] actionCosts = new int[]{ 0, 1, 0, 1, 0, 0, 0 };

    // Use this for initialization
    void Start()
    {
        Name = "Frank";
		Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Catcher";
        
    }

    // Update is called once per frame
    void Update()
    {

    }


	// Rumble: Frank blocks an attack aimed at Trevor. 1 turn cooldown. Cost: 1 ball
	public override void Skill1(Character target)
    {
		actionCooldowns [4] = 2;
		if(this.Target == this)
		{
			int highestStamina = 0;
			Character attacker;
			GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
			for (int i = 0; i < 3; i++) 
			{
				if(players[i].GetComponent<Character>().Stamina > highestStamina)
				{
					attacker = players[i].GetComponent<Character>();
				}
			}
			target.Target = this;
			this.Target = target;
		}
		else
		{
			// Blocks the attack but does not catch(no stamina lost)
			if(catching)
			{
				return;
			}
			catchBall (target);
		}

    }


}
