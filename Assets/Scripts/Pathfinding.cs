using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(destination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(-Vector3.left * Time.deltaTime);
    }
}
