using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeFollowBehaviour : MonoBehaviour
{
    private bool canFollow = false;
    private Transform target;

    public float speed = 10f;
    public float distance;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetAnimation();
        

        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        /*
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > distance)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        */
    }

    public void SetAnimation() {
        Debug.Log("teste");
        int i = Mathf.RoundToInt( Random.Range(1f, 3f));
        Debug.Log(i);
        this.animator.SetInteger("anim", i);
    }
}
