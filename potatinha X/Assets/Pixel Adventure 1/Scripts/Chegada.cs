using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string lvlNome;

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvlNome);
        }
    }
}
