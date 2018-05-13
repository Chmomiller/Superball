using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {
    //characters appear in order
    //special include offscreen
    //{character,character,character,character,character,character,dialogue,whose talking split by a space,special, special param}
    static string[,] sceneName = new string[,] {
        { "char1", "char2", "char3", "char4", "char5", "char6", "text", "char1 char2 char3", "", "" },
		{ "char1", "char2", "char3", "char4", "char5", "char6", "text", "char1 char2 char3", "BG", "Mightmain Battle" },
        { "", "", "char1", "char2", "", "", "text","char1","", "" },
        { "", "", "char1", "char2", "", "", "text","x","", "" },

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
            "shiro full invert","shiro full invert","shiro full invert","shiro full","shiro full","shiro full",
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


























    ///////////////////////////////////////////////////////////////
    /// 
    /// SCHOLA GRANDIS
    /// 
    ///////////////////////////////////////////////////////////////
    
static string[,] scholaGrandisIntro = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {
            "","","","","","",
            "A few weeks later...",
            "Narrator","", ""
        },
        {
            "","Shiro","","","","",
            "(I haven’t seen those punks around that much. Thank goodness for that.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "Class is now over, everyone! Have a nice day!",
            "Teacher","", ""
        },
        {
            "","Shiro","","","","",
            "Yay! We’re free!",
            "Student A", "", ""
        },
        {
            "","Shiro","","","","",
            "Oh, it’s lunchtime! Finally, out of math class!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "I should go meet up with Theodore and see whether he can help me understand this math problem… Hm?",
            "Shiro","", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "My, what a boring school! It’s plain and hideous!",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "There simply aren’t enough cute things here, that’s why! Everyone and everything has the same bland flavor.",
            "Victoria", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Where are the balloons, the flowers, the pink rabbits, the kitties, the cute dresses, the cute blond boys—",
            "Victoria", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, please do not forget why we are here.",
            "Mei", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Yes, you don’t have to tell me that again. Father didn’t hire you to be my maid for that. And he surely did not make you enroll in the same school as I for that as well.",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Excuse me, but who are you?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Hmm, a plain girl! You must be a commoner.",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, please do not forget that commoners nowadays do not call themselves commoners. They like words like ‘normal’ and ‘average’ more.",
            "Mei", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(What are these girls’ deals?)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Very well, then. Miss Average Girl, how do you do?",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "I’m Elizabeth Kanasaki IV, the daughter of the CEO of the hi-tech company known as Elizabethans!",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(Whoa! Elizabeth Kanasaki! The daughter of Alexander Kanasaki, one of the tech world’s greats!)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(I can’t believe I’m looking at a Kanasaki in the flesh!)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "I’m Victoria Akiyoshi! Isn’t that a cute name?",
            "Victoria", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "And I am Mei Machida, miss. I am pleased to make your acquaintance.",
            "Mei", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "All three of us are students from Schola Grandis, a neighboring school, and we are here to conduct a tour of our competitors’ school.",
            "Mei", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(She’s so polite that it’s almost weird!)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(And her name’s fully Japanese, huh? She must be from the far western parts of Japan-America.)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "And wait, what do you mean, ‘competitors’?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Why, you don’t know? Schola Grandis has arranged a dodgeball game with your school!",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "What! That’s unbelievable! I’ve heard your school’s rather prestigious!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "I too am rather surprised, really, given that we of Schola Grandis are the best of the best. Why are we to fight punkish riff-raff from this school?",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Ah, well, the punks who were in the club have left not too long ago, so the club now has new members who aren’t punkish at all.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Hah! I might have known that they would be replaced eventually. It’s not as if that were a great accomplishment, however.",
            "Elizabeth", "", ""
        },
        {
            "","Shiro","","Elizabeth","Victoria","Mei",
            "I would think that the club is still filled with unskilled rabble. It’s… unbecoming to fight such lowly competition, don’t you think?",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Oh, Shiro! There you are!",
            "Clemence", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Wh-Whoa! You’re… You’re truly a cutie!",
            "Victoria", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "You’re truly one of the blond boys of my dream!",
            "Victoria", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Wait, what? Dream? Wh-What are you talking about? I don’t remember being in a dream!",
            "Clemence", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Come, now, tell me your name and everything about you! You’re so cute that surely there’s nothing dirty about you!",
            "Victoria", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "(And he’s blushing as well. Guess the feeling’s a bit mutual.)",
            "Shiro", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Ah! Help me, Shiro!",
            "Clemence", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Shiro? Hold it, Victoria. That boy’s said something interesting just now.",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Tell me, Mr. Average Boy, do you speak of Shiro Smith?",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Wh-Why, yes, I am! And she’s right here!",
            "Clemence", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "What! You’re the leader of this school’s club?",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Yep, not kidding you. And wait, I don’t think I’ve ever met you. How do you know my name?",
            "Shiro", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Heh heh heh… I’ve heard your name more times than it ought to be uttered, Miss Average Girl.",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, you should tell those two students the news.",
            "Mei", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Yes, yes, I know! Well, you of Salt Pitt High, know this! A match has been scheduled between our two schools, and our match will be held in two days.",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "I, Elizabeth Kanasaki IV, the president of Schola Grandis’s dodgeball club, will gladly show you why we ought to be thought the best of the dodgeball world!",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "A match!",
            "Shiro", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "A-Against you girls?",
            "Clemence", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Of course, my darling!",
            "Victoria", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, shall we head back?",
            "Mei", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Oh, yes, I have seen enough of this school. Goodbye, average folk.",
            "Elizabeth", "", ""
        },
        {
            "Clemence","Shiro","","Elizabeth","Victoria","Mei",
            "Aw, I didn’t get to get the cute blond boy’s name. Oh, well, I can always find out next time!",
            "Victoria", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Oh, Theodore! You’re right on cue!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Hmm… I see… Those three ladies are to fight us in a match.",
            "Theodore", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Oh, I know for sure they’ll be hard to beat! After all, they’re from Schola Grandis, a high-ranked school! Their dodgeball team is one of the best!",
            "Clemence", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "If you put it that way, I feel a little nervous about fighting them.",
            "Shiro", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Ah, you may feel that way, Shiro, but do be aware that here lies a chance to make an uproar in Ball City’s dodgeball scene.",
            "Theodore", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Schola Grandis is one of the most prestigious and elite schools of the city, and if we win against them, we’ll have more than a few look at us.",
            "Theodore", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "We’ll rise in the ranks much more quickly than they expect.",
            "Theodore", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Wow, really? Is Schola Grandis the school currently representing Ball City, then?",
            "Shiro", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Ah, no. It’s another school entirely, and once again, its name escapes me.",
            "Theodore", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Meanwhile, we ought to get ready for our match against Schola Grandis! I don’t want to fight them unready!",
            "Clemence", "", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Well, I think we can buy a few things first before ending things off for the day. Never hurts to have many refreshments, after all.",
            "Shiro", "", ""
        },
};


static string[,] magicalPreparation = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "Two days later, about 10 AM...",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "What a big and pretty school! I can somewhat understand why that Elizabeth girl scoffed at our school, if this school has an astoundingly good-looking garden!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Really looks more like a mansion, if you ask me. I’d like to be a student or at least a lowly gardener tending to the dear flowers here.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And I see that a lot of students from our school’s here. It helps that it’s a weekend, so they have free time.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Still, I didn’t expect there to be so many! Since our club hadn’t done much of significance, I wasn’t thinking that a lot of people would care enough to show up.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But it seems that there are a lot more Schola Grandis students. They seem excited about their team, just as a player is when he is about to declare checkmate.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But of course they are, if it is we who shall be up!",
            "???","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "I see that you’ve come! I’m shocked, actually.",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "You, the president of your school’s dodgeball club, are free to give up ahead of time. And I was sure that you would see why we are the best and would then gracefully concede.",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "I’m sorry to tell you that that won’t happen, miss.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Well, I’m happy, at least. Everyone will get to see me in my cute clothes!",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Ah, and as for you!",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "M-Me?",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "I’m really looking forward to seeing how you’ll do in the match!",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Oh, uh, thanks, I guess!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "(There’s that blush of his again.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Now, Victoria, Mei, let us leave the riff-raff.",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, may I talk to them about something? It will help you greatly if I may do so.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Hmm? What an odd request. But it’s not as if anything coming from you could help those fools. By all means, talk to them, but be back in fifteen minutes.",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Of course, Miss Elizabeth.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Miss Smith, I have some information that would help you.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Oh? Not what I thought would come from you. What is it?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "It is about my teammates. Let me tell you some key information about them.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Victoria Akiyoshi, Miss Elizabeth’s friend, may seem cute and harmless, but in battle, she knows to be serious and thus will become less cute, so to speak, if she is attacked.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Miss Elizabeth is unfortunately a very prideful girl and so will be unfocused and staggered until she is attacked, in which case she becomes steady.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "As for me, I will make sure that each of my teammates should return to normal after a while. That is all that I will say, for I wish to keep some surprises still hidden.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "W-Wow, that’s a lot of information!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Truly helpful for our fight.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "All of a sudden, I feel less worried now!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "But why? Why did you decide to tell us all of this? Aren’t you on the other team?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "I am one of your foes, but I thought it best that you be told of this, which leads me to my request for you.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "I humbly ask that you beat Miss Elizabeth in the match.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "What?! You, one of our opponents, are asking us to beat your mistress!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Yes, that is correct. She has been acting wrongfully and thinks herself high and mighty, as if she were a titaness.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Therefore, only a loss will put Miss Elizabeth back in her place.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "I-I see… Could I ask you something, Mei?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "What is it?",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Do you even like working for Elizabeth?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "…… She is one of the most naive and difficult people to work for. There is no day at the end of which I do not feel tired and exhausted from having watched over her.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "If you don’t like working for her family, then why haven’t you quit?",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "I appreciate your concern for me, but it is unneeded and unjustified.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Oh? What do you mean by that?",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "… When my two younger brothers and I lost everything, Elizabeth’s father, a great man in many ways, saved us.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "He gave us shelter and food, and my brothers and I had at last found a place wherein we could stay, though the cost was a life of servitude for me...",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Do you see now? Though Miss Elizabeth is a troublesome girl, we cannot leave her family, for there is nothing but the wide world and cruel misfortune for us.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "…… I… I see.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Oh… I-I can’t bear to hear such a sad story as that!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "… May I leave now? Miss Elizabeth will chide me for being late if I tarry.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "That’s all I want to ask you.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Thank you, Miss Smith.",
            "Mei","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "… Wow. I didn’t expect that maid to have that kind of story.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "… It does rend my heart a little that we can’t do anything to help her, especially when she herself won’t let us help her. … But we can do one thing for her.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And that is?",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Fulfilling her request to beat Elizabeth, of course! Come on, let’s go ready ourselves and then go into the gym!",
            "Shiro","", ""
        },
};


