using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWidthToFullScreen : MonoBehaviour
{
    private void FixedUpdate()
    {
        var rt = transform.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(MainCanvas.instance.transform.GetComponent<RectTransform>().sizeDelta.x, rt.sizeDelta.y);
    }
}
