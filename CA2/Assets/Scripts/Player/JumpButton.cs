using System.Collections;
using System.Collections.Generic;
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
        StartCoroutine(Jump());
    }
    
    private IEnumerator Jump()
    {
        input.isJumping = true;
        yield return new WaitForEndOfFrame();
        input.isJumping = false;
    }
}
