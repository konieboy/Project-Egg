using UnityEngine;
using System.Collections;

//Must always have sprite renderer attached to script
[RequireComponent (typeof(SpriteRenderer))] 

public class Titling : MonoBehaviour {

    public int offsetX = 2;

    public bool hasRightBuddy = false;
    public bool hasLeftBuddy = false;

    public bool reverseScale = false; // used if opbject is not tilable

    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;
    public Transform parents;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Use this for initialization
    void Start ()
    {
        // Get Background
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.bounds.size.x;          
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Does it still need buddies? - if not, do nothing
        if (hasLeftBuddy == false || hasRightBuddy == false)
        {
            // Calculate half the width of what the camera sees
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // Calc x pos where cam can see edge of sprite
            float edgeVisablePositionRight = (myTransform.position.x + spriteWidth/2) - camHorizontalExtend;
            float edgeVisablePositionLeft = (myTransform.position.x - spriteWidth/2) + camHorizontalExtend;

            //make right buddy
            if (cam.transform.position.x >= (edgeVisablePositionRight - offsetX) && !hasRightBuddy)
            {
                MakeNewBuddy(1);
                hasRightBuddy = true;
            }
            else if (cam.transform.position.x <= (edgeVisablePositionLeft + offsetX) && !hasLeftBuddy)
            {
                MakeNewBuddy(-1);
                hasLeftBuddy = true;
            }
        }
    }

    void MakeNewBuddy(int rightOrLeft)
    {
        // Calc position of buddy (-1 Left | 1 Right)
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);

        // Instantiate new Buddy Object
        Transform newBuddy = (Transform)Instantiate(myTransform, newPosition, myTransform.rotation);

        // If not tilable reverse x to rid seams
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }
        newBuddy.transform.parent = parents.transform;

        if (rightOrLeft == 1)
        {
            newBuddy.GetComponent<Titling>().hasLeftBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<Titling>().hasRightBuddy = true;
        }
    }
}
