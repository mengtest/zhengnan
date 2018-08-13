---
--- Generated by Tools
--- Created by zheng.
--- DateTime: 2018-08-14-00:07:11
---

---@class Modules.Role.Vo.RoleVo : Core.Ioc.BaseVo
local BaseVo = require("Core.Ioc.BaseVo")
local RoleVo = class("RoleVo",BaseVo)

function RoleVo:Ctor(roleInfo)
    self.id = roleInfo.id;
    self.playerId = roleInfo.playerId
    self.roleName = roleInfo.roleName
    self.onlineTime = roleInfo.onlineTime

    self.clientOnlineTime = Time.time--角色上线游戏时间(受到游戏帧频影响)(单位:毫秒)
    self.clientOnlineRealTime = Time.realtimeSinceStartup--角色上线实际时间(单位:毫秒)
end

function RoleVo:GetTotalOnlineTime()
    return Time.time - self.clientOnlineTime
end

function RoleVo:GetRealTotalOnlineTime()
    return Time.realtimeSinceStartup - self.clientOnlineRealTime
end

return RoleVo
