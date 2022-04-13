using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{
    public GameObject Enemy;
    public int counter =7;
    public int xPos;
    public int zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start(){
StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount < counter){
            xPos= Random.Range(-40,40);
            zPos= Random.Range(-40,30);
            Instantiate(Enemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount++;

        }
    }
}
