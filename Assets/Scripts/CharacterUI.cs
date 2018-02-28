using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour 
{
	public Text characterInfo;
	public Image characterPanel;
	public Character character;

	void Start () 
	{
		Text characterName;
		characterInfo = gameObject.GetComponentsInChildren<Text> ()[0];
		characterName = gameObject.GetComponentsInChildren<Text> ()[1];
		characterPanel = gameObject.GetComponentsInChildren<Image> ()[1];
		characterInfo.enabled = false;
		characterPanel.enabled = false;
		characterName.text = character.Name;
	}

	void Update()
	{
		characterInfo.text = character.Name 
			+ "\nStamina: "+ character.Stamina + " / " + character.maxStamina
			+ "\nBalls: " + character.heldBalls
			+ "\n\nSkills:" 
			+ "\n\t" + character.GetActionName(4)
			+ "\n\t" + character.GetActionName(5)
			+ "\n\t" + character.GetActionName(6);
	}

	void OnMouseEnter()
	{
		characterInfo.enabled = true;
		characterPanel.enabled = true;
		print ("Mouse over");
	}

	void OnMouseExit()
	{
		characterInfo.enabled = false;
		characterPanel.enabled = false;
		print ("Mouse exit");
	}
		
}
