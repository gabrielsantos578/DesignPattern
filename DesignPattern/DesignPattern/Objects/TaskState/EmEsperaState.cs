using Microsoft.EntityFrameworkCore;
using SGED.Context;
using SGED.Objects.Interfaces;

namespace DesignPattern.Objects.StatusState
{
    public class EmEsperaState : IStatusState
    {
        public string State { get; } = "Em Espera";
        public bool CanEdit() => false;
        public bool CanRelate() => false;
        public bool CanToRemove() => false;
    }
}
