using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMovingObjects : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "GameOver" || collision.gameObject.tag == "MovingObjects")
        {
            Destroy(collision.gameObject);
        }
    }
}
