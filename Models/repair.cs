//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fixture02.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class repair
    {
        public int RepairID { get; set; }
        public Nullable<int> CheckID { get; set; }
        public int ItemID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FamilyID { get; set; }
        public string FamilyName { get; set; }
        public string Model { get; set; }
        public string PartNo { get; set; }
        public string Problem { get; set; }
        public string Pic { get; set; }
        public System.DateTime AddDate { get; set; }
        public string AddUserID { get; set; }
        public string AddUserName { get; set; }
        public Nullable<System.DateTime> RepairDate { get; set; }
        public string RepairUserName { get; set; }
        public string RepairState { get; set; }
        public string WorkcellID { get; set; }
    }
}
