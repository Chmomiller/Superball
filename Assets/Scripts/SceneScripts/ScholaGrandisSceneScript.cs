using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScholaGrandisSceneScript : MonoBehaviour {
    public GameManager game;
    // Use this for initialization
    void Start() {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (/*game.hardMode*/false) {
            GameObject.Find("Character4").GetComponent<Character>().LevelUp(7);
            GameObject.Find("Character5").GetComponent<Character>().LevelUp(7);
            GameObject.Find("Character3").GetComponent<Character>().LevelUp(7);
            GameObject.Find("Character0").GetComponent<Character>().LevelUp(7);
            GameObject.Find("Character1").GetComponent<Character>().LevelUp(7);
            GameObject.Find("Character2").GetComponent<Character>().LevelUp(7);
            print("start hard mode");
        } else {
            GameObject.Find("Character4").GetComponent<Character>().LevelUp(4);
            GameObject.Find("Character5").GetComponent<Character>().LevelUp(6);
            GameObject.Find("Character3").GetComponent<Character>().LevelUp(5);
            GameObject.Find("Character0").GetComponent<Character>().LevelUp(4);
            GameObject.Find("Character1").GetComponent<Character>().LevelUp(5);
            GameObject.Find("Character2").GetComponent<Character>().LevelUp(5);
            print("start regular mode");
        }

    }

    // Update is called once per frame
    void Update() {

    }
}