static string[,] magicalMatch = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Schola Grandis Gym"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Ah, the audience is staring at us and talking to each other excitedly. No wonder, when we’re going up against a prestigious school!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "The other team hasn’t come yet. Those girls must be getting dressed.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I do wonder what kind of foes we’ll soon face. There’s something odd about those girls for certain. I don’t think they’re just girls who become overconfident because of their higher status.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Their bark can’t be stronger than their bite, you mean?",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Ah, I see them coming. Ready yourselves.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Hello, everyone! I am very glad that you could make it today!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Whoa! What in the world is with your funny clothes?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Yeah! You look like… princesses! W-Wow…",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "You have the right idea, but more clearly, we are… magical girls!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Wh-Whaaaat?! Magical girls!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "They totally look like magical girls on TV!",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Heh, look at Salt Pitt. They’re shocked by our dear Elizabeth!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Go, Elizabeth!",
            "Student C","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Why are you so surprised? If you’d done your research, you would’ve learned of what makes us number one, Miss Average Girl!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "No need to boast, Elizabeth! It’s so sad to see the cuteness of one’s clothes be smeared by such words.",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Remember that your father wants you to keep a cooler head, Miss Elizabeth.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Wait… Theodore, did you know about this?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Of course. I asked Cygnus, my friend, to ask some Schola Grandis students about the team, and they told him some ever so interesting details of the grand school’s dodgeball team.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "I was rather surprised when he told me them, to say the least.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "What?! Why didn’t you tell us beforehand?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Of all the things I had heard of the dodgeball world, it was one of the least believable for us.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "We weren’t sure whether they were joking, and I wanted to surprise myself, so I chose not to look it up online. That, and your reactions were worth seeing.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Oh, Theodore! Knowing this beforehand would’ve helped!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Excuse me for interrupting, but may we begin? Everyone has come here to watch us play and not to watch you bicker.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "You’re right. And we can still take them on, even if they’re in their weird get-up.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Weird? How dare you! You’ll pay for having insulted our extraordinary, exquisite, and expensive magical girl gear! You shall be beaten by me, Elizabeth Kanasaki IV!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "My cute magic shall overwhelm you!",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "And I will fight as best as I can for my masters of the House of Kanasaki!",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "(What weird magical girls…)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Theodore, Clemence, are you ready?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "………….",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "W-Wow. So that’s what that Victoria girl looks like…",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "I’ve seldom seen him blush that much, you ought to know.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Don’t worry about me, guys! I’m, uh, getting ready now...",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Uh, all right, then. Let’s begin!",
            "Shiro","", ""
        },
};
    
static string[,] scholaGrandisDefeat = new string[,]{
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Wh-What is this! I… I’ve lost? No, no, no! This is all wrong!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Aw, my uniform’s all dirtied!",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Hurray for Salt Pitt!",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "No! Our Elizabeth can’t have lost!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Oh, thank goodness! I was afraid their magical girl powers would beat us!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, please calm down. The match is over, and your father will appreciate it if you accept your defeat humbly—",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Magical girls aren’t supposed to lose! Haven’t you watched those shows?",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Many times. Your father even paid the school some money to set up those special effects on the stage, that our magic might be realized.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "No… No! I can’t accept this! I’m Elizabeth Kanasaki IV, daughter of the CEO of Elizabethans!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "I… I refuse to acknowledge you as the winner!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, please calm down.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "No! This isn’t fair! I… I demand a rematch!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "What? A rematch? Just accept your loss already!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "…… Elizabeth. She’s won the match. No doubt about that.",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "What? Not you, too, Victoria!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "This can’t be... Everything I’ve done has fallen apart... How…",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","Elizabeth","Victoria","Mei",
            "HOW DARE YOUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU!",
            "Elizabeth","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Victoria","Mei",
            "No, Elizabeth!",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Victoria","Mei",
            "We must help her at once!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Victoria","Mei",
            "Wh-What’s just happened?!",
            "Victoria","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "…… Miss Smith. I thank you and your team very much for fulfilling my request. I cannot tell you how grateful I am.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "I will tend to Miss Elizabeth, hoping that she will learn to have some humility.",
            "Mei","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Mei","",
            "Now… May we meet again in happier times.",
            "Mei","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And that’s the end of that. Elizabeth Kanasaki’s gotten her just deserts. And I hope that Mei and her two younger brothers will live happier lives.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "The people sure are happy about our win, Shiro!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But of course! Salt Pitt High has just beaten a prestigious school!",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "With such a victory as this, I say that we go out for some celebration!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "One of the restaurants of the Blue Ribbon—the ever so reliable cooking school—is nearby.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Sounds good to me!",
            "Clemence","", ""
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
            "The school’s proud of me and the others for winning, now that we’re above Schola Grandis, a very prestigious school!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "We’ve climbed up the ranks, and everyone was giddy upon talking to me after the match. Because of our win against such a school, more schools are eyeing us, so we ought to expect another match soon.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "I’m still not fully sure on how things will turn out for me. Though we won, the match had been tough and difficult for me. I can only wonder with dread what the higher-ranked schools are like.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "And I may even see you soon. I’d like for us to have some fun together later. I hope that you’re doing well.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "", ""
        },
};
















    ///////////////////////////////////////////////////////////////
    /// 
    /// MIGHTMAIN
    /// 
    ///////////////////////////////////////////////////////////////





        
static string[,] mightMainIntro = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "","","","","","",
            "Weeks later, when students now head home...",
            "Narrator", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh, there are lots of schools in Ball City, I tell you! We have a population of nearly nine million people, after all!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I still can’t believe it’s a city that big!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "You ought to check out the city with me. I know of a few interesting sights.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Maybe some other day.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I hope it’ll happen before we meet our new competitors. But I do suspect it won’t be long to see them.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "You’re darn right it won’t be long!",
            "???", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "It’s you three!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Wh-What are you doing here?",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "I hear you gave those magical girls a beating a while ago. I must say, I thought for sure that your match against Schola Grandis would end badly.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Yeah, but you won! That made me almost fall off my chair when I heard the news!",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "And how couldn’t we hear about it? The school’s been shoving it in our faces!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Greg’s annoyance set aside, I, the Pitt Crew’s leader, have not forgotten the minute when you stepped onto our turf and gave us a most humiliating loss.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "I’ve been waiting for a right day to fight you again. With your latest wins against some other schools, I feel that that day is now.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "How well spoken of you, boss!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Well, duh! A leader’s as good as his words!",
            "Frank", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Trevor, I do wonder why you continue your petty acts.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Oh? Whatever do you mean?",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "However much of a punk you may be, doubtless you are a smart fellow with many fine points. You could be using your intelligence for something more productive, like helping the city.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "But instead, you choose that hollow life. Why?",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "… I have seen many things that make me who I am today. I have grown weary and tired of living under the wants of others.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "What I want is to be free, to be my own self. You may call it no good, but your eyes will stay shut to the truth.",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Shut? You have a responsibility to use your freedom to help others. As a society, we must care for each other.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "And you’ve truly done no good. Even if you haven’t run afoul of the law, you still have hurt others.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "……...",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "(He looks a bit surprised… Is he taking his words seriously?)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "…... Hmph. What utter nonsense you spew out of that dumb mouth!",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "I was hoping that this wouldn’t happen. But alas, it did, and now he must be stopped.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Shiro, you needn’t worry. We can handle the porcupine and his gang.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Are you sure about that? Greg, Frank! Take care of them!",
            "Trevor", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Yes, boss! One, two, three, go!",
            "Greg", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Oof!",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Trevor","Greg","Frank",
            "Gah!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "Theodore! Clemence!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "They interfered with our fight last time. It’d be bad for me if that were to happen again, I thought.",
            "Trevor", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "That thought of yours was pretty smart, boss!",
            "Greg", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "My men only wanted to play dodgeball with those two. It so happens that they weren’t ready for their throws. A pretty big shame, isn’t it?",
            "Trevor", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "That’s a bunch of crock, and you know it, you scoundrel!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "That doesn’t change the fact that it’s now just you against us three. Now it’ll go as we first wanted that day.",
            "Trevor", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "(Oh no… What should I do? I can’t run, and I certainly don’t want to leave my two friends! And those punks mean serious business!)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","Trevor","Greg","Frank",
            "Worry not, miss! We two will deal with those no-good punks in no time!",
            "???", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "(Whoa! Who are these two?! They look like they’re from the military, and the guy’s handsome, to boot!)",
            "Shiro", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "I’m Harold Kuga! I’m a hero who will save any citizen in danger!",
            "Harold", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "And I’m Skylar Hata. I’m just a girl who knows him.",
            "Skylar", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "And we two will not let you terrorize this girl and her friends!",
            "Harold", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Oh? What’re you going to do?",
            "Trevor", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Miss, you were about to go against those three by yourself. But we two have come, and we’d like to fight alongside you!",
            "Harold", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "This shouldn’t take long. I estimate that it will take only a few minutes.",
            "Skylar", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "(W-Wow, they’re even asking that they fight with me! This is wonderful!)",
            "Shiro", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Oh, yes, by all means, please help me deal with those guys!",
            "Shiro", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Thank you, miss! Now, let’s get down to it!",
            "Harold", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Gwah! Wh-What’s this, now?!",
            "Trevor", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "As I thought. You may take off well at first, but when the going gets tough, you fall and crash.",
            "Skylar", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "(W-Wow… The guy’s as strong as he’s handsome, though the girl’s a bit cold. Who are these two?)",
            "Shiro", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Boss, we’d better hightail it out of here!",
            "Greg", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Yeah! We can’t beat her with those two around!",
            "Frank", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "…… It seems that my judgment was wrong. Payback is instead on another day.",
            "Trevor", "", ""
        },
        {
            "Skylar","Harold","Shiro","Trevor","Greg","Frank",
            "Mark my words, Shiro Smith, I, Trevor Akuouji, will take my revenge one day.",
            "Trevor", "", ""
        },
        {
            "","Shiro","","","Harold","Skylar",
            "Miss, are you okay?",
            "Harold", "", ""
        },
        {
            "","Shiro","","","Harold","Skylar",
            "Oh, yes, yes, I am! Thank you very much for helping me against those punks!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Harold","Skylar",
            "I don’t know what would’ve happened if you guys hadn’t come!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Harold","Skylar",
            "By the way, are those two fellows behind you your friends?",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Ah, I should’ve never let my guard down! How dishonorable that man is!",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Oh, thank goodness you’re okay!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Oh... The punks would just know better than to bother us ever again. Too bad their leader’s pretty mean and spiteful.",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Don’t worry about them! If they try to do their heinous deed again, I’ll be sure to teach them a good old lesson!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Well, thank you very much for saving us. Who are you, if I might ask?",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Ah, I haven’t fully introduced myself! I’m Harold Kuga, a student of the army branch of our school.",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "And I’m Skylar Hata, a simple girl of the air forces branch. Both of us are members of Mightmain Academy’s dodgeball club.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Wait! Mightmain Academy?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Mightmain Academy… That’s the same school that my older brother goes to!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Wh-What?! Your brother’s in the academy, you say, Shiro?",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Shiro! Ah, that name! By any chance, is your brother’s name Kuro Smith?",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Why, yes, he is! Do you know him?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Oh, not only do we know him, but he’s the very reason we’re right here!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "A few hours ago, he asked us to find his sister, since he was busy.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "He wanted us to deliver you this news beforehand: he had had Mightmain Academy arrange a match against Salt Pitt High!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "What?!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "A match! But how did he arrange such a thing? Even Shiro, our club president, may not tell the school to arrange a match.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "That’s easy to answer! Kuro’s not only our dodgeball club president but also a navy student of the rank of admiral!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Each of our branches has its ranks, and the higher one goes, the more benefits and rewards one gets. It’s supposed to motivate us to work hard. That’s nice, I guess.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Oh, Skylar, you really need to sound more energetic! Those headphones really dull you!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "If that means sounding like you, I say no a thousand times. Besides, I’d spoken like this long before I got these. And you know how much I value these headphones.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "What?! Why, you...",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "(A fight… against Kuro… I-I can’t believe this. What made him arrange a fight with me?)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "(When I said that I might see him soon, I wasn’t exactly thinking of this! Kuro, what are you up to?)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "(…… There’s only one way to find out.)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "I… I accept the challenge. I’ll go up against my older brother.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "What?! Are you sure, Shiro?",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Well! I definitely did not expect this to happen. If truth be told, I’m a bit worried about our chances this time.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "That’s why you ought to do this thing called practice! That’s how you go places!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "You’ll be facing against us Saturday at 11 AM. Use your time wisely.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Thank you for the tip.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Aw, Theodore, would you look at that! Our competitors are pretty friendly this time! They’re like those guys at Barrow Temple. Lucky!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Well, it’s about time we headed back to Kuro and told him that the message has been delivered.",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Harold","Skylar",
            "Goodbye, Miss Shiro. I’m looking forward to our fight!",
            "Harold", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Well, would you look at that! Another school will be fighting us. It really didn’t take long for our next competitors to appear.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "… We have time to train until the weekend comes. We can’t waste any time. Shall we start tomorrow?",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow, you sound more serious than you usually are.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I guess it’s one thing to fight rival schools, but another to fight family.",
            "Clemence", "", ""
        },
};
    
