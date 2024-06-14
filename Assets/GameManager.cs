using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text foodText;
    public TMP_Text gameText;
    public float food;

    // Start is called before the first frame update
    void Start()
    {
        foodText = GameObject.Find("foodText").GetComponent<TMP_Text>();
        gameText = GameObject.Find("gameText").GetComponent<TMP_Text>();

        gameText.text = "";

        food = 0;

    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = "Food: " + food;

        if (food >= 3)
        {
            gameText.text = "You can feed the animals!";
        }
    }
}
