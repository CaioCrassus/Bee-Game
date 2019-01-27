using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestBehaviour : MonoBehaviour
{
    private Transform target;

    public float distance;
    public float speed = 10f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > distance)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
