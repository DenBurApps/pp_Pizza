using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewContentWindow : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    [SerializeField]
    private Transform spawnTransform;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private string type;
    private GameObject spawnedWindow;
    [SerializeField]
    private string screenName;
    private void OnClick()
    {
        if(spawnedWindow == null)
        {
            spawnedWindow = Instantiate(prefab, spawnTransform);
            spawnedWindow.GetComponent<SpawnPlatesManager>().ChangeSpawnType(type, screenName);
        }
        else
        {
            spawnedWindow.SetActive(true);
        }
    }
}
