using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePart : MonoBehaviour {

    public MaterialEnums.InteractablePart InteractablePartName;
    public bool IsOpen;

    private InteractablePartsManager interablePartsManager;
    private Quaternion openRotation;
    private Quaternion closeRotation;

    private void Start() {

        interablePartsManager = GameObject.FindObjectOfType<InteractablePartsManager>();

        switch (InteractablePartName) {
            case MaterialEnums.InteractablePart.LeftDoorPivot:
                openRotation = Quaternion.Euler(0, -54.778f, 0);
                closeRotation = Quaternion.Euler(0, -8, 0);
                break;
            case MaterialEnums.InteractablePart.RightDoorPivot:
                openRotation = Quaternion.Euler(0, 110.293f, 0);
                closeRotation = Quaternion.Euler(0, 55.515f, 0);
                break;
            case MaterialEnums.InteractablePart.BootPivot:
                openRotation = Quaternion.Euler(-73.15f, 0, 0);
                closeRotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }
    
    public void MovePart() {
        StartCoroutine(LerpCoroutine());
    }

    IEnumerator LerpCoroutine() {

        Quaternion currentRotation;
        Quaternion endRotation;

        if (IsOpen) {
            IsOpen = false;
            currentRotation = openRotation;
            endRotation = closeRotation;
        } else {
            IsOpen = true;
            currentRotation = closeRotation;
            endRotation = openRotation;
        }

        float animationTime = 0;
        float animationEnd = interablePartsManager.OpenAnimation.keys[interablePartsManager.OpenAnimation.length -1].time;

        print(animationEnd);
        while(animationTime <= animationEnd) {
            float lerpFactor = interablePartsManager.OpenAnimation.Evaluate(animationTime);
            this.gameObject.transform.localRotation = Quaternion.Lerp(currentRotation, endRotation, lerpFactor);
            animationTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }



    public AnimationCurve AnimationGraph;       // Makes an easy to edit graph in editor
    public Vector3 StartLocation;               // Your start location
    public Vector3 EndLocation;                 // Your end location

    // A function used to start the coroutine
    void MoveObject()
    {
        StartCoroutine(LerpObject());
    }

    // Using a coroutine to do the movement
    IEnumerator LerpObject()
    {

        float animationTime = 0;
        // The time you set on your animation graph
        float animationEnd = AnimationGraph.keys[AnimationGraph.length - 1].time;

        // Stops when this condition is false
        while(animationTime <= animationEnd)
        {
            // Did this so you can re-use for any object 
            float lerpFactor = AnimationGraph.Evaluate(animationTime);

            // Object location = StartLocation (When lerpFactor = 0) Object location = EndLocation (When lerpFactor = 1)  
            this.gameObject.transform.position = Vector3.Lerp(StartLocation, EndLocation, lerpFactor);

            animationTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}


