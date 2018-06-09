using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {
    //characters appear in order
    //special include offscreen
    //{character,character,character,character,character,character,dialogue,whose talking split by a space,special, special param}
    static string[,] sceneName = new string[,] {
        { "char1", "char2", "char3", "char4", "char5", "char6", "text", "char1 char2 char3", "", "" },
		//{ "char1", "char2", "char3", "char4", "char5", "char6", "text", "char1 char2 char3", "BG", "Mightmain Battle" },
        { "", "", "char1", "char2", "", "", "text","char1","", "" },
        { "", "", "char1", "char2", "", "", "text","x","", "" },

    };

// Prologue and scenes 1-2 of Salt Pitt High
    
static string[,] saltPittPrebattle = new string[,]{
        {   
            "","","","","","",
            "Dear Kuro,",
            "Shiro", "black", ""
        },
        {   
            "","","","","","",
            "I’ve come to Ball City at last!",
            "Shiro", "BG", "TodaysTale"
        },
                       {    
            "","","","","","",
            "The train ride from Middleton was so boring, but I’m excited to be here!",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "I mean, it’s the biggest city in the United Pacific Federation.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "One thing sticks out to me: this city is nuts about dodgeball!",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "All the local schoolkids ever dream about is becoming the world’s top dodgeball players, and they’re beating the heck out of each other to achieve that dream.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "There’s even a national dodgeball tournament to decide which school has the most skilled players.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "That’s unbelievable, isn’t it? It’s so much to take in!",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "Anyway, how are you doing now? It’s been a while since you left home. If you want to see me, come to the apartment that Mom’s rented for me.",
            "Shiro", "", ""
        },
                       {    
            "","","","","","",
            "Hopefully you’re doing well at the academy. I’ll be busy fitting in at my new school.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "Best wishes, your little sister, Shiro.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
            {   
            "","","","","","",
            "A few days later...",
            "Narrator", "BG", "Audio stop"
        },
        {   
            "","Shiro","","","","",
            "Now, where’s Salt Pitt High? It’s my first day, and I couldn’t be any more lost.",
            "Shiro", "BG", "lovelyTime"
        },
        {   
            "","Shiro","","","","",
            "Hey, guys, hurry up! Class starts in ten minutes!",
            "Student A", "", ""
        },
        {   
            "","Shiro","","","","",
            "Don’t worry, Jared! We’ll be there on time.",
            "Student B", "", ""
        },
        {   
            "","Shiro","","","","",
            "There’s my answer. Time to follow those guys!",
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
            "Hello, everyone! I’m Shiro Smith, and I’m from Middleton, a town in the Western parts of the UPF, so I’m sorry if I don’t fully fit in. I’m still getting used to Ball City.",
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
            "Math sucks! I wanna EAT!",
            "Student B","", ""
        },
        {   
            "","Shiro","","","","",
            "Finally! Time to snoop around.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","","",
            "Hmm… I can get used to this. So far, it’s hardly any different from middle school.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Stadium"
        },
        {   
            "","Shiro","","","","",
            "Okay, I’ve checked out the library, the music room, the field…",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","","",
            "Now for that big building at the edge of campus.",
            "Shiro", "BG", "Audio stop"
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
        {   
            "","Shiro","","","","",
            "What is this? It looks like a gym, but it’s so… ruined.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","","",
            "Freeze, missy! This is Pitt Crew dirt!",
            "???", "", ""
        },
        {   
            "","Shiro","","","Greg","Frank",
            "(I’m being approached by… a sentient bucket and his father? Be cool, Shiro. Maybe they’re not as bad as they look.)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Greg","Frank",
            "You must be new meat! We’re the Pitt Crew, the school’s dodgeball club, and this old gym’s our turf!",
            "Greg", "BG", "UpToNoGood"
        },
        {   
            "","Shiro","","","Greg","Frank",
            "Wait, gym? Your turf? The school leaves the old gym like this?",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Greg","Frank",
            "Yeah, loser! The school didn't want it, so we moved in!",
            "Frank", "", ""
        },
                       {    
            "","Shiro","","","Greg","Frank",
            "We are the Pitt Crew! We’ll eat your trash!",
            "Frank", "", ""
        },
        {   
            "","Shiro","","","Greg","Frank",
            "Oh, uh… ",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Greg","Frank",
            "Listen, new meat. You clearly have some uppity new kid sass that needs to be pummeled out of you.",
            "Greg", "", ""
        },
        {   
            "","Shiro","","","Greg","Frank",
            "And I, Greg Gomi, and my buddy here, Frank Daigo, are licensed new kid pummelers!",
            "Greg", "", ""
        },
        {   
            "","Shiro","","","Greg","Frank",
            "I’m sorry to interrupt, but I must insist that this verbal roughhousing cease immediately. The fun is over!",
            "???", "BG", "Audio stop"
        },
           {    
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "Now that I’m here, I’ll make sure you won’t lay a hand on her.",
            "Theodore", "BG", "End Battle"
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "Theodore Yukimura! Snooping as usual, aren’t you? But who’s that blond guy with you?",
            "Greg", "", ""
        },
           {    
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "You’re, uh, Clemence Kadou, right? Didn’t we beat you a while ago? What’re you two doing here?",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "We followed her, once we saw that she was heading here.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "We followed her, once we saw that she was heading here. Now please, let her go! She didn’t know about your little turf situation!",
            "Clemence", "", ""
        },
                       {    
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "And this isn’t how a dodgeball club is supposed to act!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "Uh… Well, I… ",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "Sh-She was asking for it, wandering in here and all.",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "Come now, Gregory, don’t tell me your spine is only available when Spikey is around.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "Am I famous enough for nicknames already, Theodore?",
            "???", "BG", "Audio stop"
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "You’ve got some nerve saying that to my boys.",
            "???", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","","Greg","Frank",
            "I’m spine enough for you three morons, and I’m ready to throw down. That’s how Trevor Akuouji rolls!",
            "???", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Greg’s right on this one, you know. This girl ought to know her place here.",
            "Trevor", "BG", "UpToNoGood"
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "We can’t let fools come here willy-nilly without giving their skulls a few dents.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "What kind of dodgeball gang do you think I’d be running if I didn’t? That’s just bad for business.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "I have to insist that you back off.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "That’s it? Words? Is that how you do business with me? Can’t say that’s a rather wise strategy you’ve got there.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Yeah, tell him, boss! Get him for good!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Boss, is this part of the plan?",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "No, but it’s all good. Our plan isn’t affected by this goody-goody brigade.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "(Is it just me, or is this Trevor guy much better with his words than his goons? Not one of those everyday punks, at least.)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Honestly, I didn’t mean any disrespect. I don’t want a fight, honest!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "A fight? I am not an unreasonable man. We settle our disputes here in Ball City with the game of kings: dodgeball.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "A match?! With the new kid?! That’s just cruel!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "There’s three of us, and three of them. I should have seen it coming.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Knowing what's gonna happen won’t stop the pummeling coming your way. Square up.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "You guys are gonna be coughing up rubber for weeks!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Wait a minute. Dodgeball? I know that it’s a big thing here, but are we really settling this with a sport and not a good old-fashioned beating?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Eh? You don’t know how things work around here? Well, no! Dodgeball’s not only a sport! It’s our way of life!",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "That’s just silly!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Don’t you call it silly, girlie!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Hah! You are a newbie! In this city, dodgeball is our bread and butter.",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Our meat and potatoes.",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Our flavor of the good old knuckle sandwich.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Oh, that’s hogwash!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Take that back!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "That’s enough yawping, boys. Frank, you ready to be useful for once?",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Anytime, everytime!",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Then get going! Tell everyone there’s gonna be a match. I want witnesses!",
            "Trevor", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Been a while since a good match happened around here.",
            "Student A", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "I feel bad for the new girl, though. That Pitt Crew’s a bunch of slime balls.",
            "Student B", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "We’ve got great turnout today. Dozens of students to watch your shameful defeat.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "This is a wretched path you are heading down, Trevor. This won’t end the way you think it will, I promise you that.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "…… Ahahahaha!",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Oh, he’s got jokes! And here I thought all you mathletes do is practice and memorize thesauri.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Yeah! The boss is smart without any big words talk.",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Well, you did make me see one thing, Theo-dork, and it’s that I wouldn’t make you another pawn of mine if you did join me.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Instead, you’d make a good court jester. Every good king needs one, don’t you agree?",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Boss, let’s begin the match already! I’m gonna grow crazy here! I wanna take out the trash!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "(Wow… This is seriously happening.)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Shiro, as we are involved now, it’s a 3-on-3 match. Let us help you fight.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "I don’t have a choice now, do I?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Nope.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Oh, Theodore, are you sure this is right? What if we lose? We’ll definitely lose, anyone can see!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Clemence, Trevor has made a big mistake by letting us fight.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Ever since I lost against them, I’ve been shadowing them and watching them gang up on other students, and I can tell you for sure they’re not invincible.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "So we have a chance, you two.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Now, then, let’s begin!",
            "Trevor", "BG", "Audio stop"
        }
	};

// Scene 3 of Salt Pitt High

    static string[,] saltPittPostbattle = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Salt Pitt Gym Interior"
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "What?! No way! I can’t believe this!",
            "Trevor", "BG", "End Battle"
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "I got totaled by a bunch of losers!",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "We’re the losers? Are you sure about that?",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Boss, my body feels like an old bean-bag chair. I need to lie down.",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Don’t say stuff like that out loud! We’ve gotta be tough!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "That was awesome! Who are these guys?",
            "Student A", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "The dodgeball club got swept by a bunch of nobodies!",
            "Student B", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "A lot of the students are pretty shocked. What’s the big deal?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Ah, you don’t know! Our school decides our place on the totem pole by our dodgeball skills.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Trevor and his gang are at the top, but since we’ve just beaten them…",
            "Clemence", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "We’ve knocked them down a peg, right?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "More than a peg, if you ask me!.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Look at those punks! If a newbie can beat them, then the dodgeball club’s an utter joke!",
            "Student A", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Oh, come on, you don’t truly believe that now, right? I mean, they only got lucky!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Eep!",
            "Greg", "BG", "_SFX/Final Voice Lines/Crowd Sounds/Booing/Booing_3"
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Greg, I don’t think they believe you!",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "You’re a sham of a dodgeball club! Get out, Pitt Crew!",
            "Student B", "", "_SFX/Battle sfx/crowd/get out of here/get out of here"
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Some free advice, Trevor: lying low for a while might be a prudent decision.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "That sounds like a good idea to me, boss!",
            "Frank", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Oh, zip it, Frank!",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "You know what, Theo-dork? You have a good point for once.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Boys, let’s scram and cool our heels for a bit.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "What now, then?",
            "Greg", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Hey, you, girl with the bow, what’s your name?",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Uh, Shiro Smith.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "Well done, Shiro Smith. You may have new friends, but you also have a new foe, and you’re gonna pay for this.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Theodore","Clemence","Trevor","Greg","Frank",
            "The next time you see me, you’d better be ready. Pitt Crew out!",
            "Trevor", "BG", "Audio stop"
        },
        {
            "","","","","","",
            "",
            "","transition", "Stadium"
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "And that’s checkmate. Now, the game is over, and we can all go back home.",
            "Theodore", "BG", "lovelyTime"
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Phew! I’m just glad things didn’t get too violent. Are you okay, Shiro?",
            "Clemence", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Yeah. I wasn’t expecting us to win, to tell you the truth.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "You looked like you had a lot of fun playing dodgeball, despite everything.",
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
            "Given that they have left it, I should imagine it is ours for the taking. And Clemence, you ought to join, as I do see some potential in your playing.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "But I’m already Garden Club president! I don’t want to pull double duty.",
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
            "I hope you will! Salt Pitt High’s among the worst performing schools in Ball City!",
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
            "Hmm… It won’t hurt to stick with this, I guess.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Oh, class is about to begin! I’ll see you guys later!",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Of course. Goodbye, Shiro.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "See you later, Shiro!",
            "Clemence", "BG", "Audio stop"
        },
        {
            "","","","","","",
            "",
            "","black", ""
        },
        {   
            "","","","","","",
            "Dear Kuro,",
            "Shiro", "BG", "TodaysTale"
        },
        {   
            "","","","","","",
            "Today has been an odd day for me.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "I walked in a boring old student, and I walked out a dodgeball club president.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "I guess I’m doing a pretty good job so far. It’s a weird feeling being good at something that I’m not really passionate about.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "But maybe I can just be passionate about doing well, and that will be enough.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "It’s odd that it’s dodgeball of all things. It’s a thing in Middleton, but it is certainly nowhere as big as it is in Ball City!",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "Could this be the calling that Mom said that I would find at this city?",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "I guess I’ll have to go along with it and find out. I really had nothing much going on back at Middleton.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "I know you're out there killing it, and I love you, even though you are lousy at responding.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "It’ll be nice to see you later.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "BG", "Audio stop"
        },
};



























    ///////////////////////////////////////////////////////////////
    /// 
    /// SCHOLA GRANDIS
    /// 
    ///////////////////////////////////////////////////////////////

// Scenes 1-3 of Schola Grandis
    
static string[,] scholaGrandisPrebattle = new string[,]{
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
            "(It seems like the three stooges have made tracks. Thank goodness for that. I don’t know if I could make a repeat performance.)",
            "Shiro","BG", "lovelyTime"
        },
        {
            "","Shiro","","","","",
            "(Since that day, we’ve had matches against a few other schools. We’ve been winning, thankfully.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "(I have to admit, being club president has been much more tiring than I thought it would be.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "(I wonder when we’ll get our big break.)",
            "Shiro","", ""
        },
        {
            "","Shiro","","","","",
            "All right, students, class is over!",
            "Teacher","", ""
        },
        {   
            "","Shiro","","","","",
            "Finally!",
            "Student A", "", ""
        },
        {
            "","Shiro","","","","",
            "Lunchtime now. I’ve gotta track down Theodore to get some help on this calculus problem… Hm?",
            "Shiro","", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "This school… has a kind of… simple charm, I suppose. Clean and drab like an airport bathroom.",
            "Elizabeth", "BG", "Audio stop"
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Minimalism is overrated. They really need to step up their decor game. A few ribbons or poster really wouldn't kill them.",
            "Victoria", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "But even then, it’s still dull. There simply aren’t enough cute things here, that’s why!",
            "Victoria", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Where are the balloons, the flowers, the pink rabbits, the kitties, the cute dresses, the cute blond boys—",
            "Victoria", "unskippable", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, please do not forget why we are here.",
            "Mei", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Yes, yes, I know. Father didn’t hire you to be my maid just to chastise me.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "But still, I can scope out the competition and save them from becoming an aesthetic cemetary at the same time.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "That’s why I need you around to carry my things.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Uh, can I help you ladies find anything?",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Oh, hi! You are too sweet. No, I think we are getting along just fine. You can go back to sweeping the floors or whatever.",
            "Elizabeth", "BG", "TheOneOnTop"
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(Is this for a reality show or something? Am I being filmed?!)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "That is enough, Miss Elizabeth. She is clearly just a student.",
            "Mei", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "A student?! I should have known! You nearly blend in with the wallpaper in this dump.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "I am Elizabeth Kanasaki IV, heiress of Kanasaki Technologies. And my net worth being just a teensy bit more than the GDP of the United Kingdom, of course it’s a pleasure to meet me.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "That was really well done! Did you practice that speech in front of a mirror?",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Right-",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "I’m Victoria Akiyoshi. Don’t I just have the cutest name?",
            "Victoria", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "And I am Mei Machida, miss. I am pleased to make your acquaintance.",
            "Mei", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "All three of us are students from Schola Grandis, a neighboring school. We are here to conduct a tour of our competitors’ school.",
            "Mei", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(She’s so polite that it’s almost weird!)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(And her name’s fully Japanese, huh? She must be from the East.)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "When you say competitors, you mean, uh...?",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "What, you don’t know? Schola Grandis has arranged a dodgeball game with your school!",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "What?! Why are you bothering with small fry like us?",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Oh, my counselor mentioned something to me about brackets and draft picks, but I really wasn't listening.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Destroying upstarts and looking uh-mazing are more my core competencies.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "But I have to do it, however pointless and demeaning this may be. Many important persons depend on me, after all.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "My father said something about being a good girl, my teacher said something about upholding the reputation of the school, and my cousin said something about noblesse oblige.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Noblesse oblige? The Italians sure have some funny ideas, don’t they?",
            "Victoria", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "It’s Spaniards, Victoria. I know it’s very easy to confuse the two, but they’re not the same.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "……… ",
            "Mei", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "(Boy, she sure looks as dumbfounded as I am. Glad to have some company. ",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "I was told that the latest Pitt Crew joke was a bunch of slimy punks.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Could you point us in the right direction? Or should I just follow the stench? ",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Ah, well, the punks you mentioned have had their seat taken recently, and the new team is relatively more hygienic.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Ooooh! Thanks for the update! But I can’t even pretend to care, I’m afraid.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "That’s like a group of rats being beaten by a… group of slightly bigger rats.",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","","Elizabeth","Victoria","Mei",
            "Not your best, Elizabeth… ",
            "Elizabeth", "", ""
        },
        {   
            "","Shiro","Clemence","Elizabeth","Victoria","Mei",
            "Oh, Shiro! There you are!",
            "Clemence", "", ""
        },
        {   
            "","Shiro","Clemence","Elizabeth","Victoria","Mei",
            "The school’s given me a letter about our next match! We’re to fight Schola Grandis of all schools!",
            "Clemence", "", ""
        },
        {   
            "","Shiro","Clemence","Elizabeth","Victoria","Mei",
            "Wh-Whoa! You’re… who is this cutie?!",
            "Victoria", "", ""
        },
        {   
            "","Shiro","Clemence","Elizabeth","Victoria","Mei",
            "What? Who is this?",
            "Clemence", "", ""
        },
        {   
            "","Shiro","Clemence","Elizabeth","Victoria","Mei",
            "You’re… You’re here at last! You’ve come! You’re truly one of the blond boys I saw in my dream!",
            "Victoria", "", ""
        },
        {   
            "","Shiro","Clemence","Elizabeth","Victoria","Mei",
            "Wait, what? Dream? Wh-What are you talking about?",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "My name is Victoria Akiyoshi! And I demand you tell me your name and everything about you, cutie pie!",
            "Victoria", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "(I’ve never seen Clemence blush before. Guess everyone has a type.)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "With his somewhat feminine appearance, I am surprised that you saw right away that he is a boy.",
            "Mei", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Experience with all kinds of boys has given me very good eyes.",
            "Victoria", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Now, my dearest boy, let me look at you some more!",
            "Victoria", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Ah! Please, don’t get any closer! Help me, Shiro!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Shiro? Hold it, Victoria.",
            "Elizabeth", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Fair commoner boy, did you happen to mention Shiro Smith?",
            "Elizabeth", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Wh-Why, yes, I am! My name’s Clemence Kadou, and this is Shiro Smith.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "This wallflower is your leader? That's just tragic. ",
            "Elizabeth", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Oof. That stings, you know.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Also, I am positive I have never met you. I definitely would remember such a… unique young lady.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Heh heh heh… I’ve heard your name more times than it ought to be uttered! It’s practically all I hear about these days!",
            "Elizabeth", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, you should tell those two students the news.",
            "Mei", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "YFine, fine! Well, you of the Salt Pitt High dodgeball club, know this! A match has been scheduled between our two schools.",
            "Elizabeth", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "In two days time, I, Elizabeth Kanasaki IV, the president of Schola Grandis’ dodgeball club, will be giving you the grand tour of our irresistible technique!",
            "Elizabeth", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Oh, man, a match.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "A-Against you girls?",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Of course, my darling!",
            "Victoria", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, shall we head back?",
            "Mei", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Oh, yes, I think I’m about to go colorblind. Goodbye, peasants!",
            "Elizabeth", "", ""
        },
        {   
            "Shiro","Clemence","","Elizabeth","Victoria","Mei",
            "Goodbye, Clemence! I’ll stay true to you, my darling!",
            "Victoria", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Oh, Theodore, thank goodness!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Did you see the walking theme park with fancy clothing just leaving? They just challenged us to a match.",
            "Shiro", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Hmm… I see… Schola Grandis. It’s as if the perfume were sticking to the walls.",
            "Theodore", "BG", "lovelyTime"
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "They put on quite an act, but I checked the rankings. They’ve been in the upper half of our city’s rankings for the last few years.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "And now my confusion is moving steadily into fear. Awesome.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Don’t you see Shiro? Before us lies a chance to create a tremendous uproar in Ball City’s dodgeball scene.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Schola Grandis is one of the most prestigious and elite schools of the city, and if we win against them, our standings will rise prodigiously.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Wow, really? Is Schola Grandis the school currently representing this state, then?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Ah, no. That’s another school entirely, and once again, its name escapes me.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "All right, well, I’m game to take a crack at it if you two are. We need to practice harder than ever, though. I want to make it out of this thing alive, at least.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","","","Theodore","",
            "Well, I think we can buy a few things first before ending things for the day. Never hurts to have more refreshments, after all.",
            "Shiro", "BG", "Audio stop"
        },
        {
            "","","","","","",
            "",
            "","transition", "Map Screen"
        },
        {
            "","","","","","",
            "Two days later, about 10 AM...",
            "Narrator","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Wow. This school is absolutely spectacular!",
            "Shiro","BG", "lovelyTime"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "The garden alone looks better than our entire campus… I wonder whether they’re hiring gardeners.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Still, the Salt Pitt spirits are high. Look at how many of our comrades are in attendance.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "It’s a weekend. They probably didn’t have anything better to do.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Still, there’s so many! They really do care!",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "But it seems that there are a lot more Schola Grandis students. They want their queen to force us into checkmate.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And this queen never disappoints!",
            "???","BG", "Audio stop"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "I am totally shocked! I want you to know I won’t shame you if you give up now.",
            "Elizabeth","BG", "TheOneOnTop"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Look at our school. Look at our outfits. You have no chance. Keep some face and concede gracefully.",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "I’m sorry to tell you that that won’t happen, miss.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "No problem! I get to show off my battle outfit! Oh, Clemence!",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Wh-What?",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "I’m really looking forward to seeing how you’ll do in the match!",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Oh, uh, thanks, I guess!",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "(There’s that blush of his again.)",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Awesomely interesting as this conversation has been, it’s time to leave the riff-raff, Victoria",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, may I talk to them about something? It will only take a moment.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "I really, really, couldn’t care less. Just be ready to fight when I call for you.  Do you understand?",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Of course, Miss Elizabeth.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Miss Smith, I have some information that would help you.",
            "Mei","BG", "Audio stop"
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "I’m not conceding. I thought we made that pretty clear. ",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "No, worry not. It is not of that nature.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "It is about my teammates. Let me tell you some key information about them.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Victoria Akiyoshi, Miss Elizabeth’s friend, may seem cute and harmless, but in battle, she knows to be serious and can weaken your attacks.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Miss Elizabeth herself is unfortunately very prideful and would like the audience to see her more, so she works to make her attacks stronger.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "As for me, after a while, I will make sure that each of my teammates should return to normal and feel fewer of their injuries. A good old cup of tea does the trick.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "If I were you, I would use my service, so to speak, to your advantage. But you must know when it is right to do so.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "That is all that I will say, for I wish to keep some surprises still hidden.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Wow. That’s actually helpful",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Not a very tactically advantageous move, unless it’s trickery.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "We may actually have a shot at this.",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "But why? Why did you decide to tell us all of this? Aren’t you on the other team?",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "… I have one request for you. I humbly ask that you beat Miss Elizabeth in the match.",
            "Mei","BG", "DrearyDay"
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Excuse me? Are you really asking us to beat your mistress?",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Yes, that is correct. She has been, as you have seen, acting in ways unbecoming of her stature.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Only a defeat will put her back in her place.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "I guess that makes sense. But, Mei, it really seems like you don’t enjoy your job.",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "…… She is one of the most naive and difficult people to work for. There is no day at the end of which I do not feel tired and exhausted from watching over her.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "If you don’t like working for her family, then why haven’t you quit?",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "I appreciate your concern for me, but it is unneeded and unjustified.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Oh? What do you mean by that?",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Though Miss Elizabeth is a troublesome girl, I will not be pushed to leave the only home that we now have.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "My two younger brothers and I have already lost much, and as long as my brothers are kept happy, I do not mind a life of serving the Kanasakis.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "It is the duty of the elder to take care of the younger, after all.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "And as part of my debt to the Kanasakis, I must also make sure that the heiress of Kanasaki Technologies should grow into a good woman.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "That is only how things ought to go.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "…… I… I see.",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "That’s… I’m sorry, Mei.",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "… May I leave now? Miss Elizabeth will chide me for being late if I tarry.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "O-Of course.",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Thank you, Miss Smith.",
            "Mei","BG", "Audio stop"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "That poor woman. I didn’t expect her to have that kind of story.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "… It does rend my heart a little that we can’t do anything to help her, especially when she herself won’t let us help her. But we can do one thing for her.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And that is?",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Fulfilling her request to beat Elizabeth, of course! Come on, let’s go ready ourselves and then go to the gym!",
            "Shiro","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Schola Grandis Gym"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Everyone looks pretty pumped to see us compete.",
            "Shiro","", "_SFX/Final Voice Lines/Crowd Sounds/Murmuring/Murmuring_1"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "The other team hasn’t come yet. Those girls must be getting dressed.",
            "Clemence","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I do wonder what kind of foes we’ll soon face. There’s something odd about those girls for certain. I don’t think they’re just girls who become overconfident because of their higher status.",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Oh, you’ll see. They’re not what you have in mind.",
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
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Hello, everyone! I am very glad that you could make it today!",
            "Elizabeth","BG", "TheOneOnTop"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Whoa! What in the world is with your funny clothes?",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Yeah! You look like… princesses! W-Wow…",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "You have the right idea, but clearly, we are… magical girls!",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Wh-Whaaaat?! Magical girls!",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "(If I had any doubts before about being in a reality show…)",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "They totally look like magical girls on TV!",
            "Student A","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Heh, look at Salt Pitt. They’re shocked by our dear Elizabeth!",
            "Student B","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Go, Elizabeth!",
            "Student C","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Why are you so surprised? If you’d done your research, you would’ve learned of what makes us number one, Miss Average Girl!",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Don’t bother, Lizzy, our sparkle is lost on these dunces.",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Remember that your father wants you to keep a cooler head, Miss Elizabeth.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Wait… Theodore, did you know about this?",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Of course. I asked my good friend to ask some Schola Grandis students about the team, and they told him some ever so interesting details of this school’s dodgeball team.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "I was rather surprised when he told me them, to say the least.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "What?! Why didn’t you tell us beforehand?",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Of all the things I had heard of the dodgeball world, it was one of the least believable for us.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "We weren’t sure whether they were joking, and I wanted to surprise myself, so I chose not to look it up online. That, and your reactions were worth seeing.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "So are they actually magical? Or…",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Excuse me for interrupting, but may we begin? Everyone has come here to watch us play and not to watch you bicker.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "You’re right. And we can still take them on, even if they’re in their weird get-up.",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Weird? How dare you! You’ll pay for having insulted our extraordinary, exquisite, and expensive magical girl gear!",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Yeah! Ultra cute! Ultra violent!",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "And I will fight as best as I can for the House of Kanasaki!",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "(This cannot be over fast enough.)",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Theodore, Clemence, are you ready?",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Uh, guys, I don’t know about you, but I think the look really works for them.",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Don’t let it distract you, Clemence! It’s classic diversionary tactics.",
            "Theodore","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Oh, don’t worry about me, Theodore. I’m, uh, getting ready now…",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Uh, all right, then. Let’s begin!",
            "Shiro","BG", "Audio stop"
        },
};

// Scene 4 of Schola Grandis.

    
static string[,] scholaGrandisPostbattle = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Schola Grandis Gym"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "What just happened? WHAT JUST HAPPENED?!",
            "Elizabeth","BG", "End Battle"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Should have gone for something less flashy…",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Hurray for Salt Pitt!",
            "Student A","BG", "_SFX/Final Voice Lines/Crowd Sounds/Cheering/Cheering_4"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "No! Our Elizabeth can’t have lost!",
            "Student B","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "ALL RIGHT! I’m in the zone!",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "No, really, was that actual magic?",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, please calm down. The match is over, and your father will appreciate it if you accept your defeat humbly—",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Magical. Girls. Never. LOSE. Have you even watched the shows?",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Many times. Your father even paid the school some money to set up those special effects on the stage, so that our magic might be realized.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "No… No! I can’t accept this! I’m Elizabeth Kanasaki IV, heiress of Kanasaki Technologies!",
            "Elizabeth","", "_SFX/Final Voice Lines/Crowd Sounds/Cheering/Cheering_1"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "I… I refuse to acknowledge you as the winner!",
            "Elizabeth","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "Miss Elizabeth, please calm down.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "No! This isn’t fair! I… I demand a rematch!",
            "Elizabeth","BG", "Audio stop"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "What? A rematch? Just accept your loss already!",
            "Shiro","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "…… Elizabeth. She’s won the match. No doubt about that.",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "What? Not you, too, Victoria!",
            "Elizabeth","BG", "_SFX/Final Voice Lines/Crowd Sounds/Booing/Booing_3"
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "This can’t be... Everything I’ve done has fallen apart... How…",
            "Elizabeth","unskippable", ""
        },
        {
            "Shiro","Theodore","Clemence","Elizabeth","Victoria","Mei",
            "HOW DARE YOUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU!",
            "Elizabeth","unskippable", ""
        },
        {
            "Shiro","Theodore","Clemence","","Victoria","Mei",
            "No, Elizabeth! She’s fallen!",
            "Student A","BG", "_SFX/Battle sfx/hit/hit+grunt_1"
        },
        {
            "Shiro","Theodore","Clemence","","Victoria","Mei",
            "We must help her at once!",
            "Student B","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Victoria","Mei",
            "Wh-What’s just happened?!",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "…… Miss Smith. I thank you and your team very much for fulfilling my request. I cannot tell you how grateful I am.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "I will tend to Miss Elizabeth, hoping that she will learn to have some humility.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Now… May we meet again in happier times.",
            "Mei","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Oh, Clemence! I hope to see you again soon!",
            "Victoria","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Oh, uh, that’d be nice, I guess.",
            "Clemence","", ""
        },
        {
            "Shiro","Theodore","Clemence","","Mei","",
            "Yippee! Well, now that you’ve said yes, I need to start thinking of some plans! Farewell for now!",
            "Victoria","", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Map Screen"
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "And that’s the end of that. Elizabeth Kanasaki’s gotten her just deserts. And I hope that Mei and her two younger brothers will live happier lives.",
            "Shiro","BG", "lovelyTime"
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
            "A cooking school is nearby, actually.",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Do we need to defeat their dodgeball team to get a sandwich?",
            "Shiro","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "Hah! Well jested, my friend!",
            "Theodore","", ""
        },
        {
            "","Shiro","","","Theodore","Clemence",
            "I’ll take that risk. I’m feeling really pumped for some reason.",
            "Clemence","BG", "Audio stop"
        },
        {
            "","","","","","",
            "",
            "","black", ""
        },
        {   
            "","","","","","",
            "Dear Kuro,",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "How are you doing now?",
            "Shiro", "BG", "TodaysTale"
        },
        {   
            "","","","","","",
            "The Salt Pitt Dodgeball Club has climbed up the ranks again - we’ve beaten Schola Grandis, a very prestigious school! ",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "The school’s proud of me and my teammates for winning, and everyone was giddy to talk to me after the match.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "Because of our surprise victory, more schools are eyeing us, so we ought to expect another match soon.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "I’m still not fully sure on how things will turn out for me. Even though we won, the match was tough, and it strained my abilities to their limits.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "I can only wonder what kind of crazy gimmicks the higher-ranked schools have.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "But who knows? I may even see you soon at one of my games. I’d like for us to have some fun together later. I hope that you’re doing well.",
            "Shiro", "", ""
        },
        {   
            "","","","","","",
            "Best wishes, Shiro.",
            "Shiro", "BG", "Audio stop"
        },
};

















    ///////////////////////////////////////////////////////////////
    /// 
    /// MIGHTMAIN
    /// 
    ///////////////////////////////////////////////////////////////




