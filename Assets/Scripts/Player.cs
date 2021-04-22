using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isDashing;
    public float speed = 1;
    public float dashSpeed = 8;
    float horizontal;
    float vertical;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        vertical = 0;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical"); 
        // transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;

    }

    void FixedUpdate()
    {
        if (!isDashing) rb.velocity = new Vector2(horizontal, vertical) * speed;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine("Dash");
            // rb.velocity = (rb.velocity.normalized * 3);
            
        }
    }


    IEnumerator Dash()
    {
        
        isDashing = true;
        // Dash forward if idle
        if (rb.velocity.magnitude == 0) rb.velocity = new Vector2(0, 1);
        rb.velocity = (rb.velocity.normalized * dashSpeed);
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }
}
