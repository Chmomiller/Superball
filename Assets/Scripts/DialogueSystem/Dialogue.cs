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


    
    static string[,] prolog = new string[,]{
        {
            "","","","","","",
            "Dear Kuro, How are you doing now?",
            "Shiro", "black", ""
        },
                       {
            "","","","","","",
            "I’ve come to Ball City at last! The train ride from Middleton was long and dull, but I’m excited to be here!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "How can’t I, when it’s one of the biggest cities of Japan-America?",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "And you know what’s weird? Well, you already know it, I guess, but anyway!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "The city’s fixated on, of all things, dodgeball!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "The city’s fixated on, of all things, dodgeball! Many dream of becoming the world’s top dodgeball players and fight for that hope to become true.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "And Ball City’s many schools fight each other in the hopes of becoming the school to represent the city in the national competition. That’s unbelievable, isn’t it? It’s so much to take in!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Anyway, I hope to see you later. It’s been a while since you left home. If you want to see me, come to the apartment that Mom’s rented for me.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Hopefully, you’re doing well at your academy, and I’ll be doing well at my new school.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "", ""
        },
    };

    static string[,] aNewStudent = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "","","","","","",
            "A few days later....",
            "Narrator", "", ""
        },
        {
            "","Shiro","","","","",
            "Now, where’s Salt Pitt High? I’m still taking time to get used to this.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","","",
            "Hey, guys, hurry up! Class starts in ten minutes!",
            "Student A", "", ""
        },
        {
            "","Shiro","","","","",
            "Oh, relax, will you?",
            "Student B", "", ""
        },
        {
            "","Shiro","","","","",
            "That must be the place. Looks nice enough, I guess.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {
            "","Shiro","","","","",
            "Well, class, we have a new student. Please introduce yourself, dear.",
            "Teacher", "", ""
        },
        {
            "","Shiro","","","","",
            "Hello, everyone! I’m Shiro Smith, and I’m from Middleton, a town in the far western parts of Japan-America, so I’m sorry if I don’t fully fit in. I’m still getting used to Ball City.",
            "Teacher", "", ""
        },
        {
            "","Shiro","","","","",
            "Hi, Shiro!",
            "Student A", "", ""
        },
        {
            "","Shiro","","","","",
            "Nice to meet you!",
            "Student B", "", ""
        },
        {
            "","Shiro","","","","",
            "(Wow, they’re all so nice! This may go better than I thought!)",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
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
            "Finally! I can look around the school a bit more.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","","",
            "Hmm… I can get used to this. It’s hardly any different from middle school. ",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
        {
            "","Shiro","","","","",
            "Ah, I’ve checked out the library, the music room, the field… ",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","","",
            "Wait, what’s that place? It looks so big! Well, only one way to find out. ",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
};


    static string[,] aNewStudent7 = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "","","","","","",
            "A few days later....",
            "Narrator", "", ""
        },
        {
            "","Shiro","","","","",
            "Now, where’s Salt Pitt High? I’m still taking time to get used to this.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","","",
            "Hey, guys, hurry up! Class starts in ten minutes!",
            "Student A", "", ""
        },
        {
            "","Shiro","","","","",
            "Oh, relax, will yOu?",
            "Student B", "", ""
        },
        {
            "","Shiro","","","","",
            "That must be the pLace. Looks nice enough, I guess.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {
            "","Shiro","","","","",
            "Well, class, we have a new student. Please introduce yourself, deAr.",
            "Teacher", "", ""
        },
        {
            "","Shiro","","","","",
            "Hello, everYone! I’m Shiro Smith, and I’m from Middleton, a town in the far weStern parts of Japan-America, so I’m sorry if I don’t fully fit in. I’m still getting used to Ball City.",
            "Teacher", "", ""
        },
        {
            "","Shiro","","","","",
            "Hi, Shiro!",
            "Student A", "", ""
        },
        {
            "","Shiro","","","","",
            "Nice to meet you!",
            "Student B", "", ""
        },
        {
            "","Shiro","","","","",
            "(Wow, they’re all so nice! This may go better than I thought!)",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
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
            "Finally! I can look around the school a bIt more.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","","",
            "Hmm… I can get used to this. It’s hardly any different from middle school. ",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
        {
            "","Shiro","","","","",
            "Ah, I’ve cheCked out the library, the mUSic room, the field… ",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","","",
            "Wait, what’s that place? It looks so big! Well, only one way to find out. ",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
              {
      "","Shiro","","","","",
            "Shiro: Who are you?",
            "Shiro","", ""

      },

      {
      "","Shadow","","","","",
            "Shadow: We are unfamiliar With this world as wEll",
            "Shadow","", ""

      },

      {
      "","Shiro","","","","",
            "Shiro: GreAt then, we can exploRe thE School together. Do you play dodgEball?",
            "Shiro","", ""

      },

      {
      "","Shadow","","","","",
            "Shadow: Good obserVation. In some ways yes. Our time is limited, but grow your skills and you will see us soon enough.",
            "Shadow","", ""

      },
      {
      "","Shiro","","","","",
            "Shiro: Are you studEnts here?",
            "Shiro","", ""

      },
      {
      "","Shadow","","","","",
            "Shadow: Not here. There are maNy schools in New Ball City.",
            "Shadow","", ""

      },

      {
      "","Shiro","","","","",
            "Shiro: Okay, have a good rest of your day then.",
            "Shiro","", ""

      },
      {
      "","Shadow","","","","",
            "Shadow: Goodbye Shiro.",
            "Shadow","", ""

      },
      {
      "","Shiro","","","","",
            "Shiro: I don't ever recall seeing them before. Do I know them?",
            "Shiro","", ""

      },
};


    static string[,] punkConfrontation = new string[,]{
        {
            "","Shiro","","","","",
            "What is this? It looks like a gym, but it’s so… ruined.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","","",
            "Hey, you! What do you think you’re doing here?",
            "???", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "(Whoa, a boy walking in a trash can! And a big guy wearing a bucket! What weirdos! And they don’t look too happy to see me!)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Oh, am I not supposed to be here?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "You’re darn right you can’t be here! We’re the Pitt Crew, the school’s dodgeball club, and this old gym’s our turf!",
            "Greg", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Wait, gym? Your turf? The school leaves the old gym like this?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Uh, yeah! The school didn’t want it, so we took it!",
            "Frank", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "And hey, aren’t you the new girl?",
            "Frank", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Uh, well… yeah.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Oh, you are, aren’t you? Well, you ought to know your place here, then!",
            "Greg", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "And I, Greg Gomi, and my buddy here, Frank Daigo, are the perfect guys for this!",
            "Greg", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Huh? But I thought only the boss was perfect. You said so earlier.",
            "Frank", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Dang it, Frank, you’re supposed to back me up here! Think for once, can’t you? You’ll do me some good.",
            "Greg", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "But I’m supposed to do no good, right? That’s what the boss says.",
            "Frank", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "I’m sorry to interrupt your good fellows’ conversation, but I’m afraid that your fun’s to come to a stop.",
            "???", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Greg","Frank",
            "Dang it! It’s Theodore Yukimura and Clemence Kadou!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Greg","Frank",
            "We followed her, once we saw that she was heading here.",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Greg","Frank",
            "Now please, let her go! This isn’t how a dodgeball club is supposed to act!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "Oh, this isn’t good! This isn’t good at all!",
            "Frank", "", ""
        },
        {
            "","Shiro","","","Greg","Frank",
            "You don’t say!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Greg","Frank",
            "Where’s your leader? Is Spiky not ready?",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Greg","Frank",
            "Is that your new name for me, Theodore? What silly things come out of that mouth of yours!",
            "???", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Greg","Frank",
            "I, Trevor Akuouji, am always ready.",
            "???", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "And Greg’s right on this one. That girl ought to know her place here.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "We can’t let people come here willy-nilly because they would think that our bark is stronger than our bite. And you know that’ll be bad for our business.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Is that so, Mr. Porcupine?",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Mr. Porcupine? But it’s true, Theodore. Don’t you know better?",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Yeah, tell him, boss! Get him for good!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Boss, is our plan all in shambles now?",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "No, we are still fine. Our plan can still go on even if they’re here.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "(Is it just me, or is this Trevor guy oddly well spoken? Not one of those everyday punks, at least.)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Wh-What are you going to do to me?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Nothing bad, I assure you. All we’ll do is have a dodgeball match.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Oh no! A dodgeball match!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "I knew that you would do such a thing!",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "It’s too bad for you that knowing it didn’t stop it from happening.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Oh, you guys will get destroyed for sure!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Wait, what’s the big deal? Why dodgeball? Isn’t it just a sport?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Eh? You don’t know how things work around here? It’s not just a sport! It’s our way of life!",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "That’s just silly",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Don’t you call it silly!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "I can’t let you slip away, girl. The pain from losing will be with you and let you remember where you stand here.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Now, Frank, my man, you’re a fast guy, aren’t you?",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "As fast as you want me to be, boss.",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Then tell everyone that we have a new match!",
            "Trevor", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Whoa, a match is about to start!",
            "Student A", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Poor girl! To go against that worthless Pitt Crew!",
            "Student B", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "It seems that three classes’ worth of students are watching, which will make your loss all the more shameful.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "You still haven’t learned the errors of your ways, I see.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "I thought someone like you would realize that what you’d been doing would soon lead you to your downfall.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "…... Ahahahaha! Oh, Theodore, that’s so funny that if I didn’t know any better, I’d think you were a joker dressed for an act!",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Aw, boss, you’re truly smarter than he ever could be!",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Let’s begin the match already! I’ll take them down for sure, boss! I know trash when I see it, and I see something waiting to be taken out!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "(I still can’t believe they’re being serious about this whole dodgeball thing!)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "As we are involved now, it’s a 3-on-3 match. Let us help you fight.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "I don’t have a choice now, do I?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Nope.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Oh, Theodore, are you sure this is right? What if we lose? We’ll definitely lose, anyone can see!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Clemence, Trevor has made a big mistake by allowing us to fight.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Ever since I lost against them, I’ve been watching them gang up on other students, and I can tell you for sure they’re not invincible.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "So we have a chance, you two.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Now, then, let’s begin!",
            "Trevor", "", ""
        },
    };

    static string[,] tutorial = new string[,]{
        {
            "Clemence","Theodore","Shiro","","","",
            "You know how to play dodgeball, don’t you?",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Uh, I haven’t played for a long while.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Oh no, a rookie player! Now we can’t win!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Technically, we can, but it will take dumb luck, and I would rather that our chances of winning be raised. And it seems that Spiky and his fine fellows are willing to wait. Shall I explain the rules to refresh your mind?",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Do!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Then listen well! In dodgeball, a player can be one of three classes: thrower, supporter, and catcher.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "You see their leader, Trevor, over there? He’s a piece of work, but more importantly, he’s a thrower, which means that he throws all the balls that he’s caught to execute powerful attacks.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Next, we have Greg. He seems like a loony, and his trash is no one’s treasure, that’s for sure. Anyway, he’s a supporter, which means that he helps his teammates in many ways such as preventing them from getting hit.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "And finally, there’s Frank. With how fast he thinks, a snail comes into mind. He’s a catcher, which means that he is mainly to catch as many balls as he can.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Uh, by the way, you should always remember your four basic actions: Throw, Gather, Skills, and Catch.",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "With Throw, you can throw a ball at any enemy. With Gather, you get some balls, and how many you have is listed somewhere, so you don’t have to worry about remembering it.",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "With Skills, you can do many special actions, and they often have special effects to think about. And with Catch, if an enemy throws a ball at you, you get the ball instead of being hit by it.",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Is that right? Hmm… I’ll have to remember that.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Oh, and I guess I should tell you guys that I’m a supporter.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "How lucky! I’m a catcher, and Theodore is a thrower.",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "And now that we have that taken care of, let us drive off those eyesores.",
            "Theodore", "", ""
        },
};

    static string[,] punkDefeat = new string[,]{
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "What?! How can this be! I, Trevor Akuouji, cannot be beaten!",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Hmm, I beg to differ.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Boss, I say they’ve given us a good one! I feel pretty worn out.",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Frank, you nitwit! Don’t say that!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Wow, have you just seen that?",
            "Student A", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "The dodgeball club members have just lost!",
            "Student B", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "A lot of the students are pretty shocked. What’s the big deal?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Ah, you don’t know! See, we have this thing in our school where we decide our place on the totem pole by our dodgeball skills.",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Trevor and his gang are at the top, but since we’ve just beaten them…",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "We’ve knocked them down a peg, right?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Look at those punks! If a newbie can beat them, then the dodgeball club’s weaker than I thought!",
            "Student A", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Oh, come on, you don’t truly believe that now, right?",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Y-Yikes!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Boss, they’re not taking this well!",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "The dodgeball club’s not right with you around! Get out, Pitt Crew!",
            "Student B", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "If I were you, I would go away and stay low for a while.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "That sounds like a good idea to me, boss!",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Oh, zip it, Frank!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Now, hold on, Greg! Our friend here’s right for once.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "It’ll be bad for us to stay here. They’ve made the others want to fight us. We’ve been undermined.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "What now, then?",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Girl, what’s your name?",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Shiro Smith.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Shiro Smith, hmm? We’ll go away for now, don’t you worry about that.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Shiro Smith, hmm? We’ll go away for now, don’t you worry about that.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "But mark my words, you shall rue the very second you stepped upon our turf!",
            "Trevor", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Exterior"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And that’s that. The king is caught, and the winner’s name is said.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Phew! I feared things would get violent, but I’m glad things have ended peacefully. Are you okay, Shiro?",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Yeah. I wasn’t expecting us to win, to tell you the truth.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "You looked like you had a lot of fun playing dodgeball.",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Yeah, it was fun! It was a nice one-time thing!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "One-time thing? Have you not realized that we’re now the top dogs of this school, now that those punks have been dealt with?",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "What?! We are?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wait, doesn’t that mean we’re in charge of the club now?",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Given that they have left it, I should imagine it’s ours for the taking. And Clemence, you ought to join, as I do see some potential in your playing.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But I’m already Garden Club president! I don’t want to be the president!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And I’m the Chess Club president. I suppose that it makes sense that the one in charge of no club become the president, then. What say you, Shiro?",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "M-Me? President?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "You needn’t agree to it, of course. If you don’t want to, then you need only give it to someone else. This kind of thing sorts itself out, I’ve found.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "(Hmm… Should I join? I’m not too into dodgeball, and that match happened so suddenly that I was forced to do it. But…)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I might as well. I’ll be something in this school at least.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wonderful! If you’re president, I’ll just be a regular member.",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "So will I. Henceforth, you’re in charge, Shiro.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I’ll do the best that I can.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I hope you will! Salt Pitt High’s among the worst performing schools in the world of dodgeball! We’re in the bottom five in Ball City’s rankings!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "What?! I wasn’t told of that!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But now that you’re around, maybe our fortunes will turn around.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Hmm… It won’t hurt to stick with this, I guess. What are your names, by the way?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I’m Theodore Yukimura.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And I’m Clemence Kadou.",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh, class is about to begin! I’ll see you guys later!",
            "Shiro", "", ""
        },
        {    
            "","Shiro","","","Theodore","Clemence",
            "Of course.Goodbye, Shiro.",
            "Theodore", "", ""
        },
        {    
            "","Shiro","","","Theodore","Clemence",
            "See you later, Shiro!",
            "Clemence", "", ""
        },
        {
            "","","","","","",
            "",
            "","black", ""
        },
        {    
            "","","","","","",
            "Dear Kuro, How are you doing now?",
            "Shiro", "", ""
        },
        {    
            "","","","","","",
            "Today has been an odd day. I walked in a boring old student, and I walked out a dodgeball club president.",
            "Shiro", "", ""
        },
        {    
            "","","","","","",
            "I was once interested in it when I was a little girl, but I wasn’t any good at all, so I naturally gave up on it. But now it’s come back to me.",
            "Shiro", "", ""
        },
        {    
            "","","","","","",
            "What does this mean for me?",
            "Shiro", "", ""
        },
        {    
            "","","","","","",
            "It’s odd that it’s dodgeball of all things. It’s a thing in Middleton, but it is certainly nowhere as big as it is in Ball City!",
            "Shiro", "", ""
        },
        {    
            "","","","","","",
            "Anyway, I hope that you’re doing well. It’ll be nice to see you later.",
            "Shiro", "", ""
        },
        {    
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "", ""
        },
};

    /*	static string[,] steamedHam = new string[,] {
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

    public Dictionary<string, string[,]> allDialogue = new Dictionary<string, string[,]> {
        {"test scene", sceneName},
        {"Prologue", prolog },
        {"A New Student", aNewStudent},
        {"A New Student 7", aNewStudent7},
        {"What Punks", punkConfrontation },
        {"Tutorial", tutorial},
        {"Punk Defeat", punkDefeat}
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
