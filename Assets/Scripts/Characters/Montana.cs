using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montana : Character {

    public int yamatoCharge = 0;

    void Start() {
        Name = "US Navy Montana Class Battleship";
        Catch = 100;
        Gather = 9;
        Stamina = maxStamina;
        heldBalls = 0;
        maxBalls = 100;
        Role = "Supporter";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Yamato Charge", "Artillery Barrage", "Deep Torpedoes", "Skill4" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Charges up Ultimate Cannon", "Fires the 3 balls via the front cannon", "Attacks 6 random enemies", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 0, 2, 0, 0 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 0, 1, 0, 0 };
        actionCosts = new int[] { 0, 1, 0, 2, 3, 3, 6, 0 };

		base.Start ();
    }

    void Update() {
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

        if (yamatoCharge == 100) {
            enemies[0].dead = true;
            enemies[1].dead = true;
            enemies[2].dead = true;
        }
    }

    public override bool catchBall(Character attacker) {
        this.loseStamina(attacker.Damage - 15);
        return false;
    }

	public override bool Skill1() {
        yamatoCharge += 10;
        heldBalls -= 3;
		return false;
    }

	public override bool Skill2() {
        float variance = UnityEngine.Random.Range(.7f, 1.2f);
        for (int i = 0; i < 4; i++) {
            if (!Target[0].dodgeBall(this)) {
                Target[0].loseStamina((int)((this.attack) * variance));
            }
        }
        actionCooldowns[5] = 2;
		return false;
    }

	public override bool Skill3() {
        float variance;
        for (int i = 0; i < 6; i++) {
            variance = UnityEngine.Random.Range(0.7f, 1.0f);
            Target[0] = enemies[UnityEngine.Random.Range(0, 2)];
            if (!Target[0].catchBall(this)) Target[0].loseStamina((int)(this.attack * variance));
        }
		return false;
    }

	public override bool Skill4() {
		return false;
    }
}
