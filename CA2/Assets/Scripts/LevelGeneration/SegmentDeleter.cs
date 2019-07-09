using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentDeleter : MonoBehaviour
{
    // Returns true if the segment moves past the deleter's position.
    private bool CheckDelete(SegmentController segment)
    {
        if (segment.Back < transform.position.x)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Coroutine to mark the segment for deletion. Checks if segment has moved
    /// past the deleter and deletes the game object if true. Invokes in a 0.5
    /// second interval
    /// </summary>
    /// <param name="segment"></param>
    /// <returns></returns>
    public IEnumerator MarkForDeletion(GameObject segment)
    {
        while (true)
        {
            if (CheckDelete(segment.GetComponent<SegmentController>()))
            {
                Destroy(segment);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
