using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HrvestingTRY : MonoBehaviour
{
    public TMP_Text info;
    public Slider bar;
    public IEnumerator collect;

    public float timer;
    public float timerMax = 2f;
    public GameManager gameManager;
    void Start()
    {
        bar.gameObject.SetActive(false);
        info.text = "";
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           gameManager.gameText.text = "Collecting";
            bar.gameObject.SetActive(true);
            collect = Collecting();
            StartCoroutine(collect);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
            bar.value += (timer / timerMax);
        }
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine(collect);
        info.text = "";
        bar.gameObject.SetActive(false);
        bar.value = 0;
    }

    public IEnumerator Collecting()
    {
        yield return new WaitForSeconds(timerMax);
        gameManager.food += 1;

        info.text = "";
        bar.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
