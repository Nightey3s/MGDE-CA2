using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    private SegmentConstructor constructor;
    private SegmentDeleter deleter;
    [SerializeField] private ConstructionQueue queue;
    private GameObject currentSegment;

    private void Awake()
    {
        constructor = GetComponentInChildren<SegmentConstructor>();
        queue = GetComponentInChildren<ConstructionQueue>();
        deleter = GetComponentInChildren<SegmentDeleter>();
    }

    private void Update()
    {
        if (constructor.SpaceAvailable())
        {
            currentSegment = queue.GetNextSegment().gameObject;
            constructor.Construct(ref currentSegment);
            currentSegment.GetComponent<SegmentController>().MarkForDeletion(deleter);
        }
    }
}

