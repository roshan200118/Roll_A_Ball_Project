using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Creating a variable to reference the player
    public GameObject player;

    //Creating a variable to store the offset value
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Initalizing offset as the distance between the camera and player 
        offset = transform.position - player.transform.position;
    }

    //LateUpdate runs after all code runs in update
    void LateUpdate()
    {
        //The camera's position is the player's position plus the inital offset value
        //This way the camera will remain in the same angle but just translate along with the ball
        transform.position = player.transform.position + offset;
    }
}
