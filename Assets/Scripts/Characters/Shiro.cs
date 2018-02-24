using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiro : Character{

    // Use this for initialization
    void Start()
    {
        Name = "Shiro";
		Damage = 1;
        Catch = 50;
        Capacity = 8;
        Gather = 3;
        Stamina = 8;
        heldBalls = 0;
        Role = "Support";
    }

    // Update is called once per frame
    void Update()
    {

    }

	public override void Skill1(Character target)
    {

    }

}
