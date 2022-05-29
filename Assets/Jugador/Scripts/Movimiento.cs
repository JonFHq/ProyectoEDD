using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float xInput, zInput;
    public Rigidbody rb;
    public float speed = 5f;

    //int dobleSalto = 0;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    void FixedUpdate() {
        Movement();
    }

    private void GetInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Movement()
    {
        Vector3 direction = new Vector3(xInput, 0, zInput);
        rb.AddForce(direction * speed);
    }
}
