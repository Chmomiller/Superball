using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulton : Character {

    new void Start() {
        Name = "Fulton";
        Stamina = maxStamina;
        Role = "Thrower";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Cuckoo", "Sparrow", "Owl Model", "Falcon Model" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Attack enemy twice", "Attacks all enemies at once with an attack 0.5 as powerful", "Attacks an enemy. If the enemy is stunned, this does 1.5x damage", "1.5x attack and gains steady" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Offense" };
            defaultTargetingTypes = new int[] { 0, 2, 0, 0, 2, 0, 2, 2 };
          alternateTargetingTypes = new int[] { 0, 1, 0, 0, 1, 0, 1, 1 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 3, 4, 5 };
    }

    // Update is called once per frame
    new void Update() {
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        } else {
            if (allegiance == 1) { 
                this.targetingTypes = defaultTargetingTypes;
                allies = combat.Player;
                enemies = combat.Enemy;
            } else {
                this.targetingTypes = alternateTargetingTypes;
                allies = combat.Enemy;
                enemies = combat.Player;
            }
        }
    }


    public void preUltimateCatch() {
        for (int i = 0; i < 3; i++) {
            if (combat.Player[i].actionType == "Offensive") {
                combat.Player[i].action = "Throw";
                combat.Player[i].Target[0] = this;
            }
        }
    }
	// I haven't bothered to update the skill return values 
	/*
	public override bool Skill1() {
        float variance = Random.Range(0.8f, 1.2f);
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * variance));
        }
        variance = Random.Range(0.8f, 1.2f);
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * variance));
        }
		return false;
    }

	public override bool Skill2() {
        float variance;
        for(int i = 0; i< 4; i++) {
            variance = Random.Range(0.8f, 1.2f);
            if (!enemies[i].dodgeBall(this)) {
                Target[0].loseStamina((int)((this.attack) * variance));
            }
        }
		return false;
    }

	public override bool Skill3() {
        float variance = Random.Range(0.8f, 1.2f);
        //If target is stunned
        if (Target[0].findStatus("stun") != -1) {
            if (!Target[0].dodgeBall(this)) {
                Target[0].loseStamina((int)((this.attack) * 1.5f * variance));
            }
        } else {
            if (!Target[0].dodgeBall(this)) {
                Target[0].loseStamina((int)((this.attack) * variance));
            }
        }
		return false;
    }

	public override bool Skill4() {
        float variance = Random.Range(0.8f, 1.2f);
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * 1.5f * variance));
        }
        this.addStatusEffect("steady", 2);
		return false;
    }
	*/
}