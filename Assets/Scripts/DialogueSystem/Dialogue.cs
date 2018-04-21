using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue{
	
	//characters appear in order
	//{character,character,character,character,character,character,dialogue,whose talking split by a space,special, special param}
	static string[,] sceneName = new string[,] {
		{ "char1", "char2", "char3", "char4", "char5", "char6", "text", "char1 char2 char3", "", "" },
		{ "", "", "char1", "char2", "", "", "text","char1","", "" },
		{ "", "", "char1", "char2", "", "", "text","x","", "" },
		{ "shiro", "shiro", "shiro", "shiro", "shiro", "shiro", "text","shiro","", "" },


	};


	static string[,] aNewStudent = new string[,]{
		{	
			"","","","","","",
			"In this world, dodgeball is our top sport, around which we revolve.",
			"Narrator", "black", "4"
		},
		{
			"","","","","","",
			"Many dream of becoming the world’s top dodgeball player, and so in many lands, players fight for that hope to become true.",
			"Narrator", "",""
		},
		{
			"","","","","","",
			"In every city, its schools fight each other in the hopes of becoming the school to represent the city in the nationals.",
			"Narrator", "", ""
		},
		{
			"","","","","","",
			"Now, let us watch a heart-thrilling tale unfold in a united country that is now called Japan-America...",
			"Narrator", "", ""
		},
		{
			"","Shiro","","","","",
			"Ball City, huh? It’s so busy even in the mornings. Now, where’s Salt Pitt High? It’ll take me a while to get used to this. I’m not in Middleton anymore.",
			"Shiro","", ""
		},
		{
			"","Shiro","","","","",
			"Hey, guys, hurry up! Class starts in ten minutes!",
			"Student A","", ""

		},

		{
			"","Shiro","","","","",
			"Oh, relax, will you?",
			"Student B","", ""

		},
			

		{
			"","Shiro","","","","",
			"That must be the place. Looks nice enough, I guess.",
			"Shiro","", ""

		},

		{
			"","","","","","",
			"",
			"","transition", "Classroom"

		},

		{
			"","Shiro","","","","",
			"Well, class, we have a new student. Please introduce yourself, dear.",
			"Teacher","", ""

		},

		{
			"","Shiro","","","","",
			"Hello, everyone, I’m Shiro Smith. I’m from another town, so I’m sorry if I don’t completely fit in. I’m from the town of Middleton, so I’m still getting used to Ball City.",
			"Shiro","", ""

		},
		{
			"","Shiro","","","","",
			"Hi, Shiro!",
			"Student A","", ""

		},

		{
			"","Shiro","","","","",
			"Nice to meet you!",
			"Student B","", ""

		},
		{
			"","Shiro","","","","",
			"(Wow, they’re all so nice! This may go better than I thought!)",
			"Shiro","", ""

		},

		{
			"","","","","","",
			"",
			"","transition", "Classroom"

		},

		{
			"","","","","","",
			"[Class bells ring]",
			"","", ""

		},

		{
			"","","","","","",
			"Hooray, it's lunch time!",
			"Student A","", ""

		},

		{
			"","","","","","",
			"I’m so glad to be out of math class!",
			"Student B","", ""

		},

		{
			"","Shiro","","","","",
			"Finally! I can look around the school a bit more. Hmm… I can get used to this. It’s hardly any different from middle school.",
			"Shiro","", ""

		},

		{
			"","","","","","",
			"",
			"","transition", "Void"

		},

		{
			"","Shiro","","","","",
			"Ah, I’ve checked out the library, the music room, the field…",
			"Shiro","", ""

		},

		{
			"","Shiro","","","","",
			"Wait, what’s this place? It looks so big! Well, only one way to find out.",
			"Shiro","", ""

		},



	};

	static string[,] someVariable = new string[,]{
		
		{
			//Characters
			"","","","","","",
			//Spoken Text
			"",
			//Who said it
			"",
			//Special
			"",""
			
		},
	};



	public Dictionary<string, string[,]> allDialogue = new Dictionary<string,string[,]> {
		{"test scene", sceneName},
		{"A New Student", aNewStudent}
		//{"steamed hams",steamedHam}

	};




}
