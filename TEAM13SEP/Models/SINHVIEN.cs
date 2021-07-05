﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TEAM13SEP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SINHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINHVIEN()
        {
            this.GOPies = new HashSet<GOPY>();
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã số sinh viên không được bỏ trống")]
        public int MSSV { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email không được bỏ trống")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không hợp lệ")]
        public string EMAIL { get; set; }
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string PASSWORD { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Họ tên sinh viên không được bỏ trống")]
        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""]+$", ErrorMessage = "Họ tên không có kí tự đặc biệt")]
        public string HOTEN_SV { get; set; }
        public Nullable<bool> EmailConfirm { get; set; }
        public Nullable<System.Guid> ActivetionCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOPY> GOPies { get; set; }
    }
}
