using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{

    public GameObject player;
    public GameObject[] platformTypes;
    
    Vector3 lastPlatformPos;

    public GameObject current;
    public GameObject prev;
    
    
    [Range(10, 100)]
    public float minDistance = 10;
    [Range(10, 100)]
    public float maxDistance = 40;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > prev.transform.position.z){
            Debug.Log("Next");
            GenNextPlatform();
        }
    }

    void GenNextPlatform(){
        GameObject next = Instantiate(platformTypes[Random.Range(0,3)], transform);


        next.transform.position = current.transform.localPosition + new Vector3(0,0,Random.Range(minDistance, maxDistance));
        prev = current;
        current = next;
    }
}
