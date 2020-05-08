using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl3Boss : MonoBehaviour {

	public int health = 200; //boss's health
    public int damage; //damage taken
	public Slider healthBar;	//boss's health

	public Transform player; //player to follow
	private bool isFlipped = false;	//check if he is facing the player
	public Animator attack;		//attack animation

	public Text dialogue; 	//speaking
	public GameObject scroll;	//lvlcomplete scroll
    
    private void Update()	//connects health with healthbar
    {
        healthBar.value = health;
    }

	//when the boss is hurt
	public void TakeDamage (int damage)
	{
		health -= damage;

		//dialogue with decreasing health levels
		if (health == 150)
		{
			dialogue.text = "How did you feel about the event?";
			attack.SetTrigger("attack");
		}

		if (health == 100)
		{
			dialogue.text = "Wow, that sounds amazing.";
		}

		if (health == 50)
		{
			dialogue.text = "Please tell me more about how the local chapter went.";
			attack.SetTrigger("attack");
		}

		if (health <= 0)
		{
			dialogue.text = "That sounds great! I am honored to be recuited by you. I hope to hear from you again soon.";
			Die();
			scroll.SetActive(true);
		}
	}

	//Boss dies and disappears
	void Die ()
	{
		Destroy(gameObject);
	}

	//face the player
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

}
