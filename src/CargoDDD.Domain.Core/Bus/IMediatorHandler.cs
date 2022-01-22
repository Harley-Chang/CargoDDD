using CargoDDD.Domain.Commands;
using CargoDDD.Domain.Core.Events;

namespace CargoDDD.Domain.Core.Bus;
public interface IMediatorHandler
{
    /// <summary>
    /// 接收应用层转化后的命令，并将其发送到中介者
    /// </summary>
    /// <typeparam name="T">泛型T</typeparam>
    /// <param name="command">命令模型，例如：BookCargoCommand</param>
    /// PS:注意动名词顺序，动作+名词+Command
    /// <returns></returns>
    Task SendCommand<T>(T command) where T : Command;

    /// <summary>
    /// 发布事件
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    /// <param name="event">事件模型，例如CargoBookedEvent</param>
    /// PS:注意动名词顺序，名词+已发生动作+Event
    /// <returns></returns>
    Task PublishEvent<T>(T @event) where T : Event;
}
