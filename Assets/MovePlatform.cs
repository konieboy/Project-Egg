using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {


    public Sprite OffSwitchSprite; // Drag your first sprite here
    public Sprite OnSwitchSprite; // Drag your second sprite here
    public Sprite OffPlatformSprite;
    public Sprite OnPlatformSprite;
    public GameObject Platform;

    public float delta = 5f; // Amount to move up and down from the start point
    public float speed = 0.01f; // Speed of the movement
    private bool TurnedOn = true;
    private GameObject Crusher;
    private PolygonCollider2D SwitchBoxCol;
    private Vector3 CrusherStartPos;
    private float Ticker;
    private BoxCollider2D Player;
    private GameObject[] Triggers;
    private SpriteRenderer SwitchSprite;

    // Use this for initialization
    void Start()
    {
        Crusher = GameObject.FindGameObjectWithTag("MovingPlatform1");
        SwitchBoxCol = GetComponent<PolygonCollider2D>();
        CrusherStartPos = Crusher.transform.position;
        Ticker = 0.0f;
        Player = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        Triggers = GameObject.FindGameObjectsWithTag("SwitchTrigger");
        SwitchSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //Check if switch is pressed
        TurnedOn = ColCheck();

        if (TurnedOn)
        {

            Vector3 v = CrusherStartPos;
            v.x += delta * Mathf.Sin(Ticker * speed);
            Crusher.transform.position = v;
            Ticker++;

            // Turn On
            SwitchSprite.sprite = OnSwitchSprite;
            Platform.GetComponent<SpriteRenderer>().sprite = OnPlatformSprite;
        }
        else
        {
            // Turn Off
            SwitchSprite.sprite = OffSwitchSprite;
            Platform.GetComponent<SpriteRenderer>().sprite = OffPlatformSprite;
        }

    }

    bool ColCheck()
    {

        // Check if player is hitting the switch
        if (SwitchBoxCol.IsTouching(Player) || (SwitchBoxCol.IsTouching(Player)))
        {
            return true;
        }

        // Check if anything else is hitting the switch
        foreach (var Trigger in Triggers)
        {
            if (SwitchBoxCol.IsTouching(Trigger.GetComponent<BoxCollider2D>()))
            {
                return true;
            }
        }

        // else, return false
        return false;
    }

}
