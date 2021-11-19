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
    public MCJump script;
    Animator anim;
    bool Walks;
    bool yes = true;
    bool no = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startQuaternion = transform.rotation;
        script = FindObjectOfType<MCJump>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //This thing enables horizontal movement!

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        //This part makes the condition for the horizontal movement animation

        if (Input.GetKey(KeyCode.A))
        {
            Walks = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Walks = true;
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            Walks = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            Walks = false;
        }

        if (Walks == true)
        {
            anim.SetBool("Walking", yes);
        }
        else if (Walks == false)
        {
            anim.SetBool("Walking", no);
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

        if (MovX < 0 ) transform.localScale = new Vector3(-0.40285f, 0.35225f, 0);
        if (MovX > 0 ) transform.localScale = new Vector3(0.40285f, 0.35225f, 0);

    }
}
