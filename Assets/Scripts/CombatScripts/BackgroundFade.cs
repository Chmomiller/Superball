using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundFade : MonoBehaviour {
	public CombatManager CM;
	public SpriteRenderer win;
	public SpriteRenderer lose;
	public string destination;
	private Color fading;

	// Update is called once per frame
	void Update () {
		if(CM.win)
		{
			fading = win.color;
			fading.a = Mathf.Lerp (fading.a,255f,.00005f);
			this.win.color = fading;
			if(win.color.a >= 1)
			{
				SceneManager.LoadScene ("Scenes/WinScenes/BattleWin"+destination);
			}
		}
		if(CM.lose)
		{
			fading = lose.color;
			fading.a = Mathf.Lerp (fading.a,255f,.00005f);
			this.lose.color = fading;
			if(lose.color.a >= 1)
			{
				SceneManager.LoadScene ("Scenes/LossScenes/BattleLoss"+destination);
			}
		}
	}
}
