using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float xInput,
        zInput;
    public Rigidbody rb;
    public float speed;
    public GameObject camara;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void GetInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Movement()
    {
        //Change player direction based on camera rotation
        Vector3 movement = camara.transform.forward * zInput;
        movement += camara.transform.right * xInput;
        movement = movement.normalized * speed;
        //Movement with addForce
        rb.AddForce(movement);
    }
}
