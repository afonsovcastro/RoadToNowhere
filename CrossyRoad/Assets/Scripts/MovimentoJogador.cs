using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    //Variaveis
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    //Referencias
    private CharacterController controller;

    private void Start ()
    {
        controller = GetComponent<CharacterController>();

    }
    //Update por frame
    private void Update()
    {
        Move();
    }


    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
                velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        if(isGrounded)
        {
           
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

        }
        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else if(moveDirection == Vector3.zero)
        {
            Idle();
        }

        moveDirection *= moveSpeed;    
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<MObjectsD>() != null)
        {
            if(collision.collider.GetComponent<MObjectsD>().islog)
            {
                transform.parent = collision.collider.transform;
            }
            else
            {
                transform.parent = null;
            }
        }
    }*/


    private void Idle()
    {  
        //b
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
