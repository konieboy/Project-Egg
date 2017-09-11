using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    // Array of items where we apply parallaxing to
    // Includes background and forground Items
    public Transform[] parallaxItems; 
    private float[] parallaxScales; // The proportion of the camera's movement to move parallaxItems by
    public float smoothing = 1f; // Must be > 0
    private Transform cam; // Reference to the main cameras transform
    private Vector3 previousCamPosition; // Pos of cam last frame

    // Called before start but after game objects load. Great for references
    void Awake()
    {
        // Set up reference to cam
        cam = Camera.main.transform;
        
    }

	// Use this for initialization
	void Start ()
    {
        previousCamPosition = cam.position;

        //Assign coresponding parallaxScales
        parallaxScales = new float[parallaxItems.Length];
        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = parallaxItems[i].position.z * -1;           
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i < parallaxItems.Length; i++)
        {
            // Parallax is the opposite of the camera movement
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];

            // Target x = currentpos + parallax
            float parallaxItemTargetX = parallaxItems[i].position.x + parallax;

            // Recreate position with parallaxItemTargetX
            Vector3 parallaxItemTargetPosition = new Vector3(parallaxItemTargetX, parallaxItems[i].position.y, parallaxItems[i].position.z);

            // Fade between current and target pos (LERP lets you fade between positions)
            parallaxItems[i].position = Vector3.Lerp(parallaxItems[i].position, parallaxItemTargetPosition, smoothing * Time.deltaTime); // Time.deltaTime converts frames = time
        }
        // Reset prev cam pos
        previousCamPosition = cam.position;
    }
}
