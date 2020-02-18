using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
  
    /// <summary> 角色身份 </summary>
    Dictionary<int, Identity> RoleIdentity = new Dictionary<int, Identity>();
    /// <summary> 角色阵营 </summary>
    Dictionary<int, Camp> RoleCamp = new Dictionary<int, Camp>();
    /// <summary> 角色阵营剩余人数 </summary>
    private int GodCamp, ManCamp, WolfMan;


    /// <summary> 身份枚举 </summary>
    private enum Identity
    {
        Bad,
        Good
    }

    /// <summary> 阵营枚举 </summary>
    private enum Camp
    {
        WolfMan,
        Man,
        God,
    }

    void Init()
    {
        for (int i = 0; i < 9; i++)
        {

        }
    }

}
