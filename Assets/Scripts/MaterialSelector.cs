using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelector : MonoBehaviour
{
    /*
     * Loads selected Material Paint
     */
    public static Material LoadMaterial(string materialName, MaterialEnums.MaterialType type)
    {
        string typeString = type.ToString();
        typeString.ToUpper();
        Material TempMaterial = Resources.Load("Materials/" + typeString + "/" + materialName) as Material;
        //print("Materials/" + typeString + "/" + materialName);
        return TempMaterial;
    }
}
