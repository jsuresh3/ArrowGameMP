using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Arrow : NetworkBehaviour
{

    //Configurign arrow creation
    public float arrowspeed = 0.1f;
    public GameObject arrowObject;
    public Transform Player;
    public Transform arrowTransform;
    public Rigidbody2D rbody;
    private Vector3 move;
    private Vector3 center = new Vector3(0, 0, 0);
    private Vector3 diff;
    Vector3 arrowOffset;



    private bool aCreate = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        if (isLocalPlayer == true)
        {
           // CmdMove(); deprecated
            if (Input.GetButtonDown("Fire1"))

            {
                aCreate = true;

                move = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 a = Player.position;

                // print("hey " + Player.position);
                // print("hey 2 " + a);


                diff = center - a;
                move = move + diff;

                if (move.x < 1 && move.x > -1.5)
                {
                    if (move.y < 0)
                    {
                        CmdArrowDown();
                    }
                    else
                    {
                        CmdArrowUp();
                    }

                }

                else if (move.x > 0)
                {
                    CmdArrowPositive();
                }
                else
                {
                    CmdArrowNegative();
                }


                // CmdArrow();
                // print(" m" + move);
            }
        }

    }


        //Commands for server to spawn arrow based on offset

    [Command]
    void CmdArrowPositive()
    {
        arrowOffset = new Vector3(1f, 0f, 0f);
        GameObject arrow = Instantiate(arrowObject, Player.position + arrowOffset, Player.rotation);
        //rbody = arrow.GetComponent<Rigidbody2D>();
        NetworkServer.SpawnWithClientAuthority(arrow, connectionToClient);


        //move =Player.position;

    }
    [Command]
    void CmdArrowNegative()
    {
        arrowOffset = new Vector3(-1.5f, 0f, 0f);
        GameObject arrow = Instantiate(arrowObject, Player.position + arrowOffset, Player.rotation);
        //rbody = arrow.GetComponent<Rigidbody2D>();
        NetworkServer.SpawnWithClientAuthority(arrow, connectionToClient);


        //move =Player.position;

    }
    [Command]
    void CmdArrowDown()
    {
        arrowOffset = new Vector3(0f, -1.5f, 0f);
        GameObject arrow = Instantiate(arrowObject, Player.position + arrowOffset, Player.rotation);
        //rbody = arrow.GetComponent<Rigidbody2D>();
        NetworkServer.SpawnWithClientAuthority(arrow, connectionToClient);


        //move =Player.position;

    }

    [Command]
    void CmdArrowUp()
    {
        arrowOffset = new Vector3(0f, 1f, 0f);
        GameObject arrow = Instantiate(arrowObject, Player.position + arrowOffset, Player.rotation);
        //rbody = arrow.GetComponent<Rigidbody2D>();
        NetworkServer.SpawnWithClientAuthority(arrow, connectionToClient);


        //move =Player.position;

    }
        //move =Player.position;

}
    /*
    void CmdMove()
    {
        print("move start");
        if (aCreate==false)
        { return; }

        print("move stop");

        Vector2 move2 = move;
        print("mooove"+move);
            move2.Normalize();
            print("rbodypos"+rbody.position.x);
            if ( Mathf.Abs(rbody.position.x)<20)

                if ((Mathf.Abs(rbody.position.y) < 20))
                {
                    rbody.MovePosition(rbody.position + (move2 * arrowspeed));
                }
        }

    */
