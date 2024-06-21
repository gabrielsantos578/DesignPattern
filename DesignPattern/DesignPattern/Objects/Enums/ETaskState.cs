using DesignPattern.Objects.Interfaces;
using DesignPattern.Objects.TaskState;

namespace DesignPattern.Objects.Enums
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
        public static string GetState(ETaskState taskEnum)
        {
            return taskEnum switch
            {
                ETaskState.Create => "Criada",
                ETaskState.InProgress => "Em Progresso",
                ETaskState.Concluded => "Concluída",
                ETaskState.Canceled => "Cancelada",
                _ => "Criada"
            };
        }
    }
}
