using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _screen;
    [SerializeField]
    private GameObject _closeScreen;
    [SerializeField]
    private GameObject[] _openSecondScreens;
    [SerializeField]
    private bool _dontCloseClosingScreen = false;

    [SerializeField]
    private bool _dontChangeActiveScreen = false;
    private void Start()
    {
        if(GetComponent<Button>())
            GetComponent<Button>().onClick.AddListener(Onclick);
    }
    public void Onclick()
    {

        UIController.UIControllerS.CloseScreen(_dontCloseClosingScreen);
        if(!_dontChangeActiveScreen)
            UIController.UIControllerS.ChangeActiveScreen(_screen);
          
        _screen.SetActive(true);
          
        if (_closeScreen != null)
            _closeScreen.SetActive(false);

        if(_openSecondScreens.Length != 0)
            foreach(GameObject go in _openSecondScreens) { go.SetActive(true); }
    }
    public void SetScreens(GameObject screen, GameObject closeScreen, GameObject[] openScreens)
    {
        
        _screen = screen; _closeScreen = closeScreen; _openSecondScreens = openScreens;
    }
}
