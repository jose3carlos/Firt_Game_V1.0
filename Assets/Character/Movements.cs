using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    Rigidbody2D rb;
    float MovX;
    public float MovementSpeed;
    public Quaternion startQuaternion;
    public float lerptime = 1;
    public bool rotate;
    public Jump_mechanic script;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startQuaternion = transform.rotation;
        script = FindObjectOfType<Jump_mechanic>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //This thing enables horizontal movement!

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Horizontal")) anim.SetTrigger("Walking");

        if (movement > 0)
        {
            bool walking = true;

            anim.SetBool("walking", walking);
        }       

            
                
        


        //This part rotates the character when pressing R!

        if (rotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startQuaternion, Time.deltaTime * lerptime);
        }

        if (Input.GetKeyDown(KeyCode.R)) rotate = true;
        if (Input.GetKeyUp(KeyCode.R)) rotate = false;










        //Esta parte permite girar el personaje a la izquierda o derecha!

        MovX = Input.GetAxis("Horizontal");

        if (MovX < 0 && script.enPiso) transform.localScale = new Vector3(-3.97f, 2.84f, 0);
        if (MovX > 0 && script.enPiso) transform.localScale = new Vector3( 3.97f, 2.84f, 0);

    }
}
