using DesignPattern.Objects.TaskState;
using DesignPattern.Objects.Enums;

namespace DesignPattern.Objects.Interfaces
{
    public interface ITaskState
    {
        bool Create(ref string error);
        bool InProgress(ref string error);
        bool Concluded(ref string error);
        bool Canceled(ref string error);
    }

    public static class ITaskStateExtensions
    {
        private static ITaskState CreateState(ETaskState taskEnum)
        {
            return taskEnum switch
            {
                ETaskState.Create => new CreateState(),
                ETaskState.InProgress => new InProgressState(),
                ETaskState.Concluded => new ConcludedState(),
                ETaskState.Canceled => new CanceledState(),
                _ => new CreateState()
            };
        }

        public static ETaskState Create(ETaskState taskEnum, ref string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.Create(ref error) ? ETaskState.Create : taskEnum;
        }

        public static ETaskState InProgress(ETaskState taskEnum, ref string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.InProgress(ref error) ? ETaskState.InProgress : taskEnum;
        }

        public static ETaskState Concluded(ETaskState taskEnum, ref string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.Concluded(ref error) ? ETaskState.Concluded : taskEnum;
        }

        public static ETaskState Canceled(ETaskState taskEnum, ref string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.Canceled(ref error) ? ETaskState.Canceled : taskEnum;
        }
    }
}
