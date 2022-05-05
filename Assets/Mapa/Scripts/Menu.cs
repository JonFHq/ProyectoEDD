using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonChange()
    {
        Scene currentScence = SceneManager.GetActiveScene();
        int escenas = Random.Range(0, 3);//el id de las escenas
        if (currentScence == SceneManager.GetSceneByBuildIndex(escenas))//mira si la escena que estoy va a ser la misma que la que va a cargar
        {
            //llamo a la misma funcion hasta que cargue una escena distinta
            return;
        }
        SceneManager.LoadScene(escenas);//hace random de las escenas 0,1,2
    }
}
