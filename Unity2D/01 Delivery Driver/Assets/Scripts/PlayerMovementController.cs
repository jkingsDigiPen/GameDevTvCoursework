// Name: PlayerMovementController.cs
// Author(s): Jeremy kings
// Purpose: Move and rotate player
// avatar based on user input.
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 90.0f;
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float reverseSpeedMultiplier = 0.5f;

    // Update is called once per frame
    void Update()
    {
        bool isMoving = Move();

        Rotate(isMoving);
    }

    private void Rotate(bool isMoving)
    {
        // Disallow rotation when car is
        // not already moving
        if (!isMoving)
            return;

        // Make sure rotation works opposite way when reversing
        // to mimic car controls
        float sign = Mathf.Sign(Input.GetAxis("Vertical"));

        float speedMod = rotationSpeed * (sign < 0.0f ? reverseSpeedMultiplier : 1.0f);

        float direction = -Input.GetAxis("Horizontal") * sign;

        transform.Rotate(0, 0, direction * speedMod * Time.deltaTime);
    }

    private bool Move()
    {
        Vector2 direction = Vector2.up;

        float sign = Input.GetAxis("Vertical");

        float speedMod = moveSpeed * (sign < 0.0f ? reverseSpeedMultiplier : 1.0f);

        transform.Translate(direction * sign * speedMod * Time.deltaTime);

        return sign != 0.0f;
    }
}
