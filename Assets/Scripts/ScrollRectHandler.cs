using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.ScrollRect))]

public class ScrollRectHandler : MonoBehaviour {

    public void SetupScrollRect(RectTransform content) {

        GetComponent<UnityEngine.UI.ScrollRect>().content = content;
    }
}
