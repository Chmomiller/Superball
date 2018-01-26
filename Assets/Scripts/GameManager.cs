using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public enum PHASE{CHARACTER, ACTION, TARGET}

	public Button yourButton;
	public Text battleText;
	public GameObject cursorHead;
	public CursorManager cursorScript;
	public PlayerManager[] player;
	public EnemyManager[] enemy;
	public int cursor = 0;
	public bool playerTurn = true;
	public PHASE currentPhase = PHASE.CHARACTER;


	void Start()
	{
		//Button btn = yourButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
	}

	void Update()
	{
		//battleText.text = "Player " +
		//(cursor + 1);

		//StartCoroutine (MoveCursor());
		//cursorHead.transform.position = new Vector3 (player [cursor].transform.position.x, 
		//	player [cursor].transform.position.y + 1, 2);


		if (playerTurn) 
		{
//			cursor -= (int)(Input.GetAxisRaw ("Vertical"));
			/*if (cursor < 0) 
			{
				cursor = 0;
			}
			if (cursor > 2) 
			{
				cursor = 2;
			}
*/
			if (Input.GetButtonUp ("Submit"))
			{
				TaskOnClick (cursor);
			}
			cursorScript.cursor = cursor;
		}
		else
		{
			playerTurn = true;
			StartCoroutine (EnemyTurn ());
		}
	}

	IEnumerator EnemyTurn()
	{
		player [0].currentStamina -= 2;
		yield return new WaitForSeconds (1);
		battleText.text = "Enemy attacks Player! \n Player has " + 
			player[0].currentStamina + 
			" stamina!";
	}

	void TaskOnClick(int player)
	{
		if (playerTurn) 
		{
			enemy [0].currentStamina -= 2;
			battleText.text = "Player " + 
				(player+1) +
				" attacks Enemy! \n Enemy has " + 
				enemy[0].currentStamina + 
				" stamina!";
			playerTurn = false;
		} 
	}
}
