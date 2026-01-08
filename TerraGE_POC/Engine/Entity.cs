using MoonSharp.Interpreter;
using TerraGE_POC.Engine.Interfaces;

namespace TerraGE_POC.Engine;

[MoonSharpUserData]
public class Entity
{
    private Script _lua;
    public string Id { get; }
    public Table Properties { get; }

    public Entity(Script lua, string? id = null)
    {
        _lua = lua;
        Id = id ?? Guid.NewGuid().ToString();
        Properties = new Table(lua);
    }
}