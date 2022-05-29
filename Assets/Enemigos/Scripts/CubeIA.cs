
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
    public float timeToDestroy=5;
    
    public float vidaBala=1;

    public void Start()
    {

        shootSpeed = 50;
        timeBetweenShots = 3;
        timeToDestroy = 5;
    }
    public void FixedUpdate()
    {
        
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if (Distance <= 100)
        {
            IsPlayerInSight = true;
            agent.isStopped=false;
        //    agent.SetDestination(Player.transform.position);
        }
        else
        {
            IsPlayerInSight = false;

        }
        if (IsPlayerInSight && Distance<=100)
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
        //if (!IsPlayerInSight)
        //{
        //    agent.isStopped = true;
            
       // }
        transform.LookAt(target);

       
        
    }

    private void ShootPlayer()
    {
        
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponentInChildren<Rigidbody>();
        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
                timeToDestroy-= Time.deltaTime;
              if(timeToDestroy<=0)
                {

              Destroy(currentBullet);
               }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jugador")
        {
            Destroy(gameObject);
        }
    }
/*
    private void OnCollisionEnter(Collision collision)
    {
        //al golpear una bala esta desaparece
        if (collision.gameObject.tag == "bala")
        {
            vidaBala--;
            if (vidaBala <= 0)
                Destroy(collision.gameObject);
            
        }
       
        if (collision.gameObject.tag == "bala")
        {
            life -= 25;
            if (life <= 0)
            {

                Destroy(gameObject);
            }
            
        }
       
    }
    */
}

