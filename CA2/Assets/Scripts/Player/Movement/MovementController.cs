using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private PlayerJump playerJump;
    private PlayerFly playerFly;

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
        playerJump = GetComponent<PlayerJump>();
        playerFly = GetComponent<PlayerFly>();
        playerJump.enabled = true;
        playerFly.enabled = false;
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
        playerJump.enabled = true;
        playerFly.enabled = false;
    }

    // Changes to flying movement mode
    private IEnumerator ChangeToFlyMode(float time)
    {
        playerJump.enabled = false;
        playerFly.enabled = true;

        if (time >= 0)
        {
            yield return new WaitForSeconds(time);
            ChangeToJumpMode();
        }
    }
}
