using UnityEngine;
using System.Collections;   
using System.Collections.Generic;
public class Move : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velPersonaje;
    public Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        heroMov();
    }

    void heroMov()
    {
        float h = Input.GetAxis("Horizontal");

        // Movimiento físico
        rb2d.linearVelocity = new Vector2(h * velPersonaje, rb2d.linearVelocity.y);

        // Giro del personaje (Solo si hay movimiento)
        if (h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (h < 0) // Agregamos "else if" para que no gire si h es 0
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // Animación (Usamos Mathf.Abs para detectar movimiento en ambas direcciones)
        if (Mathf.Abs(h) > 0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
