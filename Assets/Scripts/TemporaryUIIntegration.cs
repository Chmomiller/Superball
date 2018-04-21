using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryUIIntegration : MonoBehaviour 
{
	//public Text Name;
	public Character Player;
	public RectTransform HealthBar;
	public float StaminaBar;
	public float HealthMax;
	// Use this for initialization
	void Start () 
	{
		HealthBar = gameObject.GetComponent<RectTransform> ();
		StaminaBar = HealthBar.localScale.x;
		//HealthMax = Player.maxStamina;
	}

	public void Init(Character copyCharacter)
	{
		Player = copyCharacter;
		HealthMax = Player.maxStamina;
	}
	
	// Update is called once per frame
	//can be optimized by making a bool needsUpdate, setting it to true when stamina changes,
	//and then having update check needsUpdate rather than calculating
	void Update () 
	{
		HealthBar.localScale = new Vector3(StaminaBar * (Player.Stamina/HealthMax),
											HealthBar.localScale.y,
											HealthBar.localScale.z);
		if (Player.Stamina/HealthMax <= .5) {
			//HealthBar.colors = new ColorBlock (1f, 0f, 0f); //Set to Red
		} else if (Player.Stamina/HealthMax > .5) {
			//HealthBar.colors = new ColorBlock (0f, 1f, 0f); //Set to Green
		}
	}
}
