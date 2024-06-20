using SGED.Objects.Enums;
using SGED.Objects.Interfaces;
using SGED.Objects.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SGED.Objects.DTO.Entities
{
    public class TaskDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required!")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description is required!")]
        [MaxLength(200)]
        public string Description { get; set; }

        public ETaskState State { get; set; }

        [JsonIgnore]
        public string? Error { get; set; }


        public void Create() => this.State = ITaskStateExtensions.Create(this.State, this.Error);
        public void InProgress() => this.State = ITaskStateExtensions.InProgress(this.State, this.Error);
        public void Concluded() => this.State = ITaskStateExtensions.Concluded(this.State, this.Error);
        public void Canceled() => this.State = ITaskStateExtensions.Canceled(this.State, this.Error);
        public bool ErrorOccurred() => !Operator.IsNullString(this.Error);
    }
}