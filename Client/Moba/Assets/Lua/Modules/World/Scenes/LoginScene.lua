---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by zheng.
--- DateTime: 2018/6/30 0:02
---

---@class Modules.World.Scenes.LoginScene : Modules.World.Scenes.BaseScene
local BaseScene = require('Modules.World.Scenes.BaseScene')
local LoginScene = class("BaseScene",BaseScene)

function LoginScene:Ctor()
    BaseScene.Ctor(self)
end

return LoginScene