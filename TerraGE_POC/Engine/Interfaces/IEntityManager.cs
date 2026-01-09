namespace TerraGE_POC.Engine.Interfaces;

public interface IEntityManager
{
    void AddEntity(Entity entity);
    IEnumerable<Entity> GetEntitiesWithComponent(Component component);
    IEnumerable<Entity> GetEntitiesWith(params Component[] components);
    void RemoveEntity(Entity entity);
}