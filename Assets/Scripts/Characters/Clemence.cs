using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clemence : Character
{

    public Character person1;
    public Character person2;
    bool plantedStance = false;
    bool rainShield = false;

    // Use this for initialization
    void Start()
    {
        Name = "Clemence";
		Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Catcher";
        
    }

    // Update is called once per frame
    void Update()
    {

    }
	/*
	public override int catchBall(int damage, Character attacker)
    {
        if (this.rainShield)
        {
            if (this.heldBalls > 0)
            {
                this.rainShield = false;
                this.catching = false;
				// This uses Clemence's Damage instead of the attackers Damage
				this.throwBall(attacker);
                heldBalls++;
            }
            return 0;
        }
        else if (this.catching)
        {
            if ((Random.Range(1, 100) + Random.Range(1, 100) / 2) < this.Catch)
            { // you can catch it
                if (!this.plantedStance)
                {
                    this.catching = false;
                }
                if (this.heldBalls < Capacity)
                {
                    this.heldBalls++;
                }
                return 1;
            }
           
        }
		else if ((Random.Range(1, 100) + Random.Range(1, 100) / 2) < (this.Stamina/this.maxStamina) * 100)
        {//dodge success
			loseStamina(damage);
            return 0;
        }
        else
        {
            loseStamina(1);
            if (this.Stamina <= 0)
                this.dead = true;
            return -1;
        }
        return 0;
    }
	*/

	public override void Skill1(Character target) //Special move #1 PicketFences
    {
        //Activates catching for both other characters
         person1.catching = true;
         person2.catching = true;
    }

    void Skill2() //Planted stance
    {
        this.catching = true;
        this.plantedStance = true;
    }

    void Skill3() //Rain Shield
    {
        this.catching = true;
        this.rainShield = true;
    }

}
