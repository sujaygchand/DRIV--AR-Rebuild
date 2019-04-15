using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToneMenu : MonoBehaviour {

    public MaterialMenu materialmenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public struct MaterialMenu {

    public MaterialEnums.MaterialType materialType;
    public MaterialEnums.ToneType toneType;

    public MaterialMenu(MaterialEnums.MaterialType materialType, MaterialEnums.ToneType toneType) {

        this.materialType = materialType;
        this.toneType = toneType;
    }
}