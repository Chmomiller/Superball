using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LambdaTest : MonoBehaviour {

	public Button[] btn;
	public Button attack;
	public Text battleText;

	void Start () 
	{
		/*for (int i = 0; i < 3; i++) 
		{
			btn [i].onClick.AddListener (()=>TaskOnClick (i));
		}*/
		btn [0].onClick.AddListener (()=>TaskOnClick (0));
		btn [1].onClick.AddListener (()=>TaskOnClick (1));
		btn [2].onClick.AddListener (()=>TaskOnClick (2));
		attack.onClick.AddListener (Attack);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void TaskOnClick(int number)
	{
		battleText.text = "0" + number;
	}

	void Attack()
	{
		battleText.text = "Attack";
	}
}
