using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, ICollectible
{
    public void PickUp(GameObject collector)
    {
        MovementController movement = collector.GetComponent<MovementController>();
        Debug.Log("collided");
        if (movement)
        {
            movement.SetMovementMode(MovementController.Mode.Fly, 10f);
            Debug.Log("set to fly");
            Destroy(this.gameObject);
        }
    }
}
