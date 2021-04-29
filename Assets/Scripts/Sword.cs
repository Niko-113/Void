using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    List<Collider2D> collidersInRange = new List<Collider2D>();
    ContactFilter2D filter = new ContactFilter2D();
    public bool isSlashing;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // collidersInRange.Add(collider);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // collidersInRange.Remove(collider);
    }

    void Update()
    {
        // if (!isSlashing)
        // {
        //     foreach (Collider2D c in collidersInRange)
        //     {
        //         if (c == null) collidersInRange.Remove(c);
        //     }
        // }
        this.GetComponent<Collider2D>().OverlapCollider(filter.NoFilter(), collidersInRange);
    }

    public void Swing()
    {
        isSlashing = true;
        foreach (Collider2D c in collidersInRange)
        {
           if (c.tag == "Enemy") c.GetComponent<Enemy>().TakeDamage(1);
           if (c.tag == "Bullet")
           {
               Rigidbody2D bullet = c.GetComponent<Rigidbody2D>();
               
               float angle = c.transform.position.x - transform.position.x;
               bullet.velocity = new Vector2(angle * 2, Mathf.Abs(bullet.velocity.y * -1) + 2);
               c.tag = "Reflected";
               c.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
           }
            
           Debug.Log("Slashed " + c.name);
        }

        isSlashing = false;
    }
}
