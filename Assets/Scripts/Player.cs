using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sword sword;
    public Animator animator;
    Rigidbody2D rb;

    
    public float speed = 1;
    public float dashSpeed = 8;
    public float hp = 3;

    bool isDashing;
    float horizontal;
    float vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical"); 
        // transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sword.Swing();
            animator.SetTrigger("Swing");
        }
        
        if (!isDashing) rb.velocity = new Vector2(horizontal, vertical) * speed;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;
            StartCoroutine("Dash");            
        }

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
            {
                // Perish
            }
        }
    }

    IEnumerator Dash()
    {
        // Dash forward if idle
        if (rb.velocity.magnitude == 0) rb.velocity = new Vector2(0, 1);
        rb.velocity = (rb.velocity.normalized * dashSpeed);
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }
}
