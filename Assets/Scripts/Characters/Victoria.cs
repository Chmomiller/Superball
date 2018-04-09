using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : Character {

    public bool Transform = false;

    // Use this for initialization
    void Start() {
        Name = "Victoria";
        Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Catcher";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Parasol", "Idol Scream", "Skill3", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Rebounds next shot thrown at her", "Reduce stamina of all enemy players", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Offense", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 2, 3 };
    }

    // Update is called once per frame
    void Update() {
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        } else {
            if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
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


    //Kawaii / Kowaii: Gets a boost to catch until misses a catch(Kawaii), then gets a hit boost (Kowaii)
    public void preTransform() { if (true) { Transform = true; } else { Transform = false; } }

    //we dont really have sequential moves yet.

    
    public override void Skill1() { 
        //Parasoul(Kawaii): Rebounds the next shot thrown at her
        //Nothing yet allows multi turn logic. This just needs a framework and should be simple
    }

    public override void Skill2() {
        //      Idol Scream (Kowaii): reduce stamina of all enemy players
        int value = (int)((Damage * 1.5f) * (heldBalls / 3f) * 2f);
        enemies[0].Stamina -= value;
        enemies[1].Stamina -= value;
        enemies[2].Stamina -= value;
    }

    public override void Skill3() {
    }

    public override void Skill4() { }

}
