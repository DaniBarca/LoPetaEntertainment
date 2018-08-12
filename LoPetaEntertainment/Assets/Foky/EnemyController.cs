﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {


    public float lookRadius = 10f;
    private Animator anim;
    Transform target;
    NavMeshAgent agent;

    bool doingDamage;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(DoDamageLoop());
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                anim.SetBool("isAttacking", true);
                FaceTarget();
                doingDamage = true;
            } else
            {
                anim.SetBool("isAttacking", false);
                doingDamage = false;
            }
        }
    }

    IEnumerator DoDamageLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if(doingDamage)
            {
                Debug.Log("asfdg");
                DamagePlayer();
            }
        }
    }

    void DamagePlayer()
    {
        PlayerManager.instance.player.GetComponent<GoodGuy>().ReceiveDamage();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}
