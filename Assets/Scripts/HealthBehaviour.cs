using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


// defines condition to destroy player object based on arrow hits
public class HealthBehaviour : NetworkBehaviour
{

	Rigidbody2D rb;
	public Rigidbody2D Player;
	[SyncVar]
	public float charHealth = 1f;
	// charHealth = HealthController.healthValue;

	// Use this for initialization
	void Start () {

		Debug.Log(charHealth);
		Player = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
        if (charHealth <= 0)
        {
			Player.MovePosition(new Vector2(1000f,1000f));
            Destroy(gameObject,1);
        }
	}
		void OnTriggerEnter2D(Collider2D col)
		{
			if (col.gameObject.name.Equals ("arrow(Clone)"))
				charHealth -= 0.1f;
				Debug.Log("Player health: "+charHealth);
		}



}
