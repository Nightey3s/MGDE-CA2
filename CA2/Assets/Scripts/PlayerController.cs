using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private bool isJumping, isSliding;
    [SerializeField] private float jumpHeight, speed;
    [Tooltip("Target to move towards to")]
    [SerializeField] private Transform target; // target to move towards to

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveTowardsMiddle();
        CheckStates();
        ApplyInputs();
    }

    private void CheckStates()
    {
        if (isJumping)
        {
            rigidBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }

        if (isSliding)
        {
            transform.localScale = new Vector3(1, 1, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, 2, transform.localScale.z);
        }
    }

    private void ApplyInputs()
    {
        isJumping = Input.GetKeyDown(KeyCode.W);
        isSliding = Input.GetKey(KeyCode.E);
    }

    private void MoveTowardsMiddle()
    {
        if(transform.position.x != target.position.x)
        {
            Vector3 targetPosition =
                new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
        }
    }
}
