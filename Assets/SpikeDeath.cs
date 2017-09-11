using UnityEngine;
using System.Collections;

public class SpikeDeath : MonoBehaviour {

    private Animator anim; // Reference to the player's animator component.
    BoxCollider2D Player;
    GameObject SpikeBody;

    // Use this for initialization
    void Start()
    {
        Player = GetComponent<BoxCollider2D>();
        SpikeBody = GameObject.FindWithTag("InstantDeath");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.IsTouching(SpikeBody.GetComponent<PolygonCollider2D>()))
        {
            anim.SetBool("IsCrushed", true);
        }
    }
}
