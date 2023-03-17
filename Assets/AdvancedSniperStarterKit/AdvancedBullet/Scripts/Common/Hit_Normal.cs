using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Hit_Normal : AS_BulletHiter
{
    public Animator anim;
    private NavMeshAgent agent;
    private int death = 0;
    Level_Manager level;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        level = GameObject.FindObjectOfType<Level_Manager>();
    }

    public override void OnHit (RaycastHit hit, AS_Bullet bullet)
	{
		AddAudio (hit.point);
		base.OnHit (hit, bullet);
        if(death == 0)
        {
            StartCoroutine(StopAnimation());
            death++;
        }
    }

    IEnumerator StopAnimation()
    {
        anim.SetBool("Death", true);
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        yield return new WaitForSeconds(0.2f);
        agent.isStopped = true;
        GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(3f);
        if(level!=null)
        {
            for(int i=0;i<level.Name.Count;i++)
            {
                if (gameObject.name == level.Name[i])
                {
                    GamePlay.Instance.UpdateScore();
                    level.Name.RemoveAt(i);
                    //Reward = Random.Range(200, 500);
                    //GameManager.Instance.Coins = Reward;
                    //GameManager.Instance.SaveUserData();
                }
            }
          
        }
        //GameManager.Instance.UpdateScore();
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

}
