using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float rotationalSpeed;


    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.eulerAngles += new Vector3(0, 0, rotationalSpeed * Time.deltaTime);
    }
}
