using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour 
{
	public CombatManager CM;
	public GameObject[] actionButton;
	public Button skillMenu;
	public Button backButton;
	public Text PhaseText;
	public bool openMenu;
	public float AlphaThreshold = 0.1f;


	// Use this for initialization
	void Start () 
	{
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();
		backButton = GameObject.Find ("BackButton").GetComponent<Button>();
		backButton.onClick.AddListener (ToggleSkillMenu);
		actionButton = GameObject.FindGameObjectsWithTag ("Action");
		skillMenu = GameObject.Find ("SkillButton").GetComponent<Button>();
		skillMenu.onClick.AddListener (ToggleSkillMenu);
		PhaseText = GameObject.Find ("PhasePanel").GetComponentInChildren<Text> ();
		openMenu = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CM.currentPhase == CombatManager.PHASE.CONFLICT
			|| CM.currentPhase == CombatManager.PHASE.SELECT
			|| CM.currentPhase == CombatManager.PHASE.ACTION
			|| CM.currentPhase == CombatManager.PHASE.TARGET)
		{
			PhaseText.text = "Planning Phase";
		}
		if(CM.currentPhase == CombatManager.PHASE.EXECUTE)
		{
			PhaseText.text = "Execution Phase";
		}
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
