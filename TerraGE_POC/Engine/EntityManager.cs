namespace TerraGE_POC.Engine;

public enum Component
{
    Sprite2D,
    Transform2D,
    Script
}

public class EntityManager
{
    private Dictionary<Component, HashSet<Entity>> _entities = new();
}