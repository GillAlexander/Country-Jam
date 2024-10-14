using System;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject playerObject = null;
    private Vector3 SteerDirection = Vector3.zero;
    private Vector3 lastMousePos = Vector3.zero;
    private Vector3 currMousePos = Vector3.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        Movement();
        
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            AimBroom();
        }
    }

    private void AimBroom()
    {
        Vector3 direction = Vector3.zero;
        float time = 0;
        float magnitude = 0;

        if (Time.frameCount % 5 == 0)
        {
            lastMousePos = Input.mousePosition;
        }

        
        if (lastMousePos != Input.mousePosition)
        {
            direction = lastMousePos - Input.mousePosition;
            magnitude = direction.magnitude / 5;
        }

        Debug.LogError(Math.Clamp(magnitude, 0, 10));

        if (magnitude > 1)
        {
            //playerObject.transform.position += direction.normalized * 2;
            //playerObject.transform.position += Vector3.Lerp(lastMousePos, direction, magnitude);
            //playerObject.transform.position += direction.normalized * 2;
            playerObject.transform.position = Vector3.Lerp(playerObject.transform.position, playerObject.transform.position + direction.normalized * 2, magnitude);
        }
    }

    private void Movement()
    {
        playerObject.transform.Translate(playerObject.transform.forward, Space.World);
    }
}
