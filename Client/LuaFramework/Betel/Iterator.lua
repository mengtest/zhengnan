---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by zhengnan.
--- DateTime: 2020/1/8 12:07
--- 迭代器
---

local LuaObject = require("Betel.LuaObject")
---@class Iterator : Betel.LuaObject
---@field New fun(table:table<number, any>) : Iterator
---@field list List
---@field private _current any
---@field private _icout number
local Iterator = class("Iterator",LuaObject)

function Iterator:Ctor(table)
    Iterator.super.Ctor(self, table)
    self.list = List.New(table)
    self._icout = 1
end

function Iterator:MoveNext()
    if self._icout >= self.list:Size() then
        return false;
    else
        self._current = self.list[self._icout];
        self._icout = self._icout + 1;
        return true;
    end
end

function Iterator:Reset()
    self._icout = 1
end

function Iterator:Add(t)
    self.list:Add(t)
end

function Iterator:Remove(t)
    if self.list:Contain(t) then
        if self.list:IndexOf(t) <= self._icout then
            self._icout = self._icout - 1;
        end
        self.list:Remove(t);
    end
end

return Iterator