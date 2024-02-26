using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeFontOnAwake : MonoBehaviour
{
    private TextMeshProUGUI text => GetComponent<TextMeshProUGUI>();
    private void OnEnable()
    {
        if(ContentManager.instance != null)
            text.font = ContentManager.instance.tMP_Fonts[ContentManager.instance.currentJsonNumber];
    }
}
