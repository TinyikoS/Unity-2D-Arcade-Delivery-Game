using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    //declare variables
    //serialise adds it into the inspector
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float currentSpeed = 5f;

    //Boosts and bumps
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float normalSpeed = 5f;

    //creating a reference to the UI text
    [SerializeField] TMP_Text boostText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //plays once when run is clicked
    {
        boostText.gameObject.SetActive(false);
    }

    //boost
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            //enables view of UI text
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    //bump
    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = normalSpeed;
        boostText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float steer = 0f; //right, left
        float move = 0f; //up,down
        
        if(Keyboard.current.upArrowKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            steer = -1f;
        }
        //time.deltatime makes it framerate independent
        float steerAmount = steer*steerSpeed*Time.deltaTime; 
        float moveAmount =  move*currentSpeed*Time.deltaTime;
        //accesses transform property from sprite that its linked to
        //(x, y, z)
        transform.Rotate(0, 0, steerAmount); //f is used to covert to float number
        transform.Translate(0, moveAmount, 0);
    }
}
