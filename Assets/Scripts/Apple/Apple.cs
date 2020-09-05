using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Vector3 ApplePosition;

    private void Start()
    {
        ApplePosition = transform.position;
    }
}
