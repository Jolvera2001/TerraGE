local test = require('test')
local items = require('items')

function initialize() 
	test.test_item_loading()
	
	local item_list = items.load_items()
	
	for i, item in ipairs(item_list) do
		print("[LUA]: ======== ITEM LOADED ========")
		print("[LUA]: Item id: " .. item.id)
		print("[LUA]: Item name: " .. item.name)
		print("[LUA]: Item weight: " .. item.weight)
	end
end

function update()

end