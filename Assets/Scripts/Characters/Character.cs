using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string Name = "default";
	public int Damage = 1;
    public int Catch = 100;
    public int Gather = 0;
    public int Capacity = 4;
    public int Stamina = 10;
	public int maxStamina = 10;
    public int heldBalls = 0;
    public string Role = "Supporter";

    public bool dead = false;
	public bool catching = false;


    public void loseStamina(int staminaLoss) { this.Stamina -= staminaLoss; }
    public void gainStamina(int staminaLoss) { this.Stamina += staminaLoss; }

	public virtual int catchBall(int damage, Character attacker)
	{
		int caught = 0;
		if (this.catching) 
		{
			if ((Random.Range (1, 100) + Random.Range (1, 100) / 2) < this.Catch) 
			{ // you can catch it
				this.catching = false;
				if (this.heldBalls < Capacity) 
				{
					this.heldBalls++;
				}
				caught = 1;
			}
		}
		if(this.Stamina > this.Stamina/2)
		{
			loseStamina (damage);
			return caught;
		}
		else
		{
			 
			if ((Random.Range (1, 100) + Random.Range (1, 100) / 2) < (this.Stamina/this.maxStamina) * 100) 
			{//dodge success
				loseStamina (1);
				return 0;
			} 
			else 
			{
				if (this.Stamina <= 0)
					this.dead = true; 
				loseStamina (1);
				return 0;
			}
		}
    }

	public int throwBall(Character target)
	{
		heldBalls--;
		return target.catchBall (this.Damage, target);
	}

    public void Rest()
	{
		this.gainStamina (1);
    }

	public void gatherBall()
	{
		heldBalls += Gather;
		if(heldBalls > Capacity)
		{
			heldBalls = Capacity;
		}
	}

    public virtual void Skill1(){

    }

    public virtual void Skill2(){

    }

    public virtual void Skill3(){

    }

    public void Skill4(){

    }
}
