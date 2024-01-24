using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateCost : MonoBehaviour
{
    public static CalculateCost Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        Calculate();
    }
    private float allSum;

    [SerializeField]
    private TextMeshProUGUI priceTMP;
    private float deliveryPrice = 1;
    [SerializeField]
    private TextMeshProUGUI deliveryPriceTMP;
    [SerializeField]
    private TextMeshProUGUI fullPriceTMP;
    private int itemsCount;
    [SerializeField]
    private TextMeshProUGUI itemsCountTMP;

    [SerializeField]
    private SpawnPlatesManager2 spawnPlatesManager;
    public void Calculate()
    {
        allSum = 0;
        itemsCount = 0;
        foreach (var obj in spawnPlatesManager._spawnedPlates)
        {
            var properties = obj.GetComponent<PlateData>().properties;
            allSum += properties.price * properties.inBagCount;
            itemsCount += properties.inBagCount;
        }

        priceTMP.text = "$" + allSum.ToString();
        deliveryPriceTMP.text = "$" + deliveryPrice.ToString();
        fullPriceTMP.text = "$" + (allSum + deliveryPrice).ToString();
        itemsCountTMP.text = $"({itemsCount.ToString()} items)";
    }
}
