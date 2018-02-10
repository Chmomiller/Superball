using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryUIIntegration : MonoBehaviour 
{
	public Text Name;
	public Character Player;
	public Slider HealthBar;

	// Use this for initialization
	void Start () 
	{
		Name = gameObject.GetComponent<Text> ();
		Player = gameObject.GetComponent<Character> ();
		Name.text = Player.Name;
		HealthBar = gameObject.GetComponent<Slider> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
