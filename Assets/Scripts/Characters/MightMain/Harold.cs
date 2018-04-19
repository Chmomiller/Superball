using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harold : Character {
    
    void Start() {
        Name = "Harold";
		Stamina = maxStamina;
        Gather = 2;
        maxBalls = 4;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Reactive Armor", "Suppressing Fire", "Heavy Bombardment", "Five Rounds Rapid" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "If attacked this turn, catch the ball and gain steady", "Attack against all enemies, lower damage", "Reduced accuracy but target has reduced hit and dodge calculations", "Throws five balls at a single target inaccurately" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Offense" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 2, 2, 2 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 1, 1 };
		actionCosts = new int[]{ 0, 1, 0, 0, 2, 0, 6, 5 };

		base.Start ();
    }

    void Update() {
		/*
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
        */
    }

	// Reactive Armor: If he is attacked on this turn, then he catches the ball and becomes steady
    public override bool Skill1() {
		this.heldBalls++;
		if(this.heldBalls > this.maxBalls)
		{
			this.heldBalls = this.maxBalls;
		}
		// adds steady for 1 turn
		addStatusEffect ("steady", 2);

        actionCooldowns[4] = 3;
		return false;
    }

	// Suppressing Fire: Becomes read to counterattack when he is hit on the next two turns
    public override bool Skill2() {
        float variance = UnityEngine.Random.Range(.6f, 1.1f); //most likely to throw weaker variance
        if (this.heldBalls == 0) print("Rikuto has no ammo!");
        while (this.heldBalls > 0) {
            Character target = combat.Player[UnityEngine.Random.Range(0, 2)];
            if (target.actionType != "Defense") target.loseStamina( (int)(this.attack * variance) );
            if (target.actionType == "Defense") target.catchBall(this);
            this.heldBalls--;
        }
		return true;
    }

	// Heavy Bombardment: Charges for a turn then attacks with a powerful strike against all enemies and becomes staggered
    public override bool Skill3() {
		if(findStatus("misc") != -1)
		{
			// This attack does stamina loss before checking for dodging
			Target[2].loseStamina(Damage * 2);
			Target[2].dodgeBall (this);
			addStatusEffect ("steady", 1);
		}
		else
		{
			addStatusEffect("misc", 2);
		}
		this.heldBalls -= actionCosts [6];
		return true;
    }

    public override bool Skill4() {
        //Five rounds rapid
        float variance = UnityEngine.Random.Range(.6f, 1.1f); //most likely to throw weaker variance
        for(int i = 0; i <= 5; i++) {
            Target[0].loseStamina((int)(this.attack * variance));
        }
		return true;
    }

	public override void cleanUp()
	{
		base.cleanUp ();

		// If getting ready for skill 3 set action and target for next turn
		if(findStatus("misc") != -1)
		{
			action = "Skill3";
			actionType = "Offense";
			Target [0] = Target [2];
			Target [1] = Target [2];
		}
	}
}