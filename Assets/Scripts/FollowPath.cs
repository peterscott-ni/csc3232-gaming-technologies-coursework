using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(!agent.enabled)
        {
            agent.enabled = true;
        }
        Vector3 destinationLocation = destination.transform.position;
        agent.SetDestination(destinationLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
