using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henry : Character {

    new void Start() {
        Name = "Henry";
        Stamina = maxStamina;
        Role = "Catcher";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Electri Generator", "Electric Switch", "Electric Loudspeaker", "Electric Provision" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Hurts an enemy with an attack 0.5 times stronger and makes him unsteady", "Remove all status effects from anyone", "Makes all enemies unsteady", "Gives an ally 3 balls" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Utility", "Offense", "Utility" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 2, 0, 2, 1 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 3, 3, 3 };
    }

    // Update is called once per frame
    new void Update() {
		base.Update ();
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
            Target[0].loseStamina((int)((this.attack) * 0.5f* variance));
        }
        Target[0].addStatusEffect("unsteady", 2);
        actionCooldowns[4] = 2;
		return false;
    }

	public override bool Skill2() {
        for(int i = 0; i< this.statusEffects.Length; i++) {
            combat.Player[0].statusEffects[i].duration = 0;
            combat.Player[0].removeDoneStatusEffects();
            combat.Player[1].statusEffects[i].duration = 0;
            combat.Player[1].removeDoneStatusEffects();
            combat.Player[2].statusEffects[i].duration = 0;
            combat.Player[2].removeDoneStatusEffects();
            combat.Enemy[0].statusEffects[i].duration = 0;
            combat.Enemy[0].removeDoneStatusEffects();
            combat.Enemy[1].statusEffects[i].duration = 0;
            combat.Enemy[1].removeDoneStatusEffects();
            combat.Enemy[2].statusEffects[i].duration = 0;
            combat.Enemy[2].removeDoneStatusEffects();
        }
        actionCooldowns[5] = 3;
		return false;
    }

	public override bool Skill3() {
        for(int i = 0; i<=3; i++) {
            enemies[i].addStatusEffect("unsteady", 2);
        }
        actionCooldowns[6] = 4;
		return false;
    }

	public override bool Skill4() {
        Target[0].heldBalls += 3;
        if (Target[0].heldBalls > Target[0].maxBalls) Target[0].heldBalls = Target[0].maxBalls;
		return false;
    }
	*/
}