using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For moving background in setup and mainmenu scenes
/// </summary>
public class CameraBackgroundMover : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Vector3 rotationAxis = Vector3.up;

    private void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
