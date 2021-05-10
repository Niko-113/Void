using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : Enemy
{

    Vector2 direction;
    LineRenderer laser;

    bool isFiring;

    void Start()
    {
        laser = GetComponent<LineRenderer>();
        
    }

    void Update()
    {
        if (!isFiring)
        {
            direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        }
    }

    public override void Fire()
    {
        rb.velocity = Vector2.zero;
        laser.enabled = true;
        laser.material.SetColor("_Color", Color.gray);
        
        StartCoroutine("Solidify");
    }

    IEnumerator Solidify()
    {
        isFiring = true;
        Vector2 from = transform.position;
        Vector2 to = player.transform.position - transform.position;
        Ray2D ray = new Ray2D(from, to);
        laser.SetPosition(0, this.transform.position);
        laser.SetPosition(1, ray.GetPoint(100));
        yield return new WaitForSeconds(1);
        laser.material.SetColor("_Color", Color.red);
        for (int i = 0; i < 120; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(from, to, 1000, 1 << LayerMask.NameToLayer("Player"));
            // Debug.DrawRay(from, to, Color.blue, 3);
            if (hit)
            {
                hit.collider.GetComponentInParent<Player>().TakeDamage();
            }
            yield return new WaitForSeconds(0.01f);
        }
        laser.enabled = false;
        isFiring = false;
        rb.velocity = startVelocity;
    }
}
