using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referencias : MonoBehaviour
{
    public GameObject[] objectToFind;

    public Enemigo enemy;

    string tagName = "Enemigo";

    // Start is called before the first frame update
    void Start()
    {
        objectToFind = GameObject.FindGameObjectsWithTag(tagName);

        Debug.Log(objectToFind.Length);
    }
}
