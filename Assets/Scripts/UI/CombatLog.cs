using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatLog : MonoBehaviour {
	private Text combatLog;
	//private System.Collections.Generic.List<string> combatActions;
	public string [] combatActions;

	void Start () {
		combatLog = gameObject.GetComponent<Text> ();
		combatActions = new string[48];
		for(int i = 0; i < combatActions.Length; i++)
		{
			combatActions [i] = "";
		}

		combatActions [0] = "Time for Dodgeball!";
		combatLog.text = combatActions [0];
	}

	public void UpdateLog(string currentAction)
	{
		for(int i = combatActions.Length - 1; i > 0; i--)
		{
			combatActions [i] = combatActions [i - 1];
		}
		combatActions [0] = currentAction;
		combatLog.text = "";
		for(int i = 0; i < combatActions.Length; i++)
		{
			combatLog.text += combatActions[i] + "\n";
		}
	}
}
