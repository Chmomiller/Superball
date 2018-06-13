using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harold : Character {
    
    new void Start() {
        Name = "Harold";
		Stamina = maxStamina;
        Role = "Thrower";

        actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Reactive Armor", "Suppressing Fire", "Heavy Bombardment", "Five Rounds Rapid" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls",
                                            "If attacked this turn, catch the ball and gain <color=lime>steady</color> for a turn. <color=red>2</color> turn cooldown.\nCost: None    Target: Self", 
											"Counterattack when attacked on the next 2 turns\nCost: 3    Target: Self", 
											"Charge for a turn then attack with a <b>hard-hitting</b> attack against an enemy and become <color=orange>unsteady</color>.\nCost: 4    Target: Single Enemy", 
											"Throw 5<i>weak</i> attacks at a single target with a chance to miss.  <color=red>3</color> turn cooldown.\nCost: 6    Target: Single Enemy" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Defense", "Offense", "Offense" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 1, 1 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 3, 4, 6 };

		base.Start ();
    }

    new void Update() {
		base.Update ();
    }

	public override bool dodgeBall(Character attacker)
	{
		if(findStatus(STATUS.MISC) != -1 && action != "Skill2")
		{
			throwBall (attacker);
		}
		return base.dodgeBall (attacker);
	}

	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override int Skill1() {
		if(combat.combatQueue[combat.currentCharacter] != this)
		{
			this.heldBalls++;
			if(this.heldBalls > this.maxBalls)
			{
				this.heldBalls = this.maxBalls;
			}
			// adds steady for 1 turn
			addStatusEffect (STATUS.STEADY, 1);

			actionCooldowns[4] = 3;
		}
		return -1;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override int Skill2() {
		addStatusEffect (STATUS.MISC, 2);
        this.heldBalls -= this.actionCosts[5];
		return 0;
    }

	// Heavy Bombardment: Charges for a turn then attacks with a powerful strike against all enemies and becomes staggered
	public override int Skill3() {
		int damage = 0;
		if(findStatus(STATUS.MISC2) != -1)
		{
			// This attack does stamina loss before checking for dodging
			damage = (int)(Damage * 2 * attackMultiplier * Target[2].defenseMultiplier);
			Target[2].loseStamina(damage);
			Target[2].dodgeBall (this);
			addStatusEffect (STATUS.UNSTEADY, 2);
		}
		else
		{
			addStatusEffect(STATUS.MISC2, 1);
		}
		this.heldBalls -= actionCosts [6];
		return damage;
    }
		
    public override int Skill4() {
        //Five rounds rapid
        float variance = UnityEngine.Random.Range(.6f, 1.1f); //most likely to throw weaker variance
		int damage = 0;
        for(int i = 0; i <= 5; i++) {
			int partialDamage = (int)(this.Damage * variance * attackMultiplier * Target [0].defenseMultiplier);
			damage += partialDamage;
			Target[0].loseStamina(partialDamage);
        }
        this.heldBalls -= this.actionCosts[7];
        this.actionCooldowns[7] = 4;
		return damage;
    }

	public override void cleanUp()
	{
		// Checks if Skill3 or Skill2 was used
		Character tempTarget = Target[2];
		bool whichAction = false;
		if(action == "Skill3")
		{
			whichAction = true;
		}
		base.cleanUp ();

		// If getting ready for skill 3 set action and target for next turn
		if(findStatus(STATUS.MISC2) != -1)
		{
			if(Random.Range(0f, 100f) < 80f)
			{
				Target [2] = tempTarget;
			}
			if(whichAction)
			{
				action = "Skill3";
				actionType = "Offense";
				Target [0] = Target [2];
				Target [1] = Target [2];
				CSUI.ShowTell ("Offense");
			}
		}

	}
}