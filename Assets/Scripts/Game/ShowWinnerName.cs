using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWinnerName : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = GameManager.Instance.winnerName + " has won the game!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
