using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    // Background layers' transform
    [SerializeField] private Transform backLayer, frontLayer;
    [SerializeField] private float backVelocity, frontVelocity;
    private Vector3 initialBackTransform, initialFrontTransform;

    private void Awake()
    {
        initialBackTransform = backLayer.position;
        initialFrontTransform = frontLayer.position;
    }

    // Moves game objects according to their offset multiplied by the device's
    // accelerometer input
    private void LateUpdate()
    {
        Vector3 input = Input.acceleration.normalized;
        input = new Vector3(input.x, input.y, 0);
        backLayer.position = initialBackTransform + (input * backVelocity);
        frontLayer.position = initialFrontTransform + (input * frontVelocity);
    }
}
