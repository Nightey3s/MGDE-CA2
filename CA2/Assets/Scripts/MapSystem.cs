using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    private SegmentConstructor constructor;
    private SegmentDeleter deleter;
    [SerializeField] private ConstructionQueue queue;
    private bool isReady;
    private bool isEmpty;
    private SegmentController currentSegment;

    private void Awake()
    {
        constructor = GetComponentInChildren<SegmentConstructor>();
        queue = GetComponentInChildren<ConstructionQueue>();
        isReady = true;
        isEmpty = false;
    }
    private void Update()
    {
        if (constructor.SpaceAvailable())
        {
            currentSegment = queue.GetNextSegment();
            constructor.Construct(currentSegment.gameObject);
            deleter.MarkForDeletion(currentSegment);
        }
    }

    private void CheckStates()
    {
        
    }
}

