using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string Name = "default";
	public int Damage = 1;
    public int Catch = 100;
    public int Gather = 1;
    public int Capacity = 4;
    public int Stamina = 10;
	public int maxStamina = 10;
    public int heldBalls = 0;
    public string Role = "Supporter";
	public Character Target; //Create an empty Character in the combat manager that other charaters can select when not targetting
	public string action = "";
	public string actionType = "";
	public int targetingType = 0; //0 for self/predetermined, 1 for enemies, 2 for allies
	//Following 3 arrays are paired, so when an action is selected it can look at the same index
	//of the different arrays and set the corresponding variable to the array value
	private string[] actions = {"None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Rest" };
	private string[] actionNames = { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Rest" }; 
	private string[] actionTypes = { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility" };
	private int[] targetingTypes = { 0, 1, 0, 0, 0, 0, 0 };
	private int[] actionCosts = { 0, 1, 0, 0, 0, 0, 0 };
	public int[] actionCooldowns = { 0, 0, 0, 0, 0, 0, 0 };

    public bool dead = false;
	public bool catching = false;


    public void loseStamina(int staminaLoss) { this.Stamina -= staminaLoss; }
    public void gainStamina(int staminaLoss) { this.Stamina += staminaLoss; }
	public string GetAction(int index){return this.actions [index];}
	public string GetActionName(int index){return this.actionNames [index];}
	public string GetActionType(int index){return this.actionTypes [index];}
	public int GetTargetingType(int index){return this.targetingTypes [index];}
	public int GetActionCost(int index){return this.actionCosts [index];}

	// Currently the character is still catching if they weren't targeted in the last round
	public virtual int catchBall(int damage, Character attacker)
	{
		int caught = 0;
		if (this.catching) 
		{
			if ((Random.Range (1, 100) + Random.Range (1, 100) / 2) < this.Catch) 
			{ // you can catch it
				if (this.heldBalls < Capacity) 
				{
					this.heldBalls++;
				}
				caught = 1;
			}
			this.catching = false;
		}
		if(this.Stamina > this.maxStamina/2)
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
