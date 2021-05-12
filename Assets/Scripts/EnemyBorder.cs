using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBorder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<Enemy>().Flee();
        }
        else if (collider.tag == "Bullet")
        {
            Destroy(collider.gameObject);
        }
    }
}
