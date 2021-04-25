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
           //if (c.tag == "Enemy") c.GetComponent<Enemy>().TakeDamage(1);
           Debug.Log("Slashed " + c.name);
        }

        isSlashing = false;
    }
}
