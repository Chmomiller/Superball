using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rikuto : Character {
    
    void Start() {
        Name = "Rikuto";
        Damage = 1;
        Catch = 100;
        Gather = 1;
        Stamina = 10;
        maxStamina = 10;
        heldBalls = 0;
        Capacity = 4;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Armor Piercing", "Ultimate Throw", "Suppressing Fire", "Five Rounds Rapid" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Attack against a target that can only be dodged", "Attack against all enemies, lower damage", "Reduced accuracy but target has reduced hit and dodge calculations", "Throws five balls at a single target inaccurately" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Offense" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 2, 2, 2 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 1, 1 };
		actionCosts = new int[]{ 0, 1, 0, 0, 2, 0, 2, 5 };
    }

    void Update() {
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

    public override void Skill1() {
        float variance = UnityEngine.Random.Range(.9f, 1.5f); //higher damage 
        if (!Target.dodgeBall(this)) Target.loseStamina( (int)(this.attack * variance) );
        actionCooldowns[4] = 3;
    }

    public override void Skill2() {
        float variance = UnityEngine.Random.Range(.6f, 1.1f); //most likely to throw weaker variance
        if (this.heldBalls == 0) print("Rikuto has no ammo!");
        while (this.heldBalls > 0) {
            Character target = combat.Player[UnityEngine.Random.Range(0, 2)];
            if (target.actionType != "Defensive") target.loseStamina( (int)(this.attack * variance) );
            if (target.actionType == "Defensive") target.catchBall(this);
            this.heldBalls--;
        }
    }

    public override void Skill3() {
        //Suppressing Fire!: tthrows at a player with a reduced hit chance. target gets a large devuff to hit and dodge calculations

        //Not sure how hit is calculated
    }

    public override void Skill4() {
        //Five rounds rapid
        float variance = UnityEngine.Random.Range(.6f, 1.1f); //most likely to throw weaker variance
        for(int i = 0; i <= 5; i++) {
            Target.loseStamina((int)(this.attack * variance));
        }
    }
}