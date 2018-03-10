using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharCreator : MonoBehaviour {

    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    public GameObject[] chars = new GameObject[3];
    public Character test;
    public delegate void SkillPtr();


    public enum CHOICE { NEW, LOAD, BACK };
    public CHOICE choice = CHOICE.NEW;
    public bool done = false;
    // Use this for initialization
    void Start () {
        Instantiate(char1);
        Instantiate(char2);
        Instantiate(char3);
        chars[0] = char1;
        chars[1] = char2;
        chars[2] = char3;

    }
    
// Update is called once per frame
void Update () {
        while (!done) {
            showCharacters();
            //UI:  What would you like to do?
            //     New OR Load OR BACK? 
            choice = choice;

            switch (choice) {
                case (CHOICE.NEW):
                    //CreateCharacter();
                    break;

                case (CHOICE.LOAD):
                    loadCharacters();
                    break;

                default:
                    done = true;
                    break;
            }
        }
        //Return back to before
    }


    void CreateCharacter<T>() {
        //UI: Which slot would you like to create them, keep in mind you will ovewrite the slot
        int characterNum = 0;
        //UI for 1,2,3
        Character ch;
        if (characterNum == 1) {
            Save1 c = new Save1();
            ch = c;
            editCharacter(c, characterNum);
        } else if(characterNum == 1) {
            Save2 c = new Save2();
            editCharacter(c, characterNum);
        } else if(characterNum == 2) {
            Save3 c = new Save3();
            editCharacter(c, characterNum);
        } else {
            print("Error: CustomCharCreator.cs: Invalid characterNum");
        }

        

    }

    void showCharacters() {

    }

    void loadCharacters() {
    //UI: Which do you want to load? 1,2,3
        int characterNum = 0;

        //UI: Do you want to edit?
        bool edit = true;
        editCharacter(chars[characterNum].GetComponent<Character>(), characterNum);
    }

    void editCharacter(Character newKid, int slotNum) {
        //maybe have some way to view the stats of another character
        int maxStats = 60;
        while (!done) {
            changeStats(newKid, maxStats);
            changeAppearance(newKid);
            //changeAbilities(newKid);
            if(/*Is UI "Done" button pressed?*/ false) {
                done = true ;
            }
        }
    }

    void changeStats(Character newKid, int maxStats) {
        //UI: You have X stat points to use, what would you like to do
        int classNum = 0;
        //UI Button: Change Class
        {
            
            classNum++;
            if(classNum == 0) { newKid.Role = "Thrower";
            }else if(classNum == 1) { newKid.Role = "Catcher";
            } else {newKid.Role = "Support";
            }
        }

        //UI Button: + Attack
        { newKid.Damage++;
            maxStats -= 5;
        }
        
        //UI Button: - Attack
        { newKid.Damage--;
            maxStats += 5;
        }        
        
        //UI Button: + Catch %
        { newKid.Catch+= 5; }        
        

        //<etc...>//
    }

    void changeAppearance<SaveSlot>(SaveSlot newKid) {
        //UI: Which is closest to how you express yourself?
        int expression = 0; //0 for Male, 1 for Female, 2 for Other
        bool done = false;

        while (!done) {
            if (expression == 0) {
                //Show Male creation elements, UI button for each
            } else if (expression == 1) {
                //Show female creation elements, UI button for each
            } else {
                //Show both, UI button for each
                //on click, change the sprite
            }
            //UI Button: Done
                { done = true;}
        }
    }

    /*
    void changeAbilities<SaveSlot>(SaveSlot newKid) {
        bool done = false;
        while (!done) {
            //some listing method of abilities
            //be able to get reference to a character and put hostName euqal to ti
            //then get what ability you want to copy and set skillChosen to it
            int skillNum = 0;
            Character hostName = new Character();
            string SkillChosen = "N/A";

            if (SkillChosen == "Skill1") {
                SkillPtr Skill = hostName.Skill1;
                newKid.hosts[0] = Skill;
                newKid.validSkills[0] = true;
            } else if (SkillChosen == "Skill2") {
                SkillPtr Skill = hostName.Skill2;
                newKid.hosts[1] = Skill;
                newKid.validSkills[1] = true;
            } else if (SkillChosen == "Skill3") {
                SkillPtr Skill = hostName.Skill3;
                newKid.hosts[2] = Skill;
                newKid.validSkills[2] = true;
            } else if (SkillChosen == "Skill4") {
                SkillPtr Skill = hostName.Skill4;
                newKid.hosts[3] = Skill;
                newKid.validSkills[3] = true;
            }
            //UI: Done?
                { done = true; }
        }
    }

    */
    //outputs ability to 
    void scriptwriter(string name, string[,] data) {

    }

}
