using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentConstructor : MonoBehaviour
{
    private GameObject currentSegment;

    /// <summary>
    /// Places the gameobject in the game.
    /// </summary>
    /// <param name="segment"></param>
    /// <returns></returns>
    public void Construct(ref GameObject gameObject)
    {
        gameObject = Instantiate(gameObject, transform.position, transform.rotation);
        currentSegment = gameObject;
    }

    /// <summary>
    /// Returns true if placing an object will not result in clipping
    /// </summary>
    /// <returns></returns>
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
