using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    public static Preview Instance;
    private PlateData plateData;
    [SerializeField]
    public Obj properties { get; private set; }

    [SerializeField]
    private TextMeshProUGUI NameTMP;
    [SerializeField]
    private TextMeshProUGUI priceTMP;
    [SerializeField]
    private TextMeshProUGUI descriptionTMP;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        _favouriteBttn.GetComponent<Button>().onClick.AddListener(
    () => ChangeSubscribeBttnColor(false));
        _unFavouriteBttn.GetComponent<Button>().onClick.AddListener(
            () => ChangeSubscribeBttnColor(true));
        gameObject.SetActive(false);
    }

    public void SetData(PlateData plateData, Obj properties)
    {
        this.plateData = plateData;
        this.properties = properties;

        ChangeSubscribeBttnColor(properties.favorite);
        if (properties.image != null && properties.image != "")
            GetComponent<LoadPlateImage>().LoadPlateImageInRawImage(properties.image, properties.image);

        descriptionTMP.text = properties.description;
        NameTMP.text = properties.name;
        priceTMP.text = properties.price + "$";

        inBagCount.text = properties.inBagCount.ToString();
        if (properties.inBagCount <= 0)
            minusButton.interactable = false;
        else
            minusButton.interactable = true;
    }
    [SerializeField]
    private TextMeshProUGUI inBagCount;
    [SerializeField]
    private Button minusButton;
    public void PlusMinusInBag(bool plusMinus)
    {
        if (plusMinus) AddInBag.AddObj(true, properties);

        else AddInBag.AddObj(false, properties);

        if(properties.inBagCount <= 0)
            minusButton.interactable = false;
        else
            minusButton.interactable = true;

        inBagCount.text = properties.inBagCount.ToString();
    }

    [SerializeField]
    private GameObject _favouriteBttn;
    [SerializeField]
    private GameObject _unFavouriteBttn;
    public void ChangeSubscribeBttnColor(bool isFolowed)
    {
        if (isFolowed)
        {
            _favouriteBttn.SetActive(true);
            _unFavouriteBttn.SetActive(false);
        }
        else
        {
            _favouriteBttn.SetActive(false);
            _unFavouriteBttn.SetActive(true);
        }
        plateData.ChangeSubscribeBttnColor(isFolowed);
    }
}
