using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    [Range(0, 1)] public float smoothness;
    public float sensibility=1;

    void Awake()
    {
        target = GameObject.Find("Jugador");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        GetInputs();
    }
    
    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, smoothness);
        transform.LookAt(target.transform);
    }

    void GetInputs()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;
    }
}
