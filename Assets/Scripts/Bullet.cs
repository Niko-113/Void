using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void TargetPlayer(Transform player)
    {
        this.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") Destroy(this.gameObject);
    }
}
