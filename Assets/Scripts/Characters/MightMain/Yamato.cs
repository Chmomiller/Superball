using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yamato : Character {
	
    public int yamatoCharge = 0;

    void Start() {
        Name = "The Imperial Japanese Battleship Yamato";
        Gather = 9;
        Stamina = 300;
        maxStamina = 300;
        
        maxBalls = 100;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Yamato Charge", "Artillery Barrage", "Deep Torpedoes", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Charges up Ultimate Cannon", "Fires the 3 balls via the front cannon", "Attacks 6 random enemies", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 2, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 1, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 2, 3, 3, 6, 0 };

		base.Start();
    }

	new public void loseStamina(int staminaLoss)
	{
		AudioScript.playStaticSFX("_SFX/Battle sfx/miss/miss_1");
		if (staminaLoss > 20) 
		{
			this.Stamina -= (staminaLoss - 20); 
		} 
		else 
		{
			// I don't know if anything *needs* to go here
		}
		if(this.Stamina < 0)
		{
			this.Stamina = 0;
			this.dead = true;
		}
	}

    void Update() {
		/*
        if (yamatoCharge == 100) {
            enemies[0].dead = true;
            enemies[1].dead = true;
            enemies[2].dead = true;
        }*/
    }

    public override bool catchBall(Character attacker) {
        this.loseStamina(attacker.Damage - 15);
        return false;
    }

	// 
    public override int Skill1() {
        yamatoCharge += 10;
        heldBalls -= 3;
		return 0;
    }

    public override int Skill2() {
        float variance = UnityEngine.Random.Range(.7f, 1.2f);
        if (!Target[0].dodgeBall(this)) Target[0].loseStamina(  (int)(this.Damage * variance) );
        if (!Target[0].dodgeBall(this)) Target[0].loseStamina( (int)(this.Damage * variance) );
        if (!Target[0].dodgeBall(this)) Target[0].loseStamina( (int)(this.Damage * variance) );
        this.heldBalls -= 3;
        actionCooldowns[5] = 2;
		return 0;
    }

    public override int Skill3() {
        float variance;
        for (int i = 0; i < 6; i++) {
            variance = UnityEngine.Random.Range(0.7f, 1.0f);
            Target[0] = enemies[UnityEngine.Random.Range(0, 2)];
        if (!Target[0].catchBall(this)) Target[0].loseStamina( (int)(this.attack * variance) );
    }
		return 0;
}

	public override int Skill4() {
		return 0;
    }
}
