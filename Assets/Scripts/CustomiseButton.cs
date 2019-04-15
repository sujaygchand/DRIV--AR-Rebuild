using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AudioSource))]

public class CustomiseButton : MonoBehaviour {

    public MaterialEnums.MaterialType materialType;

    private GameObject user;
    private PlayerController playerScript;

    private string materialName;

	// Use this for initialization
	void Start () {
        user = GameObject.FindGameObjectWithTag("MainCamera");
        playerScript = user.GetComponent<PlayerController>();

        materialName = GetComponent<Image>().sprite.name;
        materialName = materialName.Replace(" ", "");
    }
	

    public void WhenButtonPressed() {
        playerScript.ChangeMaterial(materialName);
        GetComponent<AudioSource>().Play();
    }
}
