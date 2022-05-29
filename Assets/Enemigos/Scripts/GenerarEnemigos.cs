using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{
    public GameObject Enemy;
    public int counter = 7;
    public int xPos,
        yPos,
        zPos,
        enemyCount;
    public GameObject range;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
        range = GameObject.FindWithTag("Respawn");
    }
    void Update()
    {
        range = GameObject.FindWithTag("Respawn");
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < counter)
        {
            xPos = Random.Range((int)(range.transform.position.x - 25f),( int)(range.transform.position.x + 25f));
            zPos = Random.Range((int)(range.transform.position.z - 25f),( int)(range.transform.position.z + 25f));
            yPos = Random.Range((int)(range.transform.position.y + 1f), (int)(range.transform.position.y + 30f));

            Instantiate(Enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount++;
        }
    }
}
