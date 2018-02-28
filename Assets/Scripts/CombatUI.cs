using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour 
{
	private GameObject[] actionButton;
	private Button skillMenu;
	private bool openMenu;

	// Use this for initialization
	void Start () 
	{
		actionButton = GameObject.FindGameObjectsWithTag ("Action");
		skillMenu = GameObject.Find ("SkillButton").GetComponent<Button>();
		skillMenu.onClick.AddListener (ToggleSkillMenu);
		openMenu = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(openMenu)
		{
			for(int i = 0; i < 3; i++)
			{
				actionButton [i].GetComponent<Image> ().enabled = true;
				actionButton [i].GetComponent<Button> ().enabled = true;
				actionButton [i].GetComponentInChildren<Text> ().enabled = true;
			}
		}
		else
		{
			for(int i = 0; i < 3; i++)
			{
				actionButton [i].GetComponent<Image> ().enabled = false;
				actionButton [i].GetComponent<Button> ().enabled = false;
				actionButton [i].GetComponentInChildren<Text> ().enabled = false;
			}
		}
	}

	public void ToggleSkillMenu()
	{
		if(openMenu)
		{
			openMenu = false;
		}
		else
		{
			openMenu = true;
		}
	}
}
