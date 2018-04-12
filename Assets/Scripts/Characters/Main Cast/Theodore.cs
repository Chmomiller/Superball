using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theodore : Character {

    // Use this for initialization
    void Start() {
        Name = "Theodore";
        Damage = 1;
        Catch = 25;
        Capacity = 8;
        Gather = 1;
        Stamina = 7;
        heldBalls = 0;
        Role = "Thrower";

	    actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Rook", "Bishop", "Castling", "Queen" };
	    actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground","Weaker attack but enemy is stunned for 1 turn" , "Guaranteed attack on target. Cost 3, CD 2", "If a ball is to be thrown at you, redirect at a target ally instead", "Throw 8 balls at random enemies"};
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 2, 0 };
	    alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 2, 1, 0 };
	    actionCosts = new int[] { 0, 1, 0, 0, 2, 3, 1, 8 };
		base.Start ();
    }

	/*
    // Update is called once per frame
    bool Update() {
        if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
    }
	*/

    public override bool Skill1() {
        //Rook: slightly weaker attack and enemy is stunned for one turn. Cost: 2 balls
		float variance = UnityEngine.Random.Range(0.8f, 1.2f);  // currently results in a 0 Dmg attack

        if (!Target[0].dodgeBall(this)) {
			print ("Rook Damage: "+(int)((this.attack) * variance));
            Target[0].loseStamina( (int)( (this.attack) * variance) );
            Target[0].addStatusEffect("stun", 1);
        }
		this.heldBalls -= actionCosts[4];
		return false;
    }



    public override bool Skill2() {
        //Bishop: deals a guaranteed attack on any enemy, they can still catch after. Cost: 3 balls. Cooldown: 2
        //this contradicts our way of checking for defensive moves, IE dont call your own skill if the enemy uses a defensive move. Either way, I will try'

		// Switching Target increases the likelyhood that Theodore will aim for his intended target, 
		// but in the case where all enemies are catching for the target and the target is not the one with lowest stamina, 
		// Theodore will aim for the wrong target.
		Target[0] = Target[2];
		float variance = Random.Range(0.8f, 1.2f);
        Target[0].loseStamina((int)(this.attack * variance));
        actionCooldowns[5] = 3; //where N is assuming this is the N+1th ability.
		this.heldBalls -= actionCosts[5];
		return false;
    }

    public override bool Skill3() {
        //This uses your accuracy 
        if (!Target[0].dodgeBall(this)) Target[0].loseStamina(this.Damage - 15);
        actionCooldowns[6] = 2; //where N is assuming this is the N+1th ability.
		this.heldBalls -= actionCosts[6];
		return false;
    }


    public override bool Skill4() {
        float variance;
        for (int i = 0; i < 8; i++) {
            variance = Random.Range(0.7f, 1.1f);
            Target[0] = combat.Enemy[Random.Range(0, 2)];
            if (!Target[0].dodgeBall(this)) Target[0].loseStamina((int)(this.attack * variance));
			this.heldBalls -= actionCosts[7];
        }
		return false;
    }


}
