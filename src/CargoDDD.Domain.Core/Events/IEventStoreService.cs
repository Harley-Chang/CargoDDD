namespace CargoDDD.Domain.Core.Events;
/// <summary>
/// 事件存储服务
/// 由应用层实现
/// </summary>
public interface IEventStoreService
{
    /// <summary>
    /// 将已经发生的事件进行存储
    /// 必要的时候进行事件溯源
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    /// <param name="event">Event命令，例如CargoBookedEvent</param>
    /// <returns></returns>
    Task Save<T>(T @event) where T : Event;
}
