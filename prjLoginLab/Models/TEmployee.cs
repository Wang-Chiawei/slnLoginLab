using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjLoginLab.Models;

public partial class TEmployee
{
    [Required(ErrorMessage ="帳號必填")]
    [Display(Name ="帳號")]
    public string FId { get; set; } = null!;

    [Required(ErrorMessage = "密碼必填")]
    [Display(Name = "密碼")]
    public string? FPwd { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "再次驗證密碼")]
    [Compare("FPwd", ErrorMessage = "密碼驗證錯誤")]
    public string? FCPwd { get; set; }

    [Display(Name = "權限別")]
    public string? FRole { get; set; }

    
    [Display(Name = "電子郵件信箱")]
    [EmailAddress(ErrorMessage ="須符合信箱格式")]
    public string? FMail { get; set; }

    [Range(28000,65000, ErrorMessage ="28K~65K")]
    [Display(Name = "薪資")]
    public int? FSalary { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "到職日期")]
    public DateTime? FEployeeDate { get; set; }
     
    [Display(Name = "性別")]
    public string? FGender { get; set; }
    [Required(ErrorMessage = "姓名必填")]
    [Display(Name = "姓名")]
    public string? FName { get; set; }
}
