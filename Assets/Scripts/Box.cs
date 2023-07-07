using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D boxCollider;
    [SerializeField] BallController ball;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu va chạm xảy ra với đối tượng "Wall"
        if (collision.gameObject.CompareTag("Wall") )
        {
            float distance = Vector2.Distance(collision.collider.transform.position, boxCollider.transform.position);
            Debug.Log(distance);
            if(distance < 5f && ball.nearWall == true)
            {
                Vector3 pushDirection = new Vector3(-ball.horInput, 0,0);
                rb.transform.Translate(pushDirection);
          
            }
        }
        
    }
}
