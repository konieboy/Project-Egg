using UnityEngine;
using System.Collections;

public class MovingPlatformStick : MonoBehaviour {

    private BoxCollider2D Player;
    private GameObject[] MovingPlatforms;

    // Use this for initialization
    void Start () {

        Player = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        MovingPlatforms = GameObject.FindGameObjectsWithTag("MovingPlatform1");

    }

    // Update is called once per frame
    void Update () {

        foreach (var Platform in MovingPlatforms)
        {
            if (Player.IsTouching(Platform.GetComponent<EdgeCollider2D>()))
            {
                this.transform.SetParent(Platform.transform);
                break;
            }
            else
            {
                this.transform.SetParent(null);
            }
        }
    }
}
