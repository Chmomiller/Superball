using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frank : Character {
	
    // Use this for initialization
    void Start() {
        Name = "Frank";
        Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Catcher";

	    actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Rumble", "Skill2", "Skill3", "Skill4" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Blocks any balls aimed at Trevor", "", "", "" };
	    actionTypes = new string[] { "None", "Offense", "Defense", "Defense", "Utility", "Utility", "Utility" };
	    defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
	    alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };        
	    actionCosts = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
    }

    
    // Update is called once per frame
    void Update() {
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        }else{
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
	


    // Rumble: Frank blocks an attack aimed at Trevor. 1 turn cooldown. Cost: 1 ball
    public override void Skill1() {
        //Rumble: Blocks all attacks aimed at Trevor for 1 turn;
        if (combat.Player[0].Target = GameObject.Find("Trevor").GetComponent<Trevor>() ){
            combat.Player[0].action = "NONE";
            combat.Player[0].heldBalls--;
        }
        if (combat.Player[1].Target = GameObject.Find("Trevor").GetComponent<Trevor>() ){
            combat.Player[1].action = "NONE";
            combat.Player[1].heldBalls--;
        }
        if (combat.Player[2].Target = GameObject.Find("Trevor").GetComponent<Trevor>() ){
            combat.Player[2].action = "NONE";
            combat.Player[2].heldBalls--;
        }
    }

    public override void Skill2() { }

    public override void Skill3() { }

    public override void Skill4() { }    

}
