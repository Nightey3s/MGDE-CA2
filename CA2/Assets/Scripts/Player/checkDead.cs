using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDead : MonoBehaviour
{
    public void OnBecameInvisible()
    {
        Debug.Log(" can *not* be seen anymore.");
    }

    public void OnBecameVisible()
    {
        Debug.Log(" can be seen now.");
    }
}
