using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elizabeth : Character {
	
    public bool Transform = false;
    // Use this for initialization
    void Start() {
        Name = "Elizabeth";
        Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Catcher";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Preen", "Royal Touch", "Skill3", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Stacking self buff to damage", "Strong attack that may stun against one enemy", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Offense", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 2, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 2, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 2, 0, 0 };
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

    //Unfocused/Attack: Elizabeth is now unsteady, taking more dmg until she is attacked. When attacked, she switches to steady (less dmg);
    //this one is kinda weird since its more of a passive to be checked at the beginning of the execute phase, like the other abilities that occur post planning (change target to me, all attack me, etc.) 
    public void preTransform() {
        if (enemies[0].Target == this || enemies[1].Target == this || enemies[2].Target == this) {
            this.addStatusEffect("lessDmg", 1);
            this.removeStatusEffect("moreDmg");
            Transform = true;
        } else {
            this.addStatusEffect("moreDmg", 1);
            this.removeStatusEffect("lessDmg");
            Transform = false;
        }
    }



    public override void Skill1() {
        //   Preen (Unfocused): stacking self damage buff to stamina dmg.
        //cant do stacking buffs yet   
    }

  public override void Skill2() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (!Target.dodgeBall(this)) {
            Target.loseStamina(  (int)( (this.attack + 35)*variance ) );
            if (UnityEngine.Random.Range(0, 5) > 4) {
                Target.addStatusEffect("stun", 2);
            }
        }
        actionCooldowns[5] = 3;
    }

    public override void Skill3() { }

    public override void Skill4() { }

}
