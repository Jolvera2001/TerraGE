namespace TerraGE_POC.Engine;

public class Entity : IEntity
{
    public string Id { get; } = Guid.NewGuid().ToString();

    public object GetProperty(string name)
    {
        throw new NotImplementedException();
    }

    public void SetProperty(string name, object value)
    {
        throw new NotImplementedException();
    }
}