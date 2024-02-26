using UnityEngine;

public static class AddInBag
{
    public static void AddObj(bool addObj,Obj obj)
    {
        if (addObj)
        {
            if (ContentManager.allDataDic["InBag"].ContainsKey(obj.image))
            {
                ContentManager.allDataDic["InBag"][obj.image].inBagCount++;
            }
            else
            {
                ContentManager.allDataDic["InBag"].Add(obj.image, obj);

                ContentManager.allDataDic["InBag"][obj.image].inBagCount = 1;
            }
            PlayerPrefs.SetInt(obj.image + "_InBagCount",
                ContentManager.allDataDic["InBag"][obj.image].inBagCount);

        }
        else
        {
                ContentManager.allDataDic["InBag"][obj.image].inBagCount--;

                PlayerPrefs.SetInt(obj.image + "_InBagCount",
                    ContentManager.allDataDic["InBag"][obj.image].inBagCount);

                if (ContentManager.allDataDic["InBag"][obj.image].inBagCount == 0)
                    ContentManager.allDataDic["InBag"].Remove(obj.image);
        }



    }
}
