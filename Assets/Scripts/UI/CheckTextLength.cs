using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CheckTextLength : MonoBehaviour
{
    private TextMeshProUGUI text => GetComponent<TextMeshProUGUI>();
    [SerializeField]
    private int maxLength = 20;
    [SerializeField]
    private bool inUpdate = false;
    private void FixedUpdate()
    {
        if (inUpdate)
            if (text.text.Length > maxLength)
                text.text = text.text.Truncate(maxLength);
    }
    private void OnEnable()
    {
        if (text.text.Length > maxLength)
            text.text = text.text.Truncate(maxLength) + "...";

    }

}
