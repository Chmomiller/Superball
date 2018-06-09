using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamatoSceneScript : MonoBehaviour {
    public GameManager game;
    // Use this for initialization
    void Awake() {
        game = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (game.hardMode) {
            GameObject.Find("Character4").GetComponent<Character>().LevelUp(18);
            GameObject.Find("Character5").GetComponent<Character>().LevelUp(19);
            GameObject.Find("Character3").GetComponent<Character>().LevelUp(19);
            //GameObject.Find("Character0").GetComponent<Character>().LevelUp(18);
            //GameObject.Find("Character1").GetComponent<Character>().LevelUp(17);
            //GameObject.Find("Character2").GetComponent<Character>().LevelUp(16);
            print("start hard mode");
        } else {
            GameObject.Find("Character4").GetComponent<Character>().LevelUp(13);
            GameObject.Find("Character5").GetComponent<Character>().LevelUp(14);
            GameObject.Find("Character3").GetComponent<Character>().LevelUp(12);
            //GameObject.Find("Character0").GetComponent<Character>().LevelUp(11);
            //GameObject.Find("Character1").GetComponent<Character>().LevelUp(13);
            //GameObject.Find("Character2").GetComponent<Character>().LevelUp(15);
            print("start regular mode");
        }

    }

    // Update is called once per frame
    void Update() {

    }
}
