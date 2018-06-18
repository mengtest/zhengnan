﻿using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
/// <summary>
/// <para>Lua 代码文件生成器</para>
/// <para>Author: zhengnan</para>
/// <para>Create: 2018/6/14 1:22:28</para>
/// </summary> 
public class ToLuaGenerater
{
    readonly static string CLASS_NAME = "$CLASS_NAME$";

    readonly static string CLASS_PACKER = "$CLASS_PACKER$";

    readonly static string SUPER_CLASS_NAME = "$SUPER_CLASS_NAME$";

    readonly static string SUPER_CLASS_PACKER = "$SUPER_CLASS_PACKER$";

    //一般的类文件
    readonly static string LuaClassFile =
@"---
--- Generated by Tools
--- Created by {0}.
--- DateTime: {1}
---

---@class $CLASS_PACKER$.$CLASS_NAME$ : Core.LuaObject
local LuaObject = require('Core.LuaObject')
local $CLASS_NAME$ = class('$CLASS_NAME$',LuaObject)

function $CLASS_NAME$:Ctor()
    
end

return $CLASS_NAME$
";

    //Mediator类文件
    readonly static string LuaMdrClassFile =
@"---
--- Generated by Tools
--- Created by {0}.
--- DateTime: {1}
---

---@class $CLASS_PACKER$.$CLASS_NAME$Mdr : Core.Ioc.BaseMediator
local BaseMediator = require('Core.Ioc.BaseMediator')
local $CLASS_NAME$Mdr = class('$CLASS_NAME$Mdr',BaseMediator)

function $CLASS_NAME$Mdr:OnInit()
    
end

return $CLASS_NAME$Mdr
";
    //有继承的类文件
    readonly static string LuaSuperClassFile =
@"---
--- Generated by Tools
--- Created by {0}.
--- DateTime: {1}
---

local $SUPER_CLASS_NAME$ = require('$SUPER_CLASS_PACKER$')
local $CLASS_NAME$ = class('$CLASS_NAME$',$SUPER_CLASS_NAME$)

function $CLASS_NAME$:Ctor()
    
end

return $CLASS_NAME$
";
    
    /// <summary>
    /// 生成 Mediator 文件
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="viewName">viewName</param>
    public static void GeneratedMediatorFile(string path,string viewName)
    {
        string mdrFileText = LuaMdrClassFile;
        mdrFileText = string.Format(mdrFileText, SystemUtils.GetSystemUserName(), TimeUtils.NowString());
        string packerName = GetLuaPackerNameByPath(path);//包名
        mdrFileText = StringUtils.ReplaceAll(mdrFileText, CLASS_PACKER, packerName);
        mdrFileText = StringUtils.ReplaceAll(mdrFileText, CLASS_NAME, viewName);
        mdrFileText = StringUtils.ReplaceAll(mdrFileText, "'", "\"");
        //Debug.Log(mdrFileText);
        string mdrFilePath = path + viewName + "Mdr.lua";
        if (!File.Exists(mdrFilePath))
            FileUtils.SaveTextFile(mdrFilePath, mdrFileText);
        else
        {
            bool replace = EditorUtility.DisplayDialog("提示", "文件以及存在,是否替换?", "替换", "取消");
            if (replace)
                FileUtils.SaveTextFile(mdrFilePath, mdrFileText);
        }
        EditorUtility.DisplayDialog("提示", "生成 Mediator 文件成功", "确定");
    }

    //根据路径获得包名
    static string GetLuaPackerNameByPath(string path)
    {
        path = StringUtils.ReplaceAll(path, "\\", "/");
        path = path.Replace(Application.dataPath + "/Lua/", "");
        string packer = StringUtils.ReplaceAll(path, "\\", ".");
        packer = StringUtils.ReplaceAll(path, "/", ".");
        if (packer.EndsWith("."))
            packer = packer.Substring(0, packer.Length - 1);
        return packer;
    }
}

