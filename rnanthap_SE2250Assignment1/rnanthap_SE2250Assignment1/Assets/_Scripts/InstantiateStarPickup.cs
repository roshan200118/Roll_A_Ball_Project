using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStarPickup : MonoBehaviour
{
    //Creating a variable to reference the star pickup
    public GameObject starPickUp = null;

    // Start is called before the first frame update
    void Start()
    {
        //Create four GameObjects using the diamond pick up prefab and initalize with the coordinates
        //Using Quaternion.identity which means that there is no adjusted rotation needed
        Instantiate(starPickUp, new Vector3(-5f, 1f, 5f), Quaternion.identity);
        Instantiate(starPickUp, new Vector3(-5f, 1f, 0f), Quaternion.identity);
        Instantiate(starPickUp, new Vector3(-5f, 1f, -5f), Quaternion.identity);
        Instantiate(starPickUp, new Vector3(5f, 1f, 5f), Quaternion.identity);
        Instantiate(starPickUp, new Vector3(5f, 1f, 0f), Quaternion.identity);
        Instantiate(starPickUp, new Vector3(5f, 1f, -5f), Quaternion.identity);
    }
}
