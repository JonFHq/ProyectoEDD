using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public int nivel;
    //cambiador es el objeto que tiene el script
    public static GameObject cambiador;
    public Enemigo enemy;

    private void Awake()
    {
        if (cambiador != null)//si hay un cambiador en la escena me destruyo
        {
            Destroy(this.gameObject);//detruyo el gameObject que este "duplicado"
            return;
        }
        //relleno la variable conmigo mismo
        cambiador = this.gameObject;
        DontDestroyOnLoad(cambiador);//no se destruya en cambios de escena
    }

    private void OnEnable()//se llama cuando carga
    {
        SceneManager.sceneLoaded += OnLoadScene;//llama a la funcion cuando cargas la escena, += te subscribes al evento sceneLoaded
    }

    public void OnLoadScene(Scene scene, LoadSceneMode mode)
    {
        Enemigo[] enemigos = FindObjectsOfType<Enemigo>();//busca en la escena los gameObjects que tengan el script enemigo
        
    }

    void Start()
    {
        nivel = 1;
        Debug.Log("el nivel es: " + nivel);
    }

    // Update is called once per frame
    void Update()
    {
        MoverEscena();
    }

    public void MoverEscena()
    {
        Scene currentScence = SceneManager.GetActiveScene();
        if (nivel >= 1)
        {
            if (enemy == null)//si no hay enemigo 
            {
                Debug.Log("Se ha muerto el enemigo, me cambio de escena");
                int escenas = Random.Range(0, 3);//el id de las escenas
                if (currentScence == SceneManager.GetSceneByBuildIndex(escenas))//mira si la escena que estoy va a ser la misma que la que va a cargar
                {
                    //llamo a la misma funcion hasta que cargue una escena distinta
                    MoverEscena();
                    return;
                }
                SceneManager.LoadScene(escenas);//hace random de las escenas 0,1,2
                nivel++;
            }
        }
    }
    private void OnDisable()//se llama cuando el componente(script) se desactiva
    {
        SceneManager.sceneLoaded -= OnLoadScene;
    }
}
