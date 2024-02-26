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
    private bool truncated = false;
    private void FixedUpdate()
    {
        if(!truncated)
            if (text.text.Length > maxLength)
            {
                text.text = text.text.Truncate(maxLength) + "...";
                truncated = true;
            }
    }
/*    private void OnEnable()
    {
        if (text.text.Length > maxLength)
            text.text = text.text.Truncate(maxLength) + "...";

    }*/

}
