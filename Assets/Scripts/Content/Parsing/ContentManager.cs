using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    public static Root allData;
    string JsonFileName = "obj.json";
    public TextAsset json;
    private void Start()
    {
        if (checkRoutine != null)
        {
            StopCoroutine(checkRoutine);
        }
        checkRoutine = StartCoroutine(GetAllData());
    }

    Coroutine checkRoutine;
    IEnumerator GetAllData()
    {
        string jsonContent = json.ToString();

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
                objDic.Add(obj.name, obj);
                if (obj.discount)
                    discountDic.Add(obj.name,obj);

                if(CheckPlayerPrefs(obj.name + "_Fav"))
                    favDic.Add(obj.name,obj);

                if (PlayerPrefs.HasKey(obj.name + "_InBagCount"))
                {
                    if(PlayerPrefs.GetInt(obj.name + "_InBagCount") > 0)
                    {
                        inBagDic.Add(obj.name, obj);

                        inBagDic[obj.name].inBagCount =
                            PlayerPrefs.GetInt(obj.name + "_InBagCount");
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

        bool CheckPlayerPrefs(string name)
        {
            if (PlayerPrefs.HasKey(name))
            {
                if (Convert.ToBoolean(PlayerPrefs.GetInt(name)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
