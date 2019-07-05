using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentConstructor : MonoBehaviour
{
    private GameObject currentSegment;

    /// <summary>
    /// Places the gameobject in the game. Return false if segment has not been
    /// placed.
    /// </summary>
    /// <param name="segment"></param>
    /// <returns></returns>
    public void Construct(GameObject gameObject)
    {
        currentSegment = Instantiate(gameObject, transform.position, transform.rotation);
    }

    public bool SpaceAvailable()
    {
        if (!currentSegment)
            return true;

        if (currentSegment.GetComponent<SegmentController>().Back < transform.position.x)
        {
            return true;
        }

        return false;
    }
}
