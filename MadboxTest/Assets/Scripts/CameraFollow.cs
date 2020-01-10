using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowerPlayerObject;

    void Update()
    {
        transform.LookAt(FollowerPlayerObject);
    }
}
