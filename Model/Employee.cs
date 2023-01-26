using System.ComponentModel.DataAnnotations;

namespace firstA.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string firstname { get; set; } = string.Empty;
        [Required]
        public string lastname { get; set; } = string.Empty;
        public issueType issueType { get; set; }
        public DateTime created { get; set; }

    }

    public enum issueType{
        Feature, Bug, Documentation
    }
}
