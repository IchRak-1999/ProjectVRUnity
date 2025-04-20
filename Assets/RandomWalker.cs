using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalker : MonoBehaviour
{
    public float speed = 1.5f;
    public float directionChangeInterval = 3f;
    private float timer;
    private Vector3 moveDirection;
    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        PickNewDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= directionChangeInterval || IsObstacleAhead())
        {
            PickNewDirection();
            timer = 0;
        }

        controller.SimpleMove(moveDirection * speed);
        animator.SetBool("isWalking", moveDirection.magnitude > 0.1f);
    }

    void PickNewDirection()
    {
        float angle = UnityEngine.Random.Range(0f, 360f);
        moveDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }

    bool IsObstacleAhead()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, transform.forward);
        return Physics.Raycast(ray, 1.5f);
    }
}