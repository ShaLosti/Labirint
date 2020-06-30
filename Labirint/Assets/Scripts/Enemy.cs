using Cinemachine.Utility;
using System;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public enum EnemyStates
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

    public Vector3 targetWayPoint;
    public Transform plrTransform;

    [SerializeField]
    private float maxTime;
    [SerializeField]
    private short radiusAroundPlr;
    [SerializeField]
    private float speed;

    private float t;
    private NavMeshAgent agent;
    private EnemyStates state;
    public EnemyStates State { get => state; set => state = value; }

    private void Start()
    {
        Initilize();
        TryGetComponent<NavMeshAgent>(out agent);
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        CurrentEnemy = this;

        agent.speed = speed;
        State = EnemyStates.stop;
    }

    private void Update()
    {
        switch (State)
        {
            case EnemyStates.searchPlr:
                targetWayPoint = FindNearestTargetWayPoint(targetWayPoint);
                break;
            case EnemyStates.followPlr:
                targetWayPoint = plrTransform.position;
                break;
            case EnemyStates.stop:
                targetWayPoint = transform.position;
                break;
        }
        agent.SetDestination(targetWayPoint);
    }

    private Vector3 FindNearestTargetWayPoint(Vector3 _targetWayPoint)
    {
        t += Time.deltaTime;
        if(t >= maxTime || (_targetWayPoint == Vector3.zero
            || Vector3.Distance(_targetWayPoint, plrTransform.position) < 1f
            || Vector3.Distance(transform.position, _targetWayPoint) < 1f))
        {
            Vector2 newTargetWayPoint =  new Vector2(CharacterInput.ControllByPlr.transform.position.x,
            CharacterInput.ControllByPlr.transform.position.y)
            + UnityEngine.Random.insideUnitCircle * radiusAroundPlr;

            _targetWayPoint = new Vector3(newTargetWayPoint.x, newTargetWayPoint.y, _targetWayPoint.z);

            t = 0f;
        }
        return _targetWayPoint;
    }
    private void Initilize()
    {
        if (plrTransform == null)
            plrTransform = CharacterInput.ControllByPlr.transform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, targetWayPoint);
    }
}
