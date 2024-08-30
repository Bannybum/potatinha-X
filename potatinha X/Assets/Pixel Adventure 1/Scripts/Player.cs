using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Velocidade;
    public float JumpForce;

    public bool taPulando;
    public bool puloDuplo;

    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Velocidade;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("Andando", false);
        }

    }
   
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!taPulando)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                puloDuplo = true;
                anim.SetBool("Pulo", true);
            }
            else
            {
                if (puloDuplo)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    puloDuplo = false;
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.layer == 8)
        {
            taPulando = false;
            anim.SetBool("Pulo", false);
        }

        if (colisao.gameObject.tag == "Espinho")
        {
            GameController.instance.MostraGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.layer == 8)
        {
            taPulando = true;
        }
    }
}
