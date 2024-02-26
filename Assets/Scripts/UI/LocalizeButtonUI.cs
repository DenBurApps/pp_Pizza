using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeButtonUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField]
    private Image stroke;
    public Button button;
    public void ChangeUI(Color color)
    {
        stroke.color = color;
        text.color = new Color(color.r, color.g, color.b,1);
    }
}
