using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gains {


    public static int Grow(Character C, string stat) {
        int growth = 0;

        int[,] growthTableThrower = new int[,]{
        //Level             1, 2, 3, 4, 5, 6, 7, 8, 9, 10 
        /*Damage*/        { 0, 4, 2, 1, 2, 5, 2, 3, 4, 4},
        /*Catch*/         { 0, 1, 0, 1, 0, 1, 1, 1, 2, 3},
        /*Gather*/        { 0, 0, 1, 0, 2, 0, 0, 1, 0, 2},
        /*Capacity*/      { 0, 1, 0, 0, 2, 0, 1, 0, 2, 0},
        /*Max Stamina*/   { 0, 8, 7, 5,15,10,10,15,10,20},
        /*Dodge*/         { 0, 2, 0, 0, 3, 1, 2, 3, 1, 5},
        };


        int[,] growthTableCatcher = new int[,] {
        //Level             1, 2, 3, 4, 5, 6, 7, 8, 9, 10 
        /*Damage*/        { 0, 2, 1, 0, 2, 2, 1, 2, 3, 4},
        /*Catch*/         { 0, 3, 2, 2, 6, 2, 1, 3, 4, 7},
        /*Gather*/        { 0, 1, 1, 0, 2, 0, 1, 1, 0, 2},
        /*Capacity*/      { 0, 2, 1, 0, 2, 0, 2, 0, 2, 2},
        /*Max Stamina*/   { 0, 8, 7,10,15,20,10,15,10,25},
        /*Dodge*/         { 0, 2, 0, 0, 3, 1, 2, 3, 1, 5},
        };

        int[,] growthTableSupport = new int[,] {
        //Level             1, 2, 3, 4, 5, 6, 7, 8, 9, 10 
        /*Damage*/        { 0, 2, 2, 2, 3, 5, 2, 3, 4, 4},
        /*Catch*/         { 0, 1, 0, 1, 2, 2, 1, 1, 2, 3},
        /*Gather*/        { 0, 0, 1, 0, 3, 1, 0, 1, 1, 4},
        /*Capacity*/      { 0, 2, 0, 1, 2, 0, 1, 0, 2, 0},
        /*Max Stamina*/   { 0, 8, 7, 6,12,10,7,15,10, 20},
        /*Dodge*/         { 0, 3, 0, 2, 3, 1, 2, 3, 2, 5},
        };
    

        if (C.Role == "Support") {
			switch (stat) {
			case "Damage":
				//growth = growthTableSupport [0, C.Level - 1];
				break;
			case "Catch":
				//growth = growthTableSupport [1, C.Level - 1];
				break;
			case "Gather":
				//growth = growthTableSupport [2, C.Level - 1];
				break;
			case "Capacity":
				//growth = growthTableSupport [3, C.Level - 1];
				break;
			case "Stamina":
				//growth = growthTableSupport [4, C.Level - 1];
				break;
			case "Dodge":
				//growth = growthTableSupport [5, C.Level - 1];
				break;
			default:
				break;
			}
        } else if(C.Role == "Thrower") {
			switch (stat) {
			case "Damage":
				//growth = growthTableThrower [0, C.Level - 1];
				break;
			case "Catch":
				//growth = growthTableThrower [1, C.Level - 1];
				break;
			case "Gather":
				//growth = growthTableThrower [2, C.Level - 1];
				break;
			case "Capacity":
				//growth = growthTableThrower [3, C.Level - 1];
				break;
			case "Stamina":
				//growth = growthTableThrower [4, C.Level - 1];
				break;
			case "Dodge":
				//growth = growthTableThrower [5, C.Level - 1];
				break;
			default:
				break;
			}
        } else {
			switch (stat) {
			case "Damage":
				//growth = growthTableCatcher [0, C.Level - 1];
				break;
			case "Catch":
				//growth = growthTableCatcher [1, C.Level - 1];
				break;
			case "Gather":
				//growth = growthTableCatcher [2, C.Level - 1];
				break;
			case "Capacity":
				//growth = growthTableCatcher [3, C.Level - 1];
				break;
			case "Stamina":
				//growth = growthTableCatcher [4, C.Level - 1];
				break;
			case "Dodge":
				//growth = growthTableCatcher [5, C.Level - 1];
				break;
			default:
				break;
			}
        }

        return growth;
    }
    


    public static void setStat(Character C, string stat, int amount) {
        switch (stat) {
		case "Damage":
			C.Damage = amount;
			break;
		case "Catch":
			C.Catch = amount;
			break;
		case "Gather":
			C.Gather = amount;
			break;
		case "Capacity":
			C.Capacity = amount;
			break;
		case "Stamina":
			C.Stamina = amount;
			break;
		case "Dodge":
			C.dodge = amount;
			break;
		case "Attack":
			C.attack = amount;
			break;
		default:
			break;
        }
    }

public static void gainMultipleLevels(Character C, int number) {
        for(int i = 0; i< number; i++) {
            gainLevel(C);
        }
    }
		
public static void gainLevel(Character C) {
		//C.Level++;
		C.Damage += Grow (C, "Damage");
		C.Catch += Grow (C, "Catch");
		C.Gather += Grow (C, "Gather");
		C.Capacity += Grow (C, "Capacity");
		C.Stamina += Grow (C, "Stamina");
		C.dodge += Grow (C, "Dodge");
    }


}