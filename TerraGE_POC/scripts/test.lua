local M = {}

function M.test_item_loading() 
	local test_json = engine.load_json("test.json")
	
	print("[LUA]: test_json's name: " .. test_json.name)
	print("[LUA]: test_json's description: " .. test_json.description)
	print("[LUA]: test_json's texture: " .. test_json.texture)
end

return M