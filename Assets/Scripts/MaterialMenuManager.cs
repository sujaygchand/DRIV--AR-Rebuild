using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMenuManager : MonoBehaviour {

    public RectTransform ScrollRectHandler;

    private GameObject[] materialMenus;
    private GameObject user;
    private PlayerController playerScript;

    // Use this for initialization
    void Start () {
        materialMenus = GameObject.FindGameObjectsWithTag("ToneMenu");

        user = GameObject.FindGameObjectWithTag("MainCamera");
        playerScript = user.GetComponent<PlayerController>();

        RenderCorrectToneMenu();
    }
	
	// Update is called once per frame
	public void ToneButtonPressed() {
        switch (playerScript.getMaterialType()) {
            case MaterialEnums.MaterialType.Paint:
                RenderCorrectToneMenu();
                break;
            case MaterialEnums.MaterialType.Leather:
                RenderCorrectToneMenu();
                break;
            case MaterialEnums.MaterialType.Veneer:
                RenderTonelessMenu();
                break;
            case MaterialEnums.MaterialType.Metal:
                RenderTonelessMenu();
                break;
            case MaterialEnums.MaterialType.Spirit:
                RenderTonelessMenu();
                break;
            case MaterialEnums.MaterialType.Glass:
                RenderTonelessMenu();
                break;
        }
	}

    void RenderCorrectToneMenu() {
        HideAllToneMenus();

        foreach (GameObject tempMaterialMenu in materialMenus) {
            if (tempMaterialMenu.GetComponent<ToneMenu>().materialmenu.toneType == playerScript.getMaterialToneType()) {
                if (tempMaterialMenu.GetComponent<ToneMenu>().materialmenu.materialType == playerScript.getMaterialType()) {
                    tempMaterialMenu.SetActive(true);
                    ScrollRectHandler.GetComponent<ScrollRectHandler>().SetupScrollRect(tempMaterialMenu.GetComponent<RectTransform>());
                    break;
                }
            }
        }
    }

    void RenderTonelessMenu() {
        HideAllToneMenus();

        foreach (GameObject tempMaterialMenu in materialMenus) {
                if (tempMaterialMenu.GetComponent<ToneMenu>().materialmenu.materialType == playerScript.getMaterialType()) {
                    tempMaterialMenu.SetActive(true);
                    ScrollRectHandler.GetComponent<ScrollRectHandler>().SetupScrollRect(tempMaterialMenu.GetComponent<RectTransform>());
                    break;
                }
            }
        }

    void HideAllToneMenus() {
        foreach (GameObject tempMaterialMenu in materialMenus) {
            tempMaterialMenu.SetActive(false);
        }
    }

}

