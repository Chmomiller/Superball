using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theodore : Character {
    // Use this for initialization
    new void Start() {
        Name = "Theodore";
        Stamina = maxStamina;
        Role = "Thrower";

	    actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Rook", "Bishop", "Castling", "Queen" };
	    actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Offense" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls",
			"Throw a <i>weaker</i> attack that leaves the foe <color=orange>unsteady</color> for 1 turn\nCost: 2 balls    Target: Single Enemy", 
			"Throw a ball that ignores catching. <color=red>2</color> turn cooldown.\nCost: 3 balls    Target: Single Enemy", 
			"If a ball is to be thrown at you, redirect at a target ally instead", 
			"Throw 8 balls at an enemy. <color=red>2</color> turn cooldown.\nCost: 8 balls    Target: Single Enemy"};
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 2, 1 };
	    alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 2, 1, 2 };
	    actionCosts = new int[] { 0, 1, 0, 0, 4, 3, 1, 8 };
		base.Start ();
    }


    // Update is called once per frame
	new void Update() {
		base.Update ();
		/*
        if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }*/
    }


	public override int Skill1() {
        //Rook: slightly weaker attack and enemy is stunned for one turn. Cost: 2 balls
		float variance = UnityEngine.Random.Range(0.8f, 1.2f);  // currently results in a 0 Dmg attack

		// check if the target dodges the ball
		Target[0].dodgeBall(this);
		// deal damage and add statusEffect
		int damage = (int)( this.Damage * variance * .125f * attackMultiplier * Target[0].defenseMultiplier);
		Target[0].loseStamina( damage );
        Target[0].addStatusEffect("unsteady", 2);
		this.heldBalls -= actionCosts[4];
		return damage;
    }



    public override int Skill2() {
        //Bishop: deals a guaranteed attack on any enemy, they can still catch after. Cost: 3 balls. Cooldown: 2
        //this contradicts our way of checking for defensive moves, IE dont call your own skill if the enemy uses a defensive move. Either way, I will try'

		// Switching Target increases the likelyhood that Theodore will aim for his intended target, 
		// but in the case where all enemies are catching for the target and the target is not the one with lowest stamina, 
		// Theodore will aim for the wrong target.
		Target[0] = Target[2];
		float variance = Random.Range(0.8f, 1.2f);
		int damage = (int)(this.Damage * variance * attackMultiplier * Target [0].defenseMultiplier);
		Target[0].loseStamina(damage);
        actionCooldowns[5] = 3; //where N is assuming this is the N+1th ability.
		this.heldBalls -= actionCosts[5];
		return damage;
    }

	// What skill is this
	// If a ball is to be thrown at you, redirect at a target ally instead
	public override int Skill3() {
        //This uses your accuracy 
		Target[0].dodgeBall(this); 
		Target[0].loseStamina(this.Damage - 15);
        actionCooldowns[6] = 2; //where N is assuming this is the N+1th ability.
		this.heldBalls -= actionCosts[6];
		return 0;
    }

	// Queen: Throws 8 balls at a single enemy
	public override int Skill4() {
        float variance;
		int damage = 0;
        for (int i = 0; i < 8; i++) {
            variance = Random.Range(0.7f, 1.1f);
			Target[0].dodgeBall(this);
			int partialDamage = (int)(this.Damage * variance * attackMultiplier * Target [0].defenseMultiplier);
			Target[0].loseStamina(partialDamage);
			damage += partialDamage;
        }
		actionCooldowns[7] = 3;
		this.heldBalls -= actionCosts[7];
		return damage;
    }
}
