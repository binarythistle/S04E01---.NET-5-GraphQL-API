using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    /// <summary>
    /// Represents any executable command.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Represents the unique ID for the command.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represents the how-to for the command.
        /// </summary>
        [Required]
        public string HowTo { get; set; }

        /// <summary>
        /// Represents the command line.
        /// </summary>
        [Required]
        public string CommandLine { get; set; }

        /// <summary>
        /// Represents the unique ID of the platform which the command belongs.
        /// </summary>
        [Required]
        public int PlatformId { get; set; }

        /// <summary>
        /// This is the platform to which the command belongs.
        /// </summary>
        public Platform Platform { get; set; }
    }
}