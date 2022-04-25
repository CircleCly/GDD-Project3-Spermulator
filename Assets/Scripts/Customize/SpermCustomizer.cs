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
        player.GetComponent<PlayerController>().SetColor(allColors[colorInd]);
    }

    public void NextScene(int sceneInd)
    {
        SceneManager.LoadScene(sceneInd);
    }
}
