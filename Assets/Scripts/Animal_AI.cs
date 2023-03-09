using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Animal_AI : MonoBehaviour
{
    public Transform Player;
    public Transform CurrentAnimal;
    public float safeDistance = 10.0f;
    public Animator anim;

    private Vector3 initialPosition;
    private bool isRunningAway = false;
    private float distanceToPlayer;
    private NavMeshAgent agent;

    void Start()
    {
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!isRunningAway)
        {
            distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

            if (distanceToPlayer < safeDistance)
            {
                RunAway();
            }
            else if (anim.GetBool("Eating") == true)
            {
                //agent.SetDestination(transform.position);
                agent.isStopped = true;
                this.transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, 0f);
                this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                agent.speed = 1.5f;
                agent.isStopped = false;
                anim.SetBool("Run", false);
                anim.SetBool("Walk", true);
                //agent.SetDestination(transform.forward);
                // Move around randomly within a certain radius
                Vector3 randomDirection = Random.insideUnitSphere * safeDistance * 30f;
                randomDirection += initialPosition;
                UnityEngine.AI.NavMeshHit hit;
                UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, safeDistance, 1);
                Vector3 finalPosition = hit.position;
                GetComponent<UnityEngine.AI.NavMeshAgent>().destination = finalPosition;
            }
        }
    }

    void RunAway()
    {
        isRunningAway = true;
        agent.isStopped = false;
        agent.speed = 20f;
        // Play the "Run Fast" animation clip
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        Vector3 runDirection = transform.position - Player.transform.position * 30f;
        runDirection.Normalize();
        Vector3 targetPosition = transform.position + runDirection * safeDistance;
        GetComponent<UnityEngine.AI.NavMeshAgent>().destination = targetPosition;
        Invoke("ResumeNormalActivity", 5.0f);
    }

    void ResumeNormalActivity()
    {
        isRunningAway = false;
    }
}
