using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sublvl3_Dial : MonoBehaviour
{
    public GameObject bossHealth; //displays boss health
    public GameObject PlayerStats; //displays player's hearts
	public GameObject continueButton; // continues dialogue
	public GameObject startIns;
	public GameObject StartButton; //starts dialogue

	public Text bossText; //dialogue text

	public Animator textBoxMove; //textbox moving in or out

	private Queue<string> sentences; 

    // Start is called before the first frame update
    void Start()
    {
        bossHealth.SetActive(false);
        PlayerStats.SetActive(false);
		StartButton.SetActive(true);
		textBoxMove.SetBool("IsOpen", false);
		startIns.SetActive(true);
        sentences = new Queue<string>();
    }

    public void StartDialogue (DialogueIntro dialogue)
	{
		textBoxMove.SetBool("IsOpen", true); //Displays the whole dialogue box object
		StartButton.SetActive(false);
		bossHealth.SetActive(true);
        
        sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

    public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
            PlayerStats.SetActive(true);
			StartCoroutine(Fight());
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

    IEnumerator TypeSentence (string sentence)
	{
		bossText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			bossText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		textBoxMove.SetBool("IsOpen", false);
	}

	public IEnumerator Fight() //timed instructions 
    {
		yield return new WaitForSeconds(1f);
		continueButton.SetActive(false);
	}
}