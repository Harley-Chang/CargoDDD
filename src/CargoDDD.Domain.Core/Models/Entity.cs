namespace CargoDDD.Domain.Core.Models;
public abstract class Entity
{
    /// <summary>
    /// Identity
    /// </summary>
    public Guid Id { get; protected set; }
}
