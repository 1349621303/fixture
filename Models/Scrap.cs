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
    
    public partial class Scrap
    {
        public int ScrapID { get; set; }
        public Nullable<int> RepairID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FamilyID { get; set; }
        public string FamilyName { get; set; }
        public string Model { get; set; }
        public string PartNo { get; set; }
        public Nullable<int> Count { get; set; }
        public string Problem { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string AddUserID { get; set; }
        public string AddUserName { get; set; }
        public Nullable<System.DateTime> FirstReviewDate { get; set; }
        public string FirstReviewUserID { get; set; }
        public string FirstReviewUserName { get; set; }
        public Nullable<System.DateTime> SecondReviewDate { get; set; }
        public string SecondReviewUserID { get; set; }
        public string SecondReviewUserName { get; set; }
        public string WorkcellID { get; set; }
        public string ScrapState { get; set; }
        public string BackNote { get; set; }
        public Nullable<int> SeqID { get; set; }
    }
}
