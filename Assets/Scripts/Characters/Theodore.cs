using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theodore : Character {

   

    // Use this for initialization
    void Start () {
        Name = "Theodore";
		Damage = 1;
        Catch = 25;
        Capacity = 8;
        Gather = 1;
        Stamina = 7;
        heldBalls = 0;
        Role = "Thrower";

    }

    // Update is called once per frame
    void Update () {
		
	}

	public override void Skill1(Character target)
    {

    }

}
