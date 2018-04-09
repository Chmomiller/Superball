using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montana : Character {

    public int yamatoCharge = 0;

    void Start() {
        Name = "US Navy Montana Class Battleship";
        Damage = 1;
        Catch = 100;
        Gather = 9;
        Stamina = 300;
        maxStamina = 300;
        heldBalls = 0;
        Capacity = 100;
        Role = "Supporter";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Yamato Charge", "Artillery Barrage", "Deep Torpedoes", "Skill4" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Charges up Ultimate Cannon", "Fires the 3 balls via the front cannon", "Attacks 6 random enemies", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 0, 2, 0, 0 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 0, 1, 0, 0 };
        actionCosts = new int[] { 0, 1, 0, 2, 3, 3, 6, 0 };
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

    public override void Skill1() {
        yamatoCharge += 10;
        heldBalls -= 3;
    }

    public override void Skill2() {
        float variance = UnityEngine.Random.Range(.7f, 1.2f);
        for (int i = 0; i < 4; i++) {
            Target.dodgeBall((int)(this.Damage * variance));
        }
        actionCooldowns[5] = 2;
    }

    public override void Skill3() {
        float variance;
        for (int i = 0; i < 6; i++) {
            variance = UnityEngine.Random.Range(0.7f, 1.0f);
            Target = enemies[UnityEngine.Random.Range(0, 2)];
            if (!Target.catchBall(this)) Target.loseStamina((int)(this.attack * variance));
        }
    }

    public override void Skill4() {

    }
}
