using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed = 4.0f;
    public int plants; // How many plants the player has
    public bool touchingPlant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
        transform.Translate(moveDirection * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.C))
        {
            plants += 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plant")
        {
            touchingPlant = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Plant")
        {
            touchingPlant = false;
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            if (plants > 0)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    plants -= 1;
                }
            }
        }
    }*/
}
