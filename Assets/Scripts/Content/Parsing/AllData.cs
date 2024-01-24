using System;
using System.Collections.Generic;
[Serializable]
public class Obj
{
    public string name;
    public string description;
    public float price;
    public string image;
    public bool discount;
    public bool favorite;
    public int inBagCount;
    public string type;

}
[Serializable]
public class Root
{
    public List<Type> type;
}
[Serializable]
public class Type
{
    public string name;
    public List<Obj> obj;
}

