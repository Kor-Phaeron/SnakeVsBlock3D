using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Snake;
    public int CameraOffset = 1;

    private void Start()
    {

    }

    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.x = Snake.position.x-CameraOffset;
        transform.position = transformPosition;
    }
}
