
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveManager : MonoBehaviour {
	public static SaveManager toSave;

    public Shiro shiro;
    public Clemence clemence;
    public Theodore theodore;

    public bool SaltPittDialogue = false;
    public bool SaltPittBattle = false;
    public bool SaltPittBattleHard = false;

    public bool ScholaGrandisDialog = false;
    public bool ScholaGrandisBattle = false;
    public bool ScholaGrandisBattleHard = false;

    public bool MightMainDialog = false;
    public bool MightMainBattle = false;
    public bool MightMainBattleHard = false;

    public bool yamatoDialog = false;
    public bool yamatoBattle = false;
    public bool yamatoBattleHard = false;

    public bool teamSevenDialog = false;
    public bool teamSevenBattle = false;

    public bool beatSuperballRush = false;
    public bool unlockAll = false;

    void Awake () {
		if (toSave == null) {
			DontDestroyOnLoad (this);
			toSave = this;
		} else if (toSave != this) {
			Destroy (this);
		}
        if(shiro == null|| clemence == null|| theodore == null) {
            shiro = new Shiro();
            clemence = new Clemence();
            theodore = new Theodore();
        }
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void Save(){
		FileStream file = File.Open (Application.persistentDataPath + "/info.dat", FileMode.Create);
		BinaryWriter bf = new BinaryWriter (file);
		bf.Write ((decimal) shiro.Level);
		bf.Write ((decimal) shiro.maxStamina);
		bf.Write ((decimal)shiro.Damage);
		bf.Write ((decimal)shiro.maxBalls);
		//bf.Write ((decimal) shiro.experience);

		bf.Write ((decimal) theodore.Level);
		bf.Write ((decimal) theodore.maxStamina);
		bf.Write ((decimal) theodore.Damage);
		bf.Write ((decimal) theodore.maxBalls);
		//bf.Write ((decimal) theodore.experience);

		bf.Write ((decimal) clemence.Level);
		bf.Write ((decimal) clemence.maxStamina);
		bf.Write ((decimal) clemence.Damage);
		bf.Write ((decimal) clemence.maxBalls);
		//bf.Write ((decimal) clemence.experience);

		bf.Write (SaltPittDialogue);
		bf.Write (SaltPittBattle);
		bf.Write (SaltPittBattleHard);

		bf.Write (ScholaGrandisDialog);
		bf.Write (ScholaGrandisBattle);
		bf.Write (ScholaGrandisBattleHard);

		bf.Write (MightMainDialog);
		bf.Write (MightMainBattle);
		bf.Write (MightMainBattleHard);

		bf.Write (yamatoDialog);
		bf.Write (yamatoBattle);
		bf.Write (yamatoBattleHard);

		bf.Write (teamSevenDialog);
		bf.Write (teamSevenBattle);

		bf.Write (beatSuperballRush);
		bf.Write (unlockAll);

		bf.Close ();
		file.Close ();
	}

	public bool Read(){
		int[] characterStats = this.ReadCharacters ();
		bool[] conditionsMet = this.ReadBooleans ();
		if (characterStats [0] == 0 || conditionsMet [0] == false) {
			return false;
		} else {
			int shiroTempLvl = characterStats [0];
			if (shiroTempLvl > shiro.Level) {
				shiro.LevelUp (shiroTempLvl - shiro.Level);
			}
			shiro.maxStamina = characterStats [1];
			shiro.Damage = characterStats [2];
			shiro.maxBalls = characterStats [3];

			int theoTempLvl = characterStats [4];
			if (theoTempLvl > theodore.Level) {
				theodore.LevelUp (theoTempLvl - theodore.Level);
			}
			theodore.maxStamina = characterStats [5];
			theodore.Damage = characterStats [6];
			theodore.maxBalls = characterStats [7];

			int clemTempLvl = characterStats [8];
			if(clemTempLvl > clemence.Level) {
				clemence.LevelUp (clemTempLvl - clemence.Level);
			}
			clemence.maxStamina = characterStats [9];
			clemence.Damage = characterStats [10];
			clemence.maxBalls = characterStats [11];

			SaltPittDialogue = conditionsMet [0];
			SaltPittBattle = conditionsMet [1];
			SaltPittBattleHard = conditionsMet [2];

			ScholaGrandisDialog = conditionsMet [3];
			ScholaGrandisBattle = conditionsMet [4];
			ScholaGrandisBattleHard = conditionsMet [5];

			MightMainDialog = conditionsMet [6];
			MightMainBattle = conditionsMet [7];
			MightMainBattleHard = conditionsMet [8];

			yamatoDialog = conditionsMet [9];
			yamatoBattle = conditionsMet [10];
			yamatoBattleHard = conditionsMet [11];

			teamSevenDialog = conditionsMet [12];
			teamSevenBattle = conditionsMet [13];

			beatSuperballRush = conditionsMet [14];
			unlockAll = conditionsMet [15];
		}
		return true;
	}

	public void Reset()
	{
		shiro.ResetChar ();
		theodore.ResetChar ();
		clemence.ResetChar ();
	}

	public int[] ReadCharacters(){
		int[] characterStats = new int[12];
		if (File.Exists (Application.persistentDataPath + "/info.dat")) {
			FileStream file = File.Open (Application.persistentDataPath + "/info.dat", FileMode.Open);
			BinaryReader br = new BinaryReader(file);
			for (int i = 0; i < 12; i++) {
				characterStats [i] = (int) br.ReadDecimal ();
			}

			br.Close ();
			file.Close ();
		}
		return characterStats;
	}
		
	public bool[] ReadBooleans(){
		bool[] conditionsCompleted = new bool[16];
		if (File.Exists (Application.persistentDataPath + "/info.dat")) {
			FileStream file = File.Open (Application.persistentDataPath + "/info.dat", FileMode.Open);
			BinaryReader br = new BinaryReader(file);
			for (int i = 0; i < 12; i++) {
				br.ReadDecimal ();
			}
			for (int i = 0; i < 16; i++) {
				conditionsCompleted [i] = br.ReadBoolean ();
			}

			br.Close ();
			file.Close ();
		}
		return conditionsCompleted;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(scene.name == "MapScreen")
		{
			Save ();	
		}
	}
}