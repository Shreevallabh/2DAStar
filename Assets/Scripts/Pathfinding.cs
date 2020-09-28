using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public GameObject source;
    public GameObject destination;
    public GameObject path;

    void Start()
    {
        List<Vector3> initialNeighbours = Controller.GetNeightbours(source.transform.position, false);

        Controller.frontierLocations.AddRange(initialNeighbours);

        // Adding known locations to checked list which can never be destination e.g. location of source or walls
        Controller.checkedLocations.Add(source.transform.position);
        Controller.checkedLocations.Add(destination.transform.position);

        while (Controller.frontierLocations.Count > 0)
        {

            // Did we reach destination?
            if(Controller.frontierLocations[0] == destination.transform.position)
            {
                Debug.Log("Reached destination");
                Debug.Log("frontierLocations list" + Controller.frontierLocations);
                Debug.Log("checkedLocations list" + Controller.checkedLocations);
                for( int i = 0; i < Controller.checkedLocations.Count; i++)
                {
                    Instantiate(path, Controller.checkedLocations[i], Quaternion.identity);
                }
                for (int i = 0; i < Controller.frontierLocations.Count; i++)
                {
                    Instantiate(source, Controller.frontierLocations[i], Quaternion.identity);
                }
                break;
            }


            // Have we checked current frontier location already?
            if(Controller.checkedLocations.Contains(Controller.frontierLocations[0]))
            {
                Controller.frontierLocations.RemoveAt(0);
            }
            // if not, then add to checked list
            else
            {
                Controller.checkedLocations.Add(Controller.frontierLocations[0]);
                Controller.frontierLocations.AddRange(Controller.GetNeightbours(Controller.frontierLocations[0], true));
                Controller.frontierLocations.RemoveAt(0);
            }
        }
    }


    void Update()
    {
        //transform.Translate(-Vector3.left * Time.deltaTime);

    }
}
