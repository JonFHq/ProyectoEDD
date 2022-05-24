using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeIA : MonoBehaviour
{

    public float timeBetweenAttacks;
    public float Distance;
    public GameObject Player;
    public bool IsPlayerInSight;
    public Transform target;
    public NavMeshAgent agent;

    public GameObject bullet;
    public Transform shootPoint;
    public float shootSpeed = 100;
    public float timeBetweenShots = 3;
    float originalTime=3;


    public void Start()
    {

        shootSpeed = 50;
        timeBetweenShots = 3;
        
    }
    public void FixedUpdate()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if (Distance <= 25)
        {
            IsPlayerInSight = true;
            agent.isStopped=false;
            agent.SetDestination(Player.transform.position);
        }
        else
        {
            IsPlayerInSight = false;

        }
        if (IsPlayerInSight && Distance<=15)
        {
            timeBetweenShots -= Time.deltaTime;
            if (timeBetweenShots <= 0)
            {
                ShootPlayer();
                timeBetweenShots = originalTime;
            }
           // agent.isStopped = false;
           // agent.SetDestination(Player.transform.position);
        }
        if (!IsPlayerInSight)
        {
            agent.isStopped = true;
            
        }
        transform.LookAt(target);
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponentInChildren<Rigidbody>();

        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
        //si el objeto currentBullet llega a la posicion en el eje Y desaparece.

    }
    //if a bullet hits the player, the bullet dissapears
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
 



}

