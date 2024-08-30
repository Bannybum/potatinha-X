using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Plataforma : MonoBehaviour
{

    public float TempodeQueda;

    private TargetJoint2D target;
    private BoxCollider2D bc;


    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            Invoke("Caindo", TempodeQueda);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Caindo()
    {
        target.enabled = false;
        bc.isTrigger = true;

    }
}
