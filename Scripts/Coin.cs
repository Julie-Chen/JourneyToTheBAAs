using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Coin value can be customized
    public int coinValue = 1;

    //When entering collider, picks up coin and adds to counter
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
            FindObjectOfType<AudioManager>().Play("collectSound");
        }
    }
}
