using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank : Character {

	private Trevor trevor;

    // Use this for initialization
    new void Start() {
        Name = "Frank";
        Stamina = maxStamina;
        
        Role = "Catcher";

	    actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Rumble", "Power Stance", "Work Time", "Waxing Wroth" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
										  "Blocks all atacks aimed at Trevor for <color = red>1</color> turn",
                                          "Become <color = orange>Steady</color> for <color = red>2</color> turns",
                                          "Gather <color = red>3</color> balls",
                                          "If attacked on next turn, become buffed and gain <color = red>30</color> stamina"};
	    actionTypes = new string[] { "None", "Offense", "Defense", "Defense", "Utility", "Utility", "Utility","Utility" };
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
	    alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };        
	    actionCosts = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };

		base.Start ();
    }


    // Update is called once per frame
    new void Update() {
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
	public override int Skill1() {
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
        return -1;

    }

	// Skill1
	public override int Skill2() {
        this.addStatusEffect("steady", 3);
        actionCooldowns[5] = 2;
		return -1;
	}

	// Skill1
	public override int Skill3() {
		for(int i = 0; i< 3 && this.heldBalls < this.maxBalls; i++) {
            this.heldBalls++;
        }
		actionCooldowns[5] = 2;
		return -1;

	}

	public override int Skill4() {
        //Not Implemented yet
        return 0;
    }    

}
