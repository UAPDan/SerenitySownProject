using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text yourText; // Insert your text object inside unity inspector
    public Slider bar;
    public TMP_Text info;
    public GameObject Flower; // This cube has the tag of plant
    public IEnumerator plant;
    public float timer;
    public float timerMax = 4f;
    public bool playerInRange;
    public GameObject playerObject;
    public GameManager gameManager;

    void Start()
    {
        yourText.enabled = false; // You may need to use .SetActive(false);
        bar.gameObject.SetActive(false);
        playerObject = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.gameText.text = "Planting";
            bar.gameObject.SetActive(true);
            plant = Planting();
            StartCoroutine(plant);
        }
        /*if (playerInRange == true)
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (gameObject.tag == "Animal")
                {
                    if (playerObject.GetComponent<PlayerMovement>().plants > 0)
                    {
                        playerObject.GetComponent<PlayerMovement>().plants -= 1;

                    }
                }
            }

        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // This is where you make your text object appear on screen
            gameManager.gameText.text = ("Press P to Plant");
            playerInRange = true;

        }

    }

    void OnCollisionExit(Collision collision)
    {
        // Here is where you make the text disappear off screen
        if (collision.gameObject.tag == "Player")
        {
            //yourText.enabled = false; // May need to use .SetActive(false);
            playerInRange = false;
        }
    }

    public IEnumerator Planting()
    {
        yield return new WaitForSeconds(timerMax);
        Instantiate(Flower);
        info.text = "";
        bar.gameObject.SetActive(false);

    }





}
