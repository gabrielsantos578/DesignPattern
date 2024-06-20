using SGED.Objects.Interfaces;

namespace SGED.Objects.Enums
{
    public enum ETaskState
    {
        Create = 1,
        InProgress = 2,
        Concluded = 3,
        Canceled = 4
    }

    public static class ETaskStateExtensions
    {
        public static ETaskState Create(ETaskState taskState, string error) => ITaskStateExtensions.Create(taskState, error);

        public static ETaskState InProgress(ETaskState taskState, string error) => ITaskStateExtensions.InProgress(taskState, error);

        public static ETaskState Concluded(ETaskState taskState, string error) => ITaskStateExtensions.Concluded(taskState, error);

        public static ETaskState Canceled(ETaskState taskState, string error) => ITaskStateExtensions.Canceled(taskState, error);
    }
}
