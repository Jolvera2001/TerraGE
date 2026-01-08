using MoonSharp.Interpreter;

namespace TerraGE_POC.Engine.Interfaces;

public interface ITerraApi
{
    // ***********    IO RELATED    ***********
    public Table LoadJson(string path);
    
    // ***********  ENTITY RELATED  ***********
    public Entity CreateEntity(string id);
    public Entity CreateEntity(Table? properties, string id);
    public Entity? GetEntity(string id);
    public void DestroyEntity(string id);
    public object GetProperty(Entity entity, string property);
    public void SetProperty(Entity entity, string property, object value);
    
    // ***********   EVENT RELATED  ***********
    public void EmitEvent(string eventName, Table data);
    public void Subscribe(string eventName, DynValue callback);

    // *********** GRAPHICS RELATED ***********
    public void DrawSprite(string texture, float x, float y);
    
    // ***********   AUDIO RELATED  ***********
    public void PlaySound(string soundId);
}