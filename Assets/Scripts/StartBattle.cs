using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Character Shiro1 = new Shiro();
        Character Theodore1 = new Theodore();
        Character Clemence1 = new Clemence();

        Character Punk11 = new Punk1();
        Character Punk2 = new Punk1();
        Character Punk3 = new Punk1();
    }

    // Update is called once per frame
    void Update () {
        checkVictory();
	}


    void checkVictory()
    {
    }

}
