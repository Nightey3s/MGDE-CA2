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

    public void ButtonDownInputJump()
    {
        input.isJumping = true;
    }

    public void ButtonUpInputJump()
    {
        input.isJumping = false;
    }
}
