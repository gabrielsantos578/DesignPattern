using System.ComponentModel.DataAnnotations.Schema;
using SGED.Objects.Enums;

namespace SGED.Objects.Models.Entities
{
    [Table("task")]
    public class TaskModel
    {
        [Column("idtask")]
        public int Id { get; set; }

        [Column("nametask")]
        public string Name { get; set; }

        [Column("descriptiontask")]
        public string Description { get; set; }

        [Column("statetask")]
        public ETaskState State { get; set; }
    }
}