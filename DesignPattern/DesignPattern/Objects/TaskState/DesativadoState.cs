using Microsoft.EntityFrameworkCore;
using SGED.Context;
using SGED.Objects.Interfaces;

namespace DesignPattern.Objects.StatusState
{
    public class DesativadoState : IStatusState
    {
        public string State { get; } = "Desativado";
        public bool CanEdit() => false;
        public bool CanRelate() => false;
        public bool CanToRemove() => false;
    }
}
