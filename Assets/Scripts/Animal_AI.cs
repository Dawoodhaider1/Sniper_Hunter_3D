using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animal_AI : MonoBehaviour
{
    public Transform Player;
    public Transform CurrentAnimal;
    public float safeDistance = 10.0f;
    public float speed = 30f;

    private Vector3 initialPosition;
    private bool isRunningAway = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!isRunningAway)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

            if (distanceToPlayer < safeDistance)
            {
                RunAway();
            }
            else
            {
                // Move around randomly within a certain radius
                Vector3 randomDirection = Random.insideUnitSphere * safeDistance;
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
        Vector3 runDirection = transform.position - Player.transform.position;
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
