using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : Enemy
{
    public float dashSpeed = 3;

    Vector2 direction;

    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
    }

    public override void Fire()
    {
        this.GetComponent<Rigidbody2D>().velocity = direction * dashSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Reflected")
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            // Explode
            GameObject newParticle = GameObject.Instantiate(particle, this.transform.position, Quaternion.identity);
            Destroy(newParticle, 1f);
            Destroy(this.gameObject);
        }
    }
}
