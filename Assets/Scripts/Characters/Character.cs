using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    public AudioScript Audio;
    public CombatManager combat;
	public CharacterSelectUI CSUI;

    public string Name = "default";
	public int Damage = 10;
    public int Catch = 100;
    public int Gather = 1;
    public int Stamina = 100;
	public int maxStamina = 100;
    public int heldBalls = 0;
    public int maxBalls = 4;
    public int Level = 1;
	public float attackMultiplier = 1.0f;
	public float defenseMultiplier = 1.0f;

    public string Role = "Supporter";
	public Character[] Target = new Character[3]; //Create an empty Character in the combat manager that other charaters can select when not targetting
	public string action = "None";
	public string actionType = "None"; //Offense, Defense, Utility
	public int targetingType = 0; //0 for self/predetermined, 1 for enemies, 2 for allies

    //allegiance 1 is for the players, 2 is for enemies. It is there so we can have players switch teams. 
    public int allegiance = 1;
    //allies of someone on allegiance 1 (player team) would be Player[0,1,2]
    //allies of someone on allegiance 2 (enemy team) would be Enemy[0,1,2]
    public Character [] allies = new Character[3];
    //enemies of someone on allegiance 1 (player team) would be Enemy[0,1,2]
    //enemies of someone on allegiance 2 (enemy team) would be Player[0,1,2]
    public Character [] enemies = new Character[3];
    //these arrays are set in Start()

    public double attack;
	public double dodge;
	//Following 3 arrays are paired, so when an action is selected it can look at the same index
	//of the different arrays and set the corresponding variable to the array value

	// I changed these from private to protected, this is important for Character derived classes
	public string[] actions = {"None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
	public string[] actionNames = { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
    public string[] actionDescription = { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "", "", "", "", "" };
    public string[] actionTypes = { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };

    //These are to dictate who each ability can target: 0 for none or predetermined, 1 for Enemy[], 2 for Player[]
    //default is for what you would expect, alternate is if they switched teams. 
    //IE: Shiro's throw is default to enemies if you were to put Shiro on team two, 
    // she would need to now throw at team 1, which in CombatManager, is Player[], which as shown above ^ is the Player[]
    //This is because the current state makes it so Shiro,Clemence and Theodore must be the Player[] and all others must be on Enemy[]
    // or else they will do their actions on the wrong team.
    /* This change allows characters to be on whatever team they want*/
    protected int[]    defaultTargetingTypes = { 0, 1, 0, 0, 0, 0, 0, 0 };
    protected int[] alternateTargetingTypes = { 0, 2, 0, 0, 0, 0, 0, 0 };
    //depending on their allegiance, targeting types will be assigned to default or alternate within start
    public  int[] targetingTypes;

    //How many balls does each action cost?
	public int[]    actionCosts = { 0, 1, 0, 0, 0, 0, 0, 0 };
    //How many turns is the cooldown of each action?
    public int[] actionCooldowns = { 0, 0, 0, 0, 0, 0, 0, 0 };

	public bool dead = false;
	public bool catching = false;


	public void loseStamina(int staminaLoss) 
	{
        AudioScript.playStaticSFX("_SFX/Battle sfx/miss/miss_1");
		this.Stamina -= staminaLoss; 
		if(this.Stamina < 0)
		{
			this.Stamina = 0;
            this.dead = true;
		}
	}
    public void gainStamina(int staminaGain) 
	{ 
		this.Stamina += staminaGain; 
		if(this.Stamina > maxStamina)
		{
			this.Stamina = maxStamina;
		}
	}
	public string GetAction(int index){return this.actions [index];}
	public string GetActionName(int index){return this.actionNames [index];}
	public string GetActionType(int index){return this.actionTypes [index];}
	public int GetTargetingType(int index){return this.defaultTargetingTypes [index];}
	public int GetActionCost(int index){return this.actionCosts [index];}
	public struct status {
		public string name;
		public int duration;
	}
		
	//status effects should both be checked before actions are chosen for a character and ALSO when they are about to execute an action. This is because some status effects affect your ability to choose actions but moves may change status effects during combat. Prime example is stun.  


	//New function called addStatusEffect() should be added in that serves to handle adding multiple status effects. 
	//Conversely there is also a new Function called removeDoneStatusEffects() that is called at the end of your action that serves to remove all status effects that are over. 
	//There is also a applyStatusEffect() and removeStatusEffect() function that serves to add or remove one status effect chosen. Here is where the actual effects are applied to the player. apply should add the numerical effects, remove should reverse that

	//Characters also have a statusEffects array of status structs 6 long. This serves to hold all status effects you can have. EX. status statusEffects[6];
	// changed this to public because I need access to it's length
	public status[] statusEffects;// = new status[6];

    protected void Start() {
		Stamina = maxStamina;
		Target = new Character[3];
		for(int i = 0; i < 3; i++)
		{
			Target [i] = this;
		}
		statusEffects = new status[3];
		for(int i = 0; i < 3; i++)
		{
			statusEffects [i].duration = 0;
			statusEffects [i].name = "none";
		}

        //allegiance of 1 is to the player controlled team. The allies and the enemies 
        //array now refer to your teammates and the other teams respectively. This is 
        //done beacuse the Player[] and Enemy[] are absolute, but allies and enemies
        //can be relative. That is: Enemy[1] will always be the same, but enemies[1] 
        //will be the Player[1] if you have allegiance 2 (ie on team 2, aiming at team 1)
        //and will be Enemy [1] if you have allegiance 1 (ie on team 1, aiming at team 2)
        combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        Audio = GameObject.Find("AudioManager").GetComponent<AudioScript>();

        /*
        if (allegiance == 1) { 
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            allies = combat.Enemy;
            enemies = combat.Player;
        } */
    }

    protected void Update()
	{
		if(dead)
		{
			if(this.tag == "Player")
			{
				gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 90f);
			}
			else
			{
				gameObject.transform.eulerAngles = new Vector3 (0f, 0f, -90f);
			}
		}
		else
		{
			gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
		}
	}
	public virtual void Init(CombatManager CM, CharacterSelectUI combatUI)
	{
		this.combat = CM;
		this.CSUI = combatUI;	
	}


    //In decendant classes, update is used to set the allies,enemies,and targettingType arrays
    // to their proper values.
    //NOTE: AS SHIRO, CLEMENCE,AND THEODORE ARE PLAYERS BY DEFAULT, THEIR DEFAULT TARGETTING IS AIMED TOWARDS
    //ENEMIES, WHEREAS EVERYONE ELSE'S DEFAULT TARGETTING TYPE IS SET TO THE PLAYERS AS THEY ARE USUALLY THE ENEMY TEAM
    //IE: Shiro, Clemence, and Theodore have it look reversed. That is on purpose



    //here to swap teams in case we need it
    public void changeAllegiance() {
        Character[] temp = new Character[3];
        temp = this.enemies;
        this.enemies = this.allies;
        this.allies = temp;
    }



	public void addStatusEffect(string name, int duration){
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
				return;
			}
		}
	}

	//called at the end of your turn
	// Changed this to public, not public in other versions
	public void removeDoneStatusEffects(){
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
			CSUI.AddStatus(0);
			break;
		case "debuff":
			if (findStatus ("buff") != -1) {
				statusEffects [findStatus ("buff")].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect ("buff");
			}
			this.attackMultiplier = .75f;
			CSUI.AddStatus(1);
			break;
		case "buff":
			if (findStatus ("debuff") != -1) {
				statusEffects [findStatus ("debuff")].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect ("debuff");
			}
			this.attackMultiplier = 1.25f;
			CSUI.AddStatus(2);
			break;
		case "steady":
			if(findStatus("unsteady") != -1)
			{
				statusEffects [findStatus ("unsteady")].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect ("unsteady");
			}
			this.defenseMultiplier = 1.25f;
			CSUI.AddStatus(3);
			break;
		case "unsteady":
			if(findStatus("steady") != -1)
			{
				statusEffects [findStatus ("steady")].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect ("steady");
			}
			this.defenseMultiplier = 0.75f;
			CSUI.AddStatus(4);
			break;
		case "halfDmg":
			break;
		case "moreDmg":
				break;
		case "confused":
				// check during plan and randomly choose target
				// remember we can check a player's statusEffects anywhere
				break;
		case "misc":
			// This is used to check for multiturn logic
			CSUI.AddStatus(5);
			break;
		}
	}

	public void removeStatusEffect(string name){
		switch(name){
		case "stun":
			CSUI.RemoveStatus (0);
			// check during plan and skip if stunned
			// remember we can check a player's statusEffects anywhere
			break;
		case "debuff":
			CSUI.RemoveStatus (1);
			this.attack = Math.Floor (1.35 * this.attack);
			this.attackMultiplier = 1.0f;
			break;
		case "buff":
			CSUI.RemoveStatus (2);
			this.attack = Math.Floor (0.8 * this.attack);
			this.attackMultiplier = 1.0f;
			break;
		case "unsteady":
			CSUI.RemoveStatus (3);
			this.defenseMultiplier = 1.0f;
			break;
		case "steady":
			CSUI.RemoveStatus (4);
			this.defenseMultiplier = 1.0f;
			break;
		case "halfDmg":
				break;
		case "moreDmg":
				break;   
		case "confused":
				break;
		case "misc":
			CSUI.RemoveStatus (5);
			break;
		}
	}


	// I added this function, it is not in the character file normally
	public int findStatus(string effect)
	{
		for (int i = 0; i < statusEffects.Length; i++) 
		{
			if(statusEffects[i].name == effect)
			{
				return i;
			}
		}
		return -1;
	}


	// Currently the character is still catching if they weren't targeted in the last round
	public virtual bool catchBall(Character attacker)
	{
		if(catching)
		{
			catching = false;
			if ((UnityEngine.Random.Range (1, 100) + UnityEngine.Random.Range (1, 100) / 2) < this.Catch) 
			{ // you can catch it
				if (this.heldBalls < maxBalls) 
				{
					this.heldBalls++;
				}
				return true;
			}
		}
		return false;
	}


    public bool dodgeBall(Character attacker) {
        if (this.Stamina <= this.maxStamina/4) {
            if (UnityEngine.Random.Range(1, this.maxStamina / 4) < 5) {
                this.dead = true;
                print("Dodgeball hit " + this.name +" taking them out of the game!!!");
            }
            print("Dodgeball narrowly missed " + this.name + "!!!");
        }
        return false;
    }

	public int throwBall(Character target)
	{
		int damage = 0;
        Audio.playDelayedSFX("_SFX/Battle sfx/swoosh/swoosh", 2);
		this.heldBalls--;
		float variance = UnityEngine.Random.Range(0.8f, 1.2f);
		target.dodgeBall (this);
		damage = (int)(this.Damage * variance * attackMultiplier * target.defenseMultiplier);
		target.loseStamina(damage);
		return damage;
	}

    public void Rest()
	{
		this.gainStamina (Gather * 2);
    }


	public void gatherBall()
	{
		heldBalls += Gather;
		if(heldBalls > maxBalls)
		{
			heldBalls = maxBalls;
		}
	}


	public virtual int Skill1(){
		return 0;
    }

    public virtual int Skill2(){
		return 0;
    }

    public virtual int Skill3(){
		return 0;
    }

    public virtual int Skill4(){
		return 0;
    }

	public void CallTell()
	{
		CSUI.ShowTell (this.actionType);
	}

	public virtual void cleanUp()
	{
		catching = false;
		removeDoneStatusEffects ();
		for (int i = 0; i < this.statusEffects.Length; i++) 
		{
			if (this.statusEffects [i].duration > 0) 
			{
				this.statusEffects [i].duration--;
			}
		}
		this.action = "None";
		this.actionType = "None";

		for (int i = 0; i < 3; i++) 
		{
			this.Target [i] = this;
		}

		for (int i = 0; i < this.actionCooldowns.Length; i++) 
		{
			if (this.actionCooldowns [i] > 0) 
			{
				this.actionCooldowns [i]--;
			}
		}

		CSUI.ShowTell ("None");
	}
   
       public void LevelUp(int number) {
        float variance;
        for (int i = 0; i < number; i++) {
            this.Level++;
            if (this.Level < 5) { variance = UnityEngine.Random.Range(0, 5);} else{variance = UnityEngine.Random.Range(4, 9);}
            this.maxStamina = (int)((this.maxStamina * 1.1) + variance);
            this.Stamina = this.maxStamina;
            this.Damage = (int)((this.Damage * 1.1) + UnityEngine.Random.Range(0, 2));
            if (this.Level % 2 == 0 || this.Level % 3 == 0) this.maxBalls += 2;
            this.heldBalls = this.maxBalls;
        }
    }
}
