using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Levels : MonoBehaviour
{
    //cambiador es el objeto que tiene el script
    public static GameObject CAMBIADOR;

    public int nivel;

    private void Awake()
    {
        if (CAMBIADOR != null) //si hay un cambiador en la escena me destruyo
        {
            Destroy(this.gameObject); //detruyo el gameObject que este "duplicado"
            return;
        }
        //relleno la variable conmigo mismo
        CAMBIADOR = this.gameObject;
        DontDestroyOnLoad(CAMBIADOR); //no se destruya en cambios de escena
    }

    void Start()
    {
        nivel = 1;

        Debug.Log("el nivel es: " + nivel);
    }

    void Update() { }

    //Cuando el objetivo es tocado por el jugador empieza otro nivel
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        Scene currentScence = SceneManager.GetActiveScene();
        if (nivel >= 1)
        {
            Debug.Log("Se ha muerto el enemigo, me cambio de escena");
            int escenas = Random.Range(1, 4); //el id de las escenas
            if (currentScence == SceneManager.GetSceneByBuildIndex(escenas)) //mira si la escena que estoy va a ser la misma que la que va a cargar
            {
                //llamo a la misma funcion hasta que cargue una escena distinta
                ChangeScene();
                return;
            }
            SceneManager.LoadScene(escenas); //hace random de las escenas 0,1,2
            nivel++;
        }
    }
}
