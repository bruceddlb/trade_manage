//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2018-10-31 09:04:30 by bruced
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
    
using System;
namespace Trade.Model
{
    /// <summary>
    /// 数据表实体类：OrderEntity 
    /// </summary>
    [Serializable()]
    public partial class OrderEntity:BaseModel
    {    
		            
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string OrderId { get; set; }

                    
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string BillCode { get; set; }

                    
		/// <summary>
		/// int:
		/// </summary>	
                 
		public int? OrderType { get; set; }

                    
		/// <summary>
		/// datetime:
		/// </summary>	
                 
		public DateTime? OrderDate { get; set; }

                    
		/// <summary>
		/// int:
		/// </summary>	
                 
		public int? PayWay { get; set; }

                    
		/// <summary>
		/// decimal:
		/// </summary>	
                 
		public decimal? TotalPrice { get; set; }

                    
		/// <summary>
		/// int:
		/// </summary>	
                 
		public int? OrderStatus { get; set; }

                    
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string Remark { get; set; }

                    
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string AddressId { get; set; }

                    
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string MemberId { get; set; }

           
    }    
}
	