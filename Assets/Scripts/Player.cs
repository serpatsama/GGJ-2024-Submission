using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float acceleration = 0.8f;
    private float curSpeed;
    private float maxSpeed;
    private Vector2 input;
    [SerializeField] private LayerMask solidObjectsLayer;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0.0f;
        _rb.angularDrag = 0.0f;
        Debug.Log("WAHAHAHA");
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        input = input.normalized;
        Debug.Log(input.x.ToString() + " " + input.y.ToString());
    }

    private void FixedUpdate()
    {
        curSpeed = moveSpeed;
        maxSpeed = curSpeed;

        // the movement magic
        _rb.velocity = new Vector2(
            Mathf.Lerp(0, input.x * curSpeed, acceleration),
            Mathf.Lerp(0, input.y * curSpeed, acceleration)
        );
    }
}
