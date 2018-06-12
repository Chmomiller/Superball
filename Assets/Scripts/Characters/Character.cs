using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using System;

public class Character : MonoBehaviour
{
	public enum STATUS{NONE, STUN, BUFF, DEBUFF, STEADY, UNSTEADY, MISC}

    public AudioScript Audio;
    public CombatManager combat;
	public CharacterSelectUI CSUI;
	public PlayableDirector characterDirector;
	public TimelineAsset[] characterAnims;
	public GameObject damageText;

    public string Name = "default";
	public int Damage = 10;
    public int Gather = 1;
    public int Stamina = 100;
	public int maxStamina = 100;
    public int heldBalls = 0;
    public int maxBalls = 4;
    public int Level = 1;
	public float attackMultiplier = 1.0f;
	public float defenseMultiplier = 1.0f;
    public int Experience = 0;

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

	//Following 3 arrays are paired, so when an action is selected it can look at the same index
	//of the different arrays and set the corresponding variable to the array value

	// I changed these from private to protected, this is important for Character derived classes
	public string[] actions = {"None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
	public string[] actionNames = { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
    public string[] actionDescription = { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "", "", "", "", "" };
    public string[] actionTypes = { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };

    // These determine skill targets: 
	// 0: Targets none or predetermined
	// 1: Targets enemies
	// 2: Targets allies
    protected int[]    defaultTargetingTypes = { 0, 1, 0, 0, 0, 0, 0, 0 };
    //depending on their allegiance, targeting types will be assigned to default or alternate within start
    public  int[] targetingTypes;

    //How many balls does each action cost?
	public int[]    actionCosts = { 0, 1, 0, 0, 0, 0, 0, 0 };
    //How many turns is the cooldown of each action?
    public int[] actionCooldowns = { 0, 0, 0, 0, 0, 0, 0, 0 };

	public bool dead = false;
	public bool catching = false;

	public GameObject dodgeball;

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
			statusEffects [i].name = STATUS.NONE;
		}
			
		characterDirector = gameObject.GetComponentInChildren<PlayableDirector> ();
		combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
		Audio = GameObject.Find("AudioManager").GetComponent<AudioScript>();
	}

	public virtual void Init(CombatManager CM, CharacterSelectUI combatUI)
	{
		this.combat = CM;
		this.CSUI = combatUI;	
	}

	public void loseStamina(int staminaLoss) 
	{
        AudioScript.playStaticSFX("_SFX/Battle sfx/miss/miss_1");
		GameObject DT = Instantiate (damageText);
		DT.GetComponent<DamageTextScript> ().speed = .075f;
		DT.transform.SetParent (CSUI.transform);
		DT.transform.position = CSUI.transform.position;
		DT.transform.localScale = new Vector3 (1f, 1f, 1f);
		DT.GetComponent<Text> ().text = "-"+staminaLoss;

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
		public STATUS name;
		public int duration;
	}
		
	//status effects should both be checked before actions are chosen for a character and ALSO when they are about to execute an action. This is because some status effects affect your ability to choose actions but moves may change status effects during combat. Prime example is stun.  


	//New function called addStatusEffect() should be added in that serves to handle adding multiple status effects. 
	//Conversely there is also a new Function called removeDoneStatusEffects() that is called at the end of your action that serves to remove all status effects that are over. 
	//There is also a applyStatusEffect() and removeStatusEffect() function that serves to add or remove one status effect chosen. Here is where the actual effects are applied to the player. apply should add the numerical effects, remove should reverse that

	//Characters also have a statusEffects array of status structs 6 long. This serves to hold all status effects you can have. EX. status statusEffects[6];
	// changed this to public because I need access to it's length
	public status[] statusEffects;// = new status[6];

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




    //In decendant classes, update is used to set the allies,enemies,and targettingType arrays
    // to their proper values.

    //here to swap teams in case we need it
    public void changeAllegiance() {
        Character[] temp = new Character[3];
        temp = this.enemies;
        this.enemies = this.allies;
        this.allies = temp;
    }



	public void addStatusEffect(STATUS name, int duration){
		for(int i =0; i<statusEffects.Length; i++){
			//refresh status effect of same name;
			if(statusEffects[i].name == name && statusEffects[i].duration < duration){
				statusEffects[i].duration = duration;
			}
			//slot is empty
			if(statusEffects[i].name == STATUS.NONE){
				statusEffects[i].name = name;
				statusEffects[i].duration = duration;
				applyStatusEffect(name);
				return;
			}
		}
	}
		
	public void removeDoneStatusEffects(){
		for(int i =0; i<statusEffects.Length; i++){
			if(statusEffects[i].duration <= 0){
				removeStatusEffect(statusEffects[i].name);
				statusEffects [i].name = STATUS.NONE;
			}
		}
	}


