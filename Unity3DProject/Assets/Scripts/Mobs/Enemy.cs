using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
    public ParticleSystem deathEffect;

    NavMeshAgent pathfinder;
    Transform target;
    Material material;
    Color originalColor;
    Color attackColor;
    float attackDistance;
    float DistanceFromPlayer;

    protected override void Start()
    {
        base.Start();

        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
        attackColor = Color.red;

        StartCoroutine(PathUpdate());

    }

    void Update()
    {
        pathfinder.SetDestination(target.position);

        DistanceFromPlayer = Vector3.Distance(target.transform.position, transform.position);

        var main = deathEffect.main;

        if (DistanceFromPlayer < 3)
        {
            material.color = Color.red;
            main.startColor = attackColor;
            //material.SetColor("_Color", Color.red);
        }
        else if (DistanceFromPlayer > 2)
        {
            material.color = originalColor;
            main.startColor = originalColor;

            //material.SetColor("_Color", Color.black);
        }
    }

    private IEnumerator PathUpdate()
    {
        while (target != null)
        {
            //Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            Vector3 targetPosition = (target.position - transform.position).normalized;
            if (!dead)
            {
                pathfinder.SetDestination(targetPosition);
                yield return new WaitForSeconds(.25f);
            }
        }
    }

    public override void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        if (damage >= health)
        {
            Destroy(Instantiate(deathEffect.gameObject, hitPoint, Quaternion.FromToRotation(Vector3.forward, hitDirection)) as GameObject, deathEffect.startLifetime);
        }
        base.TakeHit(damage, hitPoint, hitDirection);
    }
}

