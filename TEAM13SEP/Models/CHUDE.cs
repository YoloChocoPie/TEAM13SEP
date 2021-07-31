
//------------------------------------------------------------------------------
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


    public partial class CHUDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUDE()
        {
            this.GOPies = new HashSet<GOPY>();
        }
    
        public int ID { get; set; }
        public string CHUDE_CODE { get; set; }

        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*""]+$", ErrorMessage = "Tên chủ đề không có kí tự đặc biệt")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên chủ đề không được bỏ trống")]

        public string CHUDE_NAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GOPY> GOPies { get; set; }
    }
}
