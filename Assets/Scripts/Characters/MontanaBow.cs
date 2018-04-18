using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontanaBow : Character {


    void Start() {
        Name = "The Bow of the US Navy Battleship Montana";
        Damage = 9;
        
        Gather = 9;
        Stamina = 220;
        maxStamina = 220;
        
        maxBalls = 100;
        Role = "Supporter";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Strong Ram", "Depth Charge", "Deep Torpedoes", "Skill4" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Charges forward with a ram", "Drops explosives off the front", "", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
        defaultTargetingTypes = new int[] { 0, 1, 0, 0, 1, 0, 0, 0 };
        alternateTargetingTypes = new int[] { 0, 2, 0, 0, 2, 0, 0, 0 };
        actionCosts = new int[] { 0, 1, 0, 0, 1, 1, 0, 0 };
    }

    void Update() {

    }

    public override bool catchBall(Character attacker) {
        this.loseStamina(attacker.Damage - 20);
        return false;
    }

    public override bool Skill1() {
        float variance = UnityEngine.Random.Range(.7f, 1.2f);
        Target[0].loseStamina((int)(1.5f * this.Damage * variance));
        this.actionCooldowns[4] = 3;
        return true;
    }

    public override bool Skill2() {
        float variance;
        for (int i = 0; i < 6; i++) {
            variance = UnityEngine.Random.Range(0.7f, 1.0f);
            Target[0] = enemies[UnityEngine.Random.Range(0, 2)];
            if (!Target[0].catchBall(this)) Target[0].loseStamina((int)(this.attack * variance));
        }
        this.actionCooldowns[5] = 2;
        return true;
    }

    public override bool Skill3() {
        return true;
    }

    public override bool Skill4() {
        return false;
    }
}
