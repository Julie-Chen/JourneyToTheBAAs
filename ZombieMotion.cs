using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMotion : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;

    public float speed;

	Transform player;
	Rigidbody2D rb;
	Lvl3Boss boss;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timer = Random.Range(minTime, maxTime);

        player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<Lvl3Boss>();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (timer <= 0)
        {
            animator.SetTrigger("jump");
        }
        else {
            timer -= Time.deltaTime;
        }

        boss.LookAtPlayer();

		Vector2 target = new Vector2(player.position.x, rb.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		rb.MovePosition(newPos);

	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
}
