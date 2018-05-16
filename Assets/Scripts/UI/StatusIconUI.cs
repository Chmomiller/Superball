using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIconUI : MonoBehaviour {
	public Image statusExplainationPanel;
	public Text statusExplaination;
	public int statusNumber;

	// Use this for initialization
	void Start () 
	{
		statusNumber = -1;
		Image[] temp = gameObject.GetComponentsInChildren<Image> ();
		statusExplainationPanel = temp [1];
		statusExplaination = gameObject.GetComponentInChildren<Text> ();
		//statuses = new Sprite[1];
		//statuses [0] = Resources.Load ("Sprites/UI/BuffIcon");
	}

	void OnMouseOver()
	{
		switch(statusNumber)
		{
			case(0):
				statusExplaination.text = "The character is stunned and can't act";
				break;
			case(1):
				statusExplaination.text = "The charater deals 25% more damage";
				break;
			case(2):
				statusExplaination.text = "The character deals 25% less damage";
				break;
			case(3):
				statusExplaination.text = "The charater takes 25% less damage";
				break;
			case(4):
				statusExplaination.text = "The charater takes 25% more damage";
				break;
			case(5):
				statusExplaination.text = "The charater tis doing something special...";
				break;
			default:
				statusExplaination.text = "";
			break;
		}
		statusExplainationPanel.enabled = true;
		statusExplaination.enabled = true;
	}

	void OnMouseExit()
	{
		statusExplainationPanel.enabled = false;
		statusExplaination.enabled = false;
	}
}
