using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot_AI : MonoBehaviour
{


    NavMeshAgent agent;
    public Vector3 Random_Destination;
    Animator anim;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Random_Destination = RandomNavmeshLocation(50);
        anim = GetComponent<Animator>();
      

    }

    void Update()
    {
        //anim.SetBool("Run", false);
        //anim.SetBool("Shoot", false);
        timer += Time.deltaTime;
        if (timer >= wanderTimer)
        {
            //Agent.speed = Speed;
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            agent.speed = 1.5f;
            timer = 0;
        }
    }



    public Vector3 RandomNavmeshLocation(float radius)
    {

        //Debug.Log("setiiing sedtination");
        Vector3 randomDirection = Random.insideUnitSphere * (radius);
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }




    #region Wander
    public float wanderRadius;
    public float wanderTimer;
    private Transform target;
    private float timer;
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
    #endregion
}
