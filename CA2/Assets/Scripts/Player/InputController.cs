using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [HideInInspector] public bool isJumping, isSliding;
    [SerializeField] private GameObject buttonControls;

    private Gyroscope gyro;
    private bool hasGyro, deviceTiltEnabled;

    [Tooltip("Use touch controls")]
    [SerializeField] private bool touchControls;

    private void Awake()
    {
        // Checks if device is handheld and enables touch controls
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            EnableTouchScreenInput();
        }

        //Checks if device has a gyroscope and enables and caches the gyroscope
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            hasGyro = true;
        }
    }

    private void Update()
    {
        if (!touchControls)
        {
            ApplyKeyboardInputs();
        }
    }

    private void EnableTouchScreenInput()
    {
        buttonControls.SetActive(true);
        touchControls = true;
    }

    private void ApplyKeyboardInputs()
    {
        isJumping = Input.GetKeyDown(KeyCode.W);
        isSliding = Input.GetKey(KeyCode.E);
    }
    
    /// <summary>
    /// Start streaming device tilt input
    /// </summary>
    public void ActivateDeviceTilt()
    {
        deviceTiltEnabled = true;
        if (hasGyro)
        {
            gyro.enabled = true;
        }
    }

    /// <summary>
    /// Stops streaming device tilt input
    /// </summary>
    public void DeactivateDeviceTilt()
    {
        deviceTiltEnabled = false;
        if (hasGyro)
        {
            gyro.enabled = false;
        }
    }

    /// <summary>
    /// Returns a vector of the device's tilt
    /// </summary>
    /// <returns></returns>
    public Vector3 GetDeviceTilt()
    {
        if (!deviceTiltEnabled)
        {
            return Vector3.zero;
        }

        if (hasGyro)
        {
            return gyro.rotationRate;
        }
        else
        {
            return Input.acceleration;
        }
    }
}
