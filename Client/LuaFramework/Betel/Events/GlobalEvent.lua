---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by zhengnan.
--- DateTime: 2019/5/20 17:30
---

local _handler = handler
local _Map = {}

---@param type string
---@param handler fun()
function AddEventListener(type, callback, caller)
    if _Map[callback] ~= nil then
        logError("re register event!")
        return
    end
    local handler = _handler(caller, callback)
    _Map[callback] = handler
    if type == Event.Update then
        monoMgr:AddUpdateFun(handler)
    elseif type == Event.LateUpdate then
        monoMgr:AddLateUpdateFun(handler)
    elseif type == Event.FixedUpdate then
        monoMgr:AddFixedUpdateFun(handler)
    end
end

function RemoveEventListener(type, callback)
    if _Map[callback] == nil then
        return
    end
    local handler = _Map[callback]
    if type == Event.Update then
        monoMgr:RemoveUpdateFun(handler)
    elseif type == Event.LateUpdate then
        monoMgr:RemoveLateUpdateFun(handler)
    elseif type == Event.FixedUpdate then
        monoMgr:RemoveFixedUpdateFun(handler)
    end
end