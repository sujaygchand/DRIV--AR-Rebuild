using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePartsManager : MonoBehaviour {

    public AnimationCurve OpenAnimation;
    private Dictionary<MaterialEnums.InteractablePart, GameObject> pivotPoints = new Dictionary<MaterialEnums.InteractablePart, GameObject>();
    private GameObject[] tempPivotPoints;
    private bool doScanOnce = true;

    // Use this for initialization
    void Start() {
        tempPivotPoints = GameObject.FindGameObjectsWithTag("PivotPoint");
	}

    private void Update() {
        if (Input.GetKeyDown("8")) {
            MovePart(MaterialEnums.InteractablePart.LeftDoorPivot);
        }

        if (Input.GetKeyDown("9")) {
            MovePart(MaterialEnums.InteractablePart.RightDoorPivot);
        }

        if (Input.GetKeyDown("0")) {
            MovePart(MaterialEnums.InteractablePart.BootPivot);
        }

        if (doScanOnce) {
            doScanOnce = false;

            foreach (GameObject tempPivotPoint in tempPivotPoints) {
                //print(tempPivotPoint.GetComponent<InteractablePart>().InteractablePartName);

                if (tempPivotPoint.GetComponent<InteractablePart>()) {
                    pivotPoints.Add(tempPivotPoint.GetComponent<InteractablePart>().InteractablePartName, tempPivotPoint);
                }
            }
        }
    }

    public void MovePart(MaterialEnums.InteractablePart InteractablePart) {
        pivotPoints[InteractablePart].GetComponent<InteractablePart>().MovePart();
    }
}
