using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private InputController input;
    private bool isJumping, isSliding, isGrounded;

    [SerializeField]
    private float jumpHeight = 55, speed = 0.02f;

    [Tooltip("Target to move towards to")]
    [SerializeField]
    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        isJumping = false;
        isGrounded = false;
        isSliding = false;
        rigidBody = GetComponent<Rigidbody2D>();
        input = GetComponent<InputController>();
        if (!target)
        {
            target = Camera.main.transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        MoveTowardsMiddle();
        CheckStates();
        GetPlayerInputs();
        StartCoroutine(JumpCooldownCheck());
    }

    private void GetPlayerInputs()
    {
        this.isJumping = input.isJumping;
        this.isSliding = input.isSliding;
    }

    private void CheckStates()
    {
        Jump();
        Slide();
    }

    // Check and perform jump
    private void Jump()
    {
        if (isJumping && isGrounded)
        {
            rigidBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    // Check and perform slide
    private void Slide()
    {
        if (isSliding)
        {
            transform.localScale = new Vector3(1, 1, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, 2, transform.localScale.z);
        }
    }

    // Moves character towards the target position
    private void MoveTowardsMiddle()
    {
        if (transform.position.x != target.position.x)
        {
            Vector3 targetPosition =
                new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
        }
    }
    
    // Checks if player is not in midair and sets this.isGrounded to true
    // Coroutine invocation in 0.7 seconds intervals
    private IEnumerator JumpCooldownCheck()
    {

        RaycastHit2D hitInfo = Physics2D.Linecast(
            transform.position + new Vector3(0, -1.0f, 0),
            transform.position + new Vector3(0, -1.3f, 0),
            ~(1<<gameObject.layer));
        if (hitInfo /*&& (rigidBody.velocity.y > -3 && rigidBody.velocity.y < 3)*/)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        yield return new WaitForSeconds(2.0f);
    }
}
