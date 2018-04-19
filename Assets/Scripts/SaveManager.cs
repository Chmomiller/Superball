using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour {
	public static SaveManager toSave;

    public Shiro shiro;
    public Clemence clemence;
    public Theodore theodore;

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