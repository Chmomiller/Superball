using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

	public double attack;
	public double dodge;
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

	struct status {
		public string name;
		public int duration;
	}

	//status effects should both be checked before actions are chosen for a character and ALSO when they are about to execute an action. This is because some status effects affect your ability to choose actions but moves may change status effects during combat. Prime example is stun.  


	//New function called addStatusEffect() should be added in that serves to handle adding multiple status effects. 
	//Conversely there is also a new Function called removeDoneStatusEffects() that is called at the end of your action that serves to remove all status effects that are over. 
	//There is also a applyStatusEffect() and removeStatusEffect() function that serves to add or remove one status effect chosen. Here is where the actual effects are applied to the player. apply should add the numerical effects, remove should reverse that

	//Characters also have a statusEffects array of status structs 6 long. This serves to hold all status effects you can have. EX. status statusEffects[6];
	private status[] statusEffects = new status[6];

	void addStatusEffect(string name, int duration){
		for(int i =0; i<statusEffects.Length; i++){
			//refresh status effect of same name;
			if(statusEffects[i].name == name && statusEffects[i].duration < duration){
				statusEffects[i].duration = duration;
			}
			//slot is empty
			if(statusEffects[i].name.Equals("none")){
				statusEffects[i].name = name;
				statusEffects[i].duration = duration;
				applyStatusEffect(name);
				break;
			}
		}
	}

	//called at the end of your turn
	void removeDoneStatusEffects(){
		for(int i =0; i<statusEffects.Length; i++){
			if(statusEffects[i].duration == 0){
				removeStatusEffect(statusEffects[i].name);
				statusEffects [i].name = "none";
			}
		}
	}


	//looks at name and applies change
	void applyStatusEffect(string name){
		switch(name){
		case "stun":
			// check during plan and skip if stunned
			// remember we can check a player's statusEffects anywhere
			break;
		case "debuff":
				this.attack = Math.Floor(0.75 * this.attack);
			break;
		case "buff":
				this.attack = Math.Floor(1.25 * this.attack);
			break;
		case "unsteady":
				this.dodge = Math.Floor(0.66 * this.dodge);//or however we check dodge;
			break;
		case "steady":
				this.dodge = Math.Floor(1.33 * this.dodge);//or however we check dodge;
			break;
		case "halfDmg":
				break;
		case "moreDmg":
				break;
		case "confused":
				// check during plan and randomly choose target
				// remember we can check a player's statusEffects anywhere
				break;
		}
	}

	void removeStatusEffect(string name){
		switch(name){
		case "stun":
			// check during plan and skip if stunned
			// remember we can check a player's statusEffects anywhere
			break;
		case "debuff":
				this.attack = Math.Floor(1.35 * this.attack);
			break;
		case "buff":
				this.attack = Math.Floor(0.8 * this.attack);
			break;
		case "unsteady":
				this.dodge *= 1.33;//or however we check dodge;
			break;
		case "steady":
				this.dodge *= .66;//or however we check dodge;
			break;
		case "halfDmg":
				break;
		case "moreDmg":
				break;   
		case "confused":
				break;
		}
	}

	// Currently the character is still catching if they weren't targeted in the last round
	public virtual int catchBall(Character attacker)
	{
		if ((UnityEngine.Random.Range (1, 100) + UnityEngine.Random.Range (1, 100) / 2) < this.Catch) 
		{ // you can catch it
			if (this.heldBalls < Capacity) 
			{
				this.heldBalls++;
			}
			return 1;
		}
		return 0;
	}


	public bool dodgeBall(Character attacker)
	{
		/*
		if ((Random.Range (1, 100) + Random.Range (1, 100) / 2) < (this.Stamina/this.maxStamina) * 100) 
		{//dodge success
			loseStamina (attacker.Damage);
			return true;
		} 
		else 
		{*/
		if (this.Stamina <= 0) {
			this.dead = true; 
		}
		loseStamina (attacker.Damage);//attacker.Damage);
		//}
		return false;
	}

	public int throwBall(Character target)
	{
		heldBalls--;
		target.dodgeBall (this);
		return 0;
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


	public virtual void Skill1(Character target){

    }

    public virtual void Skill2(){

    }

    public virtual void Skill3(){

    }

    public void Skill4(){

    }
}
