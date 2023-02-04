/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objects;
    public Transform pos;
    public float minTime, maxTime;

    void Start()
    {
        SpawnMovingObjects();
    }

    void SpawnMovingObjects()
    {
        //Instantiate(objects, new Vector3(-115, 0, -231), Quaternion.identity);
        Instantiate(objects, pos.position, Quaternion.identity);
        
        

        Invoke("SpawnMovingObjects", Random.Range(minTime, maxTime));
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn : MonoBehaviour{

    [SerializeField] private GameObject vehicle;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSepTime;
    [SerializeField] private float maxSepTime;

    private void Start()
    {
        StartCoroutine(SpawnVehicle());
    }
    private IEnumerator SpawnVehicle()
    {
        while(true)
        {
            yield return new WaitForSeconds (Random.Range(minSepTime, maxSepTime));
            Instantiate(vehicle, spawnPos.position, spawnPos.rotation);
        }
    }
}
