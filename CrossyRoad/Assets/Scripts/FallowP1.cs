using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowP1 : MonoBehaviour
{
    public Transform target;
    public Transform child;
    public Camera cameraComponent;
    public float mouseSens;
    public float horizontalRotationValue;
    public float verticalRotationValue;
    public float distanceOfTarget;
    public float heightOfCamera;
    public LayerMask cameraColisionDetection;
    

         // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            horizontalRotationValue += Input.GetAxis("Mouse X") * mouseSens;
        verticalRotationValue -= Input.GetAxis("Mouse Y") * mouseSens;
        transform.position = target.position;
        transform.rotation = Quaternion.Euler(verticalRotationValue, horizontalRotationValue, 0);
        child.transform.localPosition = new Vector3(0, heightOfCamera, -distanceOfTarget);
        RaycastHit hit;
        verticalRotationValue = Mathf.Clamp(verticalRotationValue, -40, 50);
        if(Physics.Linecast(transform.position, child.transform.position, out hit, cameraColisionDetection))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            cameraComponent.transform.position = hit.point;
        }
        else
        {
            Debug.DrawLine(transform.position, child.transform.position, Color.green);
            cameraComponent.transform.localPosition = new Vector3(0, 0, 0);
        }
        }
        
    }
    
   
}