static string[,] militaryFight = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "A few days pass, and it is now Saturday morning...",
            "Narrator", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "(Today’s the big day! I’ll be going up against Kuro! We’ve trained all week for this, and we should be able to withstand him.)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "(Still, I wonder why he’s done all of this…)",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Don’t worry, Shiro! Everything will be fine… I hope.",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Not exactly a source of confidence, are you?",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Anyway, Cygnus, my good friend, has done some research into the team.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Mightmain’s team uses special suits that the military made with the Witship Institute, that ever so great science academy.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "What?! They have special suits? The military has special suits designed only for dodgeball? You’ve got to be kidding me!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I jest not, I fear. And moreover, Harold Kuga will have some kind of gun, Kuro Smith some kind of cannon, and Skylar Hata some kind of missile.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Weapons are not forbidden in the game, as long as they do not seriously injure players. That’s why the government also had special weapons for dodgeball designed.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh, this I wouldn’t believe if it weren’t you telling us!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Alas, we have no such gear. There’s no point in bemoaning our lack of upper hand in Mightmain’s field, however.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "We must make do with what we have, and we may still win. Even the flow in a game of chess changes as quickly as our fickle feelings.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Th-Thanks for the advice, Theodore.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Hmm… You look more unsettled than usual. Are you still sure of yourself about fighting your brother?",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "O-Of course I am! I may be the younger sibling, but I can show him that I can stand a chance against him!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I want more than that from you, Shiro!",
            "???", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Th-That voice!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Kuro! Big brother!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Oh, Shiro, it’s been a while since we last saw each other in the flesh! I’ve gotten your letters, and I’m glad that you’ve been doing well!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "You’re Shiro’s brother, you say? If truth be told, I thought of someone taller and sterner when I first heard of you.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Heh, who told you that? We’re tall, but stern we’re mostly not.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "What made you join the navy?",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "I’ve always liked the idea of working at sea. Shiro, however, likes to stay on land.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "In many ways, we go against each other. Even our names show that.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Kuro… What pushed you to arrange this fight?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "… I’ve told you that I’ve gotten your letters. You’ve picked up dodgeball again and have made a bit of a name for yourself by beating such schools as Schola Grandis.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "You’ve clearly improved. And yet you still feel uncertain about your future with it.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "There’s one way to help you decide whether you want to go along with this any longer.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Shiro… know this: I plan to push you hard in the fight to test your heart and soul.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Have you the will to make it to the top of the dodgeball world? That answer is what I want to see.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "…...",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Well, I must get going! I must go prepare with Harold and Skylar. They’re two close friends of mine, and if truth be told, I, uh… have some special feelings for Skylar.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "I can tell you more later once all of us go out for a nice after-game meal.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Oh, that sounds nice!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Kuro… I see.",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Shiro, are you all right? You look speechless as if you had just realized your moves that have threatened your king.",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Yes… In fact, I feel a lot better now. Come on, let’s go get ready as well.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Mightmain Academy Gym"
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "(Ah, Kuro’s team is already here! Like before, Harold’s wearing some scary gear, and Skylar’s boots look like planes!)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "(But Kuro… doesn’t have any special armor. Only a sword and what I think is a cannon. Huh.)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Sorry for being the odd man out, Shiro. I don’t have armor.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "But I don’t need it, since I find it too limiting on me. My weapons here are enough.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "With my boots, I am sure that I won’t be hit that much. It’s nice I can fly around in these things, albeit ever so briefly.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "You’ll soon behold the might of my gear!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Of course, we three can fight just as well without our special weapons and gear. But it makes the crowd go crazy, so we often wear it.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Well, we’ve delayed this game long enough. Let’s begin!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Yes, let’s begin!",
            "Shiro", "", ""
        },
};
    
static string[,] yamatoBattle = new string[,]{
        {
            "","","","","Harold","Skylar",
            "O-Oof... I’m beaten!",
            "Harold", "", ""
        },
        {
            "","","","","Harold","Skylar",
            "Gah!",
            "Skylar", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I-I can’t believe I’ve beaten them on their own turf!",
            "Shiro", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Indeed! Their special gear must have done a number on them!",
            "Theodore", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Those two are too tired to even get up from the bench!",
            "Clemence", "", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Surely we’ve won now! … Wait.",
            "Theodore", "", ""
        },
        {
            "","","","","Kuro","",
            "Huff… Huff...",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Y-You’re still standing! Even after all those blows?",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "…...",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Heh heh… You’ve certainly surprised me, Shiro! Even for you, my dear sister, you’ve pulled off a feat greater than what any of us have imagined!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "You’re the only one still standing, and your teammates are too tired to stand back up.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Only a matter of time before you’ll fall as well, and the game ends.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Heh, yes, this game will end soon. But as long as I stand, it’s not over.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Let me assure you that this game will end off on a blast!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Huh?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Admiral! She’s been checked, and she’s ready to go!",
            "Military Student", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Heh, right on cue. All right, I’ll send her in.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "‘Send her in’? Uh oh.",
            "Clemence", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Mightmain Academy Gym"
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Wh-Wh-Wh… WHAAAAAAAAAAAAAAAAAT?! What in the world is that doing here?!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "This is the JAS Yamato, my trump card.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "JAS stands for Japano-American Ship, and once a great warship, she’s been repurposed to serve us in the dodgeball field!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Whoa! He’s climbed up that rope and jumped onto the ship! Incredible!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Heh heh heh... It was painful to practice that move, you should know!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "I can’t believe this! Shiro, your brother planned for this to happen!",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "She’s so big that I can’t help but tremble!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "I warned you, Shiro, that I would test your will to the fullest.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Now, can you still beat me, even with my dear ship? With her, I can at last fight with might and main!",
            "Kuro", "", ""
        },
{
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "... Oh! Shiro, look around! Look at the audience!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "What? … Ah! It’s not only our students and Mightmain ones!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "I see students from many other schools as well! They must’ve come to cheer us on!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "A most marvelous sight!",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Oh, a lot of people won’t be forgetting this match!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "It’s odd. I feel that this is a good sign for our future.",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "(Our future…)",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Can I still beat him?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "... There’s only one way to find out.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Shiro! If you say so, then I’ll fight as well!",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "And so will I! Everyone’s watching and backing us up, so we’re not alone!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kuro","",
            "Thanks, guys! Now, let’s get to the end of this game!",
            "Shiro", "", ""
        },
};
    
