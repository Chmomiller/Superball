using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public bool scholaGrandisBattleHard = false;

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
	}

	public void Save(int currLvl, int ShiroLvl, int ShiroExp, int TheoLvl, int TheoExp, int ClemLvl, int ClemExp){
		FileStream file = File.Open (Application.persistentDataPath + "/info.dat", FileMode.Create);
		BinaryWriter bf = new BinaryWriter (file);
		bf.Write ((decimal) currLvl);
		bf.Write ((decimal) ShiroLvl);
		bf.Write ((decimal) ShiroExp);
		bf.Write ((decimal) TheoLvl);
		bf.Write ((decimal) TheoExp);
		bf.Write ((decimal) ClemLvl);
		bf.Write ((decimal) ClemExp);

		bf.Close ();
		file.Close ();
	}

	public int[] Read(){
		int[] values = new int[7];
		if (File.Exists (Application.persistentDataPath + "/info.dat")) {
			FileStream file = File.Open (Application.persistentDataPath + "/info.dat", FileMode.Open);
			BinaryReader br = new BinaryReader(file);
			for (int i = 0; i < 7; i++) {
				values [i] = (int) br.ReadDecimal ();
			}
		}
		return values;
	}
		
}