using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlatesManager2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _platePrefab;
    public List<GameObject> _spawnedPlates { get; private set; } = new List<GameObject>();
    [SerializeField]
    private Transform spawnTransform;
    [SerializeField]
    private string spawnType;
    [SerializeField]
    private List<GameObject> foodPlates = new List<GameObject>();

    private void OnEnable()
    {
        ClearAllPlates();
        SpawnAllPlates();
    }
    private void ClearAllPlates()
    {
        foreach (Transform item in spawnTransform)
        {
            Destroy(item.gameObject);
        }
        _spawnedPlates.Clear();
    }
    public void SpawnAllPlates()
    {
        List<string> list = new List<string>();
        List<string> typesList = new List<string>();

        foreach (var obj in ContentManager.allDataDic[spawnType].Keys)
        {
            list.Add(obj);
            if(!typesList.Contains(ContentManager.allDataDic[spawnType][obj].type))
                typesList.Add(ContentManager.allDataDic[spawnType][obj].type);
        }
        for (int i = 0; i < typesList.Count; i++)
        {
            foreach (var item in foodPlates)
                if(item.name == typesList[i])
                    Instantiate(item, spawnTransform);

            for (int j = 0; j < ContentManager.allDataDic[spawnType].Count; j++)
            {
                if(ContentManager.allDataDic[spawnType][list[j]].type == typesList[i])
                {
                    var obj = Instantiate(_platePrefab, spawnTransform);
                    _spawnedPlates.Add(obj);

                    obj.GetComponent<PlateData>().SetDataInPlate(ContentManager.allDataDic[spawnType][list[j]]);
                }

            }
        }
        CalculateCost.Instance.Calculate();
    }
}

