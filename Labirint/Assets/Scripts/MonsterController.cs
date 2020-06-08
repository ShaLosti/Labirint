using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] public GameObject targetObject;

    private void Start()
    {
        TryGetComponent<NavMeshAgent>(out agent);
        targetObject = FindObjectOfType<CharacterInput>().gameObject;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(targetObject.transform.position);
    }
}
