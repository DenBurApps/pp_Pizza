using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorOnEmptyCart : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public void OnClick()
    {
        if (ContentManager.allDataDic["InBag"].Count == 0)
        {
            animator.SetTrigger("OnOff");
        }
    }
}
