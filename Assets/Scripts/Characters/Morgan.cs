using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morgan : Character {

    new void Start() {
        Name = "Morgan";
        Stamina = maxStamina;
        Role = "Thrower";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Limace de mer", "Moule", "La victorie", "" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Slightly stronger attack against an enemy", "Hits an enemy while making yourself steady", "Weakened attack against all enemies that has a change to make target unsteady", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 2, 2, 0, 0 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 1, 1, 0, 0 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 3, 5, 0 };

		base.Start ();
    }

    new void Update() {
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        } else {
            if (allegiance == 1) { 
                this.targetingTypes = alternateTargetingTypes;
                allies = combat.Player;
                enemies = combat.Enemy;
            } else {
                this.targetingTypes = defaultTargetingTypes;
                allies = combat.Enemy;
                enemies = combat.Player;
            }
        }
    }
	// I haven't bothered to update the skill return values
	/*
	public override bool Skill1() {
        float variance = UnityEngine.Random.Range(.8f, 1.25f);
        Target[0].loseStamina((int) ( (this.Damage * 1.15) * (variance) ) );
		return false;
	}

	public override bool Skill2() {
        float variance = UnityEngine.Random.Range(.8f, 1.25f);
        Target[0].loseStamina((int)(this.Damage * variance));
        this.addStatusEffect("steady", 2);
		return false;
    }

	public override bool Skill3() {
        Character [] randomTargets = new Character[3];
        for (int i = 0; i < 3; i++) {
            Character target = this.enemies[Random.Range(0, 2)];
            float variance = UnityEngine.Random.Range(.8f, 1.25f);
            target.loseStamina((int)((this.Damage * 1.5) * (variance)));
            if(Random.Range(0,10) > 7) { target.addStatusEffect("unsteady", 2);}
        }
		return false;
    }

	public override bool Skill4() {
		return false;
    }
    */
}