using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    public float angle;

    void Update()
    {
        this.transform.Rotate(0, angle * Time.deltaTime, 0);
    }
}
