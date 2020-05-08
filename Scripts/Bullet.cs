using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
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
        Boss enemy = hitInfo.GetComponent<Boss>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
