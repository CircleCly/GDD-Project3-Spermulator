using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpermCustomizer : MonoBehaviour
{
    [SerializeField] Color[] allColors;
    public GameObject player;

    public void SetColor(int colorInd)
    {
        Color c = allColors[colorInd];
        PlayerPrefs.SetFloat("playerR", c.r);
        PlayerPrefs.SetFloat("playerG", c.g);
        PlayerPrefs.SetFloat("playerB", c.b);
    }
}
