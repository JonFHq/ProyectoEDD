using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //hacer en la clase levels
    //String tagName = "Enemy";
    //enemigos[i].enemy = GameObject.FindGameObjectWithTag(tagName);
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Morir();
    }

    public void Morir()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //destruye el enemigo
            Destroy(this.gameObject);
            Debug.Log("Se muere el enemigo");
        }
    }
}
