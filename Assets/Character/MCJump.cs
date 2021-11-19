using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCJump: MonoBehaviour
{
    public float FuerzaSalto; 
    public float speed;
    Animator anim;
    Rigidbody2D rb;
    public bool enPiso;
    public Transform refPie;
    float weight = 0;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        //Esta parte sirve para la animación del salto!

        if (Input.GetButtonDown("Jump")) anim.SetTrigger("Jump");
        anim.SetBool("enPiso", enPiso);
        
        //Esta parte le añade peso al personaje

        if (Input.GetKeyDown(KeyCode.Z))
        {
            weight += 1;
            rb.mass = weight;
            
        }

        //Esta parte hace la variable enPiso verdadera cuando el personaje toque el piso

        enPiso = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 6);

        if (Input.GetButtonDown("Jump") && enPiso)
        {
            rb.AddForce(new Vector2(0, FuerzaSalto), ForceMode2D.Impulse);
            
        }
    }

    
}
