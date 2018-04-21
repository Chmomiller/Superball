using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank : Character {

	private Trevor trevor;

    // Use this for initialization
    void Start() {
        Name = "Frank";
        Stamina = maxStamina;
        
        Role = "Catcher";

	    actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Rumble", "Skill2", "Skill3", "Skill4" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Blocks any balls aimed at Trevor", "", "", "" };
	    actionTypes = new string[] { "None", "Offense", "Defense", "Defense", "Utility", "Utility", "Utility" };
	    defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
	    alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };        
	    actionCosts = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };

		base.Start ();
    }


    // Update is called once per frame
    void Update() {
		base.Update ();
		/*
        if (allegiance == 1) {
            this.Target[0]ingTypes = alternateTarget[0]ingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.Target[0]ingTypes = defaultTarget[0]ingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
        */
    }



    // Rumble: Frank blocks an attack aimed at Trevor. 1 turn cooldown. Cost: 1 ball
    public override bool Skill1() {
        //Rumble: Blocks all attacks aimed at Trevor for 1 turn;
		for(int i = 0; i < 3; i++)
		{
			if (enemies[i].Target[0].Name == "Trevor"){
				
				for(int j = 0; j < enemies[0].actionNames.Length; j++)
				{
					if (enemies [0].action == enemies [0].actionNames [j]) 
					{
						enemies[0].heldBalls -= enemies[0].GetActionCost(j);
					}
				}
				enemies[i].action = "None";
	        }
		}
        actionCooldowns[4] = 3;
        return false;

    }

	public override bool Skill2() { return true; }

	public override bool Skill3() { return true;}

	public override bool Skill4() { return true;}    

}
