using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDisplay : MonoBehaviour {

    public MaterialEnums.PartName PartName;
    private SpriteRenderer SpriteDisplayer;
    private Texture2D SpriteTexture;

    // Use this for initialization
    void Start()
    {
        SpriteDisplayer = this.gameObject.GetComponent<SpriteRenderer>();
        LoadImage("PrimaryPaint");
        PartName = MaterialEnums.PartName.Primary_Paint; 

    }

    public void UpdateSprite()
    {
        switch (PartName)
        {
            case MaterialEnums.PartName.Primary_Paint:
                LoadImage("PrimaryPaint");
                break;

            case MaterialEnums.PartName.Secondary_Paint:
                LoadImage("SecondaryPaint");
                break;

            case MaterialEnums.PartName.Exterior_Trim:
                LoadImage("ExteriorTrim");
                break;

            case MaterialEnums.PartName.Rear_Rims:
                LoadImage("Wheels");
                break;


            case MaterialEnums.PartName.Grill:
                LoadImage("Grill");
                break;

            case MaterialEnums.PartName.Spirit_of_Ecstasy:
                LoadImage("SpiritOfEcstasy");
                break;

            case MaterialEnums.PartName.Seat_Main_Body:
                LoadImage("SeatMainBody");
                break;

            case MaterialEnums.PartName.Seat_Valance_and_Backs:
                LoadImage("SeatValanceAndBacks");
                break;

            case MaterialEnums.PartName.Seat_Inner:
                LoadImage("SeatInner");
                break;

            case MaterialEnums.PartName.Seat_Gussets:
                LoadImage("SeatGussets");
                break;

            case MaterialEnums.PartName.Seat_Piping:
                LoadImage("SeatPiping");
                break;

            case MaterialEnums.PartName.Seatbelts:
                LoadImage("Seatbelts");
                break;

            case MaterialEnums.PartName.Center_Console:
                LoadImage("CenterConsole");
                break;

            case MaterialEnums.PartName.Center_Console_Armrest:
                LoadImage("CenterConsoleArmrest");
                break;

            case MaterialEnums.PartName.Carpets:
                LoadImage("Carpets");
                break;

            case MaterialEnums.PartName.IP_Lower:
                LoadImage("IPLower");
                break;

            case MaterialEnums.PartName.IP_Inner:
                LoadImage("IPInner");
                break;

            case MaterialEnums.PartName.IP_Top:
                LoadImage("IPTOP");
                break;

            case MaterialEnums.PartName.Interior_Veneer:
                LoadImage("InteriorVeneer");
                break;

            case MaterialEnums.PartName.Interior_Veneer_Secondary:
                LoadImage("InteriorVeneerSecondary");
                break;

            case MaterialEnums.PartName.Steering_Column:
                LoadImage("SteeringColumn");
                break;

            case MaterialEnums.PartName.Steering_Wheel_Inner:
                LoadImage("SteeringWheelInner");
                break;

            case MaterialEnums.PartName.Steering_Wheel_Outer:
                LoadImage("SteeringWheelOuter");
                break;

            case MaterialEnums.PartName.Pillars:
                LoadImage("Pillars");
                break;

            case MaterialEnums.PartName.Headlining_Primary:
                LoadImage("HeadliningPrimary");
                break;

            /*case MaterialEnums.PartName.Headlining_Secondary:
                LoadImage("HeadliningSecondary");
                break;
                */
            case MaterialEnums.PartName.Hatshelf:
                LoadImage("Hatshelf");
                break;

            case MaterialEnums.PartName.Waterfall:
                LoadImage("Waterfall");
                break;

            case MaterialEnums.PartName.Main_Door:
                LoadImage("MainDoor");
                break;

            case MaterialEnums.PartName.Left_Door_Main_Panel:
                LoadImage("MainPanel");
                break;

            case MaterialEnums.PartName.Lower_Tone:
                LoadImage("LowerTone");
                break;

            case MaterialEnums.PartName.Rear_Armrests:
                LoadImage("Armrests");
                break;

            case MaterialEnums.PartName.Left_Door_Pocket:
                LoadImage("Pockets");
                break;

            case MaterialEnums.PartName.Left_Door_Piping:
                LoadImage("DoorPiping");
                break;

            case MaterialEnums.PartName.Kickplates:
                LoadImage("Kickplates");
                break;

            case MaterialEnums.PartName.Bootlining:
                LoadImage("BootTrim");
                break;

            case MaterialEnums.PartName.Dial_Backing:
                LoadImage("DialsBacking");
                break;

            case MaterialEnums.PartName.Clock:
                LoadImage("Clock");
                break;

        }
    }

    public void LoadImage(string Name)
    {
        Texture2D TempTexture = Resources.Load("Components/" + Name) as Texture2D;
        SpriteDisplayer.sprite = Sprite.Create(TempTexture, new Rect(0, 0, TempTexture.width, TempTexture.height), new Vector2(1, 1));
        SpriteTexture = TempTexture;
    }
}
