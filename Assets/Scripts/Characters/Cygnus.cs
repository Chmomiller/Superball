using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cygnus : Character {

    void Start() {
        Name = "Cygnus";
        
        Gather = 1;
        Stamina = maxStamina;
        
        maxBalls = 4;
        Role = "Support";
        
        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Star Map: Taurus", "Star Map: Gemini", "Star Map: Sagittarius", "Sun Model" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Buffs all allies", "Debuffs all enemies", "All allies gain 20 stamina", "Stuns an enemy" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Offense"};
          defaultTargetingTypes = new int[] { 0, 2, 0, 0, 0, 0, 0, 2 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 0, 0, 0, 1 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 2, 3, 0 };

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
    }

	public override bool Skill1() {
        if(allies[0] != this) {
            allies[0].addStatusEffect("buff", 2);
        }
        if(allies[1] != this) {
            allies[1].addStatusEffect("buff", 2);
        }
        if(allies[2] != this) {
            allies[2].addStatusEffect("buff", 2);
        }
        actionCooldowns[4] = 4;
		return false;
    }

	public override bool Skill2() {
        for(int i = 0; i <= 3; i++) {
            enemies[i].addStatusEffect("debuff", 2);
        }
        actionCooldowns[5] = 3;
		return false;
    }

	public override bool Skill3() {
        if (allies[0] != this) {
            if(allies[0].Stamina + 20 > allies[0].maxStamina) {
                allies[0].gainStamina(Mathf.Abs(allies[0].maxStamina - allies[0].Stamina + 20));
            }
            allies[0].gainStamina(20);
        }
        if (allies[1] != this) {
            if (allies[1].Stamina + 20 > allies[1].maxStamina) {
                allies[1].gainStamina(Mathf.Abs(allies[1].maxStamina - allies[1].Stamina + 20));
            }
            allies[1].gainStamina(20);
        }
        if (allies[2] != this) {
            if (allies[2].Stamina + 20 > allies[2].maxStamina) {
                allies[2].gainStamina(Mathf.Abs(allies[2].maxStamina - allies[2].Stamina + 20));
            }
            allies[2].gainStamina(20);
        }
        actionCooldowns[6] = 3;
		return false;
    }

	public override bool Skill4() {
        float variance = Random.Range(0.8f, 1.2f);
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * variance));
        }
        Target[0].addStatusEffect("stun", 2);
        actionCooldowns[7] = 2;
		return false;
    }
}