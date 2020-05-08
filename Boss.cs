using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	public int health = 100;	//boss's health
    public int damage; //damage taken

    public Slider healthBar;

	public Text dialogue; //textbox dialogue

	public GameObject scroll;	//ending scroll (Level completion)
    
    private void Update()	//connects health with health bar
    {
        healthBar.value = health;
    }

	//when the boss is hurt
	public void TakeDamage (int damage)
	{
		health -= damage;

		//dialogue at specific health levels
		if (health == 50)
		{
			dialogue.text = "HOW DARE YOU INSULT ME YOU FOOL!!";
		}

		if (health <= 0)
		{
			dialogue.text = "You have bested me... You are one brave soul";
			Die();
			FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
			scroll.SetActive(true);
		}
	}

	//Boss dies and disappears
	void Die ()
	{
		Destroy(gameObject);
	}
}