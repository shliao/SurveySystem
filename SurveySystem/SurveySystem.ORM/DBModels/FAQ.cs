namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FAQ")]
    public partial class FAQ
    {
        [Key]
        [StringLength(50)]
        public string CustomName { get; set; }

        public int AnswerType { get; set; }

        [Required]
        [StringLength(50)]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string FOption { get; set; }
    }
}
