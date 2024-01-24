using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    [SerializeField]
    private Transform baseWindow;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private Transform ContentWindowsHolder;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        foreach (Transform item in baseWindow)
            item.gameObject.SetActive(false);
        foreach (Transform item in ContentWindowsHolder)
            item.gameObject.SetActive(false);
        menu.SetActive(true);
        ContentWindowsHolder.gameObject.SetActive(true);
    }
}