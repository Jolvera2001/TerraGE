local M = {}

---@class Item
---@field id string Item Id
---@field weight number Weight of the item
local Item = {}
Item.__index = Item

function Item.new(data)
	---@type Item
	local self = setmetatable({}, Item)
	
	self.id = data.id or "unknown"
	self.name = data.name or "unknown"
	self.weight = data.weight or 1.0
	return self
end

function Item:get_weight()
	return self.weight
end

function M.load_items()
	local raw = engine.load_json("items.json")
	local items = {}
	
	for i, item_data in ipairs(raw) do
		local item = Item.new(item_data)
		
		table.insert(items, item)
	end
	
	return items
end

return M