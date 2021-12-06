namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SurveyD_QuestD_View
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QDID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid UserInfoID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionnaireID { get; set; }

        [StringLength(50)]
        public string Answer { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr2 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string QuestionType { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Question { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string QOption { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(10)]
        public string Required { get; set; }
    }
}
