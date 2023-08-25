using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    NavMeshPath path;
    int indexpath = -1;
    public float angleSensor = 5;
    public int numberSensor = 5;
    public float rangeSensor = 2;
    public LayerMask maskSensor;
    public Transform anchorSensor;
    private float angleSteer = 0;
    private float targetSteer = 0;
    void Start()
    {
        path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        agent.updateRotation = false;
        agent.updatePosition = false;
    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.enabled = true;
                // agent.destination = hit.point;
                agent.Warp(transform.position);
                agent.CalculatePath(hit.point, path);
                indexpath = 0;
                StopCoroutine("LoopMove");
                StartCoroutine("LoopMove");
            }
        
       
        }

        angleSteer = Mathf.Lerp(angleSteer, targetSteer, Time.deltaTime * 2);
    }
    IEnumerator LoopMove()
    {
        yield return new WaitForSeconds(0.1f);

        while(indexpath!=-1)
        {
            while (Vector3.Distance(transform.position, path.corners[indexpath]) > 0.25f)
            {
                targetSteer = 0;
                for (int i = -numberSensor / 2; i <= numberSensor / 2; i++)
                {
                   
                    Quaternion q = Quaternion.Euler(0, i * angleSensor, 0);
                    Vector3 dir = q * anchorSensor.forward;
                    dir.Normalize();
                    if (Physics.Raycast(anchorSensor.position, dir, rangeSensor, maskSensor))
                    {
                        targetSteer -= i * angleSensor;
                    }
                }
                yield return new WaitForSeconds(0.02f);
                RotataToMove();
                transform.Translate(Vector3.forward * Time.deltaTime * 6);
                //transform.position = Vector3.MoveTowards(transform.position, path.corners[indexpath], Time.deltaTime * 3);
            }
            indexpath++;
            if (indexpath >= path.corners.Length)
            {
                // het path 
                indexpath = -1;
            }
        }
       
        agent.enabled = false;
     

    }
    private void RotataToMove( )
    {
        if (indexpath > -1)
        {
            float speed = 120;
            Vector3 dir = path.corners[indexpath]- transform.position;
            Quaternion qSteer = Quaternion.Euler(0, angleSteer, 0);
            dir = qSteer * dir;
            Quaternion q = Quaternion.LookRotation(dir.normalized, Vector3.up);
           
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, Time.deltaTime * speed);
        }

        //transform.forward = dir;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = -numberSensor / 2; i <= numberSensor / 2; i++)
        {
            Quaternion q = Quaternion.Euler(0, i * angleSensor, 0);
            Vector3 dir = q * anchorSensor.forward;
            dir.Normalize();
            Gizmos.DrawLine(anchorSensor.position, anchorSensor.position + dir * rangeSensor);
        }
        Gizmos.color = Color.red;
        if (path == null)
            return;
        if(path.corners.Length>=2)
        {
            for (int i = 1; i < path.corners.Length; i++)
            {
                Gizmos.DrawLine(path.corners[i - 1], path.corners[i]);
            }
        }



    }

}
