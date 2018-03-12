using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue{
	//characters appear in order
	//special include offscreen
	//{character,character,character,character,character,character,dialogue,whose talking split by a space,special, special param}
	static string[,] sceneName = new string[,] {
		{ "char1", "char2", "char3", "char4", "char5", "char6", "text", "char1 char2 char3", "" },
		{ "", "", "char1", "char2", "", "", "text","char1","" },
		{ "", "", "char1", "char2", "", "", "text","x","" },

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
			"Shiro: Ah, I’ve checked out the library, the music room, the field…",
			"Shiro","", ""

		},

		{
			"","Shiro","","","","",
			"Shiro: Wait, what’s this place? It looks so big! Well, only one way to find out.",
			"Shiro","", ""

		},

	};

	/*

	static string[,] steamedHam = new string[,] {
		{"Chalmers", "Seymour" , "Well, Seymour, I made it- despite your directions."},
		{"Seymour", "Chalmers" ,"Ah. Superintendent Chalmers. Welcome. I hope you're prepared for an unforgettable luncheon."},
		{"Chalmers", "Seymour" , "Yeah..."},
		{"Seymour", "","Oh, egads! My roast is ruined. But what if I were to purchase fast food and disguise it as my own cooking? Delightfully devilish, Seymour."},
		{"Chalmers", "Seymour" , "Ah-"},
		{"Chalmers", "Seymour" , "SEYMOUR!"},
		{"Seymour", "Chalmers" ,"Superintendent, I was just... uh, just stretching my calves on the windowsill. Isometric exercise. Care to join me?"},
		{"Chalmers", "Seymour" , "Why is there smoke coming out of your oven, Seymour?"},
		{"Seymour", "Chalmers" , "Uh- Oh. That isn't smoke. It's steam. Steam from the steamed clams we're having. Mmm. Steamed clams."},
		{"Chalmers", "Seymour" , "..."},
		{"Seymour", "Chalmers" , "Whew."},
		{"","", "[Seymour leaves to purchase hamburgers]"},
		{"Seymour", "Chalmers" , "Superintendent, I hope you're ready for mouthwatering hamburgers."},
		{"Chalmers", "Seymour" , "I thought we were having steamed clams."},
		{"Seymour", "Chalmers" , "D'oh, no. I said steamed hams. That's what I call hamburgers."},
		{"Chalmers", "Seymour" , "You call hamburgers steamed hams? "},
		{"Seymour", "Chalmers" , "Yes. It's a regional dialect."},
		{"Chalmers", "Seymour" , " Uh-huh. Uh, what region?"},
		{"Seymour", "Chalmers" , "Uh, upstate New York."},
		{"Chalmers", "Seymour" , "Really. Well, I'm from Utica, and I've never heard anyone use the phrase \"steamed hams.\""},
		{"Seymour", "Chalmers" , "Oh, not in Utica. No. It's an Albany expression."},
		{"Chalmers", "Seymour" , "I see."},
		{"Chalmers", "Seymour" , "You know, these hamburgers are quite similar to the ones they have at Krusty Burger."},
		{"Seymour", "Chalmers" , "Oh, no. Patented Skinner burgers. Old family recipe."},
		{"Chalmers", "Seymour" , "For steamed hams."},
		{"Seymour", "Chalmers" , "Yes."},
		{"Chalmers", "Seymour" , "Yes. And you call them steamed hams despite the fact that they are obviously grilled."},
		{"Seymour", "Chalmers" , "Ye-"},
		{"Seymour", "Chalmers" , "You know, the- "},
		{"Seymour", "Chalmers" , "One thing I should-"},
		{"Seymour", "Chalmers" , "Excuse me for one second."},
		{"Chalmers", "Seymour" , "Of course."},
		{"Chalmers", "" , "..."},
		{"Seymour", "Chalmers" , "Well, that was wonderful. A good time was had by all. I'm pooped."},
		{"Chalmers", "Seymour" , "Yes. I should be-"},
		{"Chalmers", "Seymour" , "Good Lord! What is happening in there?"},
		{"Seymour", "Chalmers" , "Aurora borealis."},
		{"Chalmers", "Seymour" , "Au- Aurora borealis at this time of year-"},
		{"Chalmers", "Seymour" , "At this time of day-"},
		{"Chalmers", "Seymour" , "In this part of the country-"},
		{"Chalmers", "Seymour" , "Localized entirely within your kitchen? "},
		{"Seymour", "Chalmers" , "... Yes."},
		{"Chalmers", "Seymour" , "May I see it?"},
		{"Seymour", "Chalmers" , "No."},
		{"", "Seymour", "Seymour! The house is on fire!"},
		{"Seymour", "Chalmers" , "No, Mother. It's just the northern lights."},
		{"Chalmers", "Seymour" , "Well, Seymour, you are an odd fellow but I must say you steam a good ham."},




		{"", "Seymour" , "Help! Help!"},
	};

	*/

	public Dictionary<string, string[,]> allDialogue = new Dictionary<string,string[,]> {
		{"test scene", sceneName},
		{"A New Student", aNewStudent}
		//{"steamed hams",steamedHam}

	};
	/*
	public Dictionary<string, string[][]> characters = new Dictionary<string, string[][]> {
		//must have 3 in each
		{"test scene", new string[][]{ new string[]{"char1","char2",""}, new string[]{"char3","char3",""}} },
		{"steamed hams", new string[][]{new string[]{"Chalmers","Seymour"}} }
	};
	*/



}
