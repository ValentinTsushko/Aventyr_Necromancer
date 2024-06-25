using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector3 velocity;
    
    private new Rigidbody rigidbody;

    [SerializeField] private float Speed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GroundMoveLeftRight(1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GroundMoveLeftRight(-1);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GroundMoveUpDown(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GroundMoveUpDown(-1);
        }
        else if (!Input.anyKey) { GroundStop(); }
    }

    public void GroundMoveLeftRight(float diraction)
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        velocity.x += (Speed * diraction);
        rigidbody.velocity = velocity;
    }
    public void GroundMoveUpDown(float diraction)
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        velocity.y += (Speed * diraction);
        rigidbody.velocity = velocity;
    }
    public void GroundStop() 
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        velocity = Vector3.zero;
        rigidbody.velocity = velocity;
    }
}
