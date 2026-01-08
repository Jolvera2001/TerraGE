using Raylib_cs;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using TerraGE_POC.Engine;

namespace TerraGE_POC;

internal static class Program
{
    private static Script _lua = null!;
    private static TerraApi _engine = null!;
    
    public static void Main()
    {
        Raylib.InitWindow(800, 400, "Hello world!");
        Raylib.SetTargetFPS(60);

        InitLua();
        
        while (!Raylib.WindowShouldClose())
        {
            float deltaTime = Raylib.GetFrameTime();
            
            Update(deltaTime);
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            // Render();
            
            Raylib.EndDrawing();
        }
        
        Raylib.CloseWindow();
    }

    private static void InitLua()
    {
        UserData.RegisterType<TerraApi>();
        var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
        var scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");
        
        _lua = new Script();
        ((ScriptLoaderBase)_lua.Options.ScriptLoader).ModulePaths =
        [
            "scripts/?.lua",
            "scripts/?/init.lua"
        ];
        
        _engine = new TerraApi(_lua, dataPath);
        _lua.Globals["engine"] = _engine;
        
        var mainEntry = Path.Combine(scriptPath, "main.lua");
        _lua.DoFile(mainEntry);

        try
        {
            _lua.Call(_lua.Globals["initialize"]);
        }
        catch (ScriptRuntimeException ex)
        {
            Console.WriteLine($"Lua init error: {ex.DecoratedMessage}");
        }
    }

    private static void Update(float deltaTime)
    {
        // Call Lua's update function
        try {
            _lua.Call(_lua.Globals["update"], deltaTime);
        } catch (ScriptRuntimeException ex) {
            Console.WriteLine($"Lua update error: {ex.DecoratedMessage}");
        }
    }
    
    // private Static void Render() {
    //     // Render all entities based on their properties
    //     foreach (var entity in _engine.GetAllEntities()) {
    //         RenderEntity(entity);
    //     }
    // }
}