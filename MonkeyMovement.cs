using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonkeyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera cam;

    private bool isMoving;
    // Update is called once per frame
    void Update()
    {
        

       /* if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                agent.SetDestination(hit.point);
            }
        }*/

        
    }
    private void MonkeyMove()
    {
        bool res = false;
        //bool res = agent.SetDestination(position);
        
        Vector3 position = RandomPosition();
        
        if (res)
        {
            Debug.Log("deplacement du singe : x = " + position.x + " z = " + position.z);
        }
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));

    }
}
