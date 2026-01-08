using System.Text.Json;
using MoonSharp.Interpreter;
using TerraGE_POC.Engine.Interfaces;

namespace TerraGE_POC.Engine;

[MoonSharpUserData]
public partial class TerraApi : ITerraApi
{
    private readonly Script _lua;
    private string _dataPath;
    private Dictionary<string, List<DynValue>> _eventSubscribers = new();

    public TerraApi(Script lua, string dataPath = "data")
    {
        _lua = lua;
        _dataPath = dataPath;
    }

    public Table LoadJson(string path)
    {
        var fullPath = Path.Combine(_dataPath, path);

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException($"JSON file not found: {fullPath}");
        }
        
        var json = File.ReadAllText(fullPath);
        var jsonDoc = JsonDocument.Parse(json);
        return ConvertToTable(jsonDoc.RootElement);
    }

    public void CreateEntity(Table entity)
    {
        throw new NotImplementedException();
    }

    public Entity GetEntity(Guid id)
    {
        throw new NotImplementedException();
    }

    public void DestroyEntity(Guid id)
    {
        throw new NotImplementedException();
    }

    public object GetProperty(Entity entity, string property)
    {
        throw new NotImplementedException();
    }

    public void SetProperty(Entity entity, string property, object value)
    {
        throw new NotImplementedException();
    }

    public void EmitEvent(string eventName, Table data)
    {
        if (!_eventSubscribers.TryGetValue(eventName, out var subscribers)) return;
        foreach (var callback in subscribers)
        {
            _lua.Call(callback, data);
        }
    }

    public void Subscribe(string eventName, DynValue callback)
    {
        if (!_eventSubscribers.ContainsKey(eventName))
        {
            _eventSubscribers[eventName].Add(callback);
        }
    }

    public void DrawSprite(string texture, float x, float y)
    {
        throw new NotImplementedException();
    }

    public void PlaySound(string soundId)
    {
        throw new NotImplementedException();
    }

    private Table ConvertToTable(JsonElement element)
    {
        var table = new Table(_lua);

        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var prop in element.EnumerateObject())
                {
                    table[prop.Name] = ConvertToValue(prop.Value);
                }

                break;

            case JsonValueKind.Array:
                int index = 1;
                foreach (var item in element.EnumerateArray())
                {
                    table[index++] = ConvertToValue(item);
                }

                break;
        }

        return table;
    }

    private DynValue ConvertToValue(JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
            case JsonValueKind.Array:
                return DynValue.NewTable(ConvertToTable(element));

            case JsonValueKind.String:
                return DynValue.NewString(element.GetString());

            case JsonValueKind.Number:
                return DynValue.NewNumber(element.GetDouble());

            case JsonValueKind.True:
                return DynValue.NewBoolean(true);

            case JsonValueKind.False:
                return DynValue.NewBoolean(false);

            case JsonValueKind.Null:
            case JsonValueKind.Undefined:
                return DynValue.Nil;

            default:
                return DynValue.Nil;
        }
    }
}