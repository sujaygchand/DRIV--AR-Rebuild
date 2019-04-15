using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecSheet : MonoBehaviour {

    private GameObject[] allCarPartObjects;


    // Use this for initialization
    void Start () {
        allCarPartObjects = GameObject.FindGameObjectsWithTag("CarPart");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("s")) {
            print(SpecSheetResults());
        }
    }

    public string SpecSheetResults() {

        string outputString = null;
        MaterialEnums.PartName tempPartName = MaterialEnums.PartName.Primary_Paint;
        bool tempFirstTimeCheck = true;

        foreach (GameObject tempCarPart in allCarPartObjects) {

            if (tempCarPart.GetComponent<CarPart>().partName != tempPartName || tempFirstTimeCheck) {
                tempFirstTimeCheck = false;
                tempPartName = tempCarPart.GetComponent<CarPart>().partName;
                outputString += tempPartName + ": " + tempCarPart.GetComponent<CarPart>().GetMaterialName() + "\n";
            }
        } 
        return outputString;
    }
}
