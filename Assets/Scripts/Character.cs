using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string Name = "default";
    public int Accuracy = 100;
    public int Catch = 100;
    public int Gather = 0;
    public int Capacity = 4;
    public int Stamina = 100;
	public int maxStamina = 0;
    public int heldBalls = 0;
    public string Role = "Supporter";

    public bool dead = false;
	public bool catching = false;


    // Use this for initialization
    void Start(){

    }

    // Update is called once per frame
    void Update(){

    }
    

    void loseStamina(int staminaLoss) { this.Stamina -= staminaLoss; }
    void gainStamina(int staminaLoss) { this.Stamina += staminaLoss; }

	public int catchBall(){
		if (this.catching) {
			if ((Random.Range (1, 100) + Random.Range (1, 100) / 2) < this.Catch) { // you can catch it
				if (this.heldBalls < Capacity) {
					this.heldBalls++;
				}
				return 1;
			}
		} if ((Random.Range (1, 100) + Random.Range (1, 100) / 2) < this.Stamina * 100) {//dodge success
			loseStamina (0);
			return 0;
		} else {
			loseStamina (1);
			if (this.Stamina <= 0)
				this.dead = true; 
			return -1;
		}
    }

    public bool throwBall(Character target) 
	{
		if ((Random.Range (1, 100) + Random.Range (1, 100) / 2) < this.Accuracy) {
			return true;
		} else {
			return false;
		}
    }

    public void Rest()
	{
		this.gainStamina (1);
    }

    public void Skill1(){

    }

    void Skill2(){

    }

    void Skill3(){

    }

    void Skill4(){

    }
}