static string[,] mightmainDefeat = new string[,]{
        {
            "","","","","Kuro","",
            "Gwaaaah! My ship!",
            "Kuro", "", ""
        },
        {
            "","","","","Kuro","",
            "She’s been beaten! Unbelievable!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "He’s outside now! Get him, Shiro! ",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Right! Take this, Kuro!",
            "Shiro", "", ""
        },
        {
            "","","","","Kuro","",
            "Whoa! My balance! I’m about to fall off the deck!",
            "Kuro", "", ""
        },
        {
            "","","","","Kuro","",
            "Aah…. AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "I… I can’t believe it! We’ve won! We’ve won! We’ve won!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "I can’t believe it, too! We beat your brother, and he used a battleship against us! And even with his last-minute weapon, he was no match for us!",
            "Theodore", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "Now this was a fight that had to be seen! I can’t wait to tell everyone who’s not here about this!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "They may not believe it at first, but I, Clemence Kadou, will swear to them that this indeed did happen!",
            "Clemence", "", ""
        },
        {
            "Clemence","Theodore","Shiro","","","",
            "…… Kuro? Kuro!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Kuro! Are you okay?",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Wh-Why, Shiro... of course I am!",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Oh, Kuro, you really should just admit that you’d like nothing more than to lie down and rest!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "He’s fine. I was as worried as you the first time he got hurt badly, but you’ll be left wondering at how strong his will is.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Heh heh! Shiro, you too have a strong will, having beaten me, Skylar, and Kuro, even with his trump card! You deserve my praise!",
            "Harold", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "And you mine.",
            "Skylar", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Ah, Shiro… I take it that you’ve come to the answer.",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Yes, I have. I feel unsure no longer.",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "Then I truly have done you good. And listen! Do you hear the crowd?",
            "Kuro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            " All the students are cheering my team’s names! Even the ones from your school are cheering!",
            "Shiro", "", ""
        },
        {
            "Clemence","Theodore","Shiro","Kuro","Harold","Skylar",
            "But of course we are! We know a good match when we see one!",
            "Harold", "", ""
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
            "My life right now is great, as the school sure feels more familiar and friendly, and Salt Pitt High’s gotten quite a bit of attention in the news.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Clemence is really happy about it, while Theodore is his usual cool and calm self. We’re all doing fine.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "I’ve been doing some more thinking about the future. I now feel so sure of myself that I find myself dreaming about it.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "I dream that our team will become Ball City’s representative team for the nationals. It’s a pretty big dream, as there are still so many schools in Ball City that we will have to beat.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "But you and I can dream big, right? And though we may not reach our goal, we will have found great happiness along the way.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "That’s what you told me a lot years ago.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "I’d like to live up to those words soon.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "", ""
        },
};


//The chef’s invitation
static string[,] blueRibbonIntro = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "","","","","","",
            "A few days later, on Saturday morning…",
            "Narrator","", ""
        },
        {
            "","Shiro","","","","",
            "(Salt Pitt High isn’t too bad a school. It’s plain and could be much better, but I can make do with it.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "(And come to think of it, I haven’t seen those punks at the old gym. Hopefully, they won’t cause any trouble if I see them later.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "(Ah… I’d better walk around Ball City and see what I can do for fun here. I can’t stay in my apartment all day.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Clemence","",
            "Hey, Shiro! Nice meeting you here this lovely weekend!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Clemence","",
            "Want me to buy you a treat?",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Clemence","",
            "Hmm… I don’t want to burden you like that. It’s not right to make others spend their money on you, you know?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Clemence","",
            "Burden? Oh, no sweat! It’ll be cheap!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Clemence","",
            "A friend of mine is selling all sorts of pastries in a food truck at a nearby street! A lot of other students are there, too!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Clemence","",
            "What?! How often does this happen?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Clemence","",
            "Every Saturday. Now, come on, let’s check it out!",
            "Clemence","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Wow, a lot of students from the school are here! And a lot of young kids as well!",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Now, now, everyone, my crew and I are still preparing.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Could you please wait for a few more minutes? We’ve set up those tables for you!",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Of course, Miss Lily!",
            "Student A","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "We’ll gladly wait as long as you want!",
            "Student B","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "That baker is Lily Yaku. She’s a student of a cooking school called the Blue Ribbon.",
            "Clemence","", ""
        },
            {
            "Clemence","Shiro","","","Lily","",
            "The Blue Ribbon? That name sounds a bit familiar.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "The Blue Ribbon’s nothing big in the dodgeball scene, but it’s often at the upper half of the cooking rankings.",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Believe you me, they have really skilled cooks!",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Lily herself sets up a mobile shop supported by her school. What’s more, she’s one of the members of the Blue Ribbon’s dodgeball club!",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Wow, really?!",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Okay, everyone! We’re all done now!",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Please group yourselves into twos, and choose which you’d like to get, but be gentle!",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Now what would you like?",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "I’d like the pretzel, please!",
            "Student A","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "And I’d like that chocolate cake!",
            "Student B","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Here you go!",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Thank you very much, Miss Lily!",
            "Student A","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Oh, you’re too kind! Enjoy!",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Now, who’s next?",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "The rice bread, please!",
            "Elementary Student A","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Yeah! What he said!",
            "Elementary Student B","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Of course, dearies! And since you’re not in middle school yet, you get to have them for half-price!",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Awesome!",
            "Elementary Student A","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Thanks very much!",
            "Elementary Student B","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Now, who’s next?",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Hi, Lily! Nice day, isn’t it?",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "(Hmm? They sound like they’ve known each other already.)",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "You know her, Clemence?",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Yeah! I’ve been buying goods from her family for years! Her family’s shop is close to my home.",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Clemence is a dear boy. He once gave us flowers to make the shop look better.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Wow, that was rather kind of you, Clemence!",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Oh, who would think otherwise?",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Now, Clemence, may I ask you something before I take your order?",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "What is it, Lily?",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Do you know a girl named Shiro Smith? I’ve been asked to look for her, and heard that she lives around here.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Why, that’s me!",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "My goodness! Are you truly the one who beat your school’s dodgeball club and became its new leader?",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "She sure is, Miss Lily!",
            "Student A","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "I saw the match, and man, it was wild!",
            "Student B","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Shiro gave those goons the beating they needed!",
            "Student C","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Oh, everyone, you don’t have to put it that way! It wasn’t a big deal!",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Anyway, Lily, why are you looking for me?",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Nothing scary, dearie. I have a letter for you.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Let me see…",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Dear Shiro Smith, I am the president of the Blue Ribbon’s dodgeball club.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "I have been informed by my school that it has arranged a dodgeball fight with your school, Salt Pitt High.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "I hear that you have done a most impressive act of ousting questionable figures from the club. Perhaps that is why you have caught the Blue Ribbon’s eye.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Tonight, we shall have our dodgeball match. I do apologize for its being so sudden, but that is how things go in the hectic world of dodgeball.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "But before our match, I invite you and your team to have dinner at the Five, a restaurant on the Blue Ribbon’s school grounds.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Everything shall be on the house, so you may get what your heart likes. The dinner will start at 7:00 PM.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "From, Morgan Kaimoto.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Dinner? At one of your guys’ restaurants! Th-That’s unbelievable!",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "And we’ve been challenged to a fight! My first fight as dodgeball club president! I can’t believe it!",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Oh, I don’t like how sudden it is, but if you don’t show up, you’ll automatically lose.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "If I’d been in charge of arranging the game, I would’ve given you more time.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Oh, I don’t like this one bit! Fighting the dodgeball club of a great cooking school will definitely not end well!",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Hmm… If we have to go, then we might as well have a good dinner to go with it.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Great! Now, shall I make you a nice Italian sandwich? It’ll be on the house.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "An Italian sandwich? I’ve never had one before. Go right ahead.",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Lily","",
            "Great! Wait at a table, and I’ll take it to you.",
            "Lily","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Oh, Theodore! What are you doing here?",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "I’m passing by to see a friend of mine. Are you here for that baking lady?",
            "Theodore","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "We sure are! But, Theodore, you have to hear this!",
            "Clemence","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Our match is tonight, huh? A very shocking move, indeed.",
            "Theodore","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Oh, I know for sure its team will be hard to beat! They’re good not only at cooking but also at dodgeball!",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Dodgeball is big in today’s world, so even schools meant for only certain fields train themselves in dodgeball!",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Is it good that we’ll be fighting who I guess are cooks?",

            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Certainly! This is our, Salt Pitt High’s, chance to rise in the ranks of Ball City’s dodgeball scene.",
            "Theodore","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "It being a big city, there are many schools that fight each other, that the winning school may become Ball City’s representative in the national competition.",
            "Theodore","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Wow! What’s the school representing Ball City?",
            "Shiro","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Ah, the name’s gone from my head for the moment. I’ll tell you later.",
            "Theodore","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Oh, thank goodness I’m free tonight! If I weren’t, I’d be worrying about how my plans could work out!",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Still… I don’t feel great about this. I sense something foul.",
            "Clemence","", ""
        },
        {
            "Clemence","Shiro","","","Theodore","",
            "Oh, Clemence, there’s nothing to worry about! I’m sure things will be fine.",
            "Shiro","", ""
        },
};

    //Dinner time