// Scenes 1 and 2 of Mightmain Academy.
        
static string[,] mightmainPrebattle = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {   
            "","","","","","",
            "Weeks later, when students head home, and winter break comes near...",
            "Narrator", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "… Oh yeah, there are lots of schools in Ball City, I tell ya! We have a population of nearly nine million people, after all!",
            "Clemence", "BG", "lovelyTime"
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
            "I’m pretty bushed, honestly. Maybe some other day.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Sounds good. I’ll make a list of must-see locations and organize them by importance. Burger Ball is a top contender, obviously.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "That sounds interesting.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "You’re gonna be eating that burger through a straw!",
            "???", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Oh, man, I thought I smelled something.",
            "Shiro", "BG", "UpToNoGood"
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Wh-What are you doing here?",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "I hear you gave those magical girls a beating a while ago. Can’t say I saw it coming. I thought for sure you would lose.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Yeah, but you won! We’re proud!",
            "Frank", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Well, you are, but I’m not! How could we not know about your win, what with everyone jabbering about it non-freaking-stop?!",
            "Greg", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "The time when you stepped into my turf and humiliated me has been playing in my mind over and over again, nonstop, for the last month.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "You’d better believe I’ve been itching to put you in your place. Your little run of luck ends today. Now.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "I got shivers, boss. Really well done.",
            "Greg", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "You’re a mook’s dream come true!",
            "Frank", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Trevor, you can drop the act already.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Are you really talking to me, Four-Eyes?",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "However much of a punk you may be, doubtless you are a smart fellow with many fine points. You could be using your intelligence for something more productive, like helping the city.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "But instead, you choose to kick around with these sycophants and live that empty life of yours. Why?",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "I can live my life any way I want. I don’t need lip from goody-goods.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "But you know what? I’ll answer you.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "What I most want is control. Is that so bad now?",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "You may call it no good, but you ought to use that brain of yours for once.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "You and I may be different men, but we belong to the same society.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "As a society, we must care for each other and do good.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "And you’ve truly done no good. Even if you haven’t run afoul of the law, you still have hurt others, and I will not stand for it anymore.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "………",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "(Trevor actually looks surprised… Is he taking his words seriously?)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Hot air from some privileged shoe-shiner who tells speeches to make himself feel morally superior.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Trust me, Theodore. There will come a time when you will find yourself in my shoes.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "You’ll want to have control over something so important to you that you’ll do anything for it, even if it means becoming a lowlife like me.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "I know your kind all too well. Deep down, you are on the same level as I am.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "What? Ridiculous! If anything’s hot air, it’s your attempt to dissuade me.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Playing that way, aren’t you? Well, then, get a load of this! Greg, Frank, NOW!",
            "Trevor", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Yes, boss! One, two, three, go!",
            "Greg", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Oof!",
            "Theodore", "BG", "_SFX/Battle sfx/hit/hit+grunt_1"
        },
        {   
            "Shiro","Clemence","Theodore","Trevor","Greg","Frank",
            "Gah!",
            "Clemence", "BG", "_SFX/Battle sfx/hit/hit+grunt_2"
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "Theodore! Clemence!",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "They interfered with our fight last time. It’d be bad for me if that were to happen again, I thought.",
            "Trevor", "BG", "UpToNoGood"
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "That thought of yours was pretty smart, boss!",
            "Greg", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "Smartest boss in town, I tell you!",
            "Frank", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "My men only wanted to play dodgeball with those two. It so happens that they weren’t ready for their throws. A pretty big shame, isn’t it?",
            "Trevor", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "That’s a bad excuse, and you know it, you bully!",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "Bad excuse or not, it’s now just you against us three. Now it’ll go like it should have that day.",
            "Trevor", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "(Oh no… What should I do? I can’t run, and I certainly don’t want to leave my two friends! And those punks mean serious business!)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "Whatever plan you’re thinking up, it’s no use. Give up, and make it easy for me.",
            "Trevor", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "Never!",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "Putting up a fight, are you? Trust me, it’s not gonna be like last time.",
            "Trevor", "", ""
        },
        {   
            "","Shiro","","Trevor","Greg","Frank",
            "Worry not, miss! We two will deal with those no-good punks in no time!",
            "???", "BG", "Audio stop"
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "(Whoa! Who are these two?! They look like they’re from the military, and the guy is so… angular!)",
            "Shiro", "BG", "MilitaryMight"
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "I’m Harold Kuga! Here to save any citizen in danger!",
            "Harold", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "And I’m Skylar Hata. I’m here too.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "And we will not let you terrorize this girl and her friends!",
            "Harold", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Try me, jarhead.",
            "Trevor", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Miss, you were about to go against those three by yourself.",
            "Harold", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "That’s brave. But with your permission, we’d like to fight alongside you!",
            "Harold", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "This shouldn’t take long. Few minutes, tops.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "(As if they had to ask.)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Oh, yes, by all means, please help me deal with those guys!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Thank you, miss! Now, let’s get down to it!",
            "Harold", "BG", "Audio stop"
        },
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Gwah! Not again!",
            "Trevor", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "My face hurts!",
            "Greg", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Why is this happening?!",
            "Frank", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "As I thought. You may rev up pretty loud, but when the going gets tough, you fall and crash.",
            "Skylar", "BG", "MilitaryMight"
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "(W-Wow… these guys are something else! The man looks like he was built in a hunk factory, and the girl… well she certainly is there! Who are these two?)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Boss, we’d better hightail it out of here! I can only take so much punishment!",
            "Greg", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Yeah! We can’t beat her with those two around!",
            "Frank", "", ""
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "…… It seems that my judgment was wrong. Payback has just been rescheduled, boys.",
            "Trevor", "BG", "Audio stop"
        },
        {   
            "Shiro","Harold","Skylar","Trevor","Greg","Frank",
            "Mark my words, Shiro Smith. I, Trevor Akuouji, will return this punishment a hundred times over.",
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
            "Shiro", "BG", "lovelyTime"
        },
        {   
            "","Shiro","","","Harold","Skylar",
            "I don’t know what would’ve happened if you guys hadn’t come!",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Harold","Skylar",
            "By the way, are those two your friends?",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Ah, I should never have let my guard down! How dishonorable that man is!",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Oh, thank goodness you’re okay!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "If Trevor didn't have such a complex, they’d leave us alone. Too bad his lackeys are too drawn in to speak against him.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Don’t worry about them! If they try to do their heinous business again, their second lesson shall be far harsher!",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Well, thank you very much for saving us. Who are you, if I might ask?",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Ah, I haven’t fully introduced myself! I’m Harold Kuga, a student of the army branch of our school.",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "And I am Skylar Hata, I study in the air force branch. Both of us are members of Mightmain Academy’s dodgeball club.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Wait! You said \"Mightmain Academy\"?",
            "Shiro", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Yes, of course!",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Mightmain Academy… That’s the same school that my older brother goes to!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Wh-What?! Your brother goes to Mightmain, Shiro?!",
            "Clemence", "BG", "MilitaryMight"
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Shiro! Of course! You must be speaking of Admiral Kuro!",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Kuro! Do you know him?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Hah, he’s the reason for our little rendezvous!",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "A few hours ago, he asked us to find his sister, since he was busy.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "He wanted us to deliver you this news beforehand: he had had Mightmain Academy arrange a match against Salt Pitt High!",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Wh-What?!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "A match! That’s a school board decision! Not even Shiro can make that kind of call.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "For Kuro, it’s different! He’s the highest of his branch, and our school lets him have more say in arranging matches!",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Each of our branches has its ranks, and the higher one goes, the more benefits and rewards one gets. It’s supposed to motivate us to work hard. A carrot and the stick kind of thing, I guess.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "(A fight… against Kuro… I-I can’t believe this. What made him arrange a fight with me?)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "(When I said that I might see him soon, I wasn’t exactly thinking of this! Kuro, what are you up to?)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "(I can’t freak out now…)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "I… I accept the challenge. I’ll go up against my older brother.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "What?! Are you sure, Shiro?",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Well! We certainly have been doing well so far. But I cannot advise this move, Shiro. Mightmain outclasses us in every aspect of the game.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "You runts talk as if you’ve never heard of practice! Success is made of burpees and calloused hands! Why, just this morning, I―",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "You’ll be facing against us Saturday at 11 AM. Use your time wisely.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Thanks for the tip.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Look at it this way, Theodore: at least they are a friendly bunch. You can’t say that for everyone we’ve fought against. Lucky!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Hoorah! Mission accomplished! Today has been a good day!",
            "Harold", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "It’s about time we headed back to Kuro and told him that the message has been delivered.",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Harold","Skylar",
            "Goodbye, Miss Shiro. I’m looking forward to our fight!",
            "Harold", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Well! The gauntlet continues. We really don’t get a break between these matches lately.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "… We have time to train until the weekend comes. We can’t waste any time. We start bright and early tomorrow.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "So serious, Shiro.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "I guess it’s one thing to fight rival schools, but another to fight family.",
            "Clemence", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Map Screen"
        },
        {   
            "","","","","","",
            "A few days pass, and it is now Saturday morning...",
            "Narrator", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "(Today’s the big day! I’ll be going up against Kuro! We’ve trained all week for this, but we still have no idea how tough my brother will really be.)",
            "Shiro", "BG", "lovelyTime"
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "(And why is he doing this now?)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Don’t worry, Shiro! Everything will be fine… I hope.",
            "Clemence", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Confidence, Clemence. We need confidence if we are going to even stand a sliver of a chance.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Besides, my friend and I have done a little research into the team.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Mightmain’s team uses special suits that the military made with the Witship Institute, the great science and engineering academy.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "What?! They have special suits? The military has special suits designed only for dodgeball? That HAS to be cheating!",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "I jest not, I fear. And moreover, Harold Kuga will have some kind of cannon, and Skylar Hata a special pair of boots.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Weapons are not forbidden in the game, as long as they do not seriously injure players. The government even uses technology of a similar grade.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "A cannon?! Is that true? Do you think we could get our hands on something like that?",
            "Clemence", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Alas, we have no such gear. There’s no point in bemoaning our lack of upper hand in Mightmain’s field, however.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "We must make do with what we have, and we may still win. The flow in a game of chess changes quickly, even when you are left with a single rook.",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Uh, pluckiness isn’t a replacement for heavy machinery.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Shiro, I need you on my side here. Are you still sure of yourself about fighting your brother?",
            "Theodore", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "O-Of course I am! I may be the younger sibling, but I can show him all that I have learned in the past few months.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "You’re right, Theodore. The odds have always been stacked against us, but we always scrape on by. That will be enough, even now.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "I want more than that from you, Shiro!",
            "???", "BG", "Audio stop"
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "That’s… him!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Kuro! Big brother!",
            "Shiro", "BG", "MilitaryMight"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Oh, Shiro, it’s been a while since we last saw each other in the flesh! I’ve gotten your letters, and I’m glad that you’ve been doing well.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "You’re Shiro’s brother, you say? If truth be told, I thought of someone taller and sterner when I first heard of you.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "You’re hanging out with some real charmers, Shiro.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Don’t worry about him. Uh, I take it you’re in the Navy?",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            " That's right! I’ve always liked the idea of working at sea.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "I’ve tried to take Shiro out on fishing trips and such, but she ends up hurling into a bucket back in the cabin. But we have a lot more in common than you would think!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Kuro… What pushed you to arrange this fight?",
            "Shiro", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "… I’ve told you that I’ve gotten your letters.",
            "Kuro", "BG", "DrearyDay"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "You’ve picked up dodgeball again and have made a bit of a name for yourself by beating such schools as Schola Grandis.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "You’ve clearly improved. And yet you still feel uncertain about your future with it.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "There’s one way to help you decide whether you want to go along with this any longer.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Shiro… know this: I plan to push you hard in the fight to test your heart and soul.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Have you the will to make it to the top of the dodgeball world?",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "I want to see the answer firsthand.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "…...",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Well, I must get going! I must go prepare with Harold and Skylar.",
            "Kuro", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "They’re two close friends of mine, and I’m glad to see that you three have the same bond.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "And, hey, however today’s game may end, I’m taking you three to lunch after the match.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "You’re on!",
            "Clemence", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Kuro… I see.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Shiro, are you all right? He has a truly imposing will.",
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
            "","transition", "Mightmain Gym Full"
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "(Ah, Kuro’s team is already here! Harold’s wearing some scary cannon, and Skylar’s boots look like planes!)",
            "Shiro", "BG", "MilitaryMight"
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "(But Kuro… doesn’t have any special armor. Only a sword. Huh.)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "I know what you’re thinking, Shiro. But armor really limits the maneuverability you have on the field. Personal preference.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "With my boots, your chances of hitting me are looking pretty slim, girlie.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "You’ll soon behold the beauty of my armor piercing cannon! I’ve been shining it all morning.",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "Of course, we can fight just as well without our special weapons and gear. But it makes the crowd go crazy, so why not?",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "Well, Shiro, we’ve delayed this game long enough. Let’s begin!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "Yes, let’s begin!",
            "Shiro", "BG", "Audio stop"
        },
};



    
static string[,] mightmainInterbattle = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Mightmain Gym Full"
        },
        {   
            "","","","","Harold","Skylar",
            "Oof… Absolutely magnificent!",
            "Harold", "", ""
        },
        {   
            "","","","","Harold","Skylar",
            "Huh… That team’s better than I thought.",
            "Skylar", "", ""
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "I-I can’t believe I’ve managed to beat them on their own turf!",
            "Shiro", "BG", "End Battle"
        },
        {   
            "","Shiro","","","Theodore","Clemence",
            "Indeed! Their special gear is a little too heavy to be practical.",
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
            "Kuro", "BG", "Audio stop"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Y-You’re still standing! I thought we got you out!",
            "Clemence", "", ""
        },
        {   
            "","","","","Kuro","",
            "Nope. But the ball almost got me, I’ll give you that.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "…...",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Heh heh… You’ve certainly surprised me, Shiro! Even for you, my dear sister, you’ve pulled off a feat greater than what any of us have imagined!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "You’re the only one still standing, and your teammates are too tired to stand back up.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "It’s only a matter of time before you fall as well, and the game ends.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Heh, yes, this game will end soon. But as long as I stand, it’s not over.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "I have not yet begun to fight.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Huh?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Admiral! She’s been checked, and she’s ready to go!",
            "Military Student", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Excellent, Private. Send her in!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "\"Send her in\"? Uh oh.",
            "Clemence", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Mightmain Gym Full"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Wh-Wh-Wh… WHAAAAAAAAAAAAAAAAAT?! What in the world is that doing here?!",
            "Clemence", "BG", "KurosTrumpCard"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "This is the UPF Yamato, my trump card.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Once a great warship, she’s been repurposed to serve us in the dodgeball field!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Pretty big for a trump card, don’t you think?",
            "Student A", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Oh, the admiral’s so amazing!",
            "Student B", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "There’s no coming back from that!",
            "Student C", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Oh, come on! That has to be against the rules!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Well, according to everyone I asked about—and trust me, I asked a lot of people about this—I can have a battleship on the field, as long as I have heavily reduced her capabilities to a suitable level.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "So don’t worry, Shiro. She won’t kill you. She, compared to how she was used in the past, is graceful.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "\"Graceful\" is not what I would call that thing!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Well, you can’t deny that she’s one heck of a titaness.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "He’s right, you know!",
            "Student A", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "No one can win against that! She’s a battleship, for crying out loud!",
            "Student B", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Isn’t it amazing we can do this in dodgeball? What a sport!",
            "Student C", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "I warned you, Shiro, that I would test your will to the fullest.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Now, can you still beat me, even with my dear ship? With her, I can at last fight with all my might!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Kuro! You… You…!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "What’s wrong, Shiro? Cat got your tongue?",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Well, if you switch \"cat\" for \"big bad ship\", yeah!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "You… You aren’t playing fair, even if the rules back you up!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "I’m only telling you the facts, Shiro, and the facts are often not fair.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "And trust me, there’s much more ridiculous stuff out there. Did you even watch the national tournament last year?",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Hey, do something already!",
            "Student A", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Now’s no time for waiting!",
            "Student B", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Yeah, beat her till she says uncle!",
            "Student C", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Hear that? My men are begging me to do something. I say we’ve talked long enough.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Now… Up I go!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","","",
            "Whoa! He climbed up that rope and jumped onto the ship! Incredible!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Heh heh heh... It was painful to practice that move, you should know!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "I can’t believe this! Shiro, your brother planned for this to happen!",
            "Theodore", "", ""
        },
                       {    
            "Shiro","Clemence","Theodore","Kuro","","",
            "... Oh! Shiro, look around! Look at the audience!",
            "Clemence", "BG", "Audio Stop"
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "What? … Ah! It’s not only our students and Mightmain ones!",
            "Shiro", "BG", "End Battle"
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "I see students from many other schools as well! Are they truly all here for me?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Remember me? I was watching you the other day!",
            "Student A", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "And I as well!",
            "Student B", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Oh, shut it, you two! We were all there that day!",
            "Student C", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Why, what a marvelous sight!",
            "Theodore", "BG", "_SFX/Final Voice Lines/Crowd Sounds/Cheering/Cheering_4"
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Oh, a lot of people won’t be forgetting this match!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "It’s odd. I feel that this is a good sign for our future.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "(Our future…)",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "They’ve come to cheer us on, I’m sure of it. Even if the odds are against us, they still expect a good match.",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Is that so? But…",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Hey, Shiro! I… I’d have agreed with you, if I hadn’t been learning from my matches!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "I’ve learned that even when the odds turn against us, with a little will, we can still turn things around!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "And it takes will to stand your ground. Shiro, even with the odds stacked against us, we can still beat him, right?",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Oh, sure, Shiro, you can!",
            "Student A", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "Don’t let us down now!",
            "Student B", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","","",
            "We haven’t come all the way here to see you grovel!",
            "Student C", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Can… Can I still beat him?",
            "Shiro", "BG", "_SFX/Final Voice Lines/Crowd Sounds/Cheering/Cheering_1"
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Even when the odds are against me?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Even when my team and I have been sorely weakened from the last fight?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "………… There’s only one way to find out.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Hah! Get me, if you can! I’d like to see how far you’ll truly make it!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Though you are my sister, I won’t hold back now!",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "That’s all good enough for me!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Theodore, Clemence! I am now fully ready! I will fight, however tough the going may be!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Shiro! If you say so, then I’ll fight as well!",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "And so will I! Everyone’s watching and backing us up, so we’re not alone!",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","Kuro","",
            "Thanks, guys! Now, let’s get to the end of this game!",
            "Shiro", "BG", "Audio stop"
        },
};

    
static string[,] mightmainPostbattle = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Mightmain Gym Full"
        },
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
            "Shiro","Clemence","Theodore","","","",
            "He’s outside now! Get him, Shiro! ",
            "Theodore", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","","",
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
            "Kuro", "unskippable", ""
        },
        {   
            "Shiro","Clemence","Theodore","","","",
            "I… I can’t believe it! We’ve won! We’ve won! We’ve won!",
            "Shiro", "BG", "End Battle"
        },
        {   
            "Shiro","Clemence","Theodore","","","",
            "I can’t believe it, too! We beat your brother, and he was definitely stretching the rulebook with that last stunt.",
            "Theodore", "BG", "_SFX/Final Voice Lines/Crowd Sounds/Cheering/Cheering_4"
        },
        {   
            "Shiro","Clemence","Theodore","","","",
            "I’ve gotta get back to Salt Pitt and tell everyone. I wonder whether we’ll be on TV or something.",
            "Clemence", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","","","",
            "…… Kuro? Kuro!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "Kuro! Are you okay?",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "Shiro? Hah! Of course.",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "C’mon, brother, you clearly need to lie down.",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "He’s fine. He can handle a little water. Too strong-willed for his own good.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "Heh heh! Shiro, you too have a strong will, having beaten me, Skylar, and Kuro, even with his trump card! You deserve my praise!",
            "Harold", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "I’ve gotta give you props as well.",
            "Skylar", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "Listen! Do you hear the crowd?",
            "Kuro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            " All the students are cheering my team’s names! Even the ones from your school are cheering!",
            "Shiro", "", ""
        },
        {   
            "Shiro","Clemence","Theodore","Kuro","Harold","Skylar",
            "But of course we are! We know a good match when we see one!",
            "Harold", "", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {   
            "","Shiro","","","Kuro","",
            "What a day this has been! I still can’t believe I won our match!",
            "Shiro", "BG", "Audio stop"
        },
        {   
            "","Shiro","","","Kuro","",
            "Even with my trump card, I lost. Not my greatest tale to tell the fellows.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Now that things are all over, maybe we can finally spend some time together.",
            "Shiro", "BG", "Resolution"
        },
        {   
            "","Shiro","","","Kuro","",
            "…… Shiro, I take that you’ve found the answer to my question earlier.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "… Yes. I’m sure that dodgeball is my calling now.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Even if the matches to come are truly tough, I’ll tough it out.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "And even if I can’t get to the top, well, I’m sure I’ll have gotten myself something great along the way.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Attagirl! I’m glad to see that you’re willing to keep going forward, be it ever so tough and tiring.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "You’ll need that spirit to make it.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Kuro?",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "What is it?",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "I just want to tell you…",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Thanks. I couldn’t have realized this without you.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Don’t mention it. I was doing all this not for my sake but for yours.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "I’m your older brother. It’s only right that I take care of you.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Just like when we were kids.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "…… Come to think of it, today’s the first day of winter break, isn’t it?",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Yep. Everyone was glad to leave school yesterday, though the team and I had to get ready for practice instead of relaxing.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Ah, is that so? Well, I was wondering…",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Do you still remember Middleton?",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Our hometown? Of course I do!",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Even though I talk with Mom now and then on the phone, there’s nothing like seeing her in the flesh.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "And I miss my old classmates and my neighbors as well. Ball City’s nice and all, but…",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Then let’s pay our hometown a visit.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Huh? You mean soon?",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Very soon! I’ve just checked, and a train to the western parts of the country will come in an hour or so.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "What do you say? Shall we head back home for winter break?",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "…… It’s been quite a journey since I set out for Ball City.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "I never could have imagined myself becoming the new president of a dodgeball club.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "I’ve now found my place in this world at last, and yet I miss home…",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "Isn’t how these things usually play out? The hero gets what he wants and then returns home.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "But don’t worry, Shiro. You’ll come back here at the end of the break, and a whole new journey will begin.",
            "Kuro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "……… It’s as they say: there truly is no place like home.",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "(Everyone… I’ll be leaving now.)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "(But don’t worry. I’ll be back soon. I’ll be gone for only a short while.)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "(Well, then, it’s time for me to take my leave.)",
            "Shiro", "", ""
        },
        {   
            "","Shiro","","","Kuro","",
            "I’m all ready to go now, Kuro. Let’s go.",
            "Shiro", "BG", "Audio stop"
        },
        {
            "","","","","","",
            "",
            "","black", ""
        },
};

