using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject player;

    public float hp;
    public int points;

    public float xDir;
    public float yDir;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xDir, yDir);
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("FireTimer");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Reflected")
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) Die();
    }

    public abstract void Fire();

    public void Die()
    {
        StopCoroutine("FireTimer");
        Destroy(this.gameObject);
    }

    IEnumerator FireTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            Fire();
        }
    }


    
}
