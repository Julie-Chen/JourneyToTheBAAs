using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject instructions;
    public GameObject comBox;
    public GameObject itemBar;

    void Start()
    {
        instructions.SetActive(true);
        comBox.SetActive(false);
        itemBar.SetActive(true);
    }

      public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            comBox.SetActive(true);
            itemBar.SetActive(false);
            FindObjectOfType<AudioManager>().Play("collectSound");
            Destroy(gameObject);
        }
    }
}