static string[,] credits = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Street"
        },
        {
            "","Clemence","","","Victoria","",
            "Oh, Clemence Kadou, you ought to join me for a little walk across town!",
            "Victoria","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "I know many perfect sights just for you and me!",
            "Victoria","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "O-Oh, thank you, but—",
            "Clemence","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "No ifs, ands, and buts, my dear Clemence!",
            "Victoria","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "O-Ooh… I really have to go.",
            "Clemence","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "Come, now, Clemence! Let’s go see a movie together first! It’ll be fun!",
            "Victoria","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "Aah… I-I guess it won’t hurt to watch one with you.",
            "Clemence","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "Yay! Follow me!",
            "Victoria","unskippable", ""
        },
        {
            "","Clemence","","","Victoria","",
            "Hey! Y-You really don’t have to drag me, you know! You have a really strong grip...",
            "Clemence","unskippable", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Schola Grandis Gym"
        },
        {
            "","Mei","","","Elizabeth","",
            "Miss Elizabeth, are you still shocked by your loss?",
            "Mei","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "… I just don’t understand. How could I have lost against a commoner?",
            "Elizabeth","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "My dear equipment cost thousands of dollars! It’s first class!",
            "Elizabeth","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "If I may say something, perhaps there is more to winning a match than having better tools.",
            "Mei","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "It takes skill from the user as well.",
            "Mei","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "… Don’t be ridiculous, Mei.",
            "Elizabeth","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "That commoner girl and her friends could not have been more skilled than I, Elizabeth Kanasaki IV!",
            "Elizabeth","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "…… Do you have a plan to win the next match against them, if we should face against them again?",
            "Mei","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "I don’t like to strategize when I’m thirsty. Fetch me me some tea, Mei.",
            "Elizabeth","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "And one other thing, Mei?",
            "Elizabeth","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "Yes, Miss Elizabeth?",
            "Mei","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "Uh… Thank you for helping me. I can’t handle things in my ever so busy and important life without you.",
            "Elizabeth","unskippable", ""
        },
        {
            "","Mei","","","Elizabeth","",
            "I would not be doing my job otherwise.",
            "Mei","unskippable", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Mightmain Gym Full"
        },
        {
            "","Harold","","","Skylar","",
            "I am always willing to save my fellow citizens from any danger!",
            "Harold","unskippable", ""
        },
        {
            "","Harold","","","Skylar","",
            "That’s why I’m the ideal hero of the UPF!",
            "Harold","unskippable", ""
        },
        {
            "","Harold","","","Skylar","",
            ".....",
            "Skylar","unskippable", ""
        },
        {
            "","Harold","","","Skylar","",
            "Skylar! I just had a really good line! I need backup!",
            "Harold","unskippable", ""
        },
        {
            "","Harold","","","Skylar","",
            "I get more done ignoring you, so why start now?",
            "Skylar","unskippable", ""
        },
        {
            "","Harold","","","Skylar","",
            "You’ll never get an incredible, beefcake husband if you keep acting this way!",
            "Harold","unskippable", ""
        },
        {
            "","Harold","","","Skylar","",
            "Beefcakes are overrated. I bet I’ll get a husband before you even start dating, big guy.",
            "Skylar","unskippable", ""
        },
        {
            "","Harold","","","Skylar","",
            "Hah! Is that a challenge, I hear? Well, then, I’ll show you how wrong you are! I’ll get myself a wife before you know it!",
            "Harold","unskippable", ""
        },
        {
            "","","","","","",
            "",
            "","transition", "Classroom"
        },
        {
            "","Theodore","","","","",
            "All of this dodgeball excitement has left me ignoring my chess training!",
            "Theodore","unskippable", ""
        },
        {
            "","Theodore","","","","",
            "Unacceptable! If I can be incredible at two things, why not?",
            "Theodore","unskippable", ""
        },
        {
            "","Theodore","","","","",
            "But I’m not worried. She’ll be back, and things will as they were.",
            "Theodore","unskippable", ""
        },
        {
            "","Theodore","","","","",
            "A man must exercise both his brain and his body in order to be a true gentleman!",
            "Theodore","unskippable", ""
        },
        {
            "","Theodore","","","","",
            "… And maybe I need to stop talking to myself.",
            "Theodore","unskippable", ""
        },
        {
            "","Theodore","","","","",
            "I ought to call someone about all this instead.",
            "Theodore","unskippable", ""
        },
        {
            "","Theodore","","","","",
            "Let’s see here… Which number to pick… Ah.",
            "Theodore","unskippable", ""
        },
        {
            "","Theodore","","","","",
            "I haven’t called this one for a long while. I wonder how he’s been…",
            "Theodore","unskippable", ""
        },
};

