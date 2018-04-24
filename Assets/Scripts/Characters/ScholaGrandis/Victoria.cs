using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : Character {

    public bool Transform = false;
	private int lastStamina;

    // Use this for initialization
    void Start() {
        Name = "Victoria";
        Stamina = maxStamina;
        Role = "Catcher";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Kawii/Kowaii", "Parasol", "Idol Scream", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls ground", 
										  "Gets a boost to catch until misses a catch(Kawaii), then gets a hit boost (Kowaii)", 
										  "Rebounds next shot thrown at her", 
										  "Reduce stamina of all enemies", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Offense", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 2, 3 };

		base.Start ();

		lastStamina = Stamina;
    }

    // Update is called once per frame
    void Update() {
		/*
        if (allegiance == 1) {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
        */
		base.Update ();
    }

	public virtual bool catchBall(Character attacker)
	{
		if(findStatus("misc") != -1)
		{
			attacker.throwBall (attacker);
			statusEffects [findStatus ("misc")].duration = 0;
			removeDoneStatusEffects ();
			return true;
		}
		else if(catching)
		{
			base.catchBall (attacker);
		}
		return false;
	}

	public new bool dodgeBall(Character attacker)
	{
		if (findStatus ("misc") != -1) 
		{
			attacker.throwBall (attacker);
			statusEffects [findStatus ("misc")].duration = 0;
			removeDoneStatusEffects ();
			return false;
		}
		else
		{
			base.dodgeBall (attacker);
		}
		return false;
	}

    //we dont really have sequential moves yet.

	//Kawaii / Kowaii: Gets a boost to catch until misses a catch(Kawaii), then gets a hit boost (Kowaii)
	public override bool Skill1()
	{
		addStatusEffect ("steady", 100);
		Debug.Log (statusEffects [findStatus ("steady")].name + ": " + statusEffects [findStatus ("steady")].duration);
		return true;	
	}

	//Parasoul(Kawaii): Rebounds the next shot thrown at her
	//Nothing yet allows multi turn logic. This just needs a framework and should be simple
    public override bool Skill2() { 
		this.addStatusEffect ("misc", 100);
		Debug.Log (statusEffects [findStatus ("misc")].name + ": " + statusEffects [findStatus ("misc")].duration);
		return false;
    }

    public override bool Skill3() {
        //      Idol Scream (Kowaii): reduce stamina of all enemy players
        int value = (int)((Damage * 1.5f) * (heldBalls / 3f) * 2f);
		enemies[0].loseStamina((int)(value * attackMultiplier * enemies[0].defenseMultiplier));
		enemies[1].loseStamina((int)(value * attackMultiplier * enemies[1].defenseMultiplier));
		enemies[2].loseStamina((int)(value * attackMultiplier * enemies[2].defenseMultiplier));
		Debug.Log ("Idol Scream damage: "+value);
		return true;
    }

	public override bool Skill4() {return true; }

	public override void cleanUp()
	{
		base.cleanUp ();

		// This checks if Elizabeth was attacked this turn, isn't transformed, and is unsteady
		if(this.lastStamina < Stamina && !Transform && findStatus("steady") != -1)
		{
			this.Transform = true;
			addStatusEffect ("buff", 1);
			statusEffects [findStatus ("steady")].duration = 0;
			removeDoneStatusEffects ();
			print (statusEffects [findStatus ("buff")].name + ": " + statusEffects [findStatus ("buff")].duration);

		}

		lastStamina = Stamina;
	}
}