static string[,] dinnerTime = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "A few hours later, around 6:40 PM...",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow, the Five looks gorgeous! The flowers, the steps, the fountain… it’s great!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Is it, really? It’s actually rather mundane in comparison to the truly fancy restaurants in Ball City.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Now those I would go to often, before my parents found themselves in a little financial problem. Since then, we’ve been a bit more frugal.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "(Now that I think about it, Theodore looks the most well-off of us three. I should’ve figured he’s more on the rich side of the scale.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Even then, I’d give much to dine at a nice restaurant, were it ever so short!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "... Oh, those two guys are coming to us!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "Bonsoir, messieurs et mademoiselle. I see you’ve finally come at last.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "I am Morgan Kaimoto, the chef who invited you to come feast here tonight.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "Hello! I’m Ash Nikumaru, one of the cooks happy to cook for you tonight!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "Pardon my companion. He’s not a bad cook, but he tends to be excited over nothing worth his attention.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "Moreover, he would listen to me, if only he had put as much energy in using his wits as he does in using his voice.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "(Wow, this guy’s rather harsh! Wouldn’t want to work with him!)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "The match will be awesome, I tell you! And this is the perfect place for us to duke it out!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "And now that we’re talking about places, Ash...",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "Go back to your station already! If you wish to make your service better than mine, then tell your plan to your teammates! Immédiatement!",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","Ash",
            "Eep! Of course, Morgan!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","",
            "Ugh… Only I was supposed to welcome you.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","",
            "But, no, that hot-headed cook insisted on coming with me. His potential is hindered by his utter lack of good wits.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","",
            "Uh, could we go inside already? It’s a bit cold tonight.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","",
            "Yeah, and I’m really hungry! My stomach can’t wait to see what the Blue Ribbon can cook up!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Morgan","",
            "You shall be astounded tonight. Veuillez me suivre, s’il vous plaît.",
            "Morgan","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Here are your seats, gentlemen and lady.",
            "Waiter","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Ooh, I feel so important here! Sure, it may not be all that fancy, but I haven’t been in this kind of place before!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Hmm… How curious. The other patrons are our fellow students, as well as students from the Blue Ribbon.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Are they following us to see the match?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Ah, tonight, for the other customers, the prices have been halved. The Blue Ribbon would like many people to watch the match.",
            "Waiter","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Now, what’ll you have?",
            "Waiter","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Awful! Terrible! Épouvantable! Can’t you tell this is undercooked?! Do it again!",
            "Morgan","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "O-Of course!",
            "Cook A","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Let me tell you, if you feed that thing to someone, it will, look at me, kill him!",
            "Morgan","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Start all over again!",
            "Morgan","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Eek! Yes, sir!",
            "Cook B","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow, Morgan’s as loud as that Ash guy when he’s harsh!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "The other students are laughing at it, but I don’t see what’s so funny about that voice! It really makes me shiver!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Aah! Come on, men, keep it up! We’re almost done with it!",
            "Ash","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But, Ash, you’ve forgotten to add the seasoning!",
            "Cook A","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "No! Give it to me, then! Quickly, quickly!",
            "Ash","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But I’m using it right now!",
            "Cook B","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "No one shall stop me from making my masterpiece! I’ll show you!",
            "Ash","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh no!",
            "Cook C","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "It doesn’t seem any better on that side, either.",
            "Shiro","", ""
        },
};

 //   The cooked up match
static string[,] cookedUpMatch = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Well, tell me, did you enjoy the dinner?",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Yes, it was wonderful!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Ooh… I’m glad to have eaten those dishes, but I do feel a little full.",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Yes, I can’t say that it was by any means bad, but...",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Hah! It gladdens me to see that you enjoyed that masterpiece of mine.",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Morgan, everything’s ready now. Let’s go.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Uh, where are we going now?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Hmph. If you haven’t realized it already, then you will soon see.",
            "Morgan","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Blue Ribbon Gym"
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Welcome to the Ballers’ Kitchen! This is the gym where our matches are held!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Wh-What the! A gym, you say?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Is the match going on now?",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Pretty nice to have some food before the fight!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Ooh… Oh no! I feel a little funny!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Hmm, I feel something unpleasant as well.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Wait, was that their plan all along? Stuff us with food before the fight?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Oh, now you’ve realized it! How long was the smoke blocking your eyes?",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "I can’t believe it! They cooked up this little trick of theirs! This isn’t fair!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "La vie n’est pas juste, mademoiselle.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Personally, I would have gone with something quicker and less tricky! But Morgan decided that this should be the plan.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "I am a little unsteady, but worry not, for they haven’t put us at checkmate.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "No, no, no… I should’ve known this was too good to be true!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Oh, what’ve I done? I could’ve avoided this, but here I am, feeling staggered!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Clemence! Don’t think about what we could have done.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "But...",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "You won’t feel better by thinking like that. Instead, focus on what can be done!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Focus… on what can be done…",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "I… I think I can try.",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Do! We still can win, even though we don’t have the upper hand!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Hmph! You are naive little fools if you think you can beat us.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Nothing about you impresses me. Just save yourselves the embarrassment and leave!",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Now, now, let’s all have a friendly match! I’ll be sure to help both of you, okay?",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "And I’ll show all of you how hot and wonderful my masterpieces are! I have put all my heart into them!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Hmph. If you’re truly hungry for some more, then here! Bon appetit!",
            "Morgan","", ""
        },
};

 //   Cook defeat
static string[,] blueRibbonDefeat = new string[,]{
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "What’s this, now? I… I can’t have lost!",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "What have I done wrong? I can’t have been made the fool! I can hardly believe it!",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "No! My masterpieces! They’ve been beaten! I don’t believe it!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "A-All right! Theodore, Clemence, we’ve won!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Salt Pitt High’s won this match!",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "No! How could we lose on our home turf?!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Heh, I’d like to say that that was one flavorful match. For a moment, I thought we were in great trouble.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "I… I can’t believe it. Have we truly won? It must’ve been luck!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Luck? Think of it as faith, Clemence.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "A weak mind makes weak work. That’s why you need to have more faith in yourself.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Faith? I can feel it now, but it’ll be hard to keep it up, Lily.",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Well, let me tell you, life is not easy. It takes work to get the things you want.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "You’re a hard-working boy, Clemence. I’ve seen your works. I’m sure you can do it, if you have even a slight bit of Ash’s spirit.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "I do have a lot of blood rushing through me! It’s not too hard to keep up your spirit once you have a lot of it, I tell you!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Well… If you really say so, then I’ll try!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "… Well done. That’s the only thing I’ll say.",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","Morgan","Lily","Ash",
            "Now then... Au revoir!",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Lily","Ash",
            "Now then... Au revoir!",
            "Morgan","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Lily","Ash",
            "Oh, he’s not taking his loss well.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Lily","Ash",
            "But don’t worry about him. I’ll talk to him later.",
            "Lily","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Lily","Ash",
            "I myself am pretty shocked about our loss! But it just means that I must get better!",
            "Ash","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Lily","Ash",
            "(What a way to end tonight! I feel rather tired now...)",
            "Shiro","", ""
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
            "I got my first official match since I had become the dodgeball club president, and it really surprised me a lot!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "We were up against the Blue Ribbon, a cooking school, and the cooks gave us dinner before our match.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "That made us feel a little unsteady at first, but we won in the end, and we got a free dinner as well!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Because we’ve won against the Blue Ribbon, we’ve risen in the ranks, and according to Theodore, a teammate of mine, we’ll hear of our new actual ranking later.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "I wonder what my next match will be like.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "", ""
        },
};





