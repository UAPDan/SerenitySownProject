using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Feeding : MonoBehaviour
{
    public GameManager gameManager;
    public bool touchingPlayer;
    public TMP_Text info;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingPlayer == true)
        {
            if (gameManager.food > 0)
            {
                info.text = "Press F to feed";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    gameManager.food -= 1;
                }
            }
            else if (gameManager.food <= 0)
            {
                info.text = "";
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = false;
        }
    }
}
