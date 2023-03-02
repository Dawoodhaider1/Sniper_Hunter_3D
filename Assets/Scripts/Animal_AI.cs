using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Animal_AI : MonoBehaviour
{
    public Transform Player;
    public Transform CurrentAnimal;
    public float safeDistance = 10.0f;
    public float speed = 30f;
    private NavMeshAgent agent;

    public Animator anim;

    private Vector3 initialPosition;
    private bool isRunningAway = false;
    private float distanceToPlayer;

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
            else
            {
                agent.speed = 3.5f;
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
                // Move around randomly within a certain radius
                Vector3 randomDirection = Random.insideUnitSphere * safeDistance;
                randomDirection += initialPosition;
                UnityEngine.AI.NavMeshHit hit;
                UnityEngine.AI.NavMesh.SamplePosition(randomDirection , out hit, safeDistance, 1);
                Vector3 finalPosition = hit.position;
                GetComponent<UnityEngine.AI.NavMeshAgent>().destination = finalPosition;
            }
        }
    }

    void RunAway()
    {
        isRunningAway = true;
        agent.speed = 20f;
        // Disable all other animations
        // Play the "Run Fast" animation clip
        //StartCoroutine(Running());
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        Vector3 runDirection = transform.position - Player.transform.position * 10;
        runDirection.Normalize();
        Vector3 targetPosition = transform.position + runDirection * safeDistance;
        GetComponent<UnityEngine.AI.NavMeshAgent>().destination = targetPosition;
        Invoke("ResumeNormalActivity", 5.0f);
    }

    //IEnumerator Running()
    //{
    //    while (distanceToPlayer < safeDistance)
    //    {
    //        // Play the animation
    //        anim.Play();

    //        // Wait for the animation to finish playing
    //        yield return new WaitForSeconds(anim.clip.length);
    //    }
    //}

    void ResumeNormalActivity()
    {
        isRunningAway = false;
    }
}
