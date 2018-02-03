using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour 
{
	public int maxStamina;
	public int currentStamina;
	public int maxBallCount;
	public int ballCount;
	public int damage;
	public bool selected = false;
	SpriteRenderer character;

	public enum type
	{
		THROWER, CATCHER, SUPPORT
	}
		

	// Use this for initialization
	void Start () 
	{
		character = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (selected) 
		{
			character.color = new Color (0f, 0f, 0f, 0f);
		}
		else 
		{
			character.color = new Color (1f, 1f, 1f, 1f);
		}

	}
}
