﻿using System;
using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// <para>管理基础类</para>
/// <para>Author: zhengnan</para>
/// <para>Create: 2018/6/10 0:18:45</para>
/// </summary> 
/// 
namespace Framework
{
    public class BaseManager : MonoBehaviour
    {
        static Dictionary<string, BaseManager> s_mgrDict;

        public static void AddManager(BaseManager mgr)
        {
            if (s_mgrDict == null)
                s_mgrDict = new Dictionary<string, BaseManager>();
            s_mgrDict.Add(mgr.GetType().Name, mgr);
        }

        public static T GetManager<T>() where T : BaseManager
        {
            T t = default(T);
            return s_mgrDict[typeof(T).Name] as T;
        }

        public static GameManager GetGameManager()
        {
            return GetManager<GameManager>();
        }

        public static AssetsManager GetAssetsManager()
        {
            return GetManager<AssetsManager>();
        }

        public static SceneManager GetSceneManager()
        {
            return GetManager<SceneManager>();
        }
    }
}


