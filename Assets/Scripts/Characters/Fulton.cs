using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fulton : Character {

    void Start() {
        Name = "Fulton";
        Damage = 10;
        Catch = 100;
        Gather = 1;
        Stamina = 10;
        maxStamina = 10;
        heldBalls = 0;
        Capacity = 4;
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
    void Update() {
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
                combat.Player[i].Target = this;
            }
        }
    }

    public override void Skill1() {
        float variance = Random.Range(0.8f, 1.2f);
        Target.dodgeBall( (int)(this.Damage*variance) );
        variance = Random.Range(0.8f, 1.2f);
        Target.dodgeBall((int)(this.Damage * variance));
    }

    public override void Skill2() {
        float variance;
        for(int i = 0; i< 4; i++) {
            variance = Random.Range(0.8f, 1.2f);
            enemies[i].dodgeBall( (int)(this.Damage * variance) );
        }
    }

    public override void Skill3() {
        float variance = Random.Range(0.8f, 1.2f);
        //If target is stunned
        if (Target.findStatus("stun") != -1) {
            Target.dodgeBall((int)(this.Damage * 1.5 * variance));
        } else {
            Target.dodgeBall((int)(this.Damage * variance));
        }
    }

    public override void Skill4() {
        float variance = Random.Range(0.8f, 1.2f);
        Target.dodgeBall((int)(this.Damage * 1.5 * variance));
        this.addStatusEffect("steady", 2);
    }

}