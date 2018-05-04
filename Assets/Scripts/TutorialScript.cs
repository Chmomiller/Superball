using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public int count = 0;
    public GameObject ActionManager;
    public GameObject skill1Button;
    public GameObject skill2Button;
    public GameObject skill3Button;
    public GameObject ActionPanel;
    public GameObject PlayerUI;
    public GameObject EnemyUI;
    public GameObject PhasePanel;
    public GameObject CombatPanel;
    public GameObject Character0;
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;
    public GameObject Character5;
    public GameObject throwButton;
    public GameObject catchButton;
    public GameObject skillButton;
    public GameObject textOverlay;
    public GameObject textOverlayT;


	// Use this for initialization
	void Start () {
        throwButton = GameObject.Find("ThrowButton");
        throwButton.SetActive(false);
        catchButton = GameObject.Find("CatchButton");
        catchButton.SetActive(false);
        skillButton = GameObject.Find("SkillButton");
        skillButton.SetActive(false);
        skill1Button = GameObject.Find("Skill1Button");
        skill1Button.SetActive(false);
        skill2Button = GameObject.Find("Skill2Button");
        skill2Button.SetActive(false);
        skill3Button = GameObject.Find("Skill3Button");
        skill3Button.SetActive(false);
        ActionPanel = GameObject.Find("ActionPanel");
        ActionPanel.SetActive(false);
        ActionManager = GameObject.Find("ActionManager");
        ActionManager.SetActive(false);
        PlayerUI = GameObject.Find("PlayerUI");
        PlayerUI.SetActive(false);
        EnemyUI = GameObject.Find("EnemyUI");
        EnemyUI.SetActive(false);
        PhasePanel = GameObject.Find("PhasePanel");
        PhasePanel.SetActive(false);
        CombatPanel = GameObject.Find("CombatPanel");
        CombatPanel.SetActive(false);
        Character0 = GameObject.Find("Character0");
        Character0.SetActive(false);
        Character1 = GameObject.Find("Character1");
        Character1.SetActive(false);
        Character2 = GameObject.Find("Character2");
        Character2.SetActive(false);
        Character3 = GameObject.Find("Character3");
        Character3.SetActive(false);
        Character4 = GameObject.Find("Character4");
        Character4.SetActive(false);
        Character5 = GameObject.Find("Character5");
        Character5.SetActive(false);
        textOverlayT = GameObject.Find("textOverlayT");
        textOverlayT.SetActive(false);
        textOverlay = GameObject.Find("textOverlay");
        textOverlay.SetActive(false);

}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) == true) count++;

        if (count == 0) {
            textOverlay.SetActive(true);
            textOverlayT.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "Welcome to the world of SuperBall!!";
        } else if (count == 1) {
            Character0.SetActive(true);
            textOverlay.transform.position = new Vector3(-3.5F, 3, 0);
            textOverlayT.GetComponent<Text>().text = "This is Shiro Smith, she is nice and bubbly and anxious to meet you";
            //point out shiro
        } else if (count == 2) {
            textOverlay.transform.position = new Vector3(-4.5F, 3, 0);
            Character1.SetActive(true);
            Character2.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "These are her buds Clemence and Theodore";
            //introuduce Clemence & Theodore
        } else if (count == 3) {
            textOverlay.transform.position = new Vector3(0, 0, 0);
            textOverlayT.GetComponent<Text>().text = "Before we introduce you to the Punks, I would like to show you some important Superball simualtion elements";
            //more flavor text
        } else if (count == 4) {
            textOverlay.transform.position = new Vector3(0, 4, 0);
            PhasePanel.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "Here is the phase panel. It gives you information on what combat phase we are in";
            //point out phase panel
        } else if (count == 5) {
            textOverlay.transform.position = new Vector3(0, 1, 0);
            CombatPanel.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "This is the combat panel. We will see important battle information here";
            //point out battle text
        } else if (count == 6) {
            textOverlayT.GetComponent<Text>().text = "Now it is time to see your foes";
            //introduce enemies
        } else if (count == 7) {
            Character3.SetActive(true);
            textOverlay.transform.position = new Vector3(3, 3, 0);
            textOverlayT.GetComponent<Text>().text = "Tetsou Trevor";
            //introduce trevor
        } else if (count == 8) {
            textOverlay.transform.position = new Vector3(4, 3, 0);
            Character4.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "Futoi Frank";
            //introduce trevor
        } else if (count == 9) {
            textOverlay.transform.position = new Vector3(5, 3, 0);
            Character5.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "Gomi Greg";
            //introduce trevor
        } else if (count == 10) {
            textOverlay.transform.position = new Vector3(0, 5, 0);
            textOverlayT.GetComponent<Text>().text = "They arent the friendliest bunch but I am sure you can defeat them";
        } else if (count == 11) {
            textOverlay.transform.position = new Vector3(0, -1, 0);
            PlayerUI.SetActive(true);
            EnemyUI.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "here to help is our simlator panels, one for each combatant";
            //point out portraits
        } else if (count == 12) {
            textOverlay.transform.position = new Vector3(0, 0, 0);
            textOverlayT.GetComponent<Text>().text = "If hovered over, these portaits even give useful information such as the character's status abilities and stats";
            //point out portrait details
        } else if (count == 13) {
            textOverlay.transform.position = new Vector3(0, 0, 0);
            ActionManager.SetActive(true);
            throwButton.SetActive(true);
            catchButton.SetActive(true);
            skillButton.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "Now onto the actions you can take. These are shown in this 3 segment wheel";
            //point out basic actions
        } else if (count == 14) {
            throwButton.SetActive(false);
            catchButton.SetActive(false);
            skillButton.SetActive(false);
            skill1Button.SetActive(true);
            skill2Button.SetActive(true);
            skill3Button.SetActive(true);
            textOverlayT.GetComponent<Text>().text = "There are even skills unique to each player that can be accessed by clicking Skills";
            //point out skills examples
        } else if (count == 10) {
            throwButton.SetActive(true);
            catchButton.SetActive(true);
            skillButton.SetActive(true);
            //point out skills 2
        } else if (count == 11) {
            textOverlayT.GetComponent<Text>().text = "Most moves require a target, which can be specified by clicking on either your allies or enemies";
            //point out example skill description
        } else if (count == 12) {
            textOverlayT.GetComponent<Text>().text = "Ready to Ball?";
            //point out different targetting
        } else {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MapScreen");
        }

    }
}
