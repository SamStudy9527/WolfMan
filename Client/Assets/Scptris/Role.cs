using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 身份枚举 </summary>
public enum Identity
{
    Bad,
    Good
}

/// <summary> 阵营枚举 </summary>
public enum Camp
{
    WolfMan,
    Man,
    God,
}

public class Role : MonoBehaviour
{


    public void Init(Sprite roleId)
    {
        GameObject deal = Resources.Load("Deal") as GameObject;
        for (int i = 0; i < 9; i++)
        {
            var temp = Instantiate(deal, Vector3.zero, Quaternion.identity);
            temp.transform.parent = null;
            Image tempImage = temp.GetComponent<Image>();
            tempImage.sprite = roleId;
        }
    }

   
}
