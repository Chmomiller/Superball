using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : Character {

    public bool Transform = false;
	private int lastStamina;

    // Use this for initialization
    new void Start() {
        Name = "Victoria";
        Stamina = maxStamina;
        Role = "Catcher";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Viscious Mockery", "Parasol", "Idol Scream", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls ground",
                                          "Deliver a <i>weak</i> attack with a high chance to <color=blue>debuff</color> the target. <color=red>1</color> turn cooldown.\nCost: 1    Target: Single Enemy", 
										  "Rebounds the next shot thrown at her back at the attacker. <color=red>2</color> cooldown.\nCost: 4    Target: Self",
                                          "Throw a <i>weak</i> attack and <color=yellow>stun</color> target enemy.\nCost: 3    Target: Single Enemy",
                                          "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Defense", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 1, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 1, 4, 3, 0 };

		base.Start ();

		lastStamina = Stamina;
    }

    // Update is called once per frame
    new void Update() {
		base.Update ();
    }

	public new bool catchBall(Character attacker)
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
			return base.catchBall (attacker);
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
	public override int Skill1()
	{
        float dmg = UnityEngine.Random.Range(0.5f, 1)*this.Damage*this.attackMultiplier;
        if (UnityEngine.Random.Range(0, 9) > 3) { Target[0].addStatusEffect("debuff", 2); }
        this.heldBalls -= this.actionCosts[4];
        this.actionCooldowns[4] = 2;
        return (int)dmg;

	}

	//Parasoul(Kawaii): Rebounds the next shot thrown at her
	//Nothing yet allows multi turn logic. This just needs a framework and should be simple
	public override int Skill2() { 
		this.addStatusEffect ("misc", 100);
		Debug.Log (statusEffects [findStatus ("misc")].name + ": " + statusEffects [findStatus ("misc")].duration);
        this.heldBalls -= this.actionCosts[5];
        this.actionCooldowns[5] = 3;
        return 0;
    }


    public override int Skill3() {
        Target[0].addStatusEffect("stun", 2);
        Target[0].loseStamina(this.Damage / 2);
        return this.Damage / 2;
    }

    /*
	public override int Skill3() {
        //      Idol Scream (Kowaii): reduce stamina of all enemy players
        int value = (int)((Damage * 1.5f));
		enemies[0].loseStamina((int)(value * attackMultiplier * enemies[0].defenseMultiplier));
		enemies[1].loseStamina((int)(value * attackMultiplier * enemies[1].defenseMultiplier));
		enemies[2].loseStamina((int)(value * attackMultiplier * enemies[2].defenseMultiplier));
		Debug.Log ("Idol Scream damage: "+value);
		return (int)(value * attackMultiplier * enemies[0].defenseMultiplier) + 
			   (int)(value * attackMultiplier * enemies[1].defenseMultiplier) + 
			   (int)(value * attackMultiplier * enemies[2].defenseMultiplier);
    }
    */
    public override int Skill4() {return 0; }

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
