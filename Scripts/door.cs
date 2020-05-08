using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public int LevelToLoad;

    private gameMaster gm;

    //Sets gm object variable
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }

    //When entering collider, shows text telling player what to press
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            gm.InputText.text = ("[E] to Enter");
            if (Input.GetKeyDown("e"))
            {
                Application.LoadLevel(LevelToLoad);
            }
        }
    }
    //When in collider, will take input to change to next level
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(Input.GetKeyDown("e"))
            {
                Application.LoadLevel(LevelToLoad);
            }
        }
    }
    //Deletes the text when exiting collider
    void OnTriggerExit2D(Collider2D col)
    {
        gm.InputText.text = (" ");
    }
}
