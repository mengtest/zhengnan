---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by zheng.
--- DateTime: 2018/6/14 0:22
--- LuaMonoBehaviour
---

---@class Betel.LuaMonoBehaviour : Betel.LuaObject
local LuaObject = require("Betel.LuaObject")
local LuaMonoBehaviour = class("LuaMonoBehaviour",LuaObject)

local BehaviourFun = {"Awake","Start","OnEnable","OnDisable","OnDestroy","Update","LateUpdate","FixedUpdate"}

function LuaMonoBehaviour:Ctor()

end

function LuaMonoBehaviour:AddLuaMonoBehaviour(go,name)
    self.behaviour = nil
    for k, v in pairs(BehaviourFun) do
        if self[v] then
            self.behaviour = LuaHelper.AddLuaMonoBehaviour(go,name,v,handler(self,self[v]))
        end
    end
    return self.behaviour
end

function LuaMonoBehaviour:StartCoroutine(coFun)
    if self.coMap == nil then
        self.coMap = {}
    end
    self.coMap[coFun] = coroutine.start(function ()
        coFun()
    end)
    return self.coMap[coFun]
end

function LuaMonoBehaviour:Destroy()
    destroy(self.behaviour)
    if self.coMap then
        for _, co in pairs(self.coMap) do
            coroutine.stop(co)
        end
    end
    self.coMap = nil
end

function LuaMonoBehaviour:OnDestroy()
    self:Destroy()
end

return LuaMonoBehaviour