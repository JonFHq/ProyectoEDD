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
    public float shootSpeed = 1;
    public float timeBetweenShots = 3;
    float originalTime=5;


    public void Start()
    {

        shootSpeed = 1;
        timeBetweenShots = 3;
        
    }
    public void FixedUpdate()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if (Distance > 10 && Distance <= 1000)
        {
            IsPlayerInSight = true;
        }
        else
        {
            IsPlayerInSight = false;
        }
        if (IsPlayerInSight)
        {
            agent.isStopped = false;
            agent.SetDestination(Player.transform.position);
        }
       /* if (!IsPlayerInSight)
        {
            agent.isStopped = true;
            timeBetweenShots -= Time.deltaTime;
            if (timeBetweenShots <= 0)
            {
                ShootPlayer();
                timeBetweenShots = originalTime;
            }
        }*/
        transform.LookAt(target);
    }

   /* private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponentInChildren<Rigidbody>();

        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
*/

}

