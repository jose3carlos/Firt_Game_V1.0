using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVuela : MonoBehaviour
{
    public float velocidad;
    public float velocidadDeReversa;
    public float distanciaDelJugador;
    public float rangoDeVision;
    public float rangoDeReversa;
    public float rangoDeDisparo;
    public Transform player;
    public Rigidbody2D rb2D;
    public Animator anim;
    public bool mirandoALaDerecha;
    public bool movimiento;
    public Transform Sphere_Collider;
    public float Collider_Radius;
    
  

    

    void Start()
    {
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        //Esta parte se encarga de hacer que cuando el MC se acerque al fantasma éste cambie de animación!

        movimiento = Physics2D.OverlapCircle(Sphere_Collider.position, Collider_Radius, 1 << 0);
        if (movimiento == true)
        {
            anim.SetBool("Moving", true);
        }
        else anim.SetBool("Moving", false);

        //Esta parte es el AI del fantasma que hace que cuando el MC se acerque el fantasma se mueva hacía el!
        MirandoAlplayer();

        distanciaDelJugador = Vector2.Distance(player.position, rb2D.position);
        if (distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReversa && distanciaDelJugador > rangoDeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, velocidad * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
        else if (distanciaDelJugador < rangoDeVision && distanciaDelJugador > rangoDeReversa && distanciaDelJugador <= rangoDeDisparo)
        {
            {
                Vector2 objetivo = new Vector2(player.position.x, player.position.y);
                Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, 0 * Time.deltaTime);
                rb2D.MovePosition(nuevaPos);
            }
        }
        else if (distanciaDelJugador < rangoDeReversa)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, velocidadDeReversa * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }

        

        

    }
    //Esta parte verifica si el fantasma esta viendo al jugador para ver si gira o no!
    public void MirandoAlplayer()
    {
        Vector3 girado = transform.localScale;
        if (distanciaDelJugador< rangoDeVision)
        {
            if (transform.position.x < player.position.x && !mirandoALaDerecha)
            {
                Girar();
                mirandoALaDerecha = true;
            }
            else if (transform.position.x > player.position.x && mirandoALaDerecha)
            {
                Girar();
                mirandoALaDerecha = false;
            }
        }
    }

    //Esto gira el fantasma para que voltee de Izquierda a Derecha.
    public void Girar()
    {
        transform.Rotate(0, 180, 0);
    }

    //Esta parte dibuja los rings que se asignan a las variables de movimiento.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeVision);
        Gizmos.DrawWireSphere(transform.position, rangoDeDisparo);
        Gizmos.DrawWireSphere(transform.position, rangoDeReversa);
    }
    
}
