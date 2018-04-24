using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButtonOptions : MonoBehaviour {

    public bool saltPittEnable = false;
    public bool scholaGrandisEnable = false;
    public bool mightMainEnable = false;

    public GameObject SaltPittButton;
    public GameObject SaltPittBack;
    public GameObject SaltPittDialog;
    public GameObject SaltPittBattle;
    public GameObject SaltPittBattleHard;

    public GameObject ScholaGrandisButton;
    public GameObject ScholaGrandisBack;
    public GameObject ScholaGrandisDialog;
    public GameObject ScholaGrandisBattle;
    public GameObject ScholaGrandisBattleHard;

    public GameObject MightMainButton;
    public GameObject MightMainBack;
    public GameObject MightMainDialog;
    public GameObject MightMainBattle;
    public GameObject MightMainBattleHard;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void splitSaltPitt() {
        saltPittEnable = !saltPittEnable;
        if (saltPittEnable) {
            SaltPittBack.SetActive(true);
            SaltPittDialog.SetActive(true);
            SaltPittBattle.SetActive(true);
            SaltPittBattleHard.SetActive(true);
            SaltPittButton.SetActive(false);
        } else {
            SaltPittBack.SetActive(false);
            SaltPittDialog.SetActive(false);
            SaltPittBattle.SetActive(false);
            SaltPittBattleHard.SetActive(false);
            SaltPittButton.SetActive(true);
        }
    }

    public void splitScholaGrandis() {
        scholaGrandisEnable = !scholaGrandisEnable;
        if (scholaGrandisEnable) {
            ScholaGrandisBack.SetActive(true);
            ScholaGrandisDialog.SetActive(true);
            ScholaGrandisBattle.SetActive(true);
            ScholaGrandisBattleHard.SetActive(true);
            ScholaGrandisButton.SetActive(false);
        } else {
            ScholaGrandisBack.SetActive(false);
            ScholaGrandisDialog.SetActive(false);
            ScholaGrandisBattle.SetActive(false);
            ScholaGrandisBattleHard.SetActive(false);
            ScholaGrandisButton.SetActive(true);
        }
    }

    public void splitMightMain() {
        mightMainEnable = !mightMainEnable;

        if (mightMainEnable) {
            MightMainBack.SetActive(true);
            MightMainDialog.SetActive(true);
            MightMainBattle.SetActive(true);
            MightMainBattleHard.SetActive(true);
            MightMainButton.SetActive(false);
        } else {
            MightMainBack.SetActive(false);
            MightMainDialog.SetActive(false);
            MightMainBattle.SetActive(false);
            MightMainBattleHard.SetActive(false);
            MightMainButton.SetActive(true);
        }
    }

    public void startHardModeBattle(string battle) {
        GameObject.Find("GameManager").GetComponent<GameManager>().hardMode = true;
        GameObject.Find("GameManager").GetComponent<QuitGame>().Restart(battle);
    }
    public void startBattle(string battle) {
        GameObject.Find("GameManager").GetComponent<GameManager>().hardMode = false;
        GameObject.Find("GameManager").GetComponent<QuitGame>().Restart(battle);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameObject.Find("SaltPittButton").GetComponent<Button>().onClick.AddListener(() => this.splitSaltPitt());
        GameObject.Find("SaltPittBack").GetComponent<Button>().onClick.AddListener(() => this.splitSaltPitt());
        GameObject.Find("SaltPittBattle").GetComponent<Button>().onClick.AddListener(() => this.startBattle("SaltPittHighGym"));
        GameObject.Find("SaltPittBattleHard").GetComponent<Button>().onClick.AddListener(() => this.startHardModeBattle("Salt Pitt High Gym"));
        GameObject.Find("SaltPittDialog").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<GameManager>().loadAnyScene("Prologue"));


        GameObject.Find("ScholaGrandisButton").GetComponent<Button>().onClick.AddListener(() => this.splitScholaGrandis());
        GameObject.Find("ScholaGrandisBack").GetComponent<Button>().onClick.AddListener(() => this.splitScholaGrandis());
        GameObject.Find("ScholaGrandisBattle").GetComponent<Button>().onClick.AddListener(() => this.startBattle("Schola Grandis Gym"));
        GameObject.Find("ScholaGrandisBattleHard").GetComponent<Button>().onClick.AddListener(() => this.startHardModeBattle("Schola Grandis Gym"));
        GameObject.Find("ScholaGrandisDialog").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<GameManager>().loadAnyScene("Three Outstanding Girls"));

        GameObject.Find("MightMainButton").GetComponent<Button>().onClick.AddListener(() => this.splitMightMain());
        GameObject.Find("MightMainBack").GetComponent<Button>().onClick.AddListener(() => this.splitMightMain());
        GameObject.Find("MightMainBattle").GetComponent<Button>().onClick.AddListener(() => this.startBattle("MightMain Academy Gym"));
        GameObject.Find("MightMainBattleHard").GetComponent<Button>().onClick.AddListener(() => this.startHardModeBattle("MightMain Academy Gym"));
        GameObject.Find("MightMainDialog").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<GameManager>().loadAnyScene("Punk Ambush"));

        GameObject.Find("Yamato").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<QuitGame>().Restart("Yamato Gym Battle"));
        GameObject.Find("MainMenu").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<QuitGame>().Restart("MainMenu"));
        GameObject.Find("OpenOcean").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<QuitGame>().Restart("OpenOcean"));
    }

}
