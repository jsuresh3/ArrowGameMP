using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

//Code for Player PlayMovement
public class PlayMovement : NetworkBehaviour
{
    // Start is called before the first frame update
      Vector3 flip;
      public float speed = 5f;
      public Rigidbody2D rb;
      Vector2 move;



    // Update is called once per frame
    void FixedUpdate()
    {

            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
        if (isLocalPlayer == true)
        {
            this.rb.MovePosition(rb.position + (move * speed));

            flip = transform.localScale;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                flip.x = Math.Abs(flip.x);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                flip.x = (Math.Abs(flip.x) * -1);
            }
            transform.localScale = flip;
        }
    }
}
