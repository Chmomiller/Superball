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
	public Button cancelButton;
	public Button pageNextButton;
	public Button pageBackButton;
	public Image phasePanel;
	public Text phaseText;
	public Image actionPanel;
	public Text actionText;
	public ButtonsUI[] actionButtons;
	public int openMenu;
	public float AlphaThreshold = 0.1f;


	// Use this for initialization
	void Start () 
	{
		backButton = GameObject.Find ("BackButton").GetComponent<Button>();
		backButton.onClick.AddListener (ToggleSkillMenu);
		cancelButton = GameObject.Find ("CancelButton").GetComponent<Button> ();
		cancelButton.onClick.AddListener (CancelAction);
		//skillButton = GameObject.FindGameObjectsWithTag ("Skill");
		skillButton = new GameObject[6];
		skillButton [0] = GameObject.Find ("Skill1Button");
		skillButton [1] = GameObject.Find ("Skill2Button");
		skillButton [2] = GameObject.Find ("Skill3Button");
		skillButton [3] = GameObject.Find ("Skill4Button");
		skillButton [4] = GameObject.Find ("Skill5Button");
		skillButton [5] = GameObject.Find ("Skill6Button");
		skillMenu = GameObject.Find ("SkillButton").GetComponent<Button>();
		skillMenu.onClick.AddListener (ToggleSkillMenu);
		pageNextButton = GameObject.Find ("PageNextButton").GetComponent<Button> ();
		//pageNextButton.onClick.AddListener (()=>ToggleVisibleSkills (1));
		pageBackButton = GameObject.Find ("PageBackButton").GetComponent<Button> ();
		//pageBackButton.onClick.AddListener (()=>ToggleVisibleSkills (2));
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
		openMenu = 0;
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();
	}

	// Update is called once per frame
	void Update () 
	{
		// This is used to reset the skill page for convenience
		if(CM.currentPhase == CombatManager.PHASE.CONFLICT)
		{
			openMenu = 0;
		}

		// This activates or deactivates the cancel button when moving to or from the target phase
		if(CM.currentPhase == CombatManager.PHASE.TARGET)
		{
			cancelButton.enabled = true;
			cancelButton.GetComponentInChildren<Text> ().enabled = true;
			cancelButton.GetComponent<Image> ().enabled = true;
		}
		else
		{
			cancelButton.enabled = false;
			cancelButton.GetComponentInChildren<Text> ().enabled = false;
			cancelButton.GetComponent<Image> ().enabled = false;
		}

		// This massive block of code makes the appropriate buttons from the action menu visible based on which phase its in and which page the player is looking at
		if(CM.currentPhase == CombatManager.PHASE.ACTION)
		{
			// Check if the cursor is hovering over a skill and open the description panel or close it if not
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
		if(openMenu == 1)
		{
			backButton.GetComponent<Image> ().enabled = true;
			backButton.GetComponent<Button> ().enabled = true;
			backButton.GetComponentInChildren<Text> ().enabled = true;
			pageNextButton.GetComponent<Image> ().enabled = true;
			pageNextButton.GetComponent<Button> ().enabled = true;
			pageNextButton.GetComponentInChildren<Text> ().enabled = true;
			pageBackButton.GetComponent<Image> ().enabled = false;
			pageBackButton.GetComponent<Button> ().enabled = false;
			pageBackButton.GetComponentInChildren<Text> ().enabled = false;
			for(int i = 0; i < 3; i++)
			{
				skillButton [i].GetComponent<Image> ().enabled = true;
				skillButton [i].GetComponent<Button> ().enabled = true;
				skillButton [i].GetComponentInChildren<Text> ().enabled = true;
				skillButton [i].GetComponent<PolygonCollider2D> ().enabled = true;
				skillButton [i+3].GetComponent<Image> ().enabled = false;
				skillButton [i+3].GetComponent<Button> ().enabled = false;
				skillButton [i+3].GetComponentInChildren<Text> ().enabled = false;
				skillButton [i+3].GetComponent<PolygonCollider2D> ().enabled = false;
			}
		}
		if(openMenu == 2)
		{
			pageNextButton.GetComponent<Image> ().enabled = false;
			pageNextButton.GetComponent<Button> ().enabled = false;
			pageNextButton.GetComponentInChildren<Text> ().enabled = false;
			pageBackButton.GetComponent<Image> ().enabled = true;
			pageBackButton.GetComponent<Button> ().enabled = true;
			pageBackButton.GetComponentInChildren<Text> ().enabled = true;
			for(int i = 0; i < 3; i++)
			{
				skillButton [i].GetComponent<Image> ().enabled = false;
				skillButton [i].GetComponent<Button> ().enabled = false;
				skillButton [i].GetComponentInChildren<Text> ().enabled = false;
				skillButton [i].GetComponent<PolygonCollider2D> ().enabled = false;
				skillButton [i+3].GetComponent<Image> ().enabled = true;
				skillButton [i+3].GetComponent<Button> ().enabled = true;
				skillButton [i+3].GetComponentInChildren<Text> ().enabled = true;
				skillButton [i+3].GetComponent<PolygonCollider2D> ().enabled = true;
			}
		}
		if(openMenu == 0)
		{
			backButton.GetComponent<Image> ().enabled = false;
			backButton.GetComponent<Button> ().enabled = false;
			backButton.GetComponentInChildren<Text> ().enabled = false;
			pageNextButton.GetComponent<Image> ().enabled = false;
			pageNextButton.GetComponent<Button> ().enabled = false;
			pageNextButton.GetComponentInChildren<Text> ().enabled = false;
			pageBackButton.GetComponent<Image> ().enabled = false;
			pageBackButton.GetComponent<Button> ().enabled = false;
			pageBackButton.GetComponentInChildren<Text> ().enabled = false;
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
		if(openMenu == 1)
		{
			openMenu = 0;
			pageNextButton.enabled = false;
		}
		else
		{
			openMenu = 1;
			pageNextButton.enabled = true;
		}
	}

	public void ToggleVisibleSkills(int page)
	{
		openMenu = page;
	}

	public void ShowPhase()
	{
		phasePanel.enabled = true;
		phaseText.enabled = true;
		StartCoroutine (HidePhase());
	}

	public void CancelAction()
	{
		CM.combatQueue [CM.currentCharacter].action = "None";
		CM.combatQueue [CM.currentCharacter].actionType = "None";
		CM.currentPhase = CombatManager.PHASE.ACTION;
	}

	IEnumerator HidePhase()
	{
		yield return new WaitForSeconds(2);
		phasePanel.enabled = false;
		phaseText.enabled = false;
	}
}
