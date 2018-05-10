using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour 
{
	// This script has been modified to be used by CombatManager once per enemy action


	public Character[] Player;
	public Character[] Enemy;

	void Start () 
	{
        Player = new Character[3];
		Enemy = new Character[3];

		for(int i = 0; i < 3; i++)
		{
			Player [i] = GameObject.Find ("Character" + (i)).GetComponent<Character>();
			Enemy [i] = GameObject.Find ("Character" + (i + 3)).GetComponent<Character>();
		}
	}

    Character chooseRandomAlly(Character character) { //takes in a Character, allowing some tweaks to be made in the invoking function to allow the AI to play both sides
		Character choice;
		do { //choose non dead ally
			choice = Player[UnityEngine.Random.Range (0, 3)];
		} while (!choice.dead);
		for(int i = 0; i < 3; i++)
		{
			character.Target [i] = choice;
		}
        return choice;
    }

    Character chooseRandomEnemy(Character character) { //takes in a Character, allowing some tweaks to be made in the invoking function to allow the AI to play both sides
		Character choice; 
		Character[] choices = new Character[2];
		int count = 0;
		for(int i = 0; i < 3; i++)
		{
			if(Enemy[i] != character && !Enemy[i].dead)
			{
				choices [count] = Enemy [i];
				count++;
			}
		}
		if(count > 0)
		{
			choice = choices[UnityEngine.Random.Range(0, choices.Length)];
        }
		else
		{
			choice = character;
		}
		for(int i = 0; i < 3; i++)
		{
			character.Target [i] = choice;
		}
        return choice;
    }


	public void FullRandomAI(Character actor) {// Enemy will go full random
		int choice = 0;
		while (actor.action == "None") {
			
			choice = UnityEngine.Random.Range (1, 8); //choose random skill that isnt None
			if (actor.actionCooldowns [choice] == 0 && actor.heldBalls >= actor.actionCosts [choice]) {//if it isnt on cooldown
				actor.action = actor.actions [choice];
				actor.actionType = actor.actionTypes [choice];
				break;
			}
		}
		Character target;
		if (actor.GetTargetingType (choice) == 1) 
		{
			chooseRandomAlly (actor);
		}
		else if (actor.GetTargetingType (choice) == 2)
		{
			chooseRandomEnemy (actor);
		}
		else
		{
			for(int i = 0; i < 3; i++)
			{
				actor.Target [i] = actor;
			}
		}

    }


	void SkillsAI(Character actor) { //choose first action not on cooldown and do it. If all are on cooldown, just throwS
		Character target = actor;
		for (int i = 4; i < actor.actionNames.Length; i++) { //actor
			if (actor.actionNames[i] != "Skill"+(i-3)) {
                if (actor.actionCooldowns[i] == 0 && actor.heldBalls >= actor.actionCosts[i]) {
                    actor.action = actor.actions[i];
                    actor.actionType = actor.actionTypes[i];
                    //find your target if the ability needs one
					if (actor.GetTargetingType(i) == 1) 
					{
						chooseRandomEnemy(actor);
					} 
					else if (actor.GetTargetingType(i) == 2) 
					{
						chooseRandomAlly(actor);
					}
					else 
					{
						for(int j = 0; j < 3; j++)
						{
							actor.Target [j] = target;
						}
					}
                    break;
                }
            }
        }
		if(actor.action == "None" && actor.heldBalls > 0) {
            actor.action = "Throw";
			actor.actionType = "Offense";
			chooseRandomAlly (actor);
        }
		else
		{
			actor.action = "Catch";
			actor.actionType = "Defense";
			for(int i = 0; i < 3; i++)
			{
				actor.Target[i] = actor;
			}
		}
	
    }


	void RoleAI(Character actor) { //Catches want to do defensive skills, Throwers offensive, supporters utility

    	if (actor.Role == "Thrower") {
			for (int k = 4; k < actor.actions.Length; k++) { //for all your skills
                    if (actor.actions[k] != "") {
					if (actor.actionCooldowns [k] == 0 && actor.actionTypes [k] == "Offense" && actor.heldBalls >= actor.actionCosts [k]) { //if skill has no cooldown and is offensive
						actor.action = actor.actions [k];
						actor.actionType = "Offense";

						if (actor.GetTargetingType (k) == 1)
							chooseRandomAlly (actor);
						else if (actor.GetTargetingType (k) == 2)
							chooseRandomEnemy (actor);
						else
						{
							for (int i = 0; i < 3; i++) 
							{
								actor.Target [i] = actor;
							}
						}
                            break;
                        }
                    }
                }
			if (actor.action == "None" && actor.heldBalls > 0) {
                actor.action = "Throw";
				actor.actionType = "Offense";
				chooseRandomEnemy(actor); //throw always needs an enemy target
                }
			else if (actor.action == "None")
			{
				actor.action = "Catch";
				actor.actionType = "Defense";
				for(int i = 0; i < 3; i++)
				{
					actor.Target [i] = actor;
				}
			}

            } else if (actor.Role == "Catcher") {
			for (int k = 4; k < actor.actions.Length; k++) { //for all your skills
				if (actor.actions[k] != "") {
					if (actor.actionCooldowns[k] == 0 && actor.actionTypes[k] == "Defense" && actor.heldBalls >= actor.actionCosts[k]) { //if skill has no cooldown and is offensive
						actor.action = actor.actions[k];
						actor.actionType = "Defense";

						if (actor.GetTargetingType(k) == 1) chooseRandomAlly(actor);
						if (actor.GetTargetingType(k) == 2) chooseRandomEnemy(actor);
						else
						{
							for (int i = 0; i < 3; i++) 
							{
								actor.Target [i] = actor;
							}
						}
						break;
					}
				}
			}
			if (actor.action == "None" && actor.heldBalls > 0) {
				if(Random.Range(0f,100f) < 50f)
				{
					actor.action = "Catch";
					actor.actionType = "Defense";
					for (int i = 0; i < 3; i++) 
					{
						actor.Target [i] = actor;
					}
				}
				else
				{
					actor.action = "Throw";
					actor.actionType = "Offense";
					chooseRandomEnemy(actor); //throw always needs an enemy target
				}

			}


            } else if (actor.Role == "Supporter") {
			for (int k = 4; k < actor.actions.Length; k++) { //for all your skills
				if (actor.actions[k] != "") {
					if (actor.actionCooldowns [k] == 0 && actor.actionTypes [k] == "Utility" && actor.heldBalls >= actor.actionCosts [k]) { //if skill has no cooldown and is offensive
						actor.action = actor.actions [k];
						actor.actionType = "Utility";

						if (actor.GetTargetingType (k) == 1)
							chooseRandomAlly (actor);
						else if (actor.GetTargetingType (k) == 2)
							chooseRandomEnemy (actor);
						else
						{
							for (int i = 0; i < 3; i++) 
							{
								actor.Target [i] = actor;
							}
						}
						break;
					}
				}
			}
			if (actor.action == "None" && actor.heldBalls > 0) {
				actor.action = "Throw";
				actor.actionType = "Offense";
				chooseRandomEnemy(actor); //throw always needs an enemy target
			}
			else if (actor.action == "None")
			{
				actor.action = "Catch";
				actor.actionType = "Defense";
				for(int i = 0; i < 3; i++)
				{
					actor.Target [i] = actor;
				}
			}
            } else { 
                print("CRITICAL ERROR\n" + 
					  "EnemyAI.cs: enemy has invalid Role\n" + 
					  "CRITICAL ERROR");
            }//end enemy role if's
				
    }//end Role AI


	void SchoolAI(Character actor) {//different schools have different stratetegeis

		// Salt Pitt Crew
        if (SceneManager.GetActiveScene().name == "Salt Pitt High Gym") {
			RoleAI (actor);
                //end Salt Pitt Crew role if's

        } else if (SceneManager.GetActiveScene().name == "Schola Grandis Gym") {
			RoleAI (actor);
        } else if (SceneManager.GetActiveScene().name == "MightMain Academy Gym") {
			RoleAI (actor);
        } else if (SceneManager.GetActiveScene().name == "Yamato Battle") {
			RoleAI (actor);
        } else {

        }

    }//end SchoolAI()

}// end class enemyAI.cs
