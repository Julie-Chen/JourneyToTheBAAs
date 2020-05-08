using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Bullet : MonoBehaviour
{
    public float speed;
    public int damage = 10;
    public Rigidbody2D rb;

    // makes bullet fly forward
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //action for when bullet hits an object
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Lvl3Boss enemy = hitInfo.GetComponent<Lvl3Boss>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
