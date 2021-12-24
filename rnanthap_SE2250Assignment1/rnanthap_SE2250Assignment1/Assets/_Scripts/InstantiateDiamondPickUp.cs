using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDiamondPickUp : MonoBehaviour
{
    //Creating a variable to reference the diamond pickup
    public GameObject diamondPickUp = null;

    // Start is called before the first frame update
    void Start()
    {
        //Create four GameObjects using the diamond pick up prefab and initalize with the coordinates and rotation
        Instantiate(diamondPickUp, new Vector3(8f, 1, 8f), Quaternion.Euler(new Vector3(0f, 0f, 45f)));
        Instantiate(diamondPickUp, new Vector3(-8f, 1, 8f), Quaternion.Euler(new Vector3(0f, 0f, 45f)));
        Instantiate(diamondPickUp, new Vector3(-8f, 1, -8f), Quaternion.Euler(new Vector3(0f, 0f, 45f)));
        Instantiate(diamondPickUp, new Vector3(8f, 1, -8f), Quaternion.Euler(new Vector3(0f, 0f, 45f)));

    }
}
