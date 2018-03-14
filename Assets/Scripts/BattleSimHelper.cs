using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSimHelper : MonoBehaviour 
{
	public CombatUI CUI;
	public ButtonsUI[] buttonsUIs;
	public Character[] characters;
	public CharacterSelectUI[] characterselectUIs;
	public TemporaryUIIntegration[] temporaryUIIntegrations;
	public CombatManager combatObj;
	// Use this for initialization
	void Start () 
	{
		combatObj = GameObject.Find ("CombatManager").GetComponent<CombatManager>();
		CUI = GameObject.Find ("CombatUI").GetComponent<CombatUI> ();
		CUI.CM = combatObj;
		buttonsUIs = FindObjectsOfType<ButtonsUI> ();
		GameObject.Find ("Cursor").GetComponent<CursorManager> ().CM = combatObj;

		characters = FindObjectsOfType<Character> ();
		characterselectUIs = CharacterSelectUI.FindObjectsOfType<CharacterSelectUI> ();
		temporaryUIIntegrations = TemporaryUIIntegration.FindObjectsOfType<TemporaryUIIntegration> ();
		for(int i = 0; i < buttonsUIs.Length; i++)
		{
			buttonsUIs [i].CM = combatObj;
		}
	}
}
