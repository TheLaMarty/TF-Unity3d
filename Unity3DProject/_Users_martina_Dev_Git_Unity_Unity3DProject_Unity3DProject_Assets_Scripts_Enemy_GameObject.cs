﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GameObject : MonoBehaviour
{

    NavMeshAgent pathfinder;
    Transform target;

    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = UnityEngine.GameObject.FindGameObjectWithTag("Player").transform;
        // StartCoroutine(PathUpdate());
    }

    void Update()
    {
        pathfinder.SetDestination(target.position);
    }

    private IEnumerator PathUpdate()
    {
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(.25f);
        }
    }
}
