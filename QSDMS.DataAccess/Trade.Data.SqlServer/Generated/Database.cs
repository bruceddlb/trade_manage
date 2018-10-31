



















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `TradeConnectionString_SqlServer`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=.;Initial Catalog=Trade_DB;Persist Security Info=True;User ID=sa;password=**zapped**;`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Trade.Data
{

	public partial class Trade_SQLDB : Database
	{
		public Trade_SQLDB() 
			: base("TradeConnectionString_SqlServer")
		{
			CommonConstruct();
		}

		public Trade_SQLDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			Trade_SQLDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static Trade_SQLDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new Trade_SQLDB();
        }

		[ThreadStatic] static Trade_SQLDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static Trade_SQLDB repo { get { return Trade_SQLDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }
			public static System.Data.DataTable GetTable(string sql, params object[] args) { return repo.GetDatatable(sql, args); }
            public static int Count(string sql, params object[] args) { return repo.Count(sql, args); }
            public static int Execute(string sql, params object[] args) { return repo.Execute(sql, args); }

		}

	}
	



    
	[TableName("tbl_WxUserInfo")]


	[PrimaryKey("WxUserInfoId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_WxUserInfo : Trade_SQLDB.Record<tbl_WxUserInfo>  
    {



		[Column] public string WxUserInfoId { get; set; }





		[Column] public string Nickename { get; set; }





		[Column] public string HendIcon { get; set; }





		[Column] public string Provice { get; set; }





		[Column] public string City { get; set; }





		[Column] public string County { get; set; }





		[Column] public string Sex { get; set; }



	}

    
	[TableName("tbl_WxTemplate")]


	[PrimaryKey("WxTemplateId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_WxTemplate : Trade_SQLDB.Record<tbl_WxTemplate>  
    {



		[Column] public string WxTemplateId { get; set; }





		[Column] public string Title { get; set; }





		[Column] public string Call_index { get; set; }





		[Column] public string TemplateId { get; set; }





		[Column] public string Remark { get; set; }



	}

    
	[TableName("tbl_SmsLog")]


	[PrimaryKey("SmsLogId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_SmsLog : Trade_SQLDB.Record<tbl_SmsLog>  
    {



		[Column] public string SmsLogId { get; set; }





		[Column] public string Caption { get; set; }





		[Column] public string RecivMobile { get; set; }





		[Column] public int? Status { get; set; }





		[Column] public string SmsTempId { get; set; }





		[Column] public string Exception { get; set; }





		[Column] public DateTime? CreateTime { get; set; }





		[Column] public int? NoticeType { get; set; }



	}

    
	[TableName("tbl_ShopShipTemplates")]


	[PrimaryKey("ShopShipTemplatesId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_ShopShipTemplate : Trade_SQLDB.Record<tbl_ShopShipTemplate>  
    {



		[Column] public string ShopShipTemplatesId { get; set; }





		[Column] public int Free { get; set; }





		[Column] public int Type { get; set; }





		[Column] public string Title { get; set; }



	}

    
	[TableName("tbl_ShipFees")]


	[PrimaryKey("ShipFees", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_ShipFee : Trade_SQLDB.Record<tbl_ShipFee>  
    {



		[Column] public string ShipFees { get; set; }





		[Column] public int ShipTempId { get; set; }





		[Column] public string RegionId { get; set; }





		[Column] public decimal StartValue { get; set; }





		[Column] public decimal StartFee { get; set; }





		[Column] public decimal AddValue { get; set; }





		[Column] public decimal AddFee { get; set; }



	}

    
	[TableName("tbl_Settings")]


	[PrimaryKey("SettingId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_Setting : Trade_SQLDB.Record<tbl_Setting>  
    {



		[Column] public string SettingId { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Value { get; set; }





		[Column] public string Remark { get; set; }



	}

    
	[TableName("tbl_Product")]


	[PrimaryKey("ProductId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_Product : Trade_SQLDB.Record<tbl_Product>  
    {



		[Column] public string ProductId { get; set; }





		[Column] public string ProductNO { get; set; }





		[Column] public string ProductUnit { get; set; }





		[Column] public string ProductDescription { get; set; }





		[Column] public int? ProductStatus { get; set; }





		[Column] public string ProductCategoryId { get; set; }





		[Column] public decimal? ProductPrice { get; set; }





		[Column] public decimal? ProductCostPrice { get; set; }





		[Column] public int? ProductStock { get; set; }





		[Column] public string FaceImag { get; set; }





		[Column] public int? ProductType { get; set; }



	}

    
	[TableName("tbl_OrderdDetail")]


	[PrimaryKey("OrderdetailId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_OrderdDetail : Trade_SQLDB.Record<tbl_OrderdDetail>  
    {



		[Column] public string OrderdetailId { get; set; }





		[Column] public string ProductId { get; set; }





		[Column] public int? Status { get; set; }





		[Column] public decimal? Price { get; set; }





		[Column] public string OrderId { get; set; }



	}

    
	[TableName("tbl_Order")]


	[PrimaryKey("OrderId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_Order : Trade_SQLDB.Record<tbl_Order>  
    {



		[Column] public string OrderId { get; set; }





		[Column] public string BillCode { get; set; }





		[Column] public int? OrderType { get; set; }





		[Column] public DateTime? OrderDate { get; set; }





		[Column] public int? PayWay { get; set; }





		[Column] public decimal? TotalPrice { get; set; }





		[Column] public int? OrderStatus { get; set; }





		[Column] public string Remark { get; set; }





		[Column] public string AddressId { get; set; }





		[Column] public string MemberId { get; set; }



	}

    
	[TableName("tbl_MemberCart")]


	[PrimaryKey("CartId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_MemberCart : Trade_SQLDB.Record<tbl_MemberCart>  
    {



		[Column] public string CartId { get; set; }





		[Column] public string ProductId { get; set; }





		[Column] public int? ProductCount { get; set; }





		[Column] public string MemberId { get; set; }





		[Column] public DateTime? CreateDate { get; set; }



	}

    
	[TableName("tbl_MemberAddress")]


	[PrimaryKey("AddressId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_MemberAddress : Trade_SQLDB.Record<tbl_MemberAddress>  
    {



		[Column] public string AddressId { get; set; }





		[Column] public string MemberId { get; set; }





		[Column] public string Consignee { get; set; }





		[Column] public string Mobile { get; set; }





		[Column] public string Address { get; set; }





		[Column] public int? IsDefault { get; set; }





		[Column] public string ProvinceId { get; set; }





		[Column] public string ProvinceName { get; set; }





		[Column] public string CityId { get; set; }





		[Column] public string CityName { get; set; }





		[Column] public string CountyId { get; set; }





		[Column] public string CountyName { get; set; }



	}

    
	[TableName("tbl_Member")]


	[PrimaryKey("MemberId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_Member : Trade_SQLDB.Record<tbl_Member>  
    {



		[Column] public string MemberId { get; set; }





		[Column] public string MemberName { get; set; }





		[Column] public string Mobile { get; set; }





		[Column] public int? Sex { get; set; }





		[Column] public DateTime? CreateTime { get; set; }





		[Column] public DateTime? BornDate { get; set; }





		[Column] public int? Status { get; set; }





		[Column] public string Pwd { get; set; }





		[Column] public string OpenId { get; set; }





		[Column] public string HeadIcon { get; set; }





		[Column] public string NikeName { get; set; }





		[Column] public string ProvinceId { get; set; }





		[Column] public string ProvinceName { get; set; }





		[Column] public string CityId { get; set; }





		[Column] public string CityName { get; set; }





		[Column] public string CountyId { get; set; }





		[Column] public string CountyName { get; set; }





		[Column] public string AddressInfo { get; set; }



	}

    
	[TableName("tbl_DeliverOrderDetail")]


	[PrimaryKey("DeliverOrderDetailId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_DeliverOrderDetail : Trade_SQLDB.Record<tbl_DeliverOrderDetail>  
    {



		[Column] public string DeliverOrderDetailId { get; set; }





		[Column] public string DeliverOrderId { get; set; }





		[Column] public string ProductId { get; set; }





		[Column] public decimal? Price { get; set; }



	}

    
	[TableName("tbl_DeliverOrder")]


	[PrimaryKey("DeliverOrderId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_DeliverOrder : Trade_SQLDB.Record<tbl_DeliverOrder>  
    {



		[Column] public string DeliverOrderId { get; set; }





		[Column] public string OrderId { get; set; }





		[Column] public int? OrderStatus { get; set; }





		[Column] public decimal? Freight { get; set; }





		[Column] public string AddressId { get; set; }





		[Column] public string MemberId { get; set; }





		[Column] public string LogisticsNo { get; set; }





		[Column] public string LogisticsName { get; set; }





		[Column] public string LogisticsCode { get; set; }





		[Column] public DateTime? LogisticsTime { get; set; }



	}

    
	[TableName("tbl_Category")]


	[PrimaryKey("CategoryID", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_Category : Trade_SQLDB.Record<tbl_Category>  
    {



		[Column] public string CategoryID { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string Code { get; set; }





		[Column] public int? ParentID { get; set; }





		[Column] public string CategoryPath { get; set; }





		[Column] public byte? Depth { get; set; }





		[Column] public int? SortNum { get; set; }





		[Column] public string ImagePath { get; set; }





		[Column] public byte? IsHidden { get; set; }



	}

    
	[TableName("tbl_Banner")]


	[PrimaryKey("BannerId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_Banner : Trade_SQLDB.Record<tbl_Banner>  
    {



		[Column] public string BannerId { get; set; }





		[Column] public string Name { get; set; }





		[Column] public string ImgPath { get; set; }





		[Column] public string HrefUrl { get; set; }





		[Column] public string Remark { get; set; }





		[Column] public DateTime? CreateTime { get; set; }





		[Column] public string CreateId { get; set; }



	}

    
	[TableName("tbl_AttachmentPic")]


	[PrimaryKey("PicId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class tbl_AttachmentPic : Trade_SQLDB.Record<tbl_AttachmentPic>  
    {



		[Column] public string PicId { get; set; }





		[Column] public string PicName { get; set; }





		[Column] public int? Type { get; set; }





		[Column] public string ObjectId { get; set; }





		[Column] public int? SortNum { get; set; }



	}


}