static string[,] epilogue = new string[,]{
        {
            "","","","","","",
            "",
            "","transition", "Stadium"
        },
        {
            "","Trevor","","","Greg","Frank",
            "Boss, it’s been weeks since we got beaten badly, and we still haven’t gotten back at those nerds! I’m getting itchy.",
            "Frank","BG", "Audio stop"
        },
        {
            "","Trevor","","","Greg","Frank",
            "Yeah, what gives, boss? Don’t we have a plan to take our revenge?",
            "Greg","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "I thought we were the Pitt Crew, the best of them all!",
            "Greg","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "Waiting is difficult, but it’s the most important part of the plan.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "Think you lunks can handle it?",
            "Trevor","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "Sure thing. I’ve got nothing better to do.",
            "Frank","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "But how long do we have to wait?I can hear the school’s laughter echoing in my head.",
            "Greg","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "I’ll let you in on my thinking.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "As Shiro Smith and her crew have just beaten Mightmain Academy, they will likely be rising again and again in the world of dodgeball. They may even be chosen for the nationals!",
            "Trevor","", ""
        },      
        {
            "","Trevor","","","Greg","Frank",
            "How painful her downfall will be from such lofty heights.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "That’s good thinking there, boss! Ohohohohoho!",
            "Frank","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "Yeah! What a great plan! Ahahahahaha!",
            "Greg","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "Now, go around the school and find information on what Shiro Smith’s up to.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "And be subtle about it, for once. She’s not gonna get away with this, I swear it.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "Yes, boss!",
            "Frank","", ""
        },
        {
            "","Trevor","","","Greg","Frank",
            "We’ll be right back!",
            "Greg","", ""
        },
        {
            "","Trevor","","","","",
            "…………",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Ugh… Damn it!",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Why do I have to wait this long to get what I want?!",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "How could I let this happen?! I should have beaten that girl and her two stupid friends that day!",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "How did I lose?! Did I make a mistake? Impossible!",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "It was Shiro Smith! It was her friends! It was all those who went against me!",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Well, to hell with them all! One day, they’ll all be bowing to me, and I’ll have the last laugh!",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "……… No, no, I shouldn’t get too angry. I can still win.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Yes, yes, even with these setbacks, everything’s going smoothly.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Greg and Frank, those witless saps, have served me well, at least.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "For now, all I have to do is wait.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Shiro Smith’s no beginner anymore, but she truly does not know what she’ll be up against.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "I almost feel bad for the girl. But she was dead meat the second she stepped onto my turf.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Hahaha… Come to think of it, it’s the end of fall.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "It’ll be the beginning of winter… and the beginning of Shiro Smith’s end.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Funny how things should line up. Not a bad end for this season.",
            "Trevor","", ""
        },
        {
            "","Trevor","","","","",
            "Business will be exciting next season.",
            "Trevor","", ""
        },
        {
            "","","","","","",
            "",
            "","black", ""
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
        {"Salt Pitt Prebattle", saltPittPrebattle},
        {"Salt Pitt Postbattle", saltPittPostbattle},
        {"Schola Grandis Prebattle", scholaGrandisPrebattle},
        {"Schola Grandis Postbattle", scholaGrandisPostbattle},
        {"Mightmain Prebattle", mightmainPrebattle},
        {"Mightmain Interbattle", mightmainInterbattle},
        {"Mightmain Postbattle", mightmainPostbattle},
        {"Credits", credits},
        {"Epilogue", epilogue},
	};
	/*
	public Dictionary<string, string[][]> characters = new Dictionary<string, string[][]> {
		//must have 3 in each
		{"test scene", new string[][]{ new string[]{"char1","char2",""}, new string[]{"char3","char3",""}} },
		{"steamed hams", new string[][]{new string[]{"Chalmers","Seymour"}} }
	};
	*/



}
