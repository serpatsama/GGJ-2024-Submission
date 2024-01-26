using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool ismoving;
    private float moveSpeed = 10.0f;
    private Vector2 input;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("WAHAHAHA");
    }

    // Update is called once per frame
    void Update()
    {
        if (!ismoving)
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            if (input != Vector2.zero)
            {
                Vector3 position = transform.position;
                position.x += input.x;
                position.y += input.y;
                StartCoroutine(Move(position));
            }
        }
    }

    IEnumerator Move(Vector3 destination)
    {
        ismoving = true;
        while ((destination - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;

        ismoving = false;
    }
}
