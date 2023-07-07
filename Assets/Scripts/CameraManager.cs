using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private BoxCollider2D box;
    private BallController ball;
    private float halfHeight;
    private float halfWidth;
    void Start()
    {
        ball = FindObjectOfType<BallController>();
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    void Update()
    {
        if (ball != null)
        {
            transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x, box.bounds.min.x + halfWidth, box.bounds.max.x - halfWidth),
                Mathf.Clamp(ball.transform.position.y, box.bounds.min.y + halfHeight, box.bounds.max.y - halfHeight), transform.position.z);
        }
    }
}
