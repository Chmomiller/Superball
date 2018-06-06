using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButtonOptions : MonoBehaviour {

    public bool saltPittEnable = false;
    public bool scholaGrandisEnable = false;
    public bool mightMainEnable = false;

	public int saltPittProgress = 1;
	public int scholaGrandisProgress = 0;
	public int mightMainProgress = 0;

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

	public GameObject Yamato;



	void Start()
	{
		if(saltPittProgress > 1)
		{
			ScholaGrandisButton.SetActive (true);
		}
		if(scholaGrandisProgress > 1)
		{
			MightMainButton.SetActive (true);
		}
		if(mightMainProgress > 1)
		{
			Yamato.SetActive (true);
		}
	}

    public void splitSaltPitt() {
        saltPittEnable = !saltPittEnable;
        if (saltPittEnable) {
			SaltPittDialog.SetActive(true);
			if(saltPittProgress > 0)
			{
				SaltPittBattle.SetActive(true);
				if(saltPittProgress == 2)
				{
					SaltPittBattleHard.SetActive(true);
				}
			}
            SaltPittBack.SetActive(true);
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
			ScholaGrandisDialog.SetActive(true);
			if(scholaGrandisProgress > 0)
			{
				ScholaGrandisBattle.SetActive(true);
				if(scholaGrandisProgress == 2)
				{
					ScholaGrandisBattleHard.SetActive(true);
				}
			}
            ScholaGrandisBack.SetActive(true);
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
			MightMainDialog.SetActive(true);
			if(mightMainProgress > 0)
			{
				MightMainBattle.SetActive(true);
				if(mightMainProgress == 2)
				{
					MightMainBattleHard.SetActive(true);
				}
			}
            MightMainBack.SetActive(true);
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
		/*
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
	*/
	}

}
