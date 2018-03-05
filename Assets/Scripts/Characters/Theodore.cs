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
	    actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Defense", "Offense" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground","Weaker attack but enemy is stunned for 1 turn" , "Guaranteed attack on target. Cost 3, CD 2", "If a ball is to be thrown at you, redirect at a target ally instead", "Throw 8 balls at random enemies"};
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 2, 0 };
	    alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 2, 1, 0 };
	    actionCosts = new int[] { 0, 1, 0, 0, 1, 1, 0, 8 };

    }

    // Update is called once per frame
    void Update() {
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

    public override void Skill1() {
        //Rook: slightly weaker attack and enemy is stunned for one turn. Cost: 2 balls
        float variance = UnityEngine.Random.Range(.8f, 1.2f);  // sample damage calculation

        if (!Target.dodgeBall(this)) {
            Target.loseStamina( (int)( (this.attack - 20) * variance) );
            Target.addStatusEffect("stun", 1);
        }
        this.heldBalls -= 2;
    }



    public override void Skill2() {
        //Bishop: deals a guaranteed attack on any enemy, they can still catch after. Cost: 3 balls. Cooldown: 2
        //this contradicts our way of checking for defensive moves, IE dont call your own skill if the enemy uses a defensive move. Either way, I will try
        float variance = Random.Range(0.8f, 1.2f);
        Target.loseStamina((int)(this.attack * variance));
        actionCooldowns[4] = 3; //where N is assuming this is the N+1th ability.
        this.heldBalls -= 3;
    }

    public override void Skill3() {
        //This uses your accuracy 
        if (!Target.dodgeBall(this)) Target.loseStamina(this.Damage - 15);
        actionCooldowns[5] = 2; //where N is assuming this is the N+1th ability.
        this.heldBalls--;
    }


    public override void Skill4() {
        float variance;
        for (int i = 0; i < 8; i++) {
            variance = Random.Range(0.7f, 1.1f);
            Target = combat.Enemy[Random.Range(0, 2)];
            if (!Target.dodgeBall(this)) Target.loseStamina((int)(this.attack * variance));
            this.heldBalls -= 8;
        }
    }


}
