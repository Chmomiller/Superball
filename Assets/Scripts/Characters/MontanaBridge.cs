using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontanaBridge : Character {


    void Start() {
        Name = "The Bridge of the US Navy Battleship Montana";
        Stamina = maxStamina;
        Role = "Supporter";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Observation Gathering", "Captain's Orders", "Hasty Repairs", "Skill4" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Stuns each ally, but buffs it in return", "Attacks an enemy with an attack 0.5 times stronger, but the bridge becomes steady as well", "Each of the bridge’s allies gets 40 armor, but each ally becomes staggered as well", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
        defaultTargetingTypes = new int[] { 0, 1, 0, 0, 0, 1, 0, 0 };
        alternateTargetingTypes = new int[] { 0, 2, 0, 0, 0, 2, 0, 0 };
        actionCosts = new int[] { 0, 1, 0, 0, 1, 1, 0, 0 };
    }

    void Update() {

    }

    public override bool catchBall(Character attacker) {
        this.loseStamina(attacker.Damage - 20);
        return false;
    }

    public override bool Skill1() {
        if (this.allies[0] != null) {
            if (allies[0].Stamina > 0) {
                allies[0].addStatusEffect("stun", 1);
                allies[0].addStatusEffect("buff", 2);
            }
        } else if (this.allies[1] != null) {
            if (allies[1].Stamina > 0) {
                allies[1].addStatusEffect("stun", 1);
                allies[1].addStatusEffect("buff", 2);
            }
        } else if (this.allies[2] != null) {
            if (allies[2].Stamina > 0) {
                allies[2].addStatusEffect("stun", 1);
                allies[2].addStatusEffect("buff", 2);
            }
        }

        this.actionCooldowns[4] = 4;
        return true;
    }

    public override bool Skill2() {
        float variance;
        variance = UnityEngine.Random.Range(0.9f, 1.8f);
        if (!Target[0].catchBall(this)) Target[0].loseStamina((int)(this.attack * variance));
        this.addStatusEffect("steady", 2);
        this.actionCooldowns[5] = 2;
        return true;
    }

    public override bool Skill3() {
        for (int i = 0; i < 3; i++) {
            if (allies[i].Stamina + 40 < allies[i].maxStamina & allies[i].Stamina > 0) allies[i].Stamina += 40;
        }
        this.actionCooldowns[6] = 3;
        return true;
    }

    public override bool Skill4() {
        return false;
    }
}
