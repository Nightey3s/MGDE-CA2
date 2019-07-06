using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionQueue : MonoBehaviour
{
    [Tooltip("Array of generatable segments")]
    public SegmentController[] segmentsUsed;

    /// <summary>
    /// Segment generation mode.
    /// </summary>
    public enum Mode { RANDOMIZE, FROM_FIXED_LIST }
    public Mode SegmentGenerationType { get; set; }

    /// <summary>
    /// Returns a segment based on the constuction queue's generation mode.
    /// </summary>
    /// <returns></returns>
    public SegmentController GetNextSegment()
    {
        switch (SegmentGenerationType)
        {
            case (Mode.RANDOMIZE):
                return GetRandomSegmentFromArray(this.segmentsUsed);
            case (Mode.FROM_FIXED_LIST):
                return null;
            default:
                return null;
        }
    }

    // Returns a random segment from the array argument
    private SegmentController GetRandomSegmentFromArray(SegmentController[] segments)
    {
        int index = Random.Range(0, segments.Length);
        return segments[index];
    }
}
