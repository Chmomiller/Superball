using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSimulator : MonoBehaviour {
    public int i = 0;
    public GameObject combatObj;
    public GameObject[] players = new GameObject[6];
    
    // Use this for initialization
    void Start() {
        combatObj = GameObject.Find("CombatManager");
    }
    void Update() {
        //ChooseExtras();
       // print(i);
        if (i == 6) {
			// This will need to be changed later to fit different screens
			//GameObject.Find ("CombatUI").transform.position = new Vector3 (400, 150, 0);//GetComponent<RectTransform>()
            combatObj.AddComponent<CombatManager>();
          //  combatObj.name = "Combat_Manager";
          //  Finish(combatObj.GetComponent<CombatManager>());
			//CallInit();
			GameObject.Find("BattleSimHelper").AddComponent<BattleSimHelper>();
            Destroy(this);
        }
    }

    bool SkipChoose(){ return false; }

    void ChooseExtras() {
        //background    //sound    //announcer
    }

    public void createCharacter(GameObject G) {
        Instantiate(G);
        if (i < 3) {
            G.tag = "Player";
            print("player");
            players[i] = G;
        } else {
            G.tag = "Enemy";
            print("enemy");
            players[i] = G;
        }
        i++;
    }

    
    public void Finish(CombatManager combat) {
        for(int k = 0; k < 6; k++) {
            if (k < 3) {
            

                combat.Player[0].allies[i] = combat.Player[i];
                combat.Player[1].allies[i] = combat.Player[i];
                combat.Player[2].allies[i] = combat.Player[i];

                combat.Player[0].enemies[i] = combat.Enemy[i];
                combat.Player[1].enemies[i] = combat.Enemy[i];
                combat.Player[2].enemies[i] = combat.Enemy[i];

            } else {                
                combat.Enemy[0].allies[i] = combat.Enemy[i];
                combat.Enemy[1].allies[i] = combat.Enemy[i];
                combat.Enemy[2].allies[i] = combat.Enemy[i];

                combat.Enemy[0].enemies[i] = combat.Player[i];
                combat.Enemy[1].enemies[i] = combat.Player[i];
                combat.Enemy[2].enemies[i] = combat.Player[i];

            }

            
        }
    }

	void CallInit () 
	{
		CombatUI CUI = GameObject.Find ("CombatUI").GetComponent<CombatUI>();
		ButtonsUI[] buttonsUIs = FindObjectsOfType<ButtonsUI> ();
		TemporaryUIIntegration[] temporaryUIIntegrations = TemporaryUIIntegration.FindObjectsOfType<TemporaryUIIntegration> ();

		CUI.CM = combatObj.GetComponent<CombatManager>();

		GameObject.Find ("Cursor").GetComponent<CursorManager> ().CM = combatObj.GetComponent<CombatManager>();
		for(int i = 0; i < buttonsUIs.Length; i++)
		{
			buttonsUIs [i].CM = combatObj.GetComponent<CombatManager>();
		}
	}

}
