using DesignPattern.Objects.Interfaces;

namespace DesignPattern.Objects.TaskState
{
    public class CanceledState : ITaskState
    {
        public bool Create(ref string error)
        {
            error = "A tarefa foi cancelada, não é possível voltar para a área Criada!";
            return false;
        }

        public bool InProgress(ref string error)
        {
            error = "A tarefa foi cancelada, não é possível voltar para a área Em Progresso!";
            return false;
        }

        public bool Concluded(ref string error)
        {
            error = "A tarefa foi cancelada, não é possível concluir!";
            return false;
        }

        public bool Canceled(ref string error)
        {
            error = "A tarefa já foi cancelada!";
            return false;
        }
    }
}