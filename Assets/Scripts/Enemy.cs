using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject bullet;
    public GameObject player;

    public float hp;
    public int points;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down;
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

    void Fire()
    {
        GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
        shot.GetComponent<Bullet>().TargetPlayer(player.transform);
        Destroy(shot, 10);
    }

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
