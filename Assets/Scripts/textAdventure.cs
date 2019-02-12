using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class textAdventure : MonoBehaviour
{
    // Necessary stuff for game to work
    [Header("Text Box")]
    public Text story, left, right, title, response;
    [Space]

    [Header("Button")]
    public Button leftB, rightB, continueB;
    [Space]

    [Header("Audio Sources")]
    public AudioSource sound;
    public AudioClip jumpShort;

    /// <summary>
    /// All the story lines and button names
    /// </summary>
    GameObject buttonL;
    GameObject buttonR;
    GameObject storytext;
    GameObject titletext;
    GameObject continuebutton;
    GameObject respond;

    private List<string> one = new List<string> { "My King", "My king, my name is Aresion, the current drought has starved my family to near death. We require sustenance. Please my king, what can you do for my family of 3.", "Gold", "Sword", "I understand you must provide for a family of three and these are hard times. Please Aresion. Take this 15 pieces of gold and feed your family for the week.", "Give a man a fish and he will eat for a day, teach him to fish and he will eat forever. Please take this steel sword and provide for your family." };
    private List<string> criko = new List<string> { "The Criko", "Sir! We have word that the Criko are invading! What shall we do??", "Thats fine", "Defend!", "The Criko? HA. They don't have the balls to invade us. Just keep on doing your job.", "The Criko!? Where is Captain Yaseen!?!? Tell him to get the archers armed and ready! ALL ABLE BODIES PREPARE FOR BATTLE!" };
    private List<string> downOne = new List<string> { "Kingdom's Downfall", "Due to underestimating the strength of the Criko you have been defeated and now you must sulk in the fact that you allowed them to defeat you so easily... loser.", "Restart", "Restart", "restarting", "restarting" };
    private List<string> Weapon = new List<string> { "Weapon of Choice", "Sir you must arm yourself as well. Will you advance on the Criko with us sword in hand or stay on the walls with the archers?", "Sword", "Bow", "I am not King for nothing! These Criko will learn quickly that those who mess with my kingdom are quickly turned to mincemeat.", "My genius is better suited behind the walls where I can strategize based on the tide of the war" };
    private List<string> sword = new List<string> { "Sword", "With sword in hand you must now put on your armor my lord.", "Royal Armor", "Dark Knight Armor", "The Royal armor gives you +2 style points! Nice.", "The Dark Knight Armor comes with a cool cape and lets you blend in with the night. +2 Dexterity too!" };
    private List<string> bow = new List<string> { "Bow", "Sir I am sorry to ask but... do you know how to use the new bows we now have? After pulling it back you just have to press the trigger because the string will hold the bow back.", "Yes", "No", "Of course I do! I am your king!", "Hmmm... this is quite different from what I envisioned when you talked about us having more advanced bows.I will take my sword on second thought" };
    private List<string> downTwo = new List<string> { "Kingdom's Downfall", "Well that was dumb. After trying to figure out how to use the new crossbolts you put it on the floor to load it and shot yourself in the chin... You really hate to see it.", "Restart", "Restart", "restarting", "restarting" };
    private List<string> tide = new List<string> { "Tide of War", "My King! The Criko have arrived with 3 armies worth of men. Captain Yaseen has notified me to bring you to your quarters for safety until this all ends.", "I am the king.", "Safety", "I will not back down from a fight on my... on OUR kingdom. We will all pushback the Criko together.", "The Criko brought three armies worth of men for me? Sheesh. Let us retreat back to my quarters immediately!" };
    private List<string> downThree = new List<string> { "Kingdom's Downfall", "Upon entering your quarters, a cannonball blasts through the wall. This cannonball proceeds to explode sending fire and shrapnel everywhere. Due to unfortunate circumstances, the cannonball missed you but the fire set your cool cape ablaze and burned you to death.", "Restart", "Restart", "restarting", "restarting" };
    private List<string> frontlines = new List<string> { "Front-lines", "Sir the archers have managed to hold back the Criko and disable their ranged soldiers. Shall we advance?", "Of course!", "Hold.", "Is that a joke or a statement? Ofcourse we shall advance!", "Let the Criko eat a few more arrows before we push in on them, let them weaken themselves while we prepare to slaughter them." };
    private List<string> horse = new List<string> { "Horse", "My king! A horse approaches you! Watch out!", "Flourish", "Evade", "You perform a cool spin, slicing at the incoming horseman as he rides at menacing speeds towards you...", "After hearing that a horse was approaching you quickly jump down in efforts to avoid him..." };
    private List<string> downFour = new List<string> { "Kingdom's Downfall", "Flourishes do not work in real life and due to this acception of reality you completely miss the oncoming horseman. He then proceeds to thrust his sword through your chest, ending the war.", "Restart", "Restart", "restarting", "restarting" };
    private List<string> downFive = new List<string> { "Kingdom's Downfall", "The horse is fast, not dumb. As you dived out the way, prematurely, the horse turned about 5 degrees and trampled you to death. That is how you will be forever remembered a now. The king... that was trampled by a horse. ", "Restart", "Restart", "restarting", "restarting" };
    private List<string> retreat = new List<string> { "Criko Retreat!", "The Criko are retreating! If we act fast we can take down their king and claim the criko land as our own!", "Attack!", "Go to Town", "The Criko will be slaughtered today. No matter what this is the end. ", "We must take care of our own people before trying to care for others. The Criko will be left for another day but right now we must go and check on the people of our kingdom." };
    private List<string> winOne = new List<string> { "Kingdom's Growth", "You have defeated the Criko! Upon entering the Criko kingdom there is a feast in your honor because it was prophecized that one day a great ruler would come to bring the Criko village to greatness. The Crikans believe it is you!", "Restart", "Restart", "restarting", "restarting" };
    private List<string> town = new List<string> { "Town", "You hear screaming coming from the pub and soldiers running inside while a house on the outskirts of town is being pillaged by a man wearing the Criko sigil.", "Tavern", "House", "You run into the tavern word in hand ready to fight off whoever may be causing the screams of the woman inside", "You bring your bodyguard to help dispatch of the enemy Criko while the rest of your men stay at the tavern to help the woman." };
    private List<string> winTwo = new List<string> { "Aresion", "You sneak into the home and thrust your sword into the back of the warriors head. As you look around the home you notice more blood moving towards you from across the room. You follow the blood to find Aresion's body on the floor with the gold in his hand next to the lifeless body of a woman. As you turn around to leave the home you hear a small voice come from the closet. It is Aresion's four year old daughter, so you take her home with you to become a princess.", "Restart", "Restart", "restarting", "restarting" };
    private List<string> winThree = new List<string> { "Aresion", "You hear someone yell as the Criko warrior enters the home. After rushing inside you find Aresion with the sword you gave him plunged into the warriors neck along with four other Criko soldiers on the ground. Aresion is covered in blood and his family is hiding in the corner. You ask Aresion to serve on your royal guard and invite his family to stay in the castle where they will be clothed and fed for now on.", "Restart", "Restart", "restarting", "restarting" };
    private List<string> god = new List<string> { "Playing God", "A small man is being tied up for attacking the woman. You step up to him and your soldiers ask you how you would like to proceed", "Arrest", "Execution", "You have decided to arrest the man", "My blade shall taste blood!" };
    private List<string> winFour = new List<string> { "We The People", "As the man is being carried outside, the woman rushes him with a knife and stabs him in the throat. Screaming 'You monster, DIE!'\n\nThat's that.", "Restart", "Restart", "restarting", "restarting" };
    private List<string> winFive = new List<string> { "Execution", "You lopped his head off. Cool? But really generic.", "Restart", "Restart", "restarting", "restarting" };

    public bool alive = true;



    // Start is called before the first frame update
    void Start()
    {
        story.text = one[1];
        title.text = one[0];
        left.text = one[2];
        right.text = one[3];
        buttonL = GameObject.Find("Left");
        buttonR = GameObject.Find("Right");
        storytext = GameObject.Find("Story");
        titletext = GameObject.Find("Title");
        respond = GameObject.Find("Respond");
        continuebutton = GameObject.Find("Continue");
        continuebutton.SetActive(false);
        respond.SetActive(false);

        

    }

    /// <summary>
    /// Always looking for the next button press so the story line continues
    /// </summary>
    void Update()
    {
       
        if (story.text == one[1])
        {
            
            leftB.onClick.AddListener(() => ButtonClicked(criko, one, 4));
            leftB.onClick.AddListener(() => alive = false);
            rightB.onClick.AddListener(() => ButtonClicked(criko, one, 5));
            rightB.onClick.AddListener(() => alive = true);
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == criko[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(downOne, criko, 4));
            rightB.onClick.AddListener(() => ButtonClicked(Weapon, criko, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == downOne[1] || story.text == downTwo[1] || story.text == downThree[1] || story.text == downFour[1] || story.text == downFive[1] || story.text == winOne[1] || story.text == winTwo[1] || story.text == winThree[1] || story.text == winFour[1] || story.text == winFive[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(one, downOne, 4));
            rightB.onClick.AddListener(() => ButtonClicked(one, downOne, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == Weapon[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(sword, Weapon, 4));
            rightB.onClick.AddListener(() => ButtonClicked(bow, Weapon, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == bow[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(downTwo, bow, 4));
            rightB.onClick.AddListener(() => ButtonClicked(sword, bow, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == sword[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(tide, sword, 4));
            rightB.onClick.AddListener(() => ButtonClicked(tide, sword, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == tide[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(frontlines, tide, 4));
            rightB.onClick.AddListener(() => ButtonClicked(downThree, tide, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == frontlines[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(horse, frontlines, 4));
            rightB.onClick.AddListener(() => ButtonClicked(retreat, frontlines, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == horse[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(downFour, horse, 4));
            rightB.onClick.AddListener(() => ButtonClicked(downFive, horse, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == retreat[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(winOne, retreat, 4));
            rightB.onClick.AddListener(() => ButtonClicked(town, retreat, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == town[1])
        {
            if (alive)
            {
                leftB.onClick.AddListener(() => ButtonClicked(winThree, town, 4));
            }
            else if (!alive)
            {
                leftB.onClick.AddListener(() => ButtonClicked(god, town, 4));
            }
            rightB.onClick.AddListener(() => ButtonClicked(winTwo, town, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
        else if (story.text == god[1])
        {
            leftB.onClick.AddListener(() => ButtonClicked(winFour, god, 4));
            rightB.onClick.AddListener(() => ButtonClicked(winFive, god, 5));
            continueB.onClick.AddListener(() => continueMe());
        }
    }

    public void ButtonClicked(List <string> num, List<string> old, int choice)
    {
        leftB.onClick.RemoveAllListeners();
        rightB.onClick.RemoveAllListeners();
        continueB.onClick.RemoveAllListeners();
        sound.PlayOneShot(jumpShort);
        story.text = num[1];
        title.text = num[0];
        left.text = num[2];
        right.text = num[3];
        response.text = (old[choice]);

        buttonL.SetActive(false);
        buttonR.SetActive(false);
        titletext.SetActive(false);
        storytext.SetActive(false);
        continuebutton.SetActive(true);
        respond.SetActive(true);

       
    }

    public void continueMe()
    {
        continuebutton.SetActive(false);
        respond.SetActive(false);
        buttonL.SetActive(true);
        buttonR.SetActive(true);
        titletext.SetActive(true);
        storytext.SetActive(true);
        sound.PlayOneShot(jumpShort);
    }


}
