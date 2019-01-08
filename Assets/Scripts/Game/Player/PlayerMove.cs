using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (Input.anyKeyDown)
            CheckDircetion();
    }

    private void CheckDircetion()
    {
        Vector3 nextPosition = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.D))
            nextPosition = new Vector3(1, 0);
        if (Input.GetKeyDown(KeyCode.A))
            nextPosition = new Vector3(-1, 0);
        if (Input.GetKeyDown(KeyCode.S))
            nextPosition = new Vector3(0, -1);
        if (Input.GetKeyDown(KeyCode.W))
            nextPosition = new Vector3(0, 1);

        if (nextPosition != Vector3.zero)
            Move(nextPosition);
    }

    //TODO: Должен быть общим для всех
    protected void Move(Vector3 offset)
    {
        Vector3 start = transform.position;
        Vector3 end = start + offset;

        boxCollider.enabled = false;

        var hit = Physics2D.OverlapPoint(end);

        boxCollider.enabled = true;

        if (hit != null)
            if (hit.isTrigger)
                transform.position = end;
            else { }
        else
            transform.position = end;
    }
}
