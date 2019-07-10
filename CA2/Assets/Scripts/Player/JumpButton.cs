using System.Collections;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    [SerializeField] InputController input;

    private void Awake()
    {
        if (!input)
        {
            input = FindObjectOfType<InputController>();
        }
    }

    public void ButtonClickInputJump()
    {
        input.isJumping = true;
        StartCoroutine(ResetJump());
    }

    // Waits for end of 2 frame before setting input.isJumping to false
    private IEnumerator ResetJump()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        input.isJumping = false;
        yield return null;
    }
}