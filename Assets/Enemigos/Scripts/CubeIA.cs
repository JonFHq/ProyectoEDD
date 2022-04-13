using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeIA : MonoBehaviour
{
    

public float Distance;
    public GameObject Player;
    public bool IsPlayerInSight;
 public Transform target;
    public Transform mytransform;
    public GameObject enemy;
    public float elife = 100f;
     GameObject ebullet;

public NavMeshAgent agent;


public void Start(){
 ebullet = Resources.Load("bullets") as GameObject;
}
public void FixedUpdate(){
    Distance = Vector3.Distance(Player.transform.position, this.transform.position);
    if(Distance <= 100000){
        IsPlayerInSight = true;
    }
    else{
        IsPlayerInSight = false;
    }
    if (IsPlayerInSight){
        agent.isStopped = false;
        agent.SetDestination(Player.transform.position);
    }
    if (!IsPlayerInSight){
        agent.isStopped = true;
    }
    transform.LookAt(target);

    
    transform.Translate(Vector3.forward * 5 * Time.fixedDeltaTime);
    GameObject bullets = Instantiate(ebullet) as GameObject;
    bullets.transform.position= transform.position * 1;
    Rigidbody rb = bullets.GetComponent<Rigidbody>();
    rb.velocity = transform.forward * 20;
    Destroy(bullets, 9f);
    if(elife <= 0){
        Destroy(enemy);
    }
}
    
}

