//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_MAS_AYAH
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service_owners
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Descripion { get; set; }
        public string Photograph { get; set; }
        public string Image_to_work { get; set; }
        public Nullable<int> Service_Id { get; set; }
        public string Image_to_work2 { get; set; }
        public string Image_to_work3 { get; set; }
        public string Image_to_work4 { get; set; }
        public string Image_to_work5 { get; set; }
        public string Image_to_work6 { get; set; }
        public string Image_to_work7 { get; set; }
        public string Image_to_work8 { get; set; }
        public string Image_to_work9 { get; set; }
        public string Image_to_work10 { get; set; }
        public string Asp_Id { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Servicess Servicess { get; set; }
    }
}
