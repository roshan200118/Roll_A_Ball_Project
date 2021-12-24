using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //If the object has the tag "StarPickUp"
        if (gameObject.CompareTag("StarPickUp"))
        {
            //Rotate the object 60 degrees along the y-axis with respect to time
            transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime);
        }

        //If the object has the tag "CoinPickUp" or "DiamondPickUp"
        if (gameObject.CompareTag("CoinPickUp") || gameObject.CompareTag("DiamondPickUp"))
        {
            //Rotate the object along the object's y-axis 
            //To rotate the current position by that relative amount, multiply the current rotation by that relative amount
            transform.rotation = Quaternion.AngleAxis(1, Vector3.up) * transform.rotation;
        }
    }
}
