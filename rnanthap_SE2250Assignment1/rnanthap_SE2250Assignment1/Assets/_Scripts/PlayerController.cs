using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Creating a variable to reference the player's rigid body component
    private Rigidbody rigidBody;

    //Creating a variable to store the player's last velocity
    private Vector3 lastVelocity;

    //public float speed;

    //Creating a variable to keep track of the score
    private int score;

    //Creating a variable to reference the ScoreLabel
    public Text scoreText;

    //Creating a variable to reference the RestartLabel
    public Text restartText;

    //Creating a variable to reference the PickUp audio
    private AudioSource pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning the player's rigid body component
        rigidBody = GetComponent<Rigidbody>();

        //Assigning the player's audio source component
        pickUpSound = GetComponent<AudioSource>();

        //Initalize the score as 0
        score = 0;

        //Update the score text
        UpdateScoreText();

        //The restart text is empty
        restartText.text = "";

        //Initalize the player at the center of the box
        transform.position = new Vector3(0f, 0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //If the user hits the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //The application will close
            Application.Quit();
        }

        //The last velocity is the current velocity
        lastVelocity = rigidBody.velocity;
    }

    //FixedUpdate - Called before doing any physics calculations 
    private void FixedUpdate()
    {
        //Gets input from the player through the keyboard
        //The float variables get the input from the axises which is controlled through the keyboard
        float moveHorozontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Creating a variable to store the player's movement
        Vector3 movement = new Vector3(moveHorozontal, 0.0f, moveVertical);

        //Adds force to in the direction of the movement with a factor of 10
        rigidBody.AddForce(movement * 10f);
    }

    //Called when a GameObject collides with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        //If the GameObject has the tag "StarPickUp"
        if (other.gameObject.CompareTag("StarPickUp"))
        {
            //Play the pickup audio
            pickUpSound.Play();

            //Deactive the GameObject
            other.gameObject.SetActive(false);

            //Increase the score by 1 point
            score++;

            //Update the score label
            UpdateScoreText();
        }

        //If the GameObject has the tag "StarPickUpOverLapShape" (child of the StarPickUp GameObject)
        else if (other.gameObject.CompareTag("StarPickUpOverLapShape"))
        {
            //Play the pickup audio
            pickUpSound.Play();

            //Deactive the GameObject
            other.gameObject.SetActive(false);

            //Deactive the parent of the GameObject
            other.transform.parent.gameObject.SetActive(false);

            //Increase the score by 1 point
            score++;

            //Update the score label
            UpdateScoreText();
        }

        //If the GameObject has the tag "CoinPickUp"
        else if (other.gameObject.CompareTag("CoinPickUp"))
        {
            //Play the pickup audio
            pickUpSound.Play();

            //Deactive the GameObject
            other.gameObject.SetActive(false);

            //Increase the score by 3 points
            score += 3;

            //Update the score label
            UpdateScoreText();
        }

        //If the GameObject has the tag "DiamondPickUp"
        else if (other.gameObject.CompareTag("DiamondPickUp"))
        {
            //Play the pickup audio
            pickUpSound.Play();

            //Deactive the GameObject
            other.gameObject.SetActive(false);

            //Increase the score by 2 points
            score += 2;

            //Update the score label
            UpdateScoreText();
        }
    }

    //Method to update the score label
    public void UpdateScoreText()
    {
        //Displays the score
        scoreText.text = "Score: " + score.ToString();

        //If the score equals 20 (maximum score)
        if (score == 20)
        {
            //The restart label informs the user that the game is restarting
            restartText.text = "RESTARTING...";

            //Pauses game until Restart() yield time is over 
            StartCoroutine(Restart());
        }
    }

    //Creating a method to restart the application
    IEnumerator Restart()
    {
        //Freeze the game (freezes game time)
        Time.timeScale = 0;

        //Wait for 3 seconds in real time
        yield return new WaitForSecondsRealtime(3f);

        //Set the game time back to normal
        Time.timeScale = 1;

        //Reload the scene (restarts the game to initial state)
        SceneManager.LoadScene("SampleScene");
    }

    //This method is called when the player's rigidbody contacts another rigidbody
    private void OnCollisionEnter(Collision collision)
    {
        //Creating a variable to store the magnitude of the velocity from the last frame
        var speed = lastVelocity.magnitude;

        //Creating a variable to store the direction of the reflected angle (bounce angle)
        //Reflect - reflects a vector off the plane and uses the current direction and normal
        //normalized - returns the vector of magnitude of 1
        //collision.contacts[0].normal - creates a new array and populates it with contacts, get the first point and get the normal of that point
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        //The current velocity of the player is the speed from last frame but with a relfected angle
        rigidBody.velocity = direction * speed;
    }
}
