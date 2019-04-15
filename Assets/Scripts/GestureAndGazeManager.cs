using UnityEngine;

using HoloToolkit.Unity.InputModule;


public class GestureAndGazeManager : MonoBehaviour
{

    public static GestureAndGazeManager Instance;

    public GameObject gameScene;

    public bool isPlacing = false;

    // Represents the hologram that is currently being gazed at.
    private GameObject FocusedObject;

    UnityEngine.XR.WSA.Input.GestureRecognizer recognizer;

    void start()
    {
    }

    // Use this for initialization
    void Awake()
    {

        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            if (isPlacing) {
                gameScene.GetComponent<TransformScene>().SetCanbePlaced(false);
                
            }

            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                if (FocusedObject.GetComponent<CustomiseButton>() || FocusedObject.GetComponent<MenuButton>())
                {
                    FocusedObject.SendMessageUpwards("WhenButtonPressed", SendMessageOptions.DontRequireReceiver);
                }
            }
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }

    }
}

