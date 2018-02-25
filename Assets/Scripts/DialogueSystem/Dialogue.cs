using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue{


	static string[,] sceneName = new string[,] {
		{"char1", "char2" , "text"},
		{"char2", "char1" ,"text"},
		{"char1", "", "text"},


	};

	static string[,] steamedHam = new string[,] {
		{"Shiro", "Seymour" , "Well, Seymour, I made it- despite your directions."},
		{"Seymour", "Shiro" ,"Ah. Superintendent Shiro. Welcome. I hope you're prepared for an unforgettable luncheon."},
		{"Shiro", "Seymour" , "Yeah..."},
		{"Seymour", "","Oh, egads! My roast is ruined. But what if I were to purchase fast food and disguise it as my own cooking? Delightfully devilish, Seymour."},
		{"Shiro", "Seymour" , "Ah-"},
		{"Shiro", "Seymour" , "SEYMOUR!"},
		{"Seymour", "Shiro" ,"Superintendent, I was just... uh, just stretching my calves on the windowsill. Isometric exercise. Care to join me?"},
		{"Shiro", "Seymour" , "Why is there smoke coming out of your oven, Seymour?"},
		{"Seymour", "Shiro" , "Uh- Oh. That isn't smoke. It's steam. Steam from the steamed clams we're having. Mmm. Steamed clams."},
		{"Shiro", "Seymour" , "..."},
		{"Seymour", "Shiro" , "Whew."},
		{"","", "[Seymour leaves to purchase hamburgers]"},
		{"Seymour", "Shiro" , "Superintendent, I hope you're ready for mouthwatering hamburgers."},
		{"Shiro", "Seymour" , "I thought we were having steamed clams."},
		{"Seymour", "Shiro" , "D'oh, no. I said steamed hams. That's what I call hamburgers."},
		{"Shiro", "Seymour" , "You call hamburgers steamed hams? "},
		{"Seymour", "Shiro" , "Yes. It's a regional dialect."},
		{"Shiro", "Seymour" , " Uh-huh. Uh, what region?"},
		{"Seymour", "Shiro" , "Uh, upstate New York."},
		{"Shiro", "Seymour" , "Really. Well, I'm from Utica, and I've never heard anyone use the phrase \"steamed hams.\""},
		{"Seymour", "Shiro" , "Oh, not in Utica. No. It's an Albany expression."},
		{"Shiro", "Seymour" , "I see."},
		{"Shiro", "Seymour" , "You know, these hamburgers are quite similar to the ones they have at Krusty Burger."},
		{"Seymour", "Shiro" , "Oh, no. Patented Skinner burgers. Old family recipe."},
		{"Shiro", "Seymour" , "For steamed hams."},
		{"Seymour", "Shiro" , "Yes."},
		{"Shiro", "Seymour" , "Yes. And you call them steamed hams despite the fact that they are obviously grilled."},
		{"Seymour", "Shiro" , "Ye-"},
		{"Seymour", "Shiro" , "You know, the- "},
		{"Seymour", "Shiro" , "One thing I should-"},
		{"Seymour", "Shiro" , "Excuse me for one second."},
		{"Shiro", "Seymour" , "Of course."},
		{"Shiro", "" , "..."},
		{"Seymour", "Shiro" , "Well, that was wonderful. A good time was had by all. I'm pooped."},
		{"Shiro", "Seymour" , "Yes. I should be-"},
		{"Shiro", "Seymour" , "Good Lord! What is happening in there?"},
		{"Seymour", "Shiro" , "Aurora borealis."},
		{"Shiro", "Seymour" , "Au- Aurora borealis at this time of year-"},
		{"Shiro", "Seymour" , "At this time of day-"},
		{"Shiro", "Seymour" , "In this part of the country-"},
		{"Shiro", "Seymour" , "Localized entirely within your kitchen? "},
		{"Seymour", "Shiro" , "... Yes."},
		{"Shiro", "Seymour" , "May I see it?"},
		{"Seymour", "Shiro" , "No."},
		{"", "Seymour", "Seymour! The house is on fire!"},
		{"Seymour", "Shiro" , "No, Mother. It's just the northern lights."},
		{"Shiro", "Seymour" , "Well, Seymour, you are an odd fellow but I must say you steam a good ham."},




		{"", "Seymour" , "Help! Help!"},
	};

	public Dictionary<string, string[,]> allDialogue = new Dictionary<string,string[,]> {
		{"test scene", sceneName},
		{"steamed hams",steamedHam}

	};

	public Dictionary<string, string[]> characters = new Dictionary<string, string[]> {
		{"test scene", new string[]{"char1","char2"} },
		{"steamed hams", new string[]{"Shiro","Seymour"} }
	};




}
