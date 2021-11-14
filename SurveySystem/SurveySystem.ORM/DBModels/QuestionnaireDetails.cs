namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuestionnaireDetails
    {
        [Key]
        public int QDID { get; set; }

        public int QuestionnaireID { get; set; }

        [Required]
        [StringLength(50)]
        public string QuestionType { get; set; }

        [Required]
        [StringLength(50)]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string QOption { get; set; }

        [Required]
        [StringLength(10)]
        public string Required { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}
