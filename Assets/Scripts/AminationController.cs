using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AminationController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        Move();
    }

    void Move()
    {

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("isMove", true);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isMove", true);
        }
    }
}
