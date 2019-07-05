using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentController : MonoBehaviour
{
    Vector3 velocity;
    [SerializeField] private Transform jointBack;

    private void Start()
    {
        if (Speed == 0)
        {
            Speed = 14;
        }

        velocity = new Vector3(-Speed, 0, 0);
    }

    /// <summary>
    /// Returns the segment's right edge as the x value of its global coordinates
    /// </summary>
    public float Back
    {
        get { return jointBack.position.x; }
    }

    /// <summary>
    /// Returns the horizontal length of the segment
    /// </summary>
    public float Length
    {
        get { return jointBack.position.x - transform.position.x; }
    }

    /// <summary>
    /// Movement speed of segment. Default is 14.
    /// </summary>
    public float Speed { get; set; }

    public void MarkForDeletion(SegmentDeleter deleter)
    {
        StartCoroutine(deleter.MarkForDeletion(this.gameObject));
    }

    private void Update()
    {
        if (velocity.x != -Speed)
        {
            velocity = new Vector3(-Speed, 0, 0);
        }

        transform.Translate(velocity * Time.deltaTime);
    }
}
