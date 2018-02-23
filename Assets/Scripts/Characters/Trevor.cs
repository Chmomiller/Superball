using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trevor: Character 
{
	private string[] actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Thrash", "Skill2", "Skill3", "Rest" }; 
	private string[] actionTypes = new string[]{ "None", "Offense", "Defense", "Offense", "Utility", "Utility", "Utility" };
	private int[] actionCosts = new int[]{ 0, 1, 0, 3, 0, 0, 0 };

    // Use this for initialization
    void Start () {
        Name = "Trevor";
		Damage = 1;
        Catch = 25;
        Capacity = 8;
        Stamina = 7;
        heldBalls = 0;
        Role = "Thrower";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	// Thrash: Throws 3 balls at three random targets on your team. 1 turn cooldown. Cost: 3 balls
    // Currently doesn't allow players to res off of a catch from this skill
	public override void Skill1()
    {
		this.actionCooldowns [4] = 2;
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Player");
		for(int i = 0; i < 3; i++)
		{
			throwBall (targets[Random.Range(0,4)]);
		}
    }

}
