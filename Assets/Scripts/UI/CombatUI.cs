using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour 
{
	public CombatManager CM;
	public GameObject[] skillButton;
	public Button skillMenu;
	public Button backButton;
	public Image phasePanel;
	public Text phaseText;
	public Image actionPanel;
	public Text actionText;
	public ButtonsUI[] actionButtons;
	public bool openMenu;
	public float AlphaThreshold = 0.1f;


	// Use this for initialization
	void Start () 
	{
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();
		backButton = GameObject.Find ("BackButton").GetComponent<Button>();
		backButton.onClick.AddListener (ToggleSkillMenu);
		skillButton = GameObject.FindGameObjectsWithTag ("Skill");
		skillMenu = GameObject.Find ("SkillButton").GetComponent<Button>();
		skillMenu.onClick.AddListener (ToggleSkillMenu);
		phasePanel = GameObject.Find ("PhasePanel").GetComponentInChildren<Image> ();
		phaseText = GameObject.Find ("PhasePanel").GetComponentInChildren<Text> ();
		actionPanel = GameObject.Find ("ActionPanel").GetComponent<Image>();
		actionText = GameObject.Find ("ActionPanel").GetComponentInChildren<Text>();
		actionButtons = new ButtonsUI[skillButton.Length + 2];
		actionButtons [0] = GameObject.Find ("ThrowButton").GetComponent<ButtonsUI> ();
		actionButtons [1] = GameObject.Find ("CatchButton").GetComponent<ButtonsUI> ();
		for (int i = 0; i < skillButton.Length; i++) 
		{
			actionButtons [i + 2] = skillButton [i].GetComponent<ButtonsUI> ();
		}
		openMenu = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CM.currentPhase == CombatManager.PHASE.ACTION)
		{
			bool actionOpen = false;
			foreach (ButtonsUI BU in actionButtons) 
			{
				if (BU.menuOpen) 
				{
					actionOpen = true;
				}
			}
			if (actionOpen) 
			{
				actionPanel.enabled = true;
				actionText.enabled = true;
			}
			else
			{
				actionPanel.enabled = false;
				actionText.enabled = false;
			}
		}
		else
		{
			actionPanel.enabled = false;
			actionText.enabled = false;
		}
		if(CM.currentPhase == CombatManager.PHASE.CONFLICT
			|| CM.currentPhase == CombatManager.PHASE.SELECT
			|| CM.currentPhase == CombatManager.PHASE.ACTION
			|| CM.currentPhase == CombatManager.PHASE.TARGET)
		{
			phaseText.text = "Planning Phase";
		}
		if(CM.currentPhase == CombatManager.PHASE.EXECUTE)
		{
			phaseText.text = "Execution Phase";
		}
		if(openMenu)
		{
			backButton.GetComponent<Image> ().enabled = true;
			backButton.GetComponent<Button> ().enabled = true;
			backButton.GetComponentInChildren<Text> ().enabled = true;
			for(int i = 0; i < skillButton.Length; i++)
			{
				skillButton [i].GetComponent<Image> ().enabled = true;
				skillButton [i].GetComponent<Button> ().enabled = true;
				skillButton [i].GetComponentInChildren<Text> ().enabled = true;
				skillButton [i].GetComponent<PolygonCollider2D> ().enabled = true;
			}
		}
		else
		{
			backButton.GetComponent<Image> ().enabled = false;
			backButton.GetComponent<Button> ().enabled = false;
			backButton.GetComponentInChildren<Text> ().enabled = false;
			for(int i = 0; i < skillButton.Length; i++)
			{
				skillButton [i].GetComponent<Image> ().enabled = false;
				skillButton [i].GetComponent<Button> ().enabled = false;
				skillButton [i].GetComponentInChildren<Text> ().enabled = false;
				skillButton [i].GetComponent<PolygonCollider2D> ().enabled = false;
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

	public void ShowPhase()
	{
		phasePanel.enabled = true;
		phaseText.enabled = true;
		StartCoroutine (HidePhase());
	}

	IEnumerator HidePhase()
	{
		yield return new WaitForSeconds(2);
		phasePanel.enabled = false;
		phaseText.enabled = false;
	}
}
