using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trevor : Character {
	
    // Use this for initialization
    void Start() {
        Name = "Trevor";
        Damage = 1;
        Catch = 25;
        Capacity = 8;
        Stamina = 7;
        heldBalls = 0;
        Role = "Thrower";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Thrash", "Skill2", "Skill3", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Throws at 3 random targets", "enemy is blocked from throwing balls and must do something else next", "Blocks the first attack on the next two turns", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 }; 
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 3, 0, 0, 0 };
    }

    // Update is called once per frame
    void Update() {
        if (allegiance == 1) {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else{
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
	}

	// Thrash: Throws 3 balls at three random targets on your team. 1 turn cooldown. Cost: 3 balls
    // Currently doesn't allow players to res off of a catch from this skill
	public override void Skill1()
    {
        float variance;
        for (int i = 0; i < 3; i++) {
            variance = UnityEngine.Random.Range(0.8f, 1.2f);
            Target = this.enemies[UnityEngine.Random.Range(0, 2)];
        if (Target.catchBall(this)) Target.loseStamina( (int)(this.Damage * variance) );
    }
    actionCooldowns[4] = 1;
      heldBalls -= 3;
    }

}
