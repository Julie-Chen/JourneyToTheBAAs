using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QAMusicStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("sublvl2Music");
    }
}
