using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public static List<Vector3> frontierLocations = new List<Vector3>();
    public static List<Vector3> checkedLocations = new List<Vector3>();

    public static List<Vector3> GetNeightbours(Vector3 loc, bool getNonFrontOnly)
    {
        Vector3 top = new Vector3(loc.x, loc.y - 1, 0);
        Vector3 topRight = new Vector3(loc.x + 1, loc.y - 1, 0);
        Vector3 right = new Vector3(loc.x + 1, loc.y, 0);
        Vector3 bottomRight = new Vector3(loc.x + 1, loc.y + 1, 0);
        Vector3 bottom = new Vector3(loc.x, loc.y + 1, 0);
        Vector3 bottomLeft = new Vector3(loc.x - 1, loc.y + 1, 0);
        Vector3 left = new Vector3(loc.x - 1, loc.y, 0);
        Vector3 topLeft = new Vector3(loc.x - 1, loc.y - 1, 0);

        //Debug.Log(top);
        //Debug.Log(topRight);
        //Debug.Log(right);
        //Debug.Log(bottomRight);
        //Debug.Log(bottom);
        //Debug.Log(bottomLeft);
        //Debug.Log(left);
        //Debug.Log(topLeft);

        List<Vector3> neighbours = new List<Vector3>();
        neighbours.Add(top);
        neighbours.Add(topRight);
        neighbours.Add(right);
        neighbours.Add(bottomRight);
        neighbours.Add(bottom);
        neighbours.Add(bottomLeft);
        neighbours.Add(left);
        neighbours.Add(topLeft);

        if(getNonFrontOnly)
        {
            int temp = 0;
            for( int i = 0; i < 8; i++)
            {
                if(frontierLocations.Contains(neighbours[temp]))
                {
                    Debug.Log("Found duplicate");
                    neighbours.RemoveAt(0);
                }
                else
                {
                    temp++;
                }
            }
        }

        return neighbours;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}
