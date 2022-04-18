using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject left_camera;
    public GameObject right_camera;
    bool movimientoCamara;

    // Start is called before the first frame update
    void Start()
    {
        movimientoCamara = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (movimientoCamara)
            {
                transform.position = right_camera.transform.position;
                movimientoCamara = !movimientoCamara;
            }
            else
            {
                transform.position = left_camera.transform.position;
                movimientoCamara = !movimientoCamara;
            }
        }
    }
}
