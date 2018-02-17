using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryUIIntegration : MonoBehaviour 
{
	public Text Name;
	public Character Player;
	public Slider HealthBar;
	float HealthMax;
	// Use this for initialization
	void Start () 
	{
		Name = gameObject.GetComponent<Text> ();
		Player = gameObject.GetComponent<Character> ();
		Name.text = Player.Name;
		HealthBar = gameObject.GetComponent<Slider> ();
		HealthMax = Player.Stamina;
		HealthBar.value = Player.Stamina;
	}
	
	// Update is called once per frame
	//can be optimized by making a bool needsUpdate, setting it to true when stamina changes,
	//and then having update check needsUpdate rather than calculating
	void Update () 
	{
		HealthBar.value = Player.Stamina;
		if (HealthBar.value / HealthMax <= .5) {
			//HealthBar.colors = new ColorBlock (1f, 0f, 0f); //Set to Red
		} else if (HealthBar.value / HealthMax > .5) {
			//HealthBar.colors = new ColorBlock (0f, 1f, 0f); //Set to Green
		}
	}
}
