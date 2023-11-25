using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
  Transform playerTransform;
    [SerializeField] float speed = 1;
    [SerializeField] float maxMoveDirection = 1;
    [SerializeField] float minMoveDirection = 0;
    [SerializeField] float rotateSpeed = 5;
    [SerializeField] float acceleration = 0.02f;
    [SerializeField] float freeBreak = 0.01f;
    float breakForce = 0.04f;
    [SerializeField] float moveDirection;// 0 to 1;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerTransform.position = playerTransform.position + playerTransform.forward * Time.fixedDeltaTime * speed * moveDirection;
    }
    public void Rotate(int direction)
    {
        transform.Rotate(Vector3.up, direction * rotateSpeed * Time.fixedDeltaTime);
    }
    public void Accelerate()
    {
        moveDirection += acceleration;
        if (moveDirection > maxMoveDirection)
            moveDirection = maxMoveDirection;
    }
    public void Break()
    {
        moveDirection -= breakForce;
        if (moveDirection < minMoveDirection)
            moveDirection = minMoveDirection;
    }
    public void DecreaseSpeed()
    {
        if (moveDirection > 0)
        {
            moveDirection = Mathf.Clamp(moveDirection - freeBreak, 0, maxMoveDirection);
        }
        if (moveDirection < 0)
        {
            moveDirection = Mathf.Clamp(moveDirection + freeBreak, minMoveDirection, 0);
        }
    }
}
