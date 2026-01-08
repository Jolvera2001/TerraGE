namespace TerraGE_POC;

public interface IEntity
{
    public object GetProperty(string name);
    public void SetProperty(string name, object value);
}