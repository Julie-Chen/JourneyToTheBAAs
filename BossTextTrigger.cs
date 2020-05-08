using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTextTrigger : MonoBehaviour
{
    public DialogueIntro bossDialogue;
    //public GameObject button

    public void TriggerDialogue()
    {
        FindObjectOfType<IntroBossManager>().StartDialogue(bossDialogue);
    }

    //void ButtonClicked() { button.SetActive(false);   }   
}