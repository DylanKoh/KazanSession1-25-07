//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KazanSession1_25_07
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssetTransferLog
    {
        public long ID { get; set; }
        public long AssetID { get; set; }
        public System.DateTime TransferDate { get; set; }
        public string FromAssetSN { get; set; }
        public string ToAssetSN { get; set; }
        public long FromDepartmentLocationID { get; set; }
        public long ToDepartmentLocationID { get; set; }
    
        public virtual Asset Asset { get; set; }
        public virtual DepartmentLocation DepartmentLocation { get; set; }
        public virtual DepartmentLocation DepartmentLocation1 { get; set; }
    }
}
