using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg: Character
{
	public int terrapin = 0;

    void Start()
    {
        Name = "Greg";
        Accuracy = 25;
        Catch = 50;
        Capacity = 8;
        Gather = 2;
        Stamina = 14;
        heldBalls = 0;
        Role = "Support";
    }

	public override int catchBall()
	{
		if(terrapin == 3)
		{
			Character Trevor = GameObject.Find ("Trevor").GetComponent<Character>();
			Character Frank = GameObject.Find ("Frank").GetComponent<Character> ();
			if(Trevor.heldBalls < Trevor.Capacity)
			{
				Trevor.heldBalls++;
			}
			else if(Frank.heldBalls < Frank.Capacity)
			{
				Trevor.heldBalls++;
			}
			return 0;
		}
		return base.catchBall ();
	}


	// This skill is Greg's Terrapin skill
	// If a hit is successful against Greg and terrapin has been used it rebounds into Trevor's ball pool
	// Is there a cost for this?
	public override void Skill1()
    {
		if(terrapin == 0)
		{
			terrapin = 3;
		}
    }
		
	void Cleanup()
	{
		if(terrapin > 0)
		{
			terrapin--;
		}
	}
}
