using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoinPickup : MonoBehaviour
{
    //Creating a variable to reference the coin pickup
    public GameObject coinPickUp = null;

    // Start is called before the first frame update
    void Start()
    {
        //Create two GameObjects using the coin pick up prefab and initalize with the coordinates and rotation
        Instantiate(coinPickUp, new Vector3(0f, 0.6f, 7f), Quaternion.Euler(new Vector3(0f, 45f, 90f)));
        Instantiate(coinPickUp, new Vector3(0f, 0.6f, -7f), Quaternion.Euler(new Vector3(0f, 45f, 90f)));
    }
}
