using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    private List<GameObject> allButtons = new List<GameObject>();
    [SerializeField]
    private Color disabledColor;
    [SerializeField]
    private Color enabledColor;

    public static LocalizationManager instance;
    [SerializeField]
    private GameObject[] disableThis;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < ContentManager.instance.AllJsons.Count; i++) 
        {
            var button = Instantiate(buttonPrefab, gameObject.transform);
            allButtons.Add(button);

            int c = i;

            var LBU = button.GetComponent<LocalizeButtonUI>();
            LBU.text.text = ContentManager.instance.AllJsons[c].name;
            LBU.button.onClick.AddListener(() =>
            {
                ChangeLocalization(c);
            });
        }
        LoadFromPlayerPrefs();

        for (int i = 0; i < disableThis.Length; i++)
        {
            disableThis[i].SetActive(false);
        }
    }

    private void ChangeLocalization(int i)
    {
        ContentManager.instance.ChangeCurrentJson(i);
        ChangeColorToStandartInAllButtons();
        allButtons[i].GetComponent<LocalizeButtonUI>().ChangeUI(enabledColor);
        SaveToPlayerPrefs(i);
    }
    private void ChangeColorToStandartInAllButtons()
    {
        for(int i = 0;i < allButtons.Count;i++)
        {
            allButtons[i].GetComponent<LocalizeButtonUI>().ChangeUI(disabledColor);
        }
    }
    private const string language = "Language";
    public void LoadFromPlayerPrefs()
    {

        if (PlayerPrefs.HasKey(language))
        {
            int PPL = PlayerPrefs.GetInt(language);
            ChangeLocalization(PPL);
        }
        else
        {
            ChangeLocalization(0);
        }
    }
    private void SaveToPlayerPrefs(int langId)
    {
            PlayerPrefs.SetInt(language, langId);
    }
}
