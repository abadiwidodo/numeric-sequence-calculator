using System;
using System.ComponentModel.DataAnnotations;

namespace NumericSequenceCalculator.Models
{
    public class HomeModel
    {
        [Display(Name = "Display sequence number up to")]
        [Required(ErrorMessage = "Please enter a number")]
        [Range(0, Int32.MaxValue, ErrorMessage = "The input must be positive number")]
        public int InputNumber { get; set; }
        public ResultModel Result { get; set; }
    }
}