using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideButton : MonoBehaviour
{
    [SerializeField] InputController input;

    private void Awake()
    {
        if (!input)
        {
            input = FindObjectOfType<InputController>();
        }
    }

    public void ButtonInputSlide(bool slide)
    {
        input.isSliding = slide;
    }
}