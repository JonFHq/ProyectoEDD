using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Levels : MonoBehaviour
{
    //cambiador es el objeto que tiene el script
    public static GameObject CAMBIADOR;

    public int acum;
    public int nivel;

    public string tagName = "Enemigo";
    public GameObject[] enemigos;

    private void Awake()
    {
        if (CAMBIADOR != null)//si hay un cambiador en la escena me destruyo
        {
            Destroy(this.gameObject);//detruyo el gameObject que este "duplicado"
            return;
        }
        //relleno la variable conmigo mismo
        CAMBIADOR = this.gameObject;
        DontDestroyOnLoad(CAMBIADOR);//no se destruya en cambios de escena
        
    }

    void Start()
    {
        nivel = 1;
        
        Debug.Log("el nivel es: " + nivel);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
        acum++;
    }

    public void ChangeScene()
    {
        Scene currentScence = SceneManager.GetActiveScene();
        if (nivel >= 1)
        {
            if(acum >= 60)//esperar enemigos
            {
                if (enemigos.Length == 0)//si no hay enemigo 
                {
                    Debug.Log("Se ha muerto el enemigo, me cambio de escena");
                    int escenas = Random.Range(0, 3);//el id de las escenas
                    if (currentScence == SceneManager.GetSceneByBuildIndex(escenas))//mira si la escena que estoy va a ser la misma que la que va a cargar
                    {
                        //llamo a la misma funcion hasta que cargue una escena distinta
                        ChangeScene();
                        return;
                    }
                    SceneManager.LoadScene(escenas);//hace random de las escenas 0,1,2
                    acum = 0;
                    nivel++;
                }
            }
        }
        enemigos = GameObject.FindGameObjectsWithTag(tagName);
    }
}
