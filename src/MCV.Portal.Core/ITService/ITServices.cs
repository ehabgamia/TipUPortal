using Abp.Domain.Entities.Auditing;
using MCV.Portal.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.ITService
{
   public class Calls : FullAuditedEntity
    {
        public virtual string Reporter { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PCNo { get; set; }
        //public virtual string CostCenter { get; set; }
        public virtual string LocationTypeID { get; set; }
        //public virtual string Problem { get; set; }
        public virtual string Description { get; set; }
        //public virtual string Category { get; set; }
        //public virtual string SubCategory { get; set; }
        public virtual string Subject { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime Date { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int SubCategoryId { get; set; }
        public string UploadPathFile { get; set; }
        public int Status { get; set; }
        public int IsRejected { get; set; }
        //public virtual string AssignedTo { get; set; }
        //public virtual int ProblemByAdmin { get; set; }
        //public virtual int Priority { get; set; }
        //public virtual DateTime LastActionTime { get; set; }
        //public virtual string TicketNum { get; set; }
        //public virtual DateTime SDEntryDate { get; set; }
        //public virtual int CatID { get; set; }
        //public virtual int ITRequestID { get; set; }
        //public virtual string BudgetStatus { get; set; }
        //public virtual string PurchasingApprovalStatus { get; set; }
        //public virtual int ITPurchasingID { get; set; }
        //public virtual int Item { get; set; }
        //public virtual string AssetType { get; set; }
        //public virtual int BudgetCC { get; set; }
        //public virtual int ExtentionNo { get; set; }
    }
}
