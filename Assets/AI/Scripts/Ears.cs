﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Utility;

public class Ears : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private bool followSound;

    private Transform target;
    void OnStart()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void Hear(Transform noise)
    {
        animator.SetBool("heardSomething",true);
        target = noise;
    }

    void Update()
    {
        if (followSound)
        {
            if (Vector3.Distance(transform.position, target.position) < 1.0f)
            {
                animator.SetBool("heardSomething", false);
                return;
            }

            navMeshAgent.destination = target.position;
        }
    }

    public void StartFollowingSound()
    {
        followSound = true;
    }

    public void StopFollowingSound()
    {
        followSound = false;
    }
}
