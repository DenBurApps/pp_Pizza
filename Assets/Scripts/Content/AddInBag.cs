using UnityEngine;

public static class AddInBag
{
    public static void AddObj(bool addObj,Obj obj)
    {
        if (addObj)
        {
            if (ContentManager.allDataDic["InBag"].ContainsKey(obj.name))
            {
                ContentManager.allDataDic["InBag"][obj.name].inBagCount++;
            }
            else
            {
                ContentManager.allDataDic["InBag"].Add(obj.name,obj);

                ContentManager.allDataDic["InBag"][obj.name].inBagCount = 1;
            }
            PlayerPrefs.SetInt(obj.name + "_InBagCount",
                ContentManager.allDataDic["InBag"][obj.name].inBagCount);

        }
        else
        {
                ContentManager.allDataDic["InBag"][obj.name].inBagCount--;

                PlayerPrefs.SetInt(obj.name + "_InBagCount",
                    ContentManager.allDataDic["InBag"][obj.name].inBagCount);

                if (ContentManager.allDataDic["InBag"][obj.name].inBagCount == 0)
                    ContentManager.allDataDic["InBag"].Remove(obj.name);
        }



    }
}
