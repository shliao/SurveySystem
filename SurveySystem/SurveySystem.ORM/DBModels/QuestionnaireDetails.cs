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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionnaireID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnswerType { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Question { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string QOption { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Required { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}
