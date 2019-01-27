using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeFollowBehaviour : MonoBehaviour
{
    private bool canFollow = false;



    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetAnimation();
        

       
    }
    void Update()
    {

    }

    public void SetAnimation() {
        Debug.Log("teste");
        int i = Mathf.RoundToInt( Random.Range(1f, 3f));
        Debug.Log(i);
        this.animator.SetInteger("anim", i);
    }
}
