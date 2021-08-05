using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class arrowMove :NetworkBehaviour
{
  //Arrow movement code and collision detection

    public Rigidbody2D rbody;
    private Vector3 move;
    private Vector3 center = new Vector3(0, 0, 0);
    private Vector3 diff;
    public Rigidbody2D Player;
    // Start is called before the first frame update
    void Start()
    {



        rbody = GetComponent<Rigidbody2D>();
        Player = GetComponent<Rigidbody2D>();

            move = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            move = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 a = Player.position;



        diff = center - a;
        move = move + diff;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasAuthority)
        {
            Vector2 move2 = move;
            // print("mooove" + move);
            move2.Normalize();
            // print("rbodypos" + rbody.position.x);
            rbody.MovePosition(rbody.position + (move2 * 0.1f));
            float arrowAngle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            rbody.rotation = arrowAngle;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player(Clone)"))
            rbody.MovePosition(new Vector2(1000f,1000f));
            Destroy(gameObject,0.5f);
    }
}
