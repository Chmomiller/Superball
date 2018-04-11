using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ichirou : Character {

    void Start() {
        Name = "Ichirou";
        Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Catcher";

        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Rising Elbow Strike", "Front Stance", "Rooted Stance", "Knife Hand Strike" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Attacks enemy with a 0.5x damage attack and stuns if enemy stamina is below half", "Debuffs an enemy", "On the next turn, all damage taken is reduced by 0.5", "if enemy has less stamina than you, 1.25x damage" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Defense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 2, 2, 0, 2 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 1, 1, 0, 1 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 0, 0, 3 };
    }

    // Update is called once per frame
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
    }

    public override void Skill1() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (Target.Stamina < Target.maxStamina/2) { Target.addStatusEffect("stun", 1); }
        if (!Target.dodgeBall(this)) {
            Target.loseStamina((int)((this.attack) * 0.5f * variance));
        }
        actionCooldowns[4] = 3;
    }

    public override void Skill2() {
        Target.addStatusEffect("debuff", 2);
        actionCooldowns[5] = 2;
    }

    public override void Skill3() {
        this.addStatusEffect("halfDmg", 1);
        actionCooldowns[6] = 3;
    }

    public override void Skill4() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (this.Stamina > Target.Stamina) { variance *= 1.25f; }
        if (!Target.dodgeBall(this)) {
            Target.loseStamina((int)((this.attack) * 0.5f * variance));
        }
        actionCooldowns[7] = 2;
    }
}
