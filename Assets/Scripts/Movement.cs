using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float zSpeed;
    [SerializeField] private float maxSwerve;
    [SerializeField] private Transform collectorTf;
    
    private float _lastXPos;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.forward * (Time.deltaTime * zSpeed);
        float moveXDelta = 0;
        if (Input.GetMouseButtonDown(0))
        {
            _lastXPos = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveXDelta = Mathf.Clamp((Input.mousePosition.x - _lastXPos) * Time.deltaTime, -maxSwerve, +maxSwerve);
            _lastXPos = Input.mousePosition.x;
        }

        Vector3 handPos = collectorTf.localPosition;
        collectorTf.localPosition = new Vector3(Mathf.Clamp(moveXDelta + handPos.x, -1.2f, 1.2f), handPos.y, handPos.z);

    }
}