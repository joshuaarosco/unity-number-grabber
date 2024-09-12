using UnityEngine;
using System.Collections;

public class MouseFollow2D : MonoBehaviour
{
    public float speed = 1f; // Speed of the character movement
    public float minX; // Minimum X position the character can move to
    public float maxX; // Maximum X position the character can move to

    private Animator animator;
    private Vector2 lastPosition;

    void Start()
    {
        // Get the Animator component attached to the character
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        // Convert the screen position to a point in the 2D world
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Clamp the target position to stay within the defined bounds
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = transform.position.y; // Keep the y position constant

        // Move the character towards the target position
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPosition.x, transform.position.y), speed * Time.deltaTime);

        // Check if the character is moving
        if (transform.position != (Vector3)lastPosition)
        {
            // Set the animator to run if the character is moving
            animator.SetBool("isRunning", true);

            // Flip the sprite based on movement direction
            if (transform.position.x > lastPosition.x)
            {
                // Moving to the right
                transform.localScale = new Vector3(3f, 3f, 1);
            }
            else if (transform.position.x < lastPosition.x)
            {
                // Moving to the left
                transform.localScale = new Vector3(-3f, 3f, 1);
            }
        }
        else
        {
            // Set the animator to idle if the character is not moving
            animator.SetBool("isRunning", false);
        }

        // Update the last known position
        lastPosition = transform.position;
    }
}
