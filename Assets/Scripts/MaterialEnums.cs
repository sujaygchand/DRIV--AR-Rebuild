using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEnums : MonoBehaviour {

    /*
     * This one is Completed
     */
    public enum MaterialType {
        Paint, Leather, Veneer, Metal, Spirit, Glass
    }

    public enum ToneType {
        LightTone, MidTone, DarkTone, SpecialTone
    }

    /*
     * Primary_Paint = 1,  Secondary_Paint = 2 ......
     */
    public enum PartName {
        Primary_Paint, Secondary_Paint, Exterior_Trim, Rear_Rims, Grill, Spirit_of_Ecstasy, Seat_Main_Body, Seat_Valance_and_Backs, Seat_Inner, Seat_Gussets, Seat_Piping, Seatbelts, Center_Console, Center_Console_Armrest, Carpets, IP_Lower, IP_Inner, IP_Top, Interior_Veneer, Interior_Veneer_Secondary, Steering_Column, Steering_Wheel_Inner, Steering_Wheel_Outer, Pillars, Headlining_Primary, /*Headlining_Secondary,*/ Hatshelf, Waterfall, Main_Door, Left_Door_Main_Panel, Lower_Tone, Rear_Armrests, Left_Door_Pocket, Left_Door_Piping, Kickplates, Bootlining, Dial_Backing, Clock
    }

    public enum InteractablePart {
        LeftDoorPivot, RightDoorPivot, BootPivot
    }
}
