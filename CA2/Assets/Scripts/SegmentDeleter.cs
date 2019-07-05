using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentDeleter : MonoBehaviour
{
    public void Delete(SegmentController segment)
    {
        Destroy(segment.gameObject);
    }

    public void MarkForDeletion(SegmentController currentSegment)
    {
        
    }
}
