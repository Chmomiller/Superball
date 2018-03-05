using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionUI : MonoBehaviour 
{
	public Text ActionInfo;
	public Image ActionPanel;
	public Character character;

	void Start () 
	{
		Text ActionName;
		ActionInfo = gameObject.GetComponentsInChildren<Text> ()[0];
		ActionName = gameObject.GetComponentsInChildren<Text> ()[1];
		ActionPanel = gameObject.GetComponentsInChildren<Image> ()[1];
		ActionInfo.enabled = false;
		ActionPanel.enabled = false;
		ActionName.text = character.Name;
	}

	void Update()
	{
		ActionInfo.text = character.Name 
			+ "\nStamina: "+ character.Stamina + " / " + character.maxStamina
			+ "\nBalls: " + character.heldBalls
			+ "\n\nSkills:" 
			+ "\n\t" + character.GetActionName(4)
			+ "\n\t" + character.GetActionName(5)
			+ "\n\t" + character.GetActionName(6);
	}

	void OnMouseEnter()
	{
		ActionInfo.enabled = true;
		ActionPanel.enabled = true;
		print ("Mouse over");
	}

	void OnMouseExit()
	{
		ActionInfo.enabled = false;
		ActionPanel.enabled = false;
		print ("Mouse exit");
	}
		
}
