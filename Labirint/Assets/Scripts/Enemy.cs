using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private enum EnemyStates
    {
        searchPlr,
        followPlr,
        stop,
    }
    
    private static Enemy currentEnemy;
    public static Enemy CurrentEnemy { 
        get => currentEnemy;
        set {
            if (value != null)
                currentEnemy = value;
        }
    }

    public Transform plrTransform;
    public Transform targetWayPoint;
    private Transform _nearWayPoint;

    private NavMeshAgent agent;
    private EnemyStates state;
    private EnemyStates State { get => state; set => state = value; }

    private void Start()
    {
        Initilize();
        TryGetComponent<NavMeshAgent>(out agent);
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        CurrentEnemy = this;
        State = EnemyStates.followPlr;
    }

    private void Update()
    {
        switch (State)
        {
            case EnemyStates.searchPlr:
                targetWayPoint = FindNearestTargetWayPoint();
                break;
            case EnemyStates.followPlr:
                targetWayPoint = plrTransform;
                break;
            case EnemyStates.stop:
                targetWayPoint = transform;
                break;
        }
        agent.SetDestination(targetWayPoint.position);
    }

    private Transform FindNearestTargetWayPoint()
    {
        if(targetWayPoint == plrTransform
            || targetWayPoint == transform
            || Vector3.Distance(transform.position, _nearWayPoint.position) < 1f)
        {

        }
        return _nearWayPoint;
    }
    private void Initilize()
    {
        if (plrTransform == null)
            plrTransform = CharacterInput.ControllByPlr.transform;
    }

}
