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








		{"Chalmers", "Seymour" , ""},

		{"Seymour", "Chalmers" , ""},



	};

	public Dictionary<string, string[,]> allDialogue = new Dictionary<string,string[,]> {
		{"test scene", sceneName},
		{"steamed hams",steamedHam}

	};

	public Dictionary<string, string[]> characters = new Dictionary<string, string[]> {
		{"test scene", new string[]{"char1","char2"} },
		{"steamed hams", new string[]{"Chalmers","Seymour"} }
	};




}
