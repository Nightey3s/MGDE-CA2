using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private JumpMovement jumpMovement;
    private FlyingMovement flyingMovement;

    public enum Mode { Jump, Fly }
    private Mode mode;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMovements();
    }

    // Sets up initial movement mode
    private void SetUpMovements()
    {
        jumpMovement = GetComponent<JumpMovement>();
        flyingMovement = GetComponent<FlyingMovement>();

        if (!jumpMovement)
        {
            gameObject.AddComponent<JumpMovement>();
        }

        if (!flyingMovement)
        {
            gameObject.AddComponent<FlyingMovement>();
        }

        jumpMovement.enabled = true;
        flyingMovement.enabled = false;
    }

    /// <summary>
    /// Set the player's movement type
    /// </summary>
    /// <param name="mode"></param>
    /// <param name="time"></param>
    public void SetMovementMode(Mode mode, float time = 0)
    {
        this.mode = mode;
        switch (mode)
        {
            case (Mode.Jump): ChangeToJumpMode();
                break;
            case (Mode.Fly): StartCoroutine(ChangeToFlyMode(time));
                break;
            default: return;
        }
    }

    // Changes to jumping movement mode
    private void ChangeToJumpMode()
    {
        jumpMovement.enabled = true;
        flyingMovement.enabled = false;
    }

    // Changes to flying movement mode
    private IEnumerator ChangeToFlyMode(float time)
    {
        jumpMovement.enabled = false;
        flyingMovement.enabled = true;

        if (time >= 0)
        {
            yield return new WaitForSeconds(time);
            ChangeToJumpMode();
        }
    }
}
