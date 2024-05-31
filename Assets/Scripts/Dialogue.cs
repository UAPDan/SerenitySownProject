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
    public GameObject Cube;
    public IEnumerator plant;
    public float timer;
    public float timerMax = 2f;
    bool spawning;
    float plantAtTime;
    void Start()
    {
        yourText.enabled = false; // You may need to use .SetActive(false);
        bar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            info.text = "Planting";
            bar.gameObject.SetActive(true);
            plant = Planting();
            StartCoroutine(plant);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // This is where you make your text object appear on screen
            yourText.enabled = true; // May need to use .SetActive(true);

        }

    }

    void OnCollisionExit(Collision collision)
    {
        // Here is where you make the text disappear off screen
        if (collision.gameObject.tag == "Player")
        {
            yourText.enabled = false; // May need to use .SetActive(false);
            
        }
    }

    public IEnumerator Planting()
    {
        yield return new WaitForSeconds(timerMax);
        Instantiate(Cube);
        info.text = "";
        bar.gameObject.SetActive(false);

    }





}
