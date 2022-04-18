using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 1f;
    public float velocidadRotacion = 0.1f;
    public float velocidadSalto;
    int dobleSalto = 0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * velocidad);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * velocidad);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * velocidad);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * velocidad);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.y == 0)
            {
                dobleSalto = 0;
            }
            switch(dobleSalto)
            {
                case 0:
                    rb.AddForce(transform.up * velocidadSalto);
                    dobleSalto++;
                    break;
                case 1:
                    rb.AddForce(transform.up * velocidadSalto);
                    dobleSalto++;
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(-transform.up * velocidad);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -velocidadRotacion, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, velocidadRotacion, 0);
        }
    }
}
