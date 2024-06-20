using SGED.Objects.Enums;

namespace SGED.Objects.Interfaces
{
    public interface ITaskState
    {
        bool Create(string error);
        bool InProgress(string error);
        bool Concluded(string error);
        bool Canceled(string error);
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

        public static ETaskState Create(ETaskState taskEnum, string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.Create(error) ? ETaskState.Create : taskEnum;
        }

        public static ETaskState InProgress(ETaskState taskEnum, string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.InProgress(error) ? ETaskState.InProgress : taskEnum;
        }

        public static ETaskState Concluded(ETaskState taskEnum, string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.Concluded(error) ? ETaskState.Concluded : taskEnum;
        }

        public static ETaskState Canceled(ETaskState taskEnum, string error)
        {
            ITaskState taskInterface = CreateState(taskEnum);
            return taskInterface.Canceled(error) ? ETaskState.Canceled : taskEnum;
        }
    }
}
