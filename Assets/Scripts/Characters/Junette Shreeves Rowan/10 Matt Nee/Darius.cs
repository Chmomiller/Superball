using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darius : Character {
    
    void Start() {
        Name = "Sound Designer Darius";
		Stamina = maxStamina;
        Role = "Catcher";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "", "", "", "" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"", 
											"", 
											"", 
											"" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "", "", "", "" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 1, 2 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 1, 1 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 4, 6, 5 };

		base.Start ();
    }

    void Update() {
		
    }

	public new bool dodgeBall(Character attacker)
	{
		if(findStatus("misc") != -1)
		{
			this.throwBall (attacker);
		}
		return base.dodgeBall (attacker);
	}

	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override bool Skill1() {
		return false;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
		return true;
    }

	// Heavy Bombardment: Charges for a turn then attacks with a powerful strike against all enemies and becomes staggered
    public override bool Skill3() {
		return true;
    }

    public override bool Skill4() {
        return false;
    }

	public override void cleanUp(){
	}
}