//    The Witship Institute
//    Old friends reunite
static string[,] witshipInstituteIntro = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {
            "","","","","","",
            "A few days later, on Wednesday noon…",
            "Narrator","", ""
        },
        {
            "","Shiro","","","","",
            "All right, it’s now lunchtime.",
            "Narrator","", ""
        },
        {
            "","Shiro","","","","",
            "I should probably study for my math class. Algebra isn’t the easiest thing in the world!",
            "Narrator","", ""
        },
        {
            "","Shiro","","","","",
            "Excuse me.",
            "???","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "(Hmm? Who’s this boy? He looks rather young and handsome.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "Do you know where Theodore Yukimura is, by any chance?",
            "Cygnus","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "Theodore? Ah, the Chess Club president, you mean?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "Chess Club president?",
            "Cygnus","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "… Heh. So that’s what he’s become.",
            "Cygnus","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "Uh, shall I take that as a yes?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "Oh, yes, I’m very sorry for my lackluster answer!",
            "Cygnus","", ""
        },
        {
            "","Shiro","","","Cygnus","",
            "Anyway, I’ll gladly show you to him. He’s at the library.",
            "Shiro","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {
            "","","","","Theodore","",
            "Now, I’m afraid you’ve fallen into my trap. I can now use my knight—",
            "Theodore","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Uh, Theodore? Someone’s here to see you.",
            "Shiro","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Oh, Theodore, it truly is you! Long time no see!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Wh-What? Cygnus, is it really you?",
            "Shiro","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Oh, yes! I’ve come here to see how my dear friend is doing, and I see you’re alive and well!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Whoa, who’s this guy?",
            "Student A","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "He looks much younger and handsomer than Theodore!",
            "Student B","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Ah, I’m very sorry for not having introduced myself!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "I’m Cygnus Hoshi, an old friend of Theodore’s. We were in the same private school when we were kids.",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Heh… I remember those days now. Cygnus was the one who taught me how to play chess, actually.",
            "Theodore","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Whoa, those two are friends!",
            "Student C","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "That’s right! My grandfather himself taught me, and I loved to play games with other kids.",
            "Student D","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "You haven’t grown much since then, I see. You look barely any older.",
            "Theodore","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "But I can’t say the same for you! That’s the way things go in life, I think.",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Anyway, how have you been? I hope you’ve been fine.",
            "Theodore","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Well… Uh… Yeah! I’ve been fine!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Let me start here. You’re probably curious as to what I’m doing now.",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Well, I’m an astronomy student at the famous science academy known as the Witship Institute.",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "The Witship Institute? What an odd name.",
            "Shiro","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Ah, the founder liked the word ‘witship’ for ‘science’ a lot. He said that it was a true English word that matched the German word for ‘science’.",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Uh… I’m very sorry, but what’s your name?",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "I’m Shiro Smith, and i’m president of this school’s dodgeball club.",
            "Shiro","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "President! So you’re the one who led your team to victory against the Blue Ribbon!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Word about that has been going around town since your win! I could hardly believe the news when I first heard the details!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Oh, I envy you, Smith! I wish my win record were as good as yours!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Well, I’ve only had one match since I became president. It’s nothing to be proud of, if you ask me.",
            "Shiro","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "… Wait. Your win record? You’re also the leader of a dodgeball club?",
            "Shiro","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Oh! I’m very, very sorry for not having said it earlier! But indeed, I am the leader of the Witship Institute’s dodgeball club!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Cygnus, that’s amazing! I would’ve never imagined you to get into such a lofty position!",
            "Theodore","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "… Your school’s just challenged ours to a dodgeball match, hasn’t it?",
            "Theodore","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Nothing ever gets past you, I swear!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "On Sunday, I myself put in the request for a dodgeball match, and it so happens our match will take place this Friday at 5:30 PM.",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Our school ends around 3:00 PM. We can head there and check out what the school’s like.",
            "Theodore","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "That’s a great idea! I guess I’ll see you then, huh? See you later!",
            "Cygnus","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Goodbye, Cygnus!",
            "Student A","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Don’t get hurt now!",
            "Student B","", ""
        },
        {
            "Cygnus","Shiro","","","Theodore","",
            "Come back soon!",
            "Student C","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "(Wow, the chess club already loves Cygnus.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "Hmm...",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "Theodore, what’s wrong? You’re surprisingly gloomy for someone who’s just seen his old friend again.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "Oh, don’t get me wrong, as I am very glad about that. But something’s been troubling me.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "Cygnus was rather hesitant on his response when I asked him whether he had been fine.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "He was also rather unclear on why he had put in a request for a fight, when he had only heard about our win against the Blue Ribbon the day before. It just seemed too sudden to me.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "What, you don’t think he’s hiding something, now, is he? I really don’t want a repeat of what happened before the Blue Ribbon match.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "… Much as I hate to say it, I think that my old friend’s not telling us the whole story.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "When we look around the Witship Institute with him on Friday, I plan to confront him about it and see whether I can do anything to relieve him of his troubles. You don’t plan to stop me during then, do you?",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "(This is the first time I’ve seen Theodore look that serious.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "(There’s no doubting the concern he has for Cygnus. Hmm...)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","",
            "Nope. You have a point. We’ll have to get to the bottom of this.",
            "Shiro","", ""
        },
};

 //   Scientific visit
static string[,] scientificVisit = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "Two days later, on Friday, at 3:20 PM.",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow, this is the Witship Institute? It’s so big!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I can’t imagine how many rooms there are in this building!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Indeed, I am impressed. This is my first time visiting it, and already, I know that I will like it here.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Ah, that’s likely because a lot of guys like you come here! I’d say the same thing if this were a school dedicated to studying blossoms!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh, you’ll love it here, Theodore!",
            "???","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "I’m so happy that all of you can make it!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Hmph. I’m not. Some students from their school have already come, anticipating our match and frolicking through our sacred halls.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Now, now, let’s not talk badly about our visitors. It would simply be foolish not to acknowledge the reality that laymen see something different in the school halls from how we see them.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "The name’s Fulton Yanadori. I’m a zoology student specialized in ornithology.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Ornithology?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Ornithology is the scientific study of birds.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Had the founder had more of his way, he would have renamed it to something that would have made science much more understandable to the average man.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "My teammate there is Henry Sakai. He’s a physics student studying electricity and magnetism.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "That’s a bit simplistic, I’d say. I’m very interested in them, but I do study other subjects such as thermodynamics.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Hey, can we go inside already? I already want to be in a place where I’ll see fewer of those school uniforms.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Fulton! Be nice to Theodore and his friends!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Oh? What have you just said?",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "(Whoa, he’s just given Cygnus the evil eye! And that smirk… Ugh...)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "… Nothing! I’m very sorry for having said nothing! Let’s go inside now!",
            "Cygnus","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "That door leads to the room where birds are kept.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Birds?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Hmph. Not surprised you laymen are surprised.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Well, we keep birds in that room for various experiments, and they’re taken care of by well-trained veterinarians.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "The birds are my friends and will do as I say. If I say “Jump!\", the parrot asks, “How high\"?",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Wouldn’t you ask the birds to fly instead of jump?",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Whatever. They’ll do as I say, and the Institute lets me use them in matches. It’s lawful, I assure you.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "It’s not extended to birds such as falcons and hawks, however. Hence, I have to use their mechanical models.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "(Dodgeball is such a weird sport.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "This is the Biology and Engineering Building. My other two teammates’ workplaces are in the Physics and Astronomy Building. Follow me!",
            "Fulton","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "And now, it’s my turn to show off my facility.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "He means the laboratory where he and his classmates do their experiments.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "It looks very clean, obviously because we’ve just cleaned it up. Last time, we were working on testing Kirchhoff’s laws.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Then the chemistry crew came and did some messy things, I hear.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "What’s all that equipment on that table?",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Just some electrical equipment of mine. A loudspeaker, a fence, a toy mouse… It’s fascinating to see how much electricity plays in our modern lives, isn’t it?",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "(I wonder what the next shiny tool these guys will show off is.)",
            "Shiro","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Sorry for the tiring walk upstairs! The topmost floor of the main building is where the astronomy rooms are.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Does one of the rooms have a telescope?",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Yes! But there’s one room I want to show you.",
            "Cygnus","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Let me turn off this switch and then turn on this one…",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Whoa! It’s suddenly nighttime! And look at all those stars!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Oh, it’s just a projector that some of us like to use for our star maps. This kind of projection can be done by my special telescope as well.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Wow, that’s a pretty handy telescope! It would be nice to have something like that for other things.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "I have the star maps with all 88 constellations! And with my telescope, I can look at the star maps whenever I want! Isn’t that awesome?",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "And it’s kind of funny my name’s the name of a constellation as well.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Ah, yes, ‘Cygnus’, the swan. It is said that the swan sing its song before its death, whence the phrase swan song Heh, isn’t that fun to know?",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "With all this fancy technology, shouldn’t it be rather costly?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Indeed. Our institution is very large, but we do get much funding from several donors and alumni.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "One rather famous donor and a former student is Nicolas Akasaka, the founder and CEO of Golden Heart.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Wow! Golden Heart, that big multinational corporation? And the man himself was a student here? You must be kidding me!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Hah! There is no kidding about the Witship Institute! We get much of our funding from him, who lives in another city entirely.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Yes, the Akasakas are quite an influential family in our lives. Everyone adores them.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "(Hmm? He sounded a bit colder on the last sentence.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Now, what’s up next? I’m interested in looking more at the biology rooms.",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Hmm, but I want to look around the Physics and Astronomy Building more.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "There is an obvious solution, however. We shall simply split up into two groups.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Fulton and Henry can take Clemence back to the Biology and Engineering Building, while Smith and I look around this building with Cygnus.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "That’s a great idea, Theodore! There’s still so much of the Institute to show you, and it’ll take less time if we split off.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Hmph. I thought of that before your friend said it.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Sure you did.",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "I did! Let’s just go already!",
            "Fulton","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Now, then, let me show you the telescope—",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Hold it! Shiro, close the door.",
            "Theodore","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "(Ah, it’s time to talk to him about that.)",
            "Shiro","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Wh-What is it?",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "There’s something that’s been troubling you, isn’t there?",
            "Theodore","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "What?! Theodore, what are you talking about?",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "You’ve been acting rather funnily around Fulton. He’s been antagonistic toward you, yet you accept it, though you are the leader of the dodgeball club.",
            "Theodore","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "What I’ve been thinking is that he’s the reason why we are even here today. He pressured you to file a request for a fight with us, didn’t he?",
            "Theodore","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "…… Oh, Theodore, nothing ever gets past you, does it?",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Yes, everything you say is right. Fulton’s the mastermind behind this.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "W-Wow! Theodore, I can’t believe you figured it out!",
            "Shiro","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "It was nothing. Simple observation led me to the truth.",
            "Theodore","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Uh, Cygnus, I’m sorry for Theodore’s harsh tone, but we simply want to know the truth, so that we may help you. Could you tell us everything?",
            "Shiro","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Oh, I can’t say no now, can I? All right.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "For starters, why do you let Fulton push you around?",
            "Shiro","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "The thing is, I’ve been a rather… lousy club leader. We haven’t been winning a lot of dodgeball matches lately, and Fulton’s been saying that I’m to blame.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "I don’t think he’s off the mark. I was made leader only two months ago, when the last president left the club.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "I’m still learning how to act like a good leader, but...",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Time and time again, I fail, and even though my teammates insist that they’re happy, I just can’t help but feel that I haven’t done enough for my team.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "And you’re letting Fulton order you around?",
            "Theodore","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Y-Yes. He truly cares about the club and our school, I tell you, even though he may be a piece of work.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "On Sunday, he heard about your win against the Blue Ribbon. He thought that your win was just a fluke, and that it would be easy to beat you.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "He seemed more eager than usual to have a match, so he had me submit the request.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Well, that explains it all!",
            "Shiro","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Do you have any guesses as to why he was that eager?",
            "Theodore","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Hmm… Sorry, but nothing comes to mind.",
            "Cygnus","", ""
        },
        {
            "Theodore","Shiro","","","Cygnus","",
            "Is that so? It seems we are still missing something important here.",
            "Theodore","", ""
        },
};

 //   Scientific match
static string[,] scientificMatch = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "About an hour later...",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow, really? That’s why we’ll be fighting those guys?",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Yes, really. Who would have guessed that it was the zoology student?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "… If truth be told, I do feel rather… uneasy.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "The match itself presents no problem. But it’s the outcome that worries me.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "What do you mean?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "When Cygnus told us about how he felt that he had disappointed his club, I couldn’t help but feel unsure on whether I even wanted to win our match.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Winning against him… would sadden him a lot. He would have yet another loss on his hands.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow… This is the first time I’ve seen you unsure of yourself, Theodore.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "How can I not be? Cygnus is my friend, and I know that many friends have parted ways when they fight each other.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Only one becomes the winner. I… I don’t want that to happen.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I don’t, either. But what can we do?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "…… I don’t like to do this, but we must play the game.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I feel little excited for the match, but I am concerned about another thing as well.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Fulton, right?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Yes. To be clear, I am concerned about the truth.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Fulton is the final piece to be captured in this game, and if I beat him, I shall learn of the truth behind this.",
            "Theodore","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Witship Institute Gym"
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "It’s about time you came here!",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "There’s no need to rush. Haste makes waste, doesn’t it?",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "(Cygnus himself looks troubled. No wonder, when that Fulton guy’s pressuring him to win.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "(I feel sorry for having to do this to him, but we have to fight.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "What kind of match do you think we’ll see?",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Those guys are science students, aren’t they? They’re probably really smart!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Look the part, Cygnus! Show your friend and his buddies that you mean business! No one will believe you with that face of yours.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "R-Right! Theodore, let me warn you that I won’t hold back!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Cygnus...",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Oh, seeing this tears me apart! I want to see the end of the match already!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Well, for that to happen, we have to fight. No getting around that.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "All right, then... Let’s begin!",
            "Cygnus","", ""
        },
};

 //   Science student defeat
