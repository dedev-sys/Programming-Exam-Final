using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    public GameObject ball;
    public GameObject follow;

    private float speed = 0;
    private Vector3 _moveDirection = new Vector3(1, 0, 0);
    private bool isGround;

    void Start()
    {
        InputManager.Init(this);
    }

    public void Press()
    {
        if (speed == 0) speed = 4;
        else
        {
            if (_moveDirection == new Vector3(1, 0, 0))
            {
                _moveDirection = new Vector3(0, 0, 1);
            }
            else
            {
                _moveDirection = new Vector3(1, 0, 0);
            }
        }
    }

    
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;
        isGround = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
        fall();
    }

    public void fall()
    {
        if (isGround == false)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            Destroy(follow);
        }
    }


}
