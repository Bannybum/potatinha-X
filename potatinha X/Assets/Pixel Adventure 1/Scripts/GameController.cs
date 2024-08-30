using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int ScoreTotal;
    public Text ScoreTXT;

    public GameObject gameOver;

    public static GameController instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreTXT()
    {
        ScoreTXT.text = ScoreTotal.ToString();
    }

    public void MostraGameOver()
    {
        gameOver.SetActive(true);
    }

    public void Reiniciar(string lvlNome)
    {
        SceneManager.LoadScene(lvlNome);
    }
}
