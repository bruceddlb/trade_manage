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
    /// 数据表实体类：DeliverOrderDetailEntity 
    /// </summary>
    [Serializable()]
    public partial class DeliverOrderDetailEntity:BaseModel
    {    
		            
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string DeliverOrderDetailId { get; set; }

                    
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string DeliverOrderId { get; set; }

                    
		/// <summary>
		/// varchar:
		/// </summary>	
                 
		public string ProductId { get; set; }

                    
		/// <summary>
		/// decimal:
		/// </summary>	
                 
		public decimal? Price { get; set; }

           
    }    
}
	