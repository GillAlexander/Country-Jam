using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget = null;
    public Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = followTarget.transform.position + offset;
    }
}
