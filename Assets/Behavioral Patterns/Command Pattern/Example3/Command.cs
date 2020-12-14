
/// <summary>
/// The 'Command' abstract class that we will inherit from
/// 命令基础接口  命令接口其实都差不多  -- 执行,撤销
/// </summary>
public interface Command
{
        void Execute();
        void UnExecute();
    }
