using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 1f;
    public float tiempoRotacion = 0.1f;
    float velocidadRotacion;
    public Transform camera;
    public float velocidadSalto;
    public CharacterController controlador;
    //int dobleSalto = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(direccionHorizontal, 0, direccionVertical);
        if(direccion != Vector3.zero)
        {
            float anguloObjetivo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloObjetivo, ref velocidadRotacion, tiempoRotacion);
            transform.rotation = Quaternion.Euler(0, angulo, 0);
            Vector3 movimientoDireccion = Quaternion.Euler(0, angulo, 0) * Vector3.forward;
            controlador.Move(movimientoDireccion.normalized * velocidad * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }
}