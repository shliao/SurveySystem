namespace SurveySystem.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Survey_View
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserInfoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuestionnaireID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Caption { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreatDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public Guid Expr1 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string MobilePhone { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(3)]
        public string Age { get; set; }

        [Key]
        [Column(Order = 9)]
        public Guid Expr2 { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr3 { get; set; }

        [StringLength(50)]
        public string Answer { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr4 { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(50)]
        public string Expr5 { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(500)]
        public string QContent { get; set; }

        [Key]
        [Column(Order = 14)]
        public DateTime StartDate { get; set; }

        public DateTime? Expr6 { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(50)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QDID { get; set; }

        [Key]
        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Expr7 { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(50)]
        public string QuestionType { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(50)]
        public string Question { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(50)]
        public string QOption { get; set; }

        [Key]
        [Column(Order = 21)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Required { get; set; }
    }
}
