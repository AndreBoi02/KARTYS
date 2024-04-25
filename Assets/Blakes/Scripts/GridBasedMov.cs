using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMov : MonoBehaviour
{
    public float cellSize = 1f;
    public float moveSpeed = 5f;    

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
        {
            Move(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
        {
            Move(Vector3.down);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
        {
            Move(Vector3.left);
        }
    }

    void Move(Vector3 direction)
    {
        Vector3 newPosition = targetPosition + (direction * cellSize);
        StartCoroutine(SmoothMove(newPosition));
    }

    IEnumerator SmoothMove(Vector3 endPosition)
    {
        isMoving = true;
        float sqrRemainingDistance = (transform.position - endPosition).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            transform.position = newPosition;
            sqrRemainingDistance = (transform.position - endPosition).sqrMagnitude;
            yield return null;
        }

        targetPosition = endPosition;
        isMoving = false;
    }
}
