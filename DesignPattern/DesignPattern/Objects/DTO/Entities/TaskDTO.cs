using DesignPattern.Objects.Enums;
using DesignPattern.Objects.Interfaces;
using DesignPattern.Objects.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesignPattern.Objects.DTO.Entities
{
    public class TaskDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required!")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description is required!")]
        [MinLength(10)]
        [MaxLength(300)]
        public string Description { get; set; }

        public ETaskState State { get; set; }

        [JsonIgnore]
        public string? Error { get; set; }


        public bool Create()
        {
            string? tempError = this.Error;
            this.State = ITaskStateExtensions.Create(this.State, ref tempError);
            this.Error = tempError;
            return Operator.IsNullString(this.Error);
        }

        public bool InProgress()
        {
            string? tempError = this.Error;
            this.State = ITaskStateExtensions.InProgress(this.State, ref tempError);
            this.Error = tempError;
            return Operator.IsNullString(this.Error);
        }

        public bool Concluded()
        {
            string? tempError = this.Error;
            this.State = ITaskStateExtensions.Concluded(this.State, ref tempError);
            this.Error = tempError;
            return Operator.IsNullString(this.Error);
        }

        public bool Canceled()
        {
            string? tempError = this.Error;
            this.State = ITaskStateExtensions.Canceled(this.State, ref tempError);
            this.Error = tempError;
            return Operator.IsNullString(this.Error);
        }
    }
}