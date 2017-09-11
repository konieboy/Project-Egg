using UnityEngine;
using System.Collections;



public class BoxPhysics : MonoBehaviour {

    Collider2D BoxBody;

    GameObject Player;
    GameObject Ground;
    // Use this for initialization
    void Start ()
    {
        BoxBody = GetComponent<Collider2D>();
        Player = GameObject.FindWithTag("Player");
        Ground = GameObject.FindWithTag("Ground");
    }

    // Update is called once per frame
    void Update ()
    {
        /*
        if (BoxBody.IsTouching(Player.GetComponent<BoxCollider2D>()) && !BoxBody.IsTouching(Ground.GetComponent<BoxCollider2D>()))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
        */

        // If touching ground, allow movment in x and change mass
        if (BoxBody.IsTouching(Ground.GetComponent<BoxCollider2D>()))
        {
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            //GetComponent<Rigidbody2D>().useAutoMass = true;
            Debug.Log("On Ground");


        }
        else
        {
            //GetComponent<Rigidbody2D>().isKinematic = false;
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().velocity.Set(GetComponent<Rigidbody2D>().velocity.x, 0);
        Debug.Log("In trigger");
    }
}
