using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPlayer : MonoBehaviour
{
    
    private Rigidbody rb;

    public float moveForce = 400f;
    public float jumpForce = 400f;
    public float groundCheckDistance = 0.3f;
    private bool isGrounded = false;
    private bool gameOver = true;

    public Text stepsCount;
    public int steps = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {

            if(Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.down, groundCheckDistance))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            //Keys Inputs
            if(isGrounded)
            {
                if(Input.GetKeyDown(KeyCode.A))
                {
                    AdjustPositionAndRotation(new Vector3(0, 0, 0));
                    rb.AddForce(new Vector3(0, moveForce, moveForce));
                    steps++;
                }
                else if(Input.GetKeyDown(KeyCode.D))
                {
                    AdjustPositionAndRotation(new Vector3(0, 180, 0));
                    rb.AddForce(new Vector3(0, moveForce, -moveForce));
                    steps++;
                }
                else if(Input.GetKeyDown(KeyCode.S))
                {
                    AdjustPositionAndRotation(new Vector3(0, -90, 0));
                    rb.AddForce(new Vector3(-moveForce, moveForce, 0));
                    steps++;
                }
                else if(Input.GetKeyDown(KeyCode.W))
                {
                    AdjustPositionAndRotation(new Vector3(0, 90, 0));
                    rb.AddForce(new Vector3(moveForce, moveForce, 0));
                    steps++;
                }
            }

            stepsCount.text = steps.ToString();

         }
        else 
        {
            Destroy(gameObject);
        }
        


    }

    //GameOver Set to False
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "GameOver")
        {
            gameOver = false;
        }
    }


    //Movimento
    void AdjustPositionAndRotation(Vector3 newRotation)
    {
        if(gameOver)
        {
            rb.velocity = Vector3.zero;
        
        transform.eulerAngles = newRotation;
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        }
        
    }
    
    
}
