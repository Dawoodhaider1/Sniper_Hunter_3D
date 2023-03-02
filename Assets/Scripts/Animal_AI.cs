using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animal_AI : MonoBehaviour
{
    public Transform Player;
    public Transform CurrentAnimal;
    public float safeDistance = 10.0f;
    public float speed = 30f;

    public Animation anim;

    private Vector3 initialPosition;
    private bool isRunningAway = false;

    void Start()
    {
        anim = GetComponent<Animation>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!isRunningAway)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

            if (distanceToPlayer < safeDistance)
            {
                isRunningAway = true;
                // Disable all other animations
                foreach (AnimationState state in anim)
                {
                    if (state.name != "Run Fast") 
                    {
                        state.enabled = false;
                    }
                }
                // Play the "Run Fast" animation clip
                while(distanceToPlayer < safeDistance)
                {
                    anim.Play("Run Fast");
                    //yield return new WaitForSeconds(0.15f);
                }
                //Debug.Log("Run Animation Playing");
                Vector3 runDirection = transform.position - Player.transform.position;
                runDirection.Normalize();
                Vector3 targetPosition = transform.position + runDirection * safeDistance;
                GetComponent<UnityEngine.AI.NavMeshAgent>().destination = targetPosition;
                Invoke("ResumeNormalActivity", 5.0f);
            }
            else
            {
                // Disable all other animations
                foreach (AnimationState state in anim)
                {
                    if (state.name != "Walk") 
                    {
                        state.enabled = false;
                    }
                }
                // Play the "Walk" animation clip
                anim.Play("Walk");
                //Debug.Log("Walk Animation Playing");

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

    void ResumeNormalActivity()
    {
        isRunningAway = false;
    }
}
