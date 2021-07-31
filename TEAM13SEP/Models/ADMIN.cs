
﻿//------------------------------------------------------------------------------
=======
//------------------------------------------------------------------------------

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


    

    public partial class ADMIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADMIN()
        {
            this.GOPies = new HashSet<GOPY>();
        }
    
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email không được bỏ trống")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail không hợp lệ")]
        public string EMAIL { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được bỏ trống")]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Họ tên không được bỏ trống")]
        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""]+$", ErrorMessage = "Họ tên không có kí tự đặc biệt")]
        public string FULL_NAME { get; set; }
        public int ROLE { get; set; }
        public Nullable<bool> EmailConfirm { get; set; }
        public Nullable<System.Guid> ActivetionCode { get; set; }

        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string FULL_NAME { get; set; }
        public int ROLE { get; set; }

    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOPY> GOPies { get; set; }
    }
}
