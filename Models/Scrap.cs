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
    using System.ComponentModel;

    public partial class Scrap
    {
        [DisplayName("报废流水号")]
        public int ScrapID { get; set; }
        [DisplayName("维修编号")]
        public Nullable<int> RepairID { get; set; }
        [DisplayName("实体流水号")]
        public Nullable<int> ItemID { get; set; }
        [DisplayName("原夹具代码")]
        public string Code { get; set; }
        [DisplayName("原夹具名称")]
        public string Name { get; set; }
        [DisplayName("原大类编码")]
        public string FamilyID { get; set; }
        [DisplayName("原大类名称")]
        public string FamilyName { get; set; }
        [DisplayName("原夹具模组")]
        public string Model { get; set; }
        [DisplayName("原夹具料号")]
        public string PartNo { get; set; }
        [DisplayName("物品寿命计数")]
        public Nullable<int> Count { get; set; }
        [DisplayName("报废原因")]
        public string Problem { get; set; }
        [DisplayName("创建日期")]
        public Nullable<System.DateTime> AddDate { get; set; }
        [DisplayName("创建人编码")]
        public string AddUserID { get; set; }
        [DisplayName("创建人姓名")]
        public string AddUserName { get; set; }
        [DisplayName("初审日期")]
        public Nullable<System.DateTime> FirstReviewDate { get; set; }
        [DisplayName("初审人编码")]
        public string FirstReviewUserID { get; set; }
        [DisplayName("初审人姓名")]
        public string FirstReviewUserName { get; set; }
        [DisplayName("终审日期")]
        public Nullable<System.DateTime> SecondReviewDate { get; set; }
        [DisplayName("终审人编码")]
        public string SecondReviewUserID { get; set; }
        [DisplayName("终审人姓名")]
        public string SecondReviewUserName { get; set; }
        [DisplayName("部门编码")]
        public string WorkcellID { get; set; }
        [DisplayName("部门编码")]
        public string ScrapState { get; set; }
        [DisplayName("部门编码")]
        public string BackNote { get; set; }
        [DisplayName("夹具序列号")]
        public Nullable<int> SeqID { get; set; }
    }
}
