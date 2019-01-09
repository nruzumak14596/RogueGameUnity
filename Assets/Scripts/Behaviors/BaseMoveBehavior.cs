using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BaseMoveBehavior : MonoBehaviour, IMoveBehavior
{
    private const float moveTime = 1 / 0.1f;
    private BoxCollider2D boxCollider;
    private Coroutine moveCoroutine;

    public bool IsMoving { get; set; } = false;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
    }

    public void Move(Vector3 offset)
    {
        if (IsMoving)
            return;

        Vector3 start = transform.position;
        Vector3 end = start + offset;

        boxCollider.enabled = false;

        var hit = Physics2D.OverlapPoint(end);

        boxCollider.enabled = true;

        if (hit != null)
            if (hit.isTrigger)
                moveCoroutine = StartCoroutine(MoveCoroutine(end));
            else { }
        else
            moveCoroutine = StartCoroutine(MoveCoroutine(end));
    }

    public void Teleport(Vector3 endPosition)
    {
        if (IsMoving)
        {
            StopCoroutine(moveCoroutine);
            IsMoving = false;
        }
        transform.position = endPosition;       
    }

    public IEnumerator MoveCoroutine(Vector3 endPosition)
    {
        IsMoving = true;

        float sqrRemainingDistance = (transform.position - endPosition).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPostion = Vector3.MoveTowards(transform.position, endPosition, moveTime * Time.deltaTime);
            transform.position = newPostion;
            sqrRemainingDistance = (transform.position - endPosition).sqrMagnitude;

            yield return null;
        }

        transform.position = endPosition;

        IsMoving = false;
    }
}
