using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject destination;
    public GameObject finalDestination;
    public GameObject[] keysAndDoors;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(!agent.enabled)
        {
            agent.enabled = true;
        }
        agent.SetDestination(destination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "FireflyTargetNavAgent")
        {
            NavMeshPath path = new NavMeshPath();
/*            Debug.Log("Current Destination: " + destination.name.ToString());
*/            bool pathToDestinationExists = NavMesh.CalculatePath(transform.position, destination.transform.position, NavMesh.AllAreas, path);
            for (int i = 0; i < path.corners.Length - 1; i++)
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

            if (!destination.activeSelf) {
                CalculateNewDestination();
                agent.SetDestination(destination.transform.position);
            }
        }
    }

    private void CalculateNewDestination()
    {
        Debug.Log("Calculating new destination");
        foreach(GameObject go in keysAndDoors)
        {
            if (go.activeSelf /*&& NavMesh.CalculatePath(transform.position, go.transform.position, NavMesh.AllAreas, new NavMeshPath())*/)
            {
                if(agent.destination != go.transform.position)
                {
                    Debug.Log("Destination changed to " + go.name);
                    destination = go;
                    return;
                }
            }
            else
            {
                Debug.Log("Path to " + go.name + " not found");
            }
        }
    }
}
