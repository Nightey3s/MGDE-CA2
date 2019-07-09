using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    private Vector3 newPosition;

    private void Update()
    {
        Destroy(gameObject, 5); // Destroys gameobject after 5 seconds
        Fly();
    }

    // Move towards target over a period of time
    private void Fly()
    {
        newPosition =
            Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = newPosition;
    }
}
