using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText; //The name of the text box, (JoeName(Text))
    public Text dialogueText; //Variable for the dialogue (text)

    public Animator animator; //(gets dialogueBox in intro level, which is the animator for opening and closing the dialogue box)
    public Animator instructAnimator; //Animating the instructions to click on Joe in intro
    public Animator joe; //Basically controlling Joe in intro level
    public Animator dialoguePic;  //Animator that changes the picture of the dialogue according to nameText

    private Queue<string> sentences;
    private Queue<string> names; //Added a private queue for all the names you wanna inport for your dialogue conversation

    string temp; //for dialoguePic: temporary textName string holder for a later function
    string temp2; // so I can switch out the temp holder for the dialoguePic animator

    public GameObject note; //The note for the player

    // Start is called before the first frame update
    void Start()
    {
        note.SetActive(false);
        instructAnimator.SetBool("IsOpen", true);
        joe.SetBool("IsLeaving", false);
        sentences = new Queue<string>();
        names = new Queue<string>(); //a queue of the order of names in the dialogue box (DialogueTrigger elements on Unity)
    }

    public void StartDialogue(Dialogue dialogue) //function is called by dialogue trigger script
    {
        animator.SetBool("IsOpen",true); //Displays the whole dialogue box object


        //nameText.text = dialogue.name; /*original line: I moved this elsewhere to make the names queue thing
        //ALSO: If the converation is just by one person, but they have a lot of lines to say, and you don't want to input the same name multiple times in the DialogueTrigger component,
        // just set the size to one element and put the person's name, and then change the size to the size of the sentences queue. Not sure if the size of the names queue matters but,
        // yeah.

        sentences.Clear();
        names.Clear(); 

        //hide profile pictures 
        dialoguePic.SetBool("President Wacom", false);
        dialoguePic.SetBool("VP Tanks", false);
        dialoguePic.SetBool("Historian Achu", false);
        dialoguePic.SetBool("Secretary Bleshu", false);
        dialoguePic.SetBool("Joe", false);

        dialoguePic.SetBool(dialogue.names[0], true); //making sure the default of every other animator is false, and the first person too speak shows up in the dialogue box first

        foreach (string name in dialogue.names) //goes through people's name
        {
            names.Enqueue(name);
            nameText.text = name;
            dialoguePic.SetBool(name, false);
            Debug.Log(name + "Picture");
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        instructAnimator.SetBool("IsOpen", false); //Closes the instructions that tell you to click on joe
        if (sentences.Count == 0)
        {
            EndDialogue();
            note.SetActive(true);
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Debug.Log(name + ": " + sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));
    }

    IEnumerator TypeSentence (string sentence, string name) //Sprite img)
    {
        temp = name; //temp is a temporary holder for "name" from the foreach loop

        if (name is null) //checking to see if name slot is null, name slots shouldn't be null in the first place but this is just a precaution i guess .-.
        {
            Debug.Log("Name slots not all filled in."); //Let's the user know that they did not fill in the name slots properly, and that some were left void, which is no bueno for converting to nameText
            throw new System.ArgumentNullException(nameof(name));
        }

        nameText.text = name; //converting to nameText
        dialogueText.text = "";
        dialoguePic.SetBool(temp, true);
        dialoguePic.SetBool(temp2, false);
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        temp2 = temp; //needed to put the temp in temp2, so I can set it to false, turning off the animation for the previous image (images will keep switching back and forth in order if both animators are true, which is why I did this)
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false); //get rid of dialogue box
        joe.SetBool("IsLeaving", true); //Animator controls Joe to make him leave
    }
}
