using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotateForce;
    private bool isJumping = false;
    public bool nearWall = false;
    public float horInput;

    [SerializeField] private GameObject smokeEffect;
    private GameObject smoke;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        smoke = Instantiate(smokeEffect, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        
        smoke.transform.position = transform.position - new Vector3(0, 0.3f, 0); 
        if (isJumping == false )
        {
            smoke.SetActive(true);
        }
        else
        {
            smoke.SetActive(false);
        }
    }

    private void MoveBall()
    {
        horInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horInput * moveSpeed, rb.velocity.y);
        transform.Rotate(0f, 0f, -horInput * rotateForce);
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void SpawnSmoke()
    {
        GameObject smoke = Instantiate(smokeEffect, transform.position, Quaternion.identity);
        smoke.transform.position = transform.position - -new Vector3(0, 0.5f, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box")
        {
            isJumping = false;
        }
        if(collision.gameObject.tag == "Wall")
        {
            nearWall = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            nearWall = false;
        }
    }
}

