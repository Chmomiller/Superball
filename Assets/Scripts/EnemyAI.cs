using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour 
{



	public Character[] Player;
	public Character[] Enemy;
    CombatManager combat;

	void Start () 
	{
        CombatManager combat = GameObject.Find("Combat Manager").GetComponent<CombatManager>();
		Player = new Character[3];
		Enemy = new Character[3];

		for(int i = 0; i < 3; i++)
		{
			Player [i] = GameObject.Find ("Player" + (i + 1)).GetComponent<Character>();
			Enemy [i] = GameObject.Find ("Enemy" + (i + 1)).GetComponent<Character>();

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    Character chooseRandomAlly(Character character) { //takes in a Character, allowing some tweaks to be made in the invoking function to allow the AI to play both sides
        Character choice = new Character();
        choice.dead = true;
        while (choice.dead == true) { //choose non dead ally
            choice = character.allies[UnityEngine.Random.Range(0, 2)];
        }
        return choice;
    }

    Character chooseRandomEnemy(Character character) { //takes in a Character, allowing some tweaks to be made in the invoking function to allow the AI to play both sides
        Character choice = new Character();
        choice.dead = true;
        while (choice.dead == true) { //choose non dead ally
            choice = character.enemies[UnityEngine.Random.Range(0, 2)];
        }
        return choice;
    }


    void FullRandomAI() {// Enemy will go full random
        int choice = 0;
        for(int i = 0; i< 3; i++) {
            while (combat.Enemy[i].action == "None") {
                choice = UnityEngine.Random.Range(1, 8); //choose random skill that isnt None
                if (combat.Enemy[0].actionCooldowns[i] == 0 && combat.Enemy[0].heldBalls >= combat.Enemy[0].actionCosts[i]){//if it isnt on cooldown
                    combat.Enemy[0].action = combat.Enemy[0].actions[i];
                    combat.Enemy[0].actionType = combat.Enemy[0].actionTypes[i];
                    break;
                }

            }
            if (combat.Enemy[0].GetTargetingType(i) == 1) combat.Enemy[0].Target[0] = chooseRandomEnemy(Enemy[0]);
            if (combat.Enemy[0].GetTargetingType(i) == 2) combat.Enemy[0].Target[0] = chooseRandomAlly(Enemy[0]);
        }
    }


    void SkillsAI() { //choose first action not on cooldown and do it. If all are on cooldown, just throw
        for (int i = 3; i < 5; i++) { //combat.Enemy[0]
            if (combat.Enemy[0].actions[i] != "") {
                if (combat.Enemy[0].actionCooldowns[i] == 0 && combat.Enemy[0].heldBalls >= combat.Enemy[0].actionCosts[i]) {
                    combat.Enemy[0].action = combat.Enemy[0].actions[i];
                    combat.Enemy[0].actionType = combat.Enemy[0].actionTypes[i];
                    //find your target if the ability needs one
                    if (combat.Enemy[0].GetTargetingType(i) == 1) combat.Enemy[0].Target[0] = chooseRandomEnemy(Enemy[0]); 
                    if (combat.Enemy[0].GetTargetingType(i) == 2) combat.Enemy[0].Target[0] = chooseRandomAlly(Enemy[0]);
                    break;
                }
            }
        }
        if(combat.Enemy[0].action == "None") {
            combat.Enemy[0].action = "Throw";

        }

        for (int i = 3; i < 5; i++) {//combat.Enemy[1]
            if (combat.Enemy[1].actions[i] != "") {
                if (combat.Enemy[1].actionCooldowns[i] == 0 && combat.Enemy[1].heldBalls >= combat.Enemy[1].actionCosts[i]) {
                    combat.Enemy[1].action = combat.Enemy[1].actions[i];
                    combat.Enemy[1].actionType = combat.Enemy[1].actionTypes[i];

                    if (combat.Enemy[1].GetTargetingType(i) == 1) combat.Enemy[1].Target[0] = chooseRandomEnemy(Enemy[1]);
                    if (combat.Enemy[1].GetTargetingType(i) == 2) combat.Enemy[1].Target[0] = chooseRandomAlly(Enemy[1]);
                    break;
                }
            }
        }
        if (combat.Enemy[1].action == "None") {
            combat.Enemy[1].action = "Throw";
        }

        for (int i = 3; i < 5; i++) {//combat.Enemy[2]
            if (combat.Enemy[2].actions[i] != "") {
                if (combat.Enemy[2].actionCooldowns[i] == 0 && combat.Enemy[2].heldBalls >= combat.Enemy[2].actionCosts[i]) {
                    combat.Enemy[2].action = combat.Enemy[2].actions[i];
                    combat.Enemy[2].actionType = combat.Enemy[2].actionTypes[i];

                    if (combat.Enemy[2].GetTargetingType(i) == 1) combat.Enemy[2].Target[0] = chooseRandomEnemy(Enemy[2]);
                    if (combat.Enemy[2].GetTargetingType(i) == 2) combat.Enemy[2].Target[0] = chooseRandomAlly(Enemy[2]);
                    break;
                }
            }
        }
        if (combat.Enemy[2].action == "None") {
            combat.Enemy[2].action = "Throw";
        }

    }


    void RoleAI() { //Catches want to do defensive skills, Throwers offensive, supporters utility
        for (int i = 0; i < 3; i++) { //for all enemies
            if (combat.Enemy[i].Role == "Thrower") {
                for (int k = 3; k < 5; k++) { //for all your skills
                    if (combat.Enemy[i].actions[k] != "") {
                        if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Offensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                            combat.Enemy[i].action = combat.Enemy[i].actions[k];
                            combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                            if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                            if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                            break;
                        }
                    }
                }
                if (combat.Enemy[i].action == "None") {
                    combat.Enemy[i].action = "Throw";
                    combat.Enemy[0].Target[0] = chooseRandomEnemy(Enemy[0]); //throw always needs an enemy target
                }


            } else if (combat.Enemy[i].Role == "Catcher") {
                for (int k = 3; k < 5; k++) { //for all your skills
                    if (combat.Enemy[i].actions[k] != "") {
                        if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Defensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                            combat.Enemy[i].action = combat.Enemy[i].actions[k];
                            combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                            if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                            if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                            break;
                        }
                    }
                }
                if (combat.Enemy[i].action == "None") {
                    combat.Enemy[i].action = "Catch";
                    combat.Enemy[i].Target[0] = Enemy[i];
                }


            } else if (combat.Enemy[i].Role == "Supporter") {
                for (int k = 3; k < 5; k++) { //for all your skills
                    if (combat.Enemy[i].actions[k] != "") {
                        if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Utility" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                            combat.Enemy[i].action = combat.Enemy[i].actions[k];
                            combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];
                            if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                            if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                            break;
                        }
                    }

                }
                if (combat.Enemy[i].action == "None") {
                    combat.Enemy[i].action = "Gather";
                }
                

            } else { 
                print("CRITICAL ERROR");
                print("EnemyAI.cs: enemy has invalid Role");
                print("CRITICAL ERROR");
            }//end enemy role if's

        }//end for all enemies loop
    }//end Role AI



    void SchoolAI() {//different schools have different stratetegeis

        if (SceneManager.GetActiveScene().name == "Salt Pitt High Gym") {
            for (int i = 0; i < 3; i++) { //for all enemies
                if (combat.Enemy[i].Role == "Thrower") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Offensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Throw";
                        combat.Enemy[0].Target[0] = chooseRandomEnemy(Enemy[0]); //throw always needs an enemy target
                    }


                } else if (combat.Enemy[i].Role == "Catcher") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Defensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Catch";
                        combat.Enemy[i].Target[0] = Enemy[i];
                    }


                } else if (combat.Enemy[i].Role == "Supporter") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Utility" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];
                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }

                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Gather";
                    }


                } else {
                    print("CRITICAL ERROR");
                    print("EnemyAI.cs: enemy has invalid Role");
                    print("CRITICAL ERROR");
                }//end enemy role if's

            }//end for all enemies loop

        } else if (SceneManager.GetActiveScene().name == "Schola Grandis Gym") {


            for (int i = 0; i < 3; i++) { //for all enemies
                if (combat.Enemy[i].Role == "Thrower") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Offensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Throw";
                        combat.Enemy[0].Target[0] = chooseRandomEnemy(Enemy[0]); //throw always needs an enemy target
                    }


                } else if (combat.Enemy[i].Role == "Catcher") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Defensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Catch";
                        combat.Enemy[i].Target[0] = Enemy[i];
                    }


                } else if (combat.Enemy[i].Role == "Supporter") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Utility" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];
                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }

                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Gather";
                    }


                } else {
                    print("CRITICAL ERROR");
                    print("EnemyAI.cs: enemy has invalid Role");
                    print("CRITICAL ERROR");
                }//end enemy role if's

            }//end for all enemies loop
        } else if (SceneManager.GetActiveScene().name == "MightMain Academy Gym") {

            for (int i = 0; i < 3; i++) { //for all enemies
                if (combat.Enemy[i].Role == "Thrower") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Offensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Throw";
                        combat.Enemy[0].Target[0] = chooseRandomEnemy(Enemy[0]); //throw always needs an enemy target
                    }


                } else if (combat.Enemy[i].Role == "Catcher") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Defensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Catch";
                        combat.Enemy[i].Target[0] = Enemy[i];
                    }


                } else if (combat.Enemy[i].Role == "Supporter") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Utility" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];
                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }

                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Gather";
                    }


                } else {
                    print("CRITICAL ERROR");
                    print("EnemyAI.cs: enemy has invalid Role");
                    print("CRITICAL ERROR");
                }//end enemy role if's

            }//end for all enemies loop

        } else if (SceneManager.GetActiveScene().name == "Yamato Battle") {

            for (int i = 0; i < 3; i++) { //for all enemies
                if (combat.Enemy[i].Role == "Thrower") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Offensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Throw";
                        combat.Enemy[0].Target[0] = chooseRandomEnemy(Enemy[0]); //throw always needs an enemy target
                    }


                } else if (combat.Enemy[i].Role == "Catcher") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Defensive" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];

                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }
                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Catch";
                        combat.Enemy[i].Target[0] = Enemy[i];
                    }


                } else if (combat.Enemy[i].Role == "Supporter") {
                    for (int k = 3; k < 5; k++) { //for all your skills
                        if (combat.Enemy[i].actions[k] != "") {
                            if (combat.Enemy[i].actionCooldowns[k] == 0 && combat.Enemy[i].actionTypes[k] == "Utility" && combat.Enemy[i].heldBalls >= combat.Enemy[i].actionCosts[k]) { //if skill has no cooldown and is offensive
                                combat.Enemy[i].action = combat.Enemy[i].actions[k];
                                combat.Enemy[i].actionType = combat.Enemy[i].actionTypes[k];
                                if (combat.Enemy[i].GetTargetingType(k) == 1) combat.Enemy[i].Target[0] = chooseRandomEnemy(Enemy[i]);
                                if (combat.Enemy[i].GetTargetingType(k) == 2) combat.Enemy[i].Target[0] = chooseRandomAlly(Enemy[i]);
                                break;
                            }
                        }

                    }
                    if (combat.Enemy[i].action == "None") {
                        combat.Enemy[i].action = "Gather";
                    }


                } else {
                    print("CRITICAL ERROR");
                    print("EnemyAI.cs: enemy has invalid Role");
                    print("CRITICAL ERROR");
                }//end enemy role if's

            }//end for all enemies loop
        } else {

        }

    }//end SchoolAI()


}// end class enemyAI.cs
