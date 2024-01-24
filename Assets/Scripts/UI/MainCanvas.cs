using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
}
