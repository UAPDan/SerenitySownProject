using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Harvesting : MonoBehaviour
{
    public TMP_Text collecting;
    public Slider bar;
    public IEnumerator collect;
    public float timer;
    public float timerMax = 2f;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        bar.gameObject.SetActive(false);
        collecting.text = "";

    }

    // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                collecting.text = "Collecting";
                bar.gameObject.SetActive(true);
                collect = Collecting();
                StartCoroutine(collect);
            }
        }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // This is where you make your text object appear on screen
            collecting.enabled = true; // May need to use .SetActive(true);

        }

    }
    public IEnumerator Collecting()
    {
        yield return new WaitForSeconds(timerMax);

        DestroyImmediate(cube,true);
    }



}
