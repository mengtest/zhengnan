﻿using System;
using UnityEngine;
using System.Collections.Generic;

using BindType = ToLuaMenu.BindType;
using Framework;
/// <summary>
/// <para>Class Introduce</para>
/// <para>Author: zhengnan</para>
/// <para>Create: 2018/6/11 0:51:47</para>
/// </summary> 
public static class CustomWrap
{
    public static BindType _GT(Type t)
    {
        return new BindType(t);
    }

    public static BindType[] typeList =
    {
        //================
        _GT(typeof(Logger)),
        _GT(typeof(AssetsManager)),
        _GT(typeof(GameManager)),
    };
}
