using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 90.0f;
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float inputThreshold = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float direction = 0.0f;

        if (Input.GetAxis("Horizontal") < -inputThreshold)
        {
            direction += 1.0f;
        }

        if (Input.GetAxis("Horizontal") > inputThreshold)
        {
            direction += -1.0f;
        }

        transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        Vector2 direction = Vector2.up;

        float sign = 0.0f;

        if (Input.GetAxis("Vertical") > inputThreshold)
        {
            sign = 1.0f;
        }

        if (Input.GetAxis("Vertical") < -inputThreshold)
        {
            sign = -1.0f;
        }

        transform.Translate(direction * sign * moveSpeed * Time.deltaTime);
    }
}
