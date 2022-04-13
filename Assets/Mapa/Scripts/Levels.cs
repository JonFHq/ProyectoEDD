using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Levels : MonoBehaviour
{
    private int nivel;
    public int Nivel { get => nivel; set => nivel = value; }

    public int pruebaCambio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moverEscena();
    }

    public void moverEscena()
    {
        if (Input.GetKeyDown("f"))
        {
            SceneManager.LoadScene(1);
        }

    }
}
