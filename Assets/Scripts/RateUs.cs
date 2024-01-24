using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RateUs : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;
    [SerializeField]
    private TextMeshProUGUI RateButtonTMP;
    private void Awake()
    {
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => { OnStarButtonClick(button);});
        }
    }
    private Color disabledColor = new Color(255, 255, 255, .3f);
    private Color enabledColor = new Color(255, 255, 255, 255);

    private void OnStarButtonClick(Button clickedButton)
    {
        foreach (var button in buttons)
        {
            button.gameObject.GetComponent<Image>().color = disabledColor;
        }
        int i = 0;
        foreach (var button in buttons)
        {
            i++;
            button.gameObject.GetComponent<Image>().color = enabledColor;
            if (button == clickedButton)
            {
                break;
            }
        }
        if(i != 1)
            RateButtonTMP.text = $"{i} Stars";
        else
            RateButtonTMP.text = $"{i} Star";

    }
}
