using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour 
{
	public Text characterInfo;
	public Image characterPanel;
	public Text ballCount;
	public Character character;
	float HealthMax;
	Text characterName;

	void Start () 
	{
		// characterInfo = gameObject.GetComponentsInChildren<Text> ()[0];
		characterName = gameObject.GetComponentsInChildren<Text> ()[0];
		ballCount = gameObject.GetComponentsInChildren<Text> ()[1];
		// characterPanel = gameObject.GetComponentsInChildren<Image> ()[2];
		characterInfo.enabled = false;
		characterPanel.enabled = false;
	}

	public void Init(Character characterToSet)
	{
		// characterInfo = gameObject.GetComponentsInChildren<Text> ()[0];
		characterName = gameObject.GetComponentsInChildren<Text> ()[0];
		ballCount = gameObject.GetComponentsInChildren<Text> ()[1];
		// characterPanel = gameObject.GetComponentsInChildren<Image> ()[2];
		characterInfo.enabled = false;
		characterPanel.enabled = false;
		character = characterToSet;
		characterName.text = character.Name;
	}

	void Update()
	{
		ballCount.text = ""+character.heldBalls;
	}

	void OnMouseEnter()
	{
		characterInfo.text = character.Name 
			+ "\nStamina: "+ character.Stamina + " / " + character.maxStamina
			+ "\nBalls: " + character.heldBalls + " / " + character.maxBalls
			+ "\n\nSkills:" 
			+ "\n\t" + character.GetActionName(4)
			+ "\n\t" + character.GetActionName(5)
			+ "\n\t" + character.GetActionName(6);
		
		characterInfo.enabled = true;
		characterPanel.enabled = true;
	}

	void OnMouseExit()
	{
		characterInfo.enabled = false;
		characterPanel.enabled = false;
	}		
}