static string[,] witshipInstituteDefeat = new string[,]{
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "No… This can’t be happening… I’ve lost!",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "… I-I… I’ve failed my team once more.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Are you sure about that?",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Great game, Cygnus!",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Don’t feel bad, Cygnus!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "We’re proud of you, Cygnus!",
            "Student C","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "What? Why aren’t our club members sad that we’ve lost?",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Why should we be sad? We’re happy you’ve been working hard as our president!",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "But we’ve been losing a lot lately, and it’s all my fault!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Your fault? What silly thinking! Though it stings a little that we have another loss in our record, that doesn’t mean you’ve been poor to us!",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "There are some places where you can become better, but when you focus on your weaknesses, don’t forget about your strengths!",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "……… Th-Thanks, guys! I-I really appreciate this! I… I see what I should do.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Shiro Smith, isn’t it? This has been a well-fought match!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "We tried our hardest, but in the end, you won! Well done!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "And I’m very sorry if I’ve hurt you really badly!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Oh, no, no, I’m perfectly fine! I’m tired, but I can handle that!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "If truth be told, I wasn’t expecting this much praise from you!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Well, acknowledging that you’re not perfect is a sign of a good leader, isn’t it? Or so I’ve heard.",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Cygnus… Are you all right?",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Yes, of course! There’s no need to worry about me, Theodore! Even after a rough match, we’re still friends, after all!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Cygnus… I could go on and on about how happy those words make me!",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Aw, would you look at that! The two stay friends! I could weep!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "It is rather sweet, isn’t it?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "(Still, there’s one thing we need to attend to.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "………………",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Fulton? Are you all right?",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "…… My plan… It’s all in tatters now… I’ve failed…",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "Fulton?",
            "Henry","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "No… There is still something I can do.",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","Cygnus","Fulton","Henry",
            "I must make him change his mind...",
            "Fulton","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Cygnus","Henry",
            "Hey, where do you think you’re going? I want to ask you something!",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Cygnus","Henry",
            "… I was hoping to ask him a few questions. It seems that those will have to wait for another day.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Cygnus","Henry",
            "In the meantime, we ought to celebrate our victory with the rival team!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Cygnus","Henry",
            "That would be very nice, but you don’t have to do so!",
            "Cygnus","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Cygnus","Henry",
            "Don’t worry! I’ll just call my friend Lily about it. She’ll cook us something nice!",
            "Clemence","", ""
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
            "Today was pretty odd. We went up against the Witship Institute in a match, and even though we won, I feel rather unsatisfied about a few things.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "It turned out that Cygnus, the rival club president and a new friend of mine, was forced by one of his teammates to fight us, and in the end, we didn’t get to ask him why he made Cygnus do such a thing.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "But other than that, it was pretty great! The Witship Institute itself was interesting and awesome, and I’ve been getting to know more and more about my friends, and I’ve been getting new ones as well!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "There’s still so much of Ball City that I haven’t seen yet, but I’m excited to see what awaits me!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "", ""
        },
};








//    Barrow Temple
//Trip to the woodland
static string[,] barrowTempleIntro = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "A week later, when it is Saturday noon…",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "It sure is nice of you to drive us to the other parts of the city, Mrs. Kadou.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh, how could I refuse, when Clemence told me that he wanted to show you more of the city!",
            "Mrs. Kadou","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "He was very earnest in asking that I help you, since you’re from Middleton, which I hear is rather plain and much smaller.",
            "Mrs. Kadou","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "We’re going to see a school called Barrow Temple, and it’s at a forest near the northern exit of the bridge we’re about to go onto.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Though the match against the school is in a few days, it’s still good to know our enemies, isn’t it?",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "It sure takes a rather long time to even get there, though, don’t you think?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Well, it’s such a big city that it can take even an hour just to get from north to south, so you’d best be ready to wait a long while, Shiro.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "How many people live in Ball City?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "At least nine million. I can’t remember the exact number right now. Either one, Ball City’s one of Japan-America’s megacities.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I can’t even begin to imagine how much, no, little of the city I see everyday in my apartment’s vicinity!",
            "Shiro","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "See this, Shiro? We’re on the great Linkers’ Bridge!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Whoa! What a pretty view of the sea!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Yes, people on the beach by the bridge’s southern exit like to take pictures with the bridge in it. It makes for a pretty tourist site, at the very least.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Does it really take that longer to get to the northern parts of the city?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Ah, even at the other side of the bridge, we’re still at the southern parts! The city’s ever so big, and it’ll take much more time to get to even the center.",
            "Mrs. Kadou","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Amazing… It’s amazing what a megacity in today’s world is like!",
            "Shiro","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Well, I’ll drop you here. I’ll go back home now and tend to some work of mine, so you need only call me if you want me to pick you up.",
            "Mrs. Kadou","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "All right, Mom. Take care!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Okay, now, Wainwright Wood, I believe, is to the west. I think it’s this way…",
            "Clemence","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow, there sure are a lot of trees. Not exactly what you might find in a typical city.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "It is a little odd, I admit, to see a great woodland encircled by so many man-made structures. The city’s history is indeed strange.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wainwright Wood wasn’t always here, I hear. The trees were grown here on some plain land a few centuries ago.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Though they take only a few decades or so to fully grow, they can live for a few hundred years.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "There are also other kinds of trees and blossoms here, because of a variety of ecosystems.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow, I didn’t know that! You really do know a lot about botany.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "... Hmm? Who’s that over there?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kazuto","",
            "……...",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "(What’s that boy doing here? And is that a wooden sword he’s holding?)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kazuto","",
            "……...",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Whoa, what was that all about?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Seems to me he was playing around with that sword of his. The bark of some of those trees looks a bit scarred, for want of a better word.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh, those poor trees, being used as part of sword practice! I’m lucky that they haven’t been felled, at the very least!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "(That boy didn’t seem to notice us. I wonder what his deal is.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Guys, let’s follow him. He may be heading somewhere interesting.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "You really think so? Fine by me. It’s not as if there were anything else to make this walk exciting.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Aw, I was planning on showing you the Blossom Garden. It’d be nice if we could check out a place full of pretty blossoms.",
            "Clemence","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","","Kazuto","",
            "(It’s been a while since we started following him. Where is that boy going?)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kazuto","",
            "Hey, he’s gone into that building over there.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kazuto","",
            "It looks like… a temple.",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kazuto","",
            "Ah, I think I know what it is. I’ve heard about there being a school in the middle of this woodland.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Kazuto","",
            "Oh! Visitors!",
            "???","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Welcome to Barrow Temple, our dear school!",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Barrow Temple is known for teaching the traditional Japanese martial arts, such as kendo and karate.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "I’m Yoichi Azusayumi, and I’m a student of kyudo, the martial art of archery.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "And I’m Ichirou Yamaguchi. I’m a student of karate, a martial art of unarmed combat. May I ask who you are?",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Oh, I’m Shiro Smith. My two friends here are Theodore Yukimura and Clemence Kadou. We three are students of Salt Pitt High, and in fact, we’re part of the school’s dodgeball club. I’m the president.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Ah, Salt Pitt High. You’re the ones we’ll fight in a few days, aren’t you? I believe you guys have a problem about some punks or something like that.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Oh, no, that’s been taken care of, thanks to us.",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Ichirou and I are part of a dodgeball club as well. Our dodgeball style incorporates martial arts, so we’re not just any team.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Wow. That’s pretty cool.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "(I get the feeling this is how all of Ball City’s dodgeball teams work. If this is allowed by the dodgeball rules, then it’s pretty amazing what a team can do.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Could you show us what it’s like inside?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Oh, of course! I-It’s only right that we show you around!",
            "Yoichi","", ""
        },
};


    //Calm before the storm
    static string[,] calmBeforeTheStorm = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "This here is the dining hall. It’s really modest, but I don’t mind. You’d get used to it if you stayed here.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "This school’s a bit different from others, in that it offers housing for its students, since for many of us, it’s far from their homes.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "And that’s why you’re at this temple on a Saturday instead of being at home with your family, yes?",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Right on the mark!",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Ah, speaking of that, I can’t forget to send my family my monthly earnings.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Whenever I’m not studying or helping out at the temple, I work as a cashier at a diner a bit far from here.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "T-To do all of that must be a great burden on you!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "No, not at all! What kind of man would I be if I could not handle it?",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Now that I take a closer look at this dining hall, I do like how small it is. It brings all the occupants together, I think.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "It does, but I-I kind of wish there were a bit less arguing. Some of our other classmates can get really hot-headed and competitive.",
            "Yoichi","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "This is the practice field for us kyudo students.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "It’s pretty wide!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "I assume that those straw drums over there are archery targets.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Yes, that’s right. They’re called makiwara. I think I’m a bit good at kyudo, but, oh… I don’t think I’m good at incorporating it with dodgeball.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Yoichi, remember the old saw: practice makes perfect!",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Oh, I know, and I do practice a lot. Still, you and the others make me feel sometimes that I’m pretty far behind.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Nonsense! You’re doing well. Don’t feel bad about yourself. You need to show pluck in your words.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "I… I’ll try. Ahem…",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "With my bow and arrows, I’ll help to protect the team, come what may!",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "… Y-You want something like that?",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "A bit cheesy and awkward, but you’re on the right path. It’s the vocals that need a bit more work. They need more energy!",
            "Ichirou","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "This room’s one of the classrooms that we use. We karate students usually use it as one of our dojos.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "It’s much bigger than our classrooms.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Uh, I’ve been wondering, but are there different ways to do karate?",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Why, yes, there are different schools of karate. I’m learning the shotokan style, one of the major karate styles.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Wow, I bet there’s a lot of punching and kicking and then some.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "That’s how karate’s commonly depicted in media, but it’s not exactly accurate.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Shotokan focuses more on evasion and long range. It’s quite helpful when I want not to be the target but rather to get it instead.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "And that’s how you incorporate your techniques with dodgeball.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "It takes much dedication and work, and training is never fully done, I warn you.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "And such a thing as victory means nothing to me. All that matters is not losing.",
            "Ichirou","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Barrow Temple Gym"
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "This is the room that kendo students ordinarily use.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Kendo?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "The way of the sword.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Hey, I see someone standing outside!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Hey, I see someone standing outside!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "……...",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Ah, it’s him! I’ve been wondering about who that guy is.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "He was standing by a bunch of trees with that wooden sword of his, and he walked back here, so we followed him.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Who is that guy?",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Th-That’s Kazuto Kaneto. He’s a very good kendo student, which is why he was chosen to be our dodgeball club president.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "What?! Your president? Not very talkative, is he?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "It is a bit odd. Though he’s always been a bit aloof, he once spoke regularly when he became president, but for the last few weeks, he’s been much quieter.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "We’ve tried talking to him, but we’ve had no luck.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "… Oh, you guys are here. What do you want?",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "(Man, this guy sounds a bit cold. Kind of rude, too.)",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "O-Oh, we’ve been showing these students from Salt Pitt High around. Competitors or not, we have to treat them dearly, right?",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "So, uh, I hear you’re this school’s dodgeball club president.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Just so you know, I’m the president of our school’s club, so we have some link, don’t we?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "… Are you good at dodgeball?",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Well, I haven’t had too many games, since I’ve only started recently, but I’m getting there.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Oh, I see…",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Wow, it’s raining! It’s pretty light rain, but still!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "I guess we’d better hurry back home before the rain gets any worse.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "In that case, we’ll see you again next Monday.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "......",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Hey, where’s he going?",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "I don’t know, and he won’t tell me what he’s been up to, whatever I do.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Well, hopefully, he’ll have made a full turnabout by our match!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","","Yoichi","Ichirou",
            "Hopefully… You really think Kazuto’s going to change? Even we can’t get to him.",
            "Yoichi","", ""
        },
};



