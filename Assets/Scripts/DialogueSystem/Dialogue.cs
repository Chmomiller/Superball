using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {
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
