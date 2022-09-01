using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Management.Razor.Models
{
    /// <summary>
    /// CommonClassModel
    /// </summary>
    public class CommonClassModel
    {
        /// <summary>
        /// CLASS_VALUE_ID
        /// </summary>
        public int? CLASS_VALUE_ID { get; set; }

        /// <summary>
        /// CLASS_ID
        /// </summary>
        [Required]
        [Display(Name = "Class name")]
        public int? CLASS_ID { get; set; }

        /// <summary>
        /// CLASS_NAME
        /// </summary>
        public string? CLASS_NAME { get; set; }

        /// <summary>
        /// INACTIVE_DATE
        /// </summary>
        [Display(Name = "Inactive date")]
        public DateTime? INACTIVE_DATE { get; set; }

        /// <summary>
        /// KEY_VALUE
        /// </summary>
        [Required]
        [MinLength(1)]
        [Display(Name = "Key value")]
        public string? KEY_VALUE { get; set; }

        /// <summary>
        /// TEXT_VALUE1
        /// </summary>
        [Display(Name = "Text value1")]
        public string? TEXT_VALUE1 { get; set; }
        /// <summary>
        /// TEXT_VALUE2
        /// </summary>
        [Display(Name = "Text value2")]
        public string? TEXT_VALUE2 { get; set; }
        /// <summary>
        /// TEXT_VALUE3
        /// </summary>
        [Display(Name = "Text value3")]
        public string? TEXT_VALUE3 { get; set; }
        /// <summary>
        /// TEXT_VALUE4
        /// </summary>
        [Display(Name = "Text value4")]
        public string? TEXT_VALUE4 { get; set; }
        /// <summary>
        /// TEXT_VALUE5
        /// </summary>
        [Display(Name = "Text value5")]
        public string? TEXT_VALUE5 { get; set; }
        /// <summary>
        /// TEXT_VALUE6
        /// </summary>
        [Display(Name = "Text value6")]
        public string? TEXT_VALUE6 { get; set; }
        /// <summary>
        /// TEXT_VALUE7
        /// </summary>
        [Display(Name = "Text value7")]
        public string? TEXT_VALUE7 { get; set; }
        /// <summary>
        /// TEXT_VALUE8
        /// </summary>
        [Display(Name = "Text value8")]
        public string? TEXT_VALUE8 { get; set; }
        /// <summary>
        /// TEXT_VALUE9
        /// </summary>
        [Display(Name = "Text value9")]
        public string? TEXT_VALUE9 { get; set; }
        /// <summary>
        /// TEXT_VALUE10
        /// </summary>
        [Display(Name = "Text value10")]
        public string? TEXT_VALUE10 { get; set; }

        /// <summary>
        /// INT_VALUE1
        /// </summary>
        [Display(Name = "Int value1")]
        public int? INT_VALUE1 { get; set; }
        /// <summary>
        /// INT_VALUE2
        /// </summary>
        [Display(Name = "Int value2")]
        public int? INT_VALUE2 { get; set; }
        /// <summary>
        /// INT_VALUE3
        /// </summary>
        [Display(Name = "Int value3")]
        public int? INT_VALUE3 { get; set; }
        /// <summary>
        /// INT_VALUE4
        /// </summary>
        [Display(Name = "Int value4")]
        public int? INT_VALUE4 { get; set; }
        /// <summary>
        /// INT_VALUE5
        /// </summary>
        [Display(Name = "Int value5")]
        public int? INT_VALUE5 { get; set; }

        /// <summary>
        /// NUMBER_VALUE1
        /// </summary>
        [Display(Name = "Number value1")]
        public decimal? NUMBER_VALUE1 { get; set; }
        /// <summary>
        /// NUMBER_VALUE2
        /// </summary>
        [Display(Name = "Number value2")]
        public decimal? NUMBER_VALUE2 { get; set; }
        /// <summary>
        /// NUMBER_VALUE3
        /// </summary>
        [Display(Name = "Number value3")]
        public decimal? NUMBER_VALUE3 { get; set; }
        /// <summary>
        /// NUMBER_VALUE4
        /// </summary>
        [Display(Name = "Number value4")]
        public decimal? NUMBER_VALUE4 { get; set; }
        /// <summary>
        /// NUMBER_VALUE5
        /// </summary>
        [Display(Name = "Number value5")]
        public decimal? NUMBER_VALUE5 { get; set; }

        /// <summary>
        /// DATETIME_VALUE1
        /// </summary>
        [Display(Name = "Datetime value1")]
        public DateTime? DATETIME_VALUE1 { get; set; }
        /// <summary>
        /// DATETIME_VALUE2
        /// </summary>
        [Display(Name = "Datetime value2")]
        public DateTime? DATETIME_VALUE2 { get; set; }
        /// <summary>
        /// DATETIME_VALUE3
        /// </summary>
        [Display(Name = "Datetime value3")]
        public DateTime? DATETIME_VALUE3 { get; set; }
        /// <summary>
        /// DATETIME_VALUE4
        /// </summary>
        [Display(Name = "Datetime value4")]
        public DateTime? DATETIME_VALUE4 { get; set; }
        /// <summary>
        /// DATETIME_VALUE5
        /// </summary>
        [Display(Name = "Datetime value5")]
        public DateTime? DATETIME_VALUE5 { get; set; }
        /// <summary>
        /// SORT
        /// </summary>
        [Required]
        [Display(Name = "Sort")]
        public int? SORT { get; set; }


        /// <summary>
        /// KEY_VALUE_DESC
        /// </summary>
        public string? KEY_VALUE_DESC { get; set; }

        /// <summary>
        /// TEXT_VALUE1_DESC
        /// </summary>
        public string? TEXT_VALUE1_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE2_DESC
        /// </summary>
        public string? TEXT_VALUE2_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE3_DESC
        /// </summary>
        public string? TEXT_VALUE3_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE4_DESC
        /// </summary>
        public string? TEXT_VALUE4_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE5_DESC
        /// </summary>
        public string? TEXT_VALUE5_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE6_DESC
        /// </summary>
        public string? TEXT_VALUE6_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE7_DESC
        /// </summary>
        public string? TEXT_VALUE7_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE8_DESC
        /// </summary>
        public string? TEXT_VALUE8_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE9_DESC
        /// </summary>
        public string? TEXT_VALUE9_DESC { get; set; }
        /// <summary>
        /// TEXT_VALUE10_DESC
        /// </summary>
        public string? TEXT_VALUE10_DESC { get; set; }

        /// <summary>
        /// INT_VALUE1_DESC
        /// </summary>
        public string? INT_VALUE1_DESC { get; set; }
        /// <summary>
        /// INT_VALUE2_DESC
        /// </summary>
        public string? INT_VALUE2_DESC { get; set; }
        /// <summary>
        /// INT_VALUE3_DESC
        /// </summary>
        public string? INT_VALUE3_DESC { get; set; }
        /// <summary>
        /// INT_VALUE4_DESC
        /// </summary>
        public string? INT_VALUE4_DESC { get; set; }
        /// <summary>
        /// INT_VALUE5_DESC
        /// </summary>
        public string? INT_VALUE5_DESC { get; set; }

        /// <summary>
        /// NUMBER_VALUE1_DESC
        /// </summary>
        public string? NUMBER_VALUE1_DESC { get; set; }
        /// <summary>
        /// NUMBER_VALUE2_DESC
        /// </summary>
        public string? NUMBER_VALUE2_DESC { get; set; }
        /// <summary>
        /// NUMBER_VALUE3_DESC
        /// </summary>
        public string? NUMBER_VALUE3_DESC { get; set; }
        /// <summary>
        /// NUMBER_VALUE4_DESC
        /// </summary>
        public string? NUMBER_VALUE4_DESC { get; set; }
        /// <summary>
        /// NUMBER_VALUE5_DESC
        /// </summary>
        public string? NUMBER_VALUE5_DESC { get; set; }

        /// <summary>
        /// DATETIME_VALUE1_DESC
        /// </summary>
        public string? DATETIME_VALUE1_DESC { get; set; }
        /// <summary>
        /// DATETIME_VALUE2_DESC
        /// </summary>
        public string? DATETIME_VALUE2_DESC { get; set; }
        /// <summary>
        /// DATETIME_VALUE3_DESC
        /// </summary>
        public string? DATETIME_VALUE3_DESC { get; set; }
        /// <summary>
        /// DATETIME_VALUE4_DESC
        /// </summary>
        public string? DATETIME_VALUE4_DESC { get; set; }
        /// <summary>
        /// DATETIME_VALUE5_DESC
        /// </summary>
        public string? DATETIME_VALUE5_DESC { get; set; }
    }
}