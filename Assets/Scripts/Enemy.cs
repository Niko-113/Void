using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject player;
    public GameObject particle;
    
    public AudioClip hurt;

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
        StartCoroutine("HitFlicker");
        hp -= damage;
        SoundManager.speaker.PlaySound(hurt);
        if (hp <= 0) Die();
    }

    public abstract void Fire();

    public void Die()
    {
        GameObject newParticle = GameObject.Instantiate(particle, this.transform.position, Quaternion.identity);
        Destroy(newParticle, 1f);
        GameManager.master.AddPoints(points);
        StopAllCoroutines();
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

    IEnumerator HitFlicker()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0.75f, 0.79f, 1));
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }


    
}
