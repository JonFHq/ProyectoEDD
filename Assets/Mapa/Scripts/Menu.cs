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
        int escenas = Random.Range(0, 3);
        if (currentScence == SceneManager.GetSceneByBuildIndex(escenas))
        {
            return;
        }
        SceneManager.LoadScene(escenas);
    }
}
