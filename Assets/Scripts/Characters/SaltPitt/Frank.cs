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
										  "Block all atacks aimed at Trevor for the turn. <color=red>2</color> turn cooldown.\nCost: None    Target: Self",
                                          "Become <color=lime>Steady</color> for 2 turns. <color=red>1</color> turn cooldown.\nCost: None    Target: Self",
                                          "Gather 3 balls. <color=red>1</color> turn cooldown.\nCost: None    Target: Self",
                                          ""/*"If attacked on next turn, become buffed and gain <color=red>30</color> stamina"*/};
	    actionTypes = new string[] { "None", "Offense", "Defense", "Defense", "Defense", "Utility", "Utility","Utility" };
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };     
	    actionCosts = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };

		base.Start ();
    }


    // Update is called once per frame
    new void Update() {
		base.Update ();
    }



    // Rumble: Frank blocks all attack aimed at Trevor. 1 turn cooldown. Cost: 1 ball
	public override int Skill1() {
		for(int i = 0; i < 3; i++)
		{
			if (enemies[i].Target[0].Name == "Trevor"){
				enemies [i].Target [0] = this;
				for(int j = 0; j < enemies[0].actionNames.Length; j++)
				{
					if (enemies [i].action == enemies [i].actionNames [j]) 
					{
						enemies[i].heldBalls -= enemies[i].GetActionCost(j);
					}
				}
	        }
		}
        actionCooldowns[4] = 3;
        return -1;

    }

	// Skill1
	public override int Skill2() {
		this.addStatusEffect(STATUS.STEADY, 3);
        actionCooldowns[5] = 2;
		return 0;
	}

	// Skill1
	public override int Skill3() {
		for(int i = 0; i< 3 && this.heldBalls < this.maxBalls; i++) {
            this.heldBalls++;
        }
		actionCooldowns[5] = 2;
		return 0;

	}

	public override int Skill4() {
        //Not Implemented yet
        return 0;
    }    

}
