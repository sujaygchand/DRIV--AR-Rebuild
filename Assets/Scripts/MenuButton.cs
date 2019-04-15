using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public MenuButtonType menuButtonType;

    private GameObject user;
    private PlayerController playerScript;

    // Use this for initialization
    void Start() {
        user = GameObject.FindGameObjectWithTag("MainCamera");
        playerScript = user.GetComponent<PlayerController>();
    }

    public void WhenButtonPressed() {

        switch (menuButtonType) {
            case MenuButtonType.Begin:
                BeginButton();
                GetComponent<AudioSource>().Play();
                break;

            case MenuButtonType.Next:
                NextButton();
                GetComponent<AudioSource>().Play();
                break;

            case MenuButtonType.Previous:
                PreviousButton();
                GetComponent<AudioSource>().Play();
                break;

            case MenuButtonType.Position:
                PositionButton();
                GetComponent<AudioSource>().Play();
                break;

            case MenuButtonType.Reset:
                ResetButton();
                GetComponent<AudioSource>().Play();
                break;

            case MenuButtonType.LightTones:
                LightTonesButton();
                break;

            case MenuButtonType.MidTones:
                MidTonesButton();
                break;

            case MenuButtonType.DarkTones:
                DarkTonesButton();
                break;

            case MenuButtonType.SpecialTones:
                SpecialTonesButton();
                break;
        }
    }

    public void BeginButton() {
        GameObject.Find("StartSreen");
    }

    public void NextButton() {
        playerScript.NextCarPart();
        playerScript.UpdateMaterialUI(playerScript.getMaterialToneType());
    }

    public void PreviousButton() {
        playerScript.PreviousCarPart();
        playerScript.UpdateMaterialUI(playerScript.getMaterialToneType());
    }

    public void PositionButton() {
        GameObject gameScene = GameObject.FindGameObjectWithTag("GameScene");
        gameScene.GetComponent<TransformScene>().SetCanbePlaced(true);
       
    }

    public void ResetButton() {
        playerScript.ResetMaterials();
    }


    public void LightTonesButton() {
        playerScript.UpdateMaterialUI(MaterialEnums.ToneType.LightTone);
    }

    public void MidTonesButton() {
        playerScript.UpdateMaterialUI(MaterialEnums.ToneType.MidTone);
    }

    public void DarkTonesButton() {
        playerScript.UpdateMaterialUI(MaterialEnums.ToneType.DarkTone);
    }

    public void SpecialTonesButton() {
        playerScript.UpdateMaterialUI(MaterialEnums.ToneType.SpecialTone);
    }

}

public enum MenuButtonType {
    Begin, Next, Previous, Position, Reset, LightTones, MidTones, DarkTones, SpecialTones
}
