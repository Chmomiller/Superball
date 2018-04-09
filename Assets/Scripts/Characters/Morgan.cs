using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morgan : Character {

    void Start() {
        Name = "Morgan";
        Damage = 1;
        Catch = 100;
        Gather = 1;
        Stamina = 10;
        maxStamina = 10;
        heldBalls = 0;
        Capacity = 4;
        Role = "Thrower";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Limace de mer", "Moule", "La victorie", "" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Slightly stronger attack against an enemy", "Hits an enemy while making yourself steady", "Weakened attack against all enemies that has a change to make target unsteady", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 2, 2, 0, 0 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 1, 1, 0, 0 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 3, 5, 0 };
    }

    void Update() {
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        } else {
            if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
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

    public override void Skill1() {
        float variance = UnityEngine.Random.Range(.8f, 1.25f);
        Target.loseStamina((int) ( (this.Damage * 1.15) * (variance) ) );
    }

    public override void Skill2() {
        float variance = UnityEngine.Random.Range(.8f, 1.25f);
        Target.loseStamina((int)(this.Damage * variance));
        this.addStatusEffect("steady", 2);
    }

    public override void Skill3() {
        Character [] randomTargets = new Character[3];
        for (int i = 0; i < 3; i++) {
            Character target = this.enemies[Random.Range(0, 2)];
            float variance = UnityEngine.Random.Range(.8f, 1.25f);
            target.loseStamina((int)((this.Damage * 1.5) * (variance)));
            if(Random.Range(0,10) > 7) { target.addStatusEffect("unsteady", 2);}
        }
    }

    public override void Skill4() {
    }
}