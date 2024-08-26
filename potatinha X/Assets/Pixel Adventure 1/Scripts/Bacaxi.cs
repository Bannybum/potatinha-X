using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacaxi : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D cc;

    public GameObject Explode;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
    } 

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cc.enabled = false;
            Explode.SetActive(true);

            Destroy(gameObject, 0.3f);
        }
    }
}
