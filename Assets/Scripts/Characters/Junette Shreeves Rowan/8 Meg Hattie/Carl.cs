using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carl : Character {

    public Character Save = new Character(); //used for Save and Rollback
    public string whoIsSaved = "NA";

    void Start() { //supporting scripts like saving and loading, transition
        Name = "Programmer Carl";
		Stamina = maxStamina;
        Role = "Supporter";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Memory Glitch", "Save", "Rollback", "" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"Damages enemy with their damage stats and heals you for the same", 
											"Saves ally's stats in memory for usage later but debuffs them for 2 turns. Expires after 3 turns", 
											"Reverts ally's stats to saved value but makes them unsteady for 2 turns", 
											"" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Utility", "Utility", "" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 1, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 2, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

        actionCooldowns[5] = 6; //this is because save and rollback can be very powerful
        actionCooldowns[6] = 3;

        
		base.Start ();
    }

    void Update() {
		
    }
   
	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override bool Skill1() {
        Target[0].loseStamina(Target[0].Damage);
        this.gainStamina(Target[0].Damage);
        this.actionCooldowns[4] = 3;
        return true;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
        Save = Target[0];
        whoIsSaved = Target[0].Name;
        this.actionCooldowns[5] = 6;
		return true;
    }

	// Heavy Bombardment: Charges for a turn then attacks with a powerful strike against all enemies and becomes staggered
    public override bool Skill3() {
        if (actionCooldowns[5] >= 3) { //this is to enforce the 3 turn limit on saving data
            if (allies[0].Name == whoIsSaved) allies[0] = Save;
            if (allies[1].Name == whoIsSaved) allies[1] = Save;
            if (allies[2].Name == whoIsSaved) allies[2] = Save;
        } else {
            print("Save data lost");
            Save = new Character();
        }
        this.actionCooldowns[6] = 6;
        return true;
    }

    public override bool Skill4() {
        return false;
    }

	public override void cleanUp(){
	}
}