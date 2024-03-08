using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlateData : MonoBehaviour
{
    public Obj properties { get; private set; }

    [SerializeField]
    public RawImage Picture;
    [SerializeField]
    private TextMeshProUGUI NameTMP;
    [SerializeField]
    private GameObject discountObj;
    [SerializeField]
    private LoadPlateImage loadPlateImage;

    [SerializeField]
    private TextMeshProUGUI priceTMP;
    [SerializeField]
    private TextMeshProUGUI descriptionTMP;
    [SerializeField]
    private Button plateButton;
    [SerializeField]
    private TextMeshProUGUI inBagCount;
    [SerializeField]
    private Button minusButton;


    public void SetDataInPlate(Obj properties)
    {
        this.properties = properties;

        if(discountObj != null)
            discountObj.SetActive(properties.discount);

        NameTMP.text = properties.name;
        priceTMP.text = properties.price + "$";

        if (properties.image != null && properties.image != "")
            loadPlateImage.LoadPlateImageInRawImage(properties.image, properties.image);

        properties.favorite = Convert.ToBoolean(PlayerPrefs.GetInt(properties.image + "_Fav"));
        ChangeSubscribeBttnColor(properties.favorite);

        _favouriteBttn.GetComponent<Button>().onClick.AddListener(
            () => ChangeSubscribeBttnColor(false));
        _unFavouriteBttn.GetComponent<Button>().onClick.AddListener(
            () => ChangeSubscribeBttnColor(true));

        if (plateButton != null)
            plateButton.onClick.AddListener(() => {
                Preview.Instance.gameObject.SetActive(true);
                Preview.Instance.SetData(this, properties);
            });
        if(inBagCount != null)
            inBagCount.text = properties.inBagCount.ToString();

        if (minusButton != null)
        {
            if (properties.inBagCount <= 0)
                minusButton.interactable = false;
            else
                minusButton.interactable = true;
        }

        if (descriptionTMP != null)
            descriptionTMP.text = properties.description;
    }
    public void PlusMinusInBag(bool plusMinus)
    {
        if (plusMinus) AddInBag.AddObj(true, properties);

        else AddInBag.AddObj(false, properties);

        if(minusButton != null)
        {
            if (properties.inBagCount <= 0)
                minusButton.interactable = false;
            else
                minusButton.interactable = true;
        }

        inBagCount.text = properties.inBagCount.ToString();

        if(CalculateCost.Instance != null)
            CalculateCost.Instance.Calculate();
    }
    [SerializeField]
    private GameObject _favouriteBttn;
    [SerializeField]
    private GameObject _unFavouriteBttn;

    public void ChangeSubscribeBttnColor(bool isFolowed)
    {
        if (isFolowed)
        {
            if (!ContentManager.allDataDic["favorite"].ContainsKey(properties.image))
                ContentManager.allDataDic["favorite"].Add(properties.image, properties);
            _favouriteBttn.SetActive(true);
            _unFavouriteBttn.SetActive(false);
        }
        else
        {
            if (ContentManager.allDataDic["favorite"].ContainsKey(properties.image))
                ContentManager.allDataDic["favorite"].Remove(properties.image);
            _favouriteBttn.SetActive(false);
            _unFavouriteBttn.SetActive(true);
        }
        SetPlateFavoriteStateInPlayerPrefs(isFolowed);
    }

    private void SetPlateFavoriteStateInPlayerPrefs(bool isFolowed)
    {
        properties.favorite = isFolowed;
        PlayerPrefs.SetInt(properties.image + "_Fav", Convert.ToInt16(isFolowed));
    }
}
