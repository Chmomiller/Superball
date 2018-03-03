using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour 
{
	private GameObject[] actionButton;
	private Button skillMenu;
	public Button backButton;
	public bool openMenu;
	public float AlphaThreshold = 0.1f;


	// Use this for initialization
	void Start () 
	{
		backButton = GameObject.Find ("BackButton").GetComponent<Button>();
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
			backButton.GetComponent<Image> ().enabled = true;
			backButton.GetComponent<Button> ().enabled = true;
			backButton.GetComponentInChildren<Text> ().enabled = true;
			for(int i = 0; i < 3; i++)
			{
				actionButton [i].GetComponent<Image> ().enabled = true;
				actionButton [i].GetComponent<Button> ().enabled = true;
				actionButton [i].GetComponentInChildren<Text> ().enabled = true;
			}
		}
		else
		{
			backButton.GetComponent<Image> ().enabled = false;
			backButton.GetComponent<Button> ().enabled = false;
			backButton.GetComponentInChildren<Text> ().enabled = false;
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
