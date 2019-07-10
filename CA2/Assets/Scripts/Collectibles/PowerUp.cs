using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, ICollectible
{
    public void PickUp(GameObject collector)
    {
        MovementController movement = collector.GetComponent<MovementController>();

        if (movement)
        {
            movement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            movement.SetMovementMode(MovementController.Mode.Fly, 10f);
            Destroy(this.gameObject);
        }
    }
}
