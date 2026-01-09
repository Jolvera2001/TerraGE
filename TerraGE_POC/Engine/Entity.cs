using MoonSharp.Interpreter;
using TerraGE_POC.Engine.Interfaces;

namespace TerraGE_POC.Engine;

[MoonSharpUserData]
public class Entity
{
    private Script _lua;
    public string Id { get; }
    public Dictionary<string, Table> Components { get; set; }
    public Script? ScriptInstance { get; set; }

    public Entity(Script lua, string? id = null, Script? associatedScript = null)
    {
        _lua = lua;
        Id = id ?? Guid.NewGuid().ToString();
        ScriptInstance = associatedScript;
        Components = new Dictionary<string, Table>();
    }

    public Script? GetScript()
    {
        return ScriptInstance;
    }
}