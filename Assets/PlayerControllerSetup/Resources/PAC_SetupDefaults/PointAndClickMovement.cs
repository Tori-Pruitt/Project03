using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClickMovement : MonoBehaviour
{
    Vector3 _destination;

    NavMeshAgent _agent;

    bool _seekingDestination = false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_seekingDestination == false) { return; }

        _agent.SetDestination(_destination);
    }

    public void SetDestination(Vector3 hitLocation)
    {
        _destination = hitLocation;
        _agent.SetDestination(hitLocation);
        _seekingDestination = true;
    }
}
