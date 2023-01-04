using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class FollowPath : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject destination;
    public GameObject finalDestination;
    public GameObject[] keysAndDoors;
    public GameObject player;
    public TextMeshProUGUI tmp;
    public GameObject timeLogic;

    private bool returningToPlayer;
    private bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        returningToPlayer = false;
        
    }

    private void StartGame()
    {
        gameStarted = true;
        agent = GetComponent<NavMeshAgent>();
        if (!agent.enabled)
        {
            agent.enabled = true;
        }
        agent.SetDestination(destination.transform.position);
        GameObject.Find("Timer").GetComponent<Timer>().StartTimer();
        GameObject.Find("EntranceDoor").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if(Input.GetKey(KeyCode.E))
            {
                StartGame();
            }
        }
        if (gameObject.name == "FireflyTargetNavAgent")
        {
            NavMeshPath path = new NavMeshPath();
/*            Debug.Log("Current Destination: " + destination.name.ToString());
*/            bool pathToDestinationExists = NavMesh.CalculatePath(transform.position, destination.transform.position, NavMesh.AllAreas, path);
            for (int i = 0; i < path.corners.Length - 1; i++)
                UnityEngine.Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

            // check if too far from player
            NavMeshPath pathToPlayer = new NavMeshPath();
            NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, pathToPlayer);
            float distanceToPlayer = 0f;
            for (int i = 0; i < pathToPlayer.corners.Length - 1; i++)
            {
                var segmentLength = Vector3.Distance(pathToPlayer.corners[i], pathToPlayer.corners[i + 1]);
                distanceToPlayer += segmentLength;
            }
            if(distanceToPlayer > 7f)
            {
                if(!returningToPlayer)
                    UnityEngine.Debug.Log("Player lost, returning");
                returningToPlayer = true;
                destination = player;
                agent.SetDestination(destination.transform.position);
                timeLogic.GetComponent<TimeLogic>().SendText("Don't let the fireflies get too far...\nThey will lead the way!", tmp);

                return;
            }
            else if(distanceToPlayer < 1.5f && returningToPlayer)
            {
                returningToPlayer = false;
                CalculateNewDestination();
                agent.SetDestination(destination.transform.position);
                UnityEngine.Debug.Log("Player found, moving to " + destination.name);
            }

            // Check if new destination necessary
            if (!destination.activeSelf) {
                CalculateNewDestination();
                agent.SetDestination(destination.transform.position);
            }
        }
    }

    private void CalculateNewDestination()
    {
        UnityEngine.Debug.Log("Calculating new destination");
        foreach(GameObject go in keysAndDoors)
        {
            if (go.activeSelf /*&& NavMesh.CalculatePath(transform.position, go.transform.position, NavMesh.AllAreas, new NavMeshPath())*/)
            {
                if(agent.destination != go.transform.position)
                {
                    UnityEngine.Debug.Log("Destination changed to " + go.name);
                    destination = go;
                    return;
                }
            }
            else
            {
                UnityEngine.Debug.Log("Path to " + go.name + " not found");
            }
        }
    }
}
