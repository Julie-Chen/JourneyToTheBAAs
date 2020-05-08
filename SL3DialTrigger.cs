using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL3DialTrigger : MonoBehaviour
{
    public DialogueIntro bossDialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<Sublvl3_Dial>().StartDialogue(bossDialogue);
    }
}
