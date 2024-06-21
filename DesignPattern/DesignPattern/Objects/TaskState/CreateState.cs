using DesignPattern.Objects.Interfaces;

namespace DesignPattern.Objects.TaskState
{
    public class CreateState : ITaskState
    {
        public bool Create(ref string error)
        {
            error = "A tarefa já foi criada!";
            return false;
        }

        public bool InProgress(ref string error)
        {
            error = "";
            return true;
        }

        public bool Concluded(ref string error)
        {
            error = "Não é possível concluir a tarefa pois não foi realizado os itens!";
            return false;
        }

        public bool Canceled(ref string error)
        {
            error = "";
            return true;
        }
    }
}