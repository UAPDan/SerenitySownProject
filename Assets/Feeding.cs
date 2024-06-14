using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Feeding : MonoBehaviour
{
    public GameManager gameManager;
    public bool touchingPlayer;
    public TMP_Text info;
    public Slider bar;
    public float timerMax = 2f;
    public IEnumerator Feed;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bar.gameObject.SetActive(false);
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
                    bar.gameObject.SetActive(true);
                    Feed = FeedingUpdate();
                    StartCoroutine(Feed);
                }
            }
            else if (gameManager.food <= 0)
            {
                info.text = "";
            }
        }
    }
    public IEnumerator FeedingUpdate()
    {
        yield return new WaitForSeconds(timerMax);
        info.text = "";
        bar.gameObject.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = true;
            gameManager.gameText.text = "Press F to feed";
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingPlayer = false;
            bar.gameObject.SetActive(false);
        }
    }
}
