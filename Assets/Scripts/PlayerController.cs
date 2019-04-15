using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject UI_Rect;

    private GameObject[] allCarPartObjects;
    private List<GameObject> focusedCarParts = new List<GameObject>();
    private GameObject componentDisplay;
    private MaterialEnums.MaterialType currentMaterialType;
    private MaterialEnums.ToneType currentToneType;
    private MaterialEnums.PartName focusedPartName;
    private GameObject materialMenuManager;

    private bool isFocusing = true;
    private bool scanOnce = true;

    Vector3 currentPosition;

    private void Awake() {
        allCarPartObjects = GameObject.FindGameObjectsWithTag("CarPart");
        materialMenuManager = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Use this for initialization
    void Start () {
        focusedPartName = MaterialEnums.PartName.Primary_Paint;
        componentDisplay = GameObject.FindGameObjectWithTag("ComponentDisplay");
        this.currentToneType = MaterialEnums.ToneType.LightTone;
	}

    void Update() {
        if (scanOnce) {
            scanOnce = false;
            UpdateCarPart();
        }

        /*
         * Moves onto the next part
         * Enter would not work
         */
        if (Input.GetKeyDown("a")) {

            UI_Rect.transform.position = UI_Rect.transform.position - new Vector3(0.3f, 0,0);

        }

    }

    /*
     * 
     * BUTTON UI FUNCTIONS 
     * 
     */

    public void UpdateCarPart() {
        isFocusing = true;
        FocusOnParts(focusedPartName);
        componentDisplay.GetComponent<ComponentDisplay>().PartName = focusedPartName;
        componentDisplay.GetComponent<ComponentDisplay>().UpdateSprite();
        currentMaterialType = getMaterialType(focusedCarParts[0].GetComponent<CarPart>());
    }

    public void NextCarPart() {
        if(this.focusedPartName != MaterialEnums.PartName.Clock) {
            this.focusedPartName++;
            UpdateCarPart();
        }
    }

    public void PreviousCarPart() {
        if (this.focusedPartName != MaterialEnums.PartName.Primary_Paint) {
            this.focusedPartName--;
            UpdateCarPart();
        }
    }

    /*
     * 
     * CAR PART FUNCTIONS 
     * 
     */

    public void FocusOnParts(MaterialEnums.PartName partName) {

        if (isFocusing) {
            isFocusing = false;
            focusedCarParts.Clear();
            
            foreach(GameObject tempCarPart in allCarPartObjects) {

                if (tempCarPart.GetComponent<CarPart>() && tempCarPart.GetComponent<CarPart>().partName == partName) {

                    focusedCarParts.Add(tempCarPart);
                    //print(tempCarPart);
                }
            }
        }
    }

    public void setFocusedPartName(MaterialEnums.PartName focusedPartName) {
        this.focusedPartName = focusedPartName;
    }

    public MaterialEnums.PartName getFocusedPartName() {
        return this.focusedPartName;
    }

    /*
     * 
     * MATERIAL FUNCTIONS 
     * 
     */

    public void ChangeMaterial(string material) {
        foreach(GameObject tempCarPart in focusedCarParts) {
            tempCarPart.GetComponent<CarPart>().ChangeMaterial(material, currentMaterialType);
        }
    }

    public void setMaterialType(MaterialEnums.MaterialType materialType) {
        this.currentMaterialType = materialType;
    }

    public MaterialEnums.MaterialType getMaterialType() {
        return this.currentMaterialType;
    }

    public MaterialEnums.MaterialType getMaterialType(CarPart carPart) {
        return carPart.materialType;
    }

    public void setMaterialToneType(MaterialEnums.ToneType currentToneType) {
        this.currentToneType = currentToneType;
    }

    public MaterialEnums.ToneType getMaterialToneType() {
        return this.currentToneType;
    }

    public void ResetMaterials() {

        foreach(GameObject tempCarPart in focusedCarParts) {
            tempCarPart.GetComponent<CarPart>().ResetMaterial();
        }
    }

    public void ResetAllMaterials() {

        foreach (GameObject tempCarPart in allCarPartObjects) {
            tempCarPart.GetComponent<CarPart>().ResetMaterial();
        }
    }

    public void UpdateMaterialUI(MaterialEnums.ToneType toneType) {
        this.currentToneType = toneType;
        materialMenuManager.GetComponent<MaterialMenuManager>().ToneButtonPressed();
    } 
}
