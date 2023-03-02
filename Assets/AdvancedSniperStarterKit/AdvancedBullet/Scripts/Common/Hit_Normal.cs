using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Hit_Normal : AS_BulletHiter
{
    public Animation anim;
    private Animal_AI animal_AI;
    private NavMeshAgent agent;

    private int death = 0;

    private void Start()
    {
        animal_AI = GetComponent<Animal_AI>();
        agent = GetComponent<NavMeshAgent>();
    }

    public override void OnHit (RaycastHit hit, AS_Bullet bullet)
	{
		AddAudio (hit.point);
		base.OnHit (hit, bullet);
        // Disable all other animations
        foreach (AnimationState state in anim)
        {
            if (state.name != "Death01")
            {
                state.enabled = false;
            }
        }
        if(death == 0)
        {
            //Play the "Death" Animation
            anim.Play("Death01");
            animal_AI.enabled = false;
            StartCoroutine(StopAnimation());
            //Debug.Log("Death Animation Playing");
            //animal_AI.enabled = false;
            //agent.enabled = false;
            death++;
        }
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        anim.Stop("Death01");
        agent.enabled = false;
    }
}
