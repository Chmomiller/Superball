using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryUIIntegration : MonoBehaviour 
{
	//public Text Name;
	public Character Player;
	public RectTransform HealthBar;
	public Text HealthText;
	public float StaminaBar;
	public float HealthMax;
	// Use this for initialization
	void Start () 
	{
		HealthBar = gameObject.GetComponent<RectTransform> ();
		StaminaBar = HealthBar.localScale.x;
		//HealthText = HealthBar.GetComponentInChildren<Text> ();
	}

	public void Init(Character copyCharacter)
	{
		HealthBar = gameObject.GetComponent<RectTransform> ();
		StaminaBar = HealthBar.localScale.x;
		//HealthText = HealthBar.GetComponentInChildren<Text> ();
		Player = copyCharacter;
		HealthMax = Player.maxStamina;
		HealthText.text = "" + Player.maxStamina + " / " + Player.maxStamina;
	}
	
	// Update is called once per frame
	//can be optimized by making a bool needsUpdate, setting it to true when stamina changes,
	//and then having update check needsUpdate rather than calculating
	void Update () 
	{
		HealthBar.localScale = new Vector3(StaminaBar * (Player.Stamina/HealthMax),
											HealthBar.localScale.y,
											HealthBar.localScale.z);
		HealthText.text = Player.Stamina + " / " + Player.maxStamina;
		if (Player.Stamina/HealthMax <= .25) {
			HealthBar.GetComponent<Image>().color = new Color32 (255, 2, 0, 255);//Set to Red
		} else if (Player.Stamina/HealthMax > .25) {
			HealthBar.GetComponent<Image>().color = new Color32 (0, 255, 2, 255); //Set to Green
		}
	}
}
