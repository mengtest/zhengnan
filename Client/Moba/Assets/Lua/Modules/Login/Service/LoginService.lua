---
--- Generated by Tools
--- Created by zhengnan.
--- DateTime: 2018-06-19-16:04:56
---

LoginAction = {}

LoginAction.LoginAccount = {server = "AccountServer",action = "login_account", data = "%s&%s"}

LoginAction.LoginGameServer = {server = "GameServer",action = "login_game_server", data = "%s&%s"}

---@class Modules.Login.Service.LoginService : Core.Ioc.BaseService
local BaseService = require("Core.Ioc.BaseService")
local LoginService = class("LoginService",BaseService)

function LoginService:Ctor()
    
end

function LoginService:HttpLogin(username,password,callback)
    nmgr:HttpRqst("http://127.0.0.1:8080",LoginAction.LoginAccount,  function (data)
        self.loginModel.serverList = data.srvList.list
        self.loginModel.aid = data.aid
        self.loginModel.token = data.token
        callback(data)
    end, username,password)
end

function LoginService:LoginGameServer(aid,token,callback)
    nmgr:Request(LoginAction.LoginGameServer, function (data)
        self.loginModel.serverList = data.srvList.list
        callback(data)
    end, aid, token)
end

return LoginService