	//looks at name and applies change
	void applyStatusEffect(STATUS name){
		switch(name){
		case STATUS.STUN:
			// check during plan/execution and skip if stunned
			CSUI.AddStatus(0);
			break;
		case STATUS.BUFF:
			if (findStatus (STATUS.DEBUFF) != -1) {
				statusEffects [findStatus (STATUS.DEBUFF)].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect (STATUS.DEBUFF);
			}
			this.attackMultiplier = 1.25f;
			CSUI.AddStatus(1);
			break;
		case STATUS.DEBUFF:
			if (findStatus (STATUS.DEBUFF) != -1) {
				statusEffects [findStatus (STATUS.DEBUFF)].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect (STATUS.DEBUFF);
			}
			this.attackMultiplier = .75f;
			CSUI.AddStatus(2);
			break;
		case STATUS.STEADY:
			if(findStatus(STATUS.UNSTEADY) != -1)
			{
				statusEffects [findStatus (STATUS.UNSTEADY)].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect (STATUS.UNSTEADY);
			}
			this.defenseMultiplier = 1.25f;
			CSUI.AddStatus(3);
			break;
		case STATUS.UNSTEADY:
			if(findStatus(STATUS.STEADY) != -1)
			{
				statusEffects [findStatus (STATUS.STEADY)].duration = 0;
				removeDoneStatusEffects ();
				removeStatusEffect (STATUS.STEADY);
			}
			this.defenseMultiplier = 0.75f;
			CSUI.AddStatus(4);
			break;
		case STATUS.MISC:
			// This is used to check for multiturn logic
			CSUI.AddStatus(5);
			break;
		//case "confused":
				// check during plan and randomly choose target
				//break;
		}
	}

	public void removeStatusEffect(STATUS name){
		switch(name){
		case STATUS.STUN:
			CSUI.RemoveStatus (0);
			// check during plan and skip if stunned
			// remember we can check a player's statusEffects anywhere
			break;
		case STATUS.BUFF:
			CSUI.RemoveStatus (1);
			this.attackMultiplier = 1.0f;
			break;
		case STATUS.DEBUFF:
			CSUI.RemoveStatus (2);
			this.attackMultiplier = 1.0f;
			break;
		case STATUS.STEADY:
			CSUI.RemoveStatus (3);
			this.defenseMultiplier = 1.0f;
			break;
		case STATUS.UNSTEADY:
			CSUI.RemoveStatus (4);
			this.defenseMultiplier = 1.0f;
			break;
		//case "confused":
		//		break;
		case STATUS.MISC:
			CSUI.RemoveStatus (5);
			break;
		}
	}


	// I added this function, it is not in the character file normally
	public int findStatus(STATUS effect)
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
			if ((UnityEngine.Random.Range (1, 100) + UnityEngine.Random.Range (1, 100) / 2) < 100) 
			{ // you can catch it
				if (this.heldBalls < maxBalls) 
				{
					this.heldBalls++;
				}
				playThrow ();

				return true;
			}
		}
		return false;
	}


    public bool dodgeBall(Character attacker) {
        if (this.Stamina <= this.maxStamina/4) {
            if (UnityEngine.Random.Range(1, this.maxStamina / 4) < 5) {
                this.dead = true;
            }
        }
		if(!dead)
		{
			playDodge ();
		}
        return false;
    }

	public int throwBall(Character target)
	{
		GameObject DB = Instantiate (dodgeball, gameObject.transform.position, Quaternion.identity);
		/*DB.transform.position = new Vector3 (DB.transform.position.x, 
											 DB.transform.position.y, 
											 0f);*/
		DB.transform.localScale = new Vector3(.125f, .125f, 1f);
		DB.GetComponent<Dodgeball> ().target = target;
		playThrow ();
        Audio.playDelayedSFX("_SFX/Battle sfx/swoosh/swoosh", 2);

		int damage = 0;
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
   
	public void playDodge()
	{
		characterDirector.Play (characterAnims[0]);
	}

	public void playThrow()
	{
		characterDirector.Play (characterAnims[1]);
	}

    public void gainExperience(int exp) {
        this.Experience += exp;
        this.LevelUp( (int)(this.Experience / 100) );
        this.Experience = this.Experience % 100;
    }

    public void LevelUp(int number) {
        float variance;
        for (int i = 0; i < number; i++) {
            this.Level++;
            if (this.Level < 5) { variance = UnityEngine.Random.Range(0, 2);} else{variance = UnityEngine.Random.Range(3, 5);}
            this.maxStamina = (int)((this.maxStamina * 1.1) + variance);
            this.Damage = (int)((this.Damage * 1.1) + UnityEngine.Random.Range(0, 1));
            if (this.Level % 2 == 0 || this.Level % 3 == 0) this.maxBalls += 2;
            this.heldBalls = this.maxBalls;
        }
    }

	public virtual void ResetChar()
	{
		Name = "default";
		Damage = 10;
		Gather = 1;
		Stamina = 100;
		maxStamina = 100;
		heldBalls = 0;
		maxBalls = 4;
		Level = 1;
		Experience = 0;
	}
}