//    Kazuto’s secret
static string[,] kazutoSecret = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "Several hours later…",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Your mother sure is taking her sweet time coming her, isn’t she, Clemence?",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Traffic, maybe?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "It’ll be rather unlucky for us if it’s traffic. The rain’s gotten a little worse, and I don’t want to get a cold from staying out here too long.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "C-Could we please talk about something else? I don’t think this kind of talk gets us anywhere.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "… Well, I’m bored. Might as well take a walk around the park.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "My feet are killing me right now, so I’ll stay here.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Clemence, you’ll be here with me.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Huh? Why?",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "If there were no one to complain to, I’d look like some weird whiner talking to himself, wouldn’t I?",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Sh-Shiro?",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Nothing I can do to help you out there. Sorry about that!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Now, I’ll just be taking a short walk. Nothing big.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "If you’re going for a walk, be careful not to get lost!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Yeah, yeah, I know!",
            "Shiro","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","","",
            "(Brr! It’s pretty cold outside! I’m starting to regret this already!)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "(At least I’m not in a haunted wood. Now that’d be scary.)",
            "Shiro","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","Shiro","","","","",
            "(It’s been a few minutes, and I’m pretty sure I’m lost. Great, just great. Who wouldn’t have seen it coming?)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "(… Wait a minute, is that…?)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… Ah.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "(It’s him! What’s he doing here? I’d better hide behind this tree!)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "...",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "(He’s sitting under that pavilion, staring at this place.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "(Wait… This place…)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "(It’s… full of blossoms of several colors. They look, for some reason, all the more beautiful in this rain. I think Clemence spoke of a Blossom Garden on the way here.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "(Stumbling upon this place along with that guy! What were the chances?)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… Oh… I miss you so much...",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "(Okay, I’m not going to learn a lot if I stay behind this tree. Time to make him talk!)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Hey, Kazuto!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Ah! Wh-What are you doing here? Have you been following me?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Well, no, but I might as well have, since I wonder what you’ve been up to. You’ve been acting a bit oddly, your friends say.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Well, that’s none of their business now, is it?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Sorry, but you’re wrong. Your secret’s been keeping you stay distant from your teammates, and that’s not okay. You’re their leader, after all.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Y-You…! Stop badgering me about it!",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "After making my way through this weather, I won’t leave without an answer!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Gah… You won’t leave, you say?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… I… I guess it won’t hurt to tell you.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Great! For starters, could you tell me whether this place is important to you?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Yes. Ayane and I used to come here.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Ayane?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "My sister. She’s seven years younger than I am. She would ask me to bring her to see the Blossom Garden, and I being her brother, there was no way I’d refuse her.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "We were happy, the two of us. Those were our halcyon days. But…",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "About a month ago, she fell sick of a severe illness, and she can’t go through her everyday life without much difficulty.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Mother had her live with our uncle for a few months, so that she could get better in a different environment, but… I wanted her to stay. I was sure she could get better here.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "It was no use, however. She was made to leave in the end, and I seldom see her now.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Those blossoms… let me remember her most easily.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "W-Wow… I-I thought you were just a weird, quiet boy, but if I’d known, then I would’ve thought differently.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… I didn’t tell this to any of my teammates. They would have stopped what they were doing and spent their time on helping me instead of focusing on themselves.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Well, of course they would have! You’re part of the team! And in a good team, we would care about each other!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "If we didn’t, then the ones in trouble would fall behind, and all of us would suffer for it!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "…… I feel… much better, now that I’ve told it to you.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "So tell it to everyone else!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "I… I don’t want to be selfish and have them focus only on me.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Selfishness? Then maybe you should tell them sorry for keeping it from them and making them concerned over, well, something not as bad as they thought it was.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Tell them sorry, huh? I… I can do that.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Now that’s the spirit!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "...... This weather… Ayane likes it a lot.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "She says it gives the earth some of its life back, as water is the dearest thing for all of us.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "I must say… It’s rather calming to watch the blossoms and the rest of this woodland like this.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Yeah... I can understand it now. It’s truly surreal...",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… Tell me, Shiro, do you have any siblings?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Yep. I have an older brother. His name’s Kuro, and he’s a student of this school called Mightmain Academy.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Mightmain Academy? That’s a pretty high-ranking school, I hear. Impressive.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… He was always there for me when I was a child.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "He used to take me to many different places such as the theater and the beach, just so I could see all those different things and have so many different kinds of experiences.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "He really loved it whenever we went to the beach. He loved swimming in the sea much more than I did.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "I take it that you don’t live with your brother in the same house.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "That’s right. He lives elsewhere, but I write to him every now and then. He writes back as well, so we keep in touch.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Letter writing, huh? You don’t talk to each other online?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "No, he insists that we write to each other. He says it feels more meaningful and thoughtful if we do it this way.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "And after doing it, I feel he’s right.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "When’s the last time you saw each other in person?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "The last time I saw him was when he left or hometown, Middleton, for Mightmain Academy.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "He calls me and Mom every now and then, but I don’t think a phone conversation gives me the same feeling as talking to him in the flesh does.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Do you miss him?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "I… I do.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Then we can understand each other more than I thought.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Heh, I guess that’s true.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… I’d better head back to my friends. I’ve spent quite a lot of time talking with you, and our ride must’ve come by now.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Do you know your way out this park?",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "… Uh oh. Now that I remember, I came here while wandering around. Could you, uh, you know…",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Sure, I will. Though it’s dark, I’ve come here at night so many times that I know the path back.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "And by the way, I’d appreciate it if you kept this meeting of ours secret.",
            "Kazuto","", ""
        },
        {
            "","Shiro","","","Kazuto","",
            "Sure thing!",
            "Shiro","", ""
        }
};

//    Martial artist match
static string[,] martialArtistMatch = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "World Map"
        },
        {
            "","","","","","",
            "Two days later, when it is Monday morning…",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I’m still pretty shocked that that Kazuto guy’s made a complete turnabout! He’s now pretty open and friendly!",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Shiro, I wonder… ",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "What? Why do you suspect me? Maybe he had a change of heart because of, I don’t know, a nightmare or something!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "That’s rather unconvincing, Shiro.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Well, I don’t know what to tell you.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "… Anyway, since we’re all ready, let’s head to the kendo room for our match.",
            "Theodore","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Barrow Temple Gym"
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Finally! The other team’s come at last!",
            "Student A","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Let’s get the match started already!",
            "Student B","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Yoichi, Ichirou, are you ready?",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Oh, I am, and I do hope everything will go well for us!",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Yoichi, nothing ever goes the way we want it to go.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "That’s true, but I can still hope our practice will pay off, can’t I?",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Oh, and Kazuto!",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "What is it? We’re about to start!",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Oh, uh, just before the match started, I found a student who was willing to record the match for us.",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "I was thinking… maybe you could send a recording of the match to Ayane. I’m sure she’ll love seeing you fight!",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Yoichi! That’s… That’s a great idea! I’m glad you’ve thought of it!",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "In that case, you don’t want to let your sister down by fighting weakly, now.",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Of course not! Now, let’s begin!",
            "Kazuto","", ""
        },
};

 //   Martial artist defeat
static string[,] barrowTempleDefeat = new string[,]{
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Yay! We’ve won, we’ve won, we’ve won!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Oh, we’ve lost! If only everything had gone right for us!",
            "Yoichi","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Well, what did I say? Nothing goes the way we want, now, does it? Ha ha ha!",
            "Ichirou","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Shiro! That was a good match, wasn’t it?",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Indeed, Kazuto!",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "It feels nice to see the other team have good sportsmanship!",
            "Clemence","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Yes, if only all the other teams had that same feeling, then our relationships would be better. The loser must gracefully accept his defeat.",
            "Theodore","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Now, Yoichi, have the cameraman send me that recording. I’ll send it to Ayane.",
            "Kazuto","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "Wait! Could you send me that recording as well? I want to show it to someone.",
            "Shiro","", ""
        },
        {
            "Clemence","Theodore","Shiro","Kazuto","Yoichi","Ichirou",
            "It shouldn’t be a problem! Hang on...",
            "Yoichi","", ""
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
            "You may find this hard to believe, but because of the strong storm, my two teammates and I were trapped at this school called Barrow Temple!",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "And not only that, but we also had a scheduled match against its dodgeball team! I’ve just sent you an email with a recording of that match, so you can check out for yourself how I fight.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "The school itself was pretty good. The students are friendly, and I really liked the traditional style of the school.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "And Kazuto, their captain, is not a bad guy at all! I really liked being around with him and enjoyed sleeping in the same room as he was in.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "I hope to see you in the flesh soon.",
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
        {"Punk Defeat", punkDefeat},
        { "Three Outstanding Girls", scholaGrandisIntro },
        { "Magical Preparation", magicalPreparation },
        { "Magical Match", magicalMatch },
        { "Magical Defeat", scholaGrandisDefeat},
        { "Punk Ambush", mightMainIntro},
        { "Fight Against the Military", militaryFight},
        { "Kuro's Trump Card", yamatoBattle},
        { "Military Surrender", mightmainDefeat},
        { "Trip to the woodland", barrowTempleIntro},
        { "Calm before the storm", calmBeforeTheStorm },
        { "Kazuto's secret", kazutoSecret },
        { "Martial artist match", martialArtistMatch },
        { "Martial artist defeat", barrowTempleDefeat }
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
