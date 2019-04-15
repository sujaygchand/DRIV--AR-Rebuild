using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPart : MonoBehaviour {

    public MaterialEnums.MaterialType materialType;
    public MaterialEnums.PartName partName;

    private Renderer rend;
    private Material resetMat;
    

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = GetComponent<Renderer>().materials[0];

        resetMat = rend.sharedMaterial;
    }

    public void ChangeMaterial(string materialName, MaterialEnums.MaterialType type) {
        rend.sharedMaterial = MaterialSelector.LoadMaterial(materialName, type);
    }

    public void ResetMaterial() {
        print("Past: " + resetMat);
        rend.sharedMaterial = resetMat;
        print("Past: " + resetMat);
    }

    public string GetMaterialName() {
        return rend.sharedMaterial.name.Replace("(Instance)", "");
    }

}
