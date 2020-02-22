using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleManager : MonoBehaviour
{

    /// <summary> 角色身份 </summary>
    Dictionary<int, Identity> RoleIdentity = new Dictionary<int, Identity>();
    /// <summary> 角色阵营 </summary>
    Dictionary<int, Camp> RoleCamp = new Dictionary<int, Camp>();
    /// <summary> 角色阵营剩余人数 </summary>
    private int GodCamp, ManCamp, WolfMan;
    [SerializeField]
    private Sprite Man, Wolf, Prophet, Huntsman, Witch;
    private Vector3[] vector3s = new Vector3[12];

    public Identity Identity;
    public Camp Camp;


    private void Awake()
    {
        AddVector3();
        StartDeal();
        Instantiation(3, Man, Identity.Good, Camp.Man);
        Instantiation(3, Wolf, Identity.Bad, Camp.WolfMan);
        Instantiation(1, Prophet, Identity.Good, Camp.God);
        Instantiation(1, Huntsman, Identity.Good, Camp.God);
        Instantiation(1, Witch, Identity.Good, Camp.God);

    }

    private void AddVector3()
    {
        int x = 340;
        Vector3 vector3;
        GameObject temp = Resources.Load("Deal") as GameObject;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j % 2 != 0)
                {
                    vector3 = new Vector3(x, -120, 0);
                }
                else
                {
                    vector3 = new Vector3(x, 75, 0);
                }
                GameObject game = Instantiate(temp, Vector3.zero, Quaternion.identity, transform);
                RectTransform rectTransform = game.GetComponent<RectTransform>();
                rectTransform.localPosition = vector3;
            }
            x -= 132;
        }
    }

    private void StartDeal()
    {


    }

    private void Instantiation(int count, Sprite id, Identity identity, Camp camp)
    {
        for (int i = 0; i < count; i++)
        {
            //RoleIdentity .Add ()
        }
    }

}
