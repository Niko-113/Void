using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seer : Enemy
{
    public GameObject bullet;

    public override void Fire()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        GameObject shot = Instantiate(bullet, transform.position, transform.rotation);
        GameObject shot2 = Instantiate(bullet, transform.position, transform.rotation);
        GameObject shot3 = Instantiate(bullet, transform.position, transform.rotation);
        
        shot.GetComponent<Rigidbody2D>().velocity = direction;
        shot2.GetComponent<Rigidbody2D>().velocity = Rotate(direction, 0.5f);
        shot3.GetComponent<Rigidbody2D>().velocity = Rotate(direction, -0.5f);
        Destroy(shot, 10);
    }

    Vector2 Rotate(Vector2 vec, float angle)
    {
        return new Vector2(
            (Mathf.Cos(angle) * vec.x) - (Mathf.Sin(angle) * vec.y),
            (Mathf.Sin(angle) * vec.x) + (Mathf.Cos(angle) * vec.y)
        );
    }
}
