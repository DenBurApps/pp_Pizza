using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    public static ContentManager instance;
    public static Root allData;
    public TextAsset CurrentJson;
    public int currentJsonNumber;
    public List<TextAsset> AllJsons = new List<TextAsset>();
    public List<TMP_FontAsset> tMP_Fonts = new List<TMP_FontAsset>();

    private void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this;

/*        if (checkRoutine != null)
        {
            StopCoroutine(checkRoutine);
        }
        checkRoutine = StartCoroutine(GetAllData());*/
    }

    Coroutine checkRoutine;
    IEnumerator GetAllData()
    {
        string jsonContent = CurrentJson.ToString();

        //string jsonContent = System.IO.File.ReadAllText(Application.dataPath + "/" + JsonFileName);
        allData = JsonUtility.FromJson<Root>(jsonContent);
        yield return allData;
        FillDataInDictionary();
    }
    public static Dictionary<string,Dictionary<string,Obj>> allDataDic 
    { get; private set; } = new Dictionary<string, Dictionary<string, Obj>>(); //Dictionary<type, Dictionary<obj.name, Obj>>

    private void FillDataInDictionary()
    {

        Dictionary<string, Obj> discountDic = new Dictionary<string, Obj>();
        Dictionary<string, Obj> favDic = new Dictionary<string, Obj>();
        Dictionary<string, Obj> inBagDic = new Dictionary<string, Obj>();

        foreach (var item in allData.type)
        {
            Dictionary<string, Obj> objDic = new Dictionary<string, Obj>();

            foreach (var obj in item.obj)
            {
                obj.type = item.name;
                objDic.Add(obj.image, obj);
                if (obj.discount)
                    discountDic.Add(obj.image, obj);

                if(CheckPlayerPrefs(obj.image + "_Fav"))
                    favDic.Add(obj.image, obj);

                if (PlayerPrefs.HasKey(obj.image + "_InBagCount"))
                {
                    if(PlayerPrefs.GetInt(obj.image + "_InBagCount") > 0)
                    {
                        inBagDic.Add(obj.image, obj);

                        inBagDic[obj.image].inBagCount =
                            PlayerPrefs.GetInt(obj.image + "_InBagCount");
                    }
                }
            }
            allDataDic.Add(item.name, objDic);
        }
        allDataDic.Add("Sales", discountDic);
        allDataDic.Add("favorite", favDic);
        allDataDic.Add("InBag", inBagDic);

        Debug.Log("Sales " + allDataDic["Sales"].Count);
        Debug.Log("favorite " + allDataDic["favorite"].Count);
        Debug.Log("InBag " + allDataDic["InBag"].Count);

        bool CheckPlayerPrefs(string image)
        {
            if (PlayerPrefs.HasKey(image))
            {
                if (Convert.ToBoolean(PlayerPrefs.GetInt(image)))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public void ChangeCurrentJson(int jsonId)
    {
        allDataDic = new Dictionary<string, Dictionary<string, Obj>>();
        currentJsonNumber = jsonId;
        CurrentJson = AllJsons[jsonId];
        if (checkRoutine != null)
        {
            StopCoroutine(checkRoutine);
        }
        checkRoutine = StartCoroutine(GetAllData());
    }
}
