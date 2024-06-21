using DesignPattern.Objects.Interfaces;

namespace DesignPattern.Objects.TaskState
{
    public class ConcludedState : ITaskState
    {
        public bool Create(ref string error)
        {
            error = "A tarefa foi concluída, não é possível voltar para a área Criada!";
            return false;
        }

        public bool InProgress(ref string error)
        {
            error = "A tarefa foi concluída, não é possível voltar para a área Em Progresso!";
            return false;
        }

        public bool Concluded(ref string error)
        {
            error = "A tarefa já foi concluída!";
            return false;
        }

        public bool Canceled(ref string error)
        {
            error = "A tarefa foi concluída, não é possível cancelar!";
            return false;
        }
    }
}