using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlatesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _platePrefab;

    [SerializeField]
    private List<GameObject> _spawnedPlates = new List<GameObject>();
    [SerializeField]
    private Transform spawnTransform;
    [SerializeField]
    private TextMeshProUGUI screenName;
    private void Update()
    {
        if (_canSpawnPlates)
        {
            SpawnPlatesWave();
        }
    }
    private void OnEnable()
    {
        if (spawnType != "" && spawnType != null) 
            _canSpawnPlates = true;
        ClearAllPlates();
    }
    [SerializeField]
    private string spawnType;
    public void ChangeSpawnType(string type,string screenName)
    {
        spawnType = type;
        this.screenName.text = screenName;
        SpawnPlatesWave();
    }

    private void SpawnPlatesWave()
    {
        _canSpawnPlates = false;
        int spawnWaveCount = 8;
        List<string> list = new List<string>();
        foreach(var obj in ContentManager.allDataDic[spawnType].Keys)
        {
            list.Add(obj);

        }
        for (int i = 0; i < spawnWaveCount; i++)
        {
            if (_spawnedPlates.Count < ContentManager.allDataDic[spawnType].Count)
            {
                var obj = Instantiate(_platePrefab, spawnTransform);
                obj.GetComponent<PlateData>().SetDataInPlate(ContentManager.allDataDic[spawnType][list[i]]);
                _spawnedPlates.Add(obj);
            }
        }
        _canSpawnPlates = true;
    }
    private bool _canSpawnPlates;

    private void ClearAllPlates()
    {
        foreach (Transform item in spawnTransform)
        {
            Destroy(item.gameObject);
        }
        _spawnedPlates.Clear();
    }
}

