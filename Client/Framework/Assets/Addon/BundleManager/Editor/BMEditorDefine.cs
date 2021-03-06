﻿using System;
using UnityEngine;
using UnityEditor;

namespace BM
{
    /// <summary>
    /// <para>打包平台</para>
    /// <para>Author: zhengnan</para>
    /// <para>Create: 2019/6/12 0:24:39</para>
    /// </summary> 
    public static class Platform
    {
        public static string GetPlatformName(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return "Android";
                case BuildTarget.iOS:
                    return "IOS";
                case BuildTarget.StandaloneWindows64:
                    return "Windows";
                case BuildTarget.StandaloneOSX:
                    return "OSX";
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// 文件类型
    /// </summary>
    public static class FileType
    {
        //材质贴图 "*.psd|*.tiff|*.jpg|*.jpeg|*.tga|*.png|*.gif"
        public static string[] Texture = new string[] { ".psd", ".tiff", ".jpg", ".tga", ".png", ".gif", ".tif" };
        //材质球 
        public static string[] Material = new string[] { ".mat" };
        //场景文件
        public static string[] Scene = new string[] { ".unity" };
        //模型文件 
        public static string[] Model = new string[] { ".fbx", ".obj" };
        //预制件 
        public static string[] Prefab = new string[] { ".prefab" };

        public static bool IsValidFileType(string[] types, string fileFullName)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (fileFullName.EndsWith(types[i]))
                    return true;
            }
            return false;
        }
    }

}


