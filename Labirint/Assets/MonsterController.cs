using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        TryGetComponent<NavMeshAgent>(out agent);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(FindObjectOfType<CharacterInput>().transform.position);
    }
}
