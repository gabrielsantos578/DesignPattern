using DesignPattern.Objects.Interfaces;

namespace DesignPattern.Objects.TaskState
{
    public class InProgressState : ITaskState
    {
        public bool Create(ref string error)
        {
            error = "A tarefa está em progresso, não é possível voltar para a área Criada!";
            return false;
        }

        public bool InProgress(ref string error)
        {
            error = "A tarefa já está em progresso!";
            return false;
        }

        public bool Concluded(ref string error)
        {
            error = "";
            return true;
        }

        public bool Canceled(ref string error)
        {
            error = "";
            return true;
        }
    }
}