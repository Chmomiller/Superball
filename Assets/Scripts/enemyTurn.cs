using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTurn : Character {

    public string[] options = { "throw", "catch", "skill1", "skill2", "skill3", "gather" };
    public int[] volitions = { 0, 0, 0, 0, 0, 0 };//these are weights for the options above

    public int difficulty = 0; //easy 0, medium 1, hard 2, wrench 3

    public Character player, target;

    //mini struct since we dont need template methods. ie, no need for .push_back() or .pop() etc.
    public struct Action {
        public string name;
        public int priority;
        
        //Constructors
        public Action(string name, int priority) {
            this.name = name;
            this.priority = priority;
        }
        public Action(string name) {
            this.name = "None";
            this.priority = 0;
        }
    }
    public Action[] actions;


    // Use this for initialization
    void Start() {
        //populates the actions array with i structs that each have a string and a 0 priority
        for (int n = 0; n < options.Length; n++) {
            actions[n] = new Action(options[n], volitions[n]);
        }
    }

    // Update is called once per frame
    void Update() {
    FindPriorities();
    actions = SortByPriority(actions);
    string choice = ChooseOption(actions, difficulty);
    TakeAction(choice);
    }


    void FindPriorities() {
        actions[0].priority += throwPriority();
        actions[1].priority += catchPriority();
        actions[2].priority += skill1Priority();
        actions[3].priority += skill2Priority();
        actions[4].priority += skill3Priority();
        actions[5].priority += gatherPriority();
    }

    int throwPriority() {
        target = FindBestTarget();
        return 0; }
    int catchPriority() { return 0; }
    int skill1Priority() { return 0; }
    int skill2Priority() { return 0; }
    int skill3Priority() { return 0; }
    int gatherPriority() { return 0; }

    Character FindBestTarget() {
        Character target =  new Character();
        int priority = 0;

            //this is commented out because currently it cant access players and thus will not compile
        //where players is the character array of all combatants
        /*foreach (Character c: players)
          int newPriority = MATH EQUATION FOR BEST OPTION
            if(priority < newPriority) {
                target = c;
                priority = newPriority
            }
        */
        return target;
    }

    Action[] SortByPriority(Action[] actions) {
        for(int n = 0; n < actions.Length-1; n++) {
            for(int k = 0; k<actions.Length-n-1; k++) {
                if(actions[n].priority > actions[n+1].priority) {
                    Action temp = actions[n];
                    actions[n] = actions[n + 1];
                    actions[n + 1] = temp;
                }
            }
        }
        return actions;
    }

    string ChooseOption(Action[] actions, int difficulty) {
        //for some reason it didnt like: string[] options so I did it this way
        string[] options = new string[actions.Length];
        
        switch (difficulty) {
            case 0:
                
                options[0] = actions[1].name;
                options[1] = actions[2].name;
                options[2] = actions[3].name;
                break;
            case 1:
                options[0] = actions[1].name;
                options[1] = actions[2].name;
                break;
            case 2:
                options[0] = actions[0].name;
                options[1] = actions[1].name;
                break;
            case 3:
                options[0] = actions[0].name;
                break;
            default:
                print("Error: difficulty out of range");
                break;

        }

        return options[Random.Range(0,options.Length-1)];
    }

    void TakeAction(string choice) {
        switch (choice) {
            case "throw":
                //player.throwBall();
                break;
            case "catch":
                //player.catchBall();

                break;
            case "skill1":

                break;
            case "skill2":

                break;
            case "skill3":

                break;
            case "gather":

                break;
            default:
                print("Error: Invalid action in TakeAction()");
                break;
        }
    }
}
