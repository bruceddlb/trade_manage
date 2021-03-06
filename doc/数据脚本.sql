
--用户信息表
create table tbl_Member
(
	MemberId varchar(36) NOT NULL primary key,	--主键
	MemberName varchar(50) NULL,				--会员名称
	Mobile varchar(50) NULL,					--电话	
	Sex int,--0 女 1男							--性别
	CreateTime datetime NULL,					--注册时间
	BornDate datetime,							--出生日期
	Status int NULL,							--状态
	Pwd varchar(50) NULL,						--密码
	OpenId varchar(50) NULL,					--openid	
	HeadIcon varchar(50) NULL,					--头像
	NikeName varchar(50) NULL,					--微信昵称
	ProvinceId varchar(50) NULL,				--省
	ProvinceName varchar(50) NULL,				
	CityId varchar(50) NULL,					--市
	CityName varchar(50) NULL,					
	CountyId varchar(50) NULL,					--区
	CountyName varchar(50) NULL,
	AddressInfo varchar(200) NULL,				--地址
)

--用户收货地址表
create table tbl_MemberAddress
(
	AddressId varchar(36) NOT NULL primary key, --主键
	MemberId varchar(36),						--会员编号
	Consignee varchar(50),						--收货人
	Mobile varchar(50),							--联系电话
	Address varchar(200),						--地址
	IsDefault int,--0 否 1 是					--是否默认地址
	ProvinceId varchar(50) NULL,				--
	ProvinceName varchar(50) NULL,
	CityId varchar(50) NULL,
	CityName varchar(50) NULL,
	CountyId varchar(50) NULL,
	CountyName varchar(50) NULL,
)

--微信账号对应表
CREATE TABLE dbo.tbl_WxUserInfo(
	WxUserInfoId varchar(50) NOT NULL primary key,--微信号
	Nickename varchar(50) NULL,
	HendIcon varchar(200) NULL,
	Provice varchar(50) NULL,
	City varchar(50) NULL,
	County varchar(50) NULL,
	Sex varchar(50) NULL,
	)
	
--购物车表
create table tbl_MemberCart
(
	CartId varchar(36) primary key,	--主键
	ProductId varchar(50),			--产品编号
	ProductCount int,				--数量
	MemberId varchar(50),			--会员id
	CreateDate datetime,			--时间	
)
--订单表
create table tbl_Order(
	OrderId varchar(36) primary key,--主键
	BillCode varchar(50),			--业务单号
	OrderType int,					--订单类型 0 预售订单 1 现收订单
	OrderDate datetime,				--下单时间
	PayWay int,						--支付方式 0 微信 1支付宝 2 花呗
	TotalPrice decimal(10,2),		--订单总金额
	OrderStatus int,				--定单状态 0 未发货 1 部分发货 2 完成
	Remark varchar(200),			--备注
	AddressId varchar(50),			--地址地址
	MemberId varchar(50),			--会员id
)
--订单明细表
create table tbl_OrderdDetail(
	OrderdetailId varchar(36) primary key,	--主键
	ProductId varchar(50),					--产品编号
	Status	int,							--到货状态 0 为到货 1 已到货 2 已发货 发货单处理发货后自动更新状态，现售产品默认 1到货状态
	Price decimal(10,2),					--价格
	OrderId varchar(50),					--订单号
)

--发货单表，处理发货自动处理对于订单的信息，如果商品都发货则订单状态改为已发货
create  table tbl_DeliverOrder
(
	DeliverOrderId varchar(36) primary key,	--主键
	OrderId varchar(50),					--销售订单号
	OrderStatus int,						--发货状态 0 待支付运费 1 未发货 2 已发货  支付成功状态 为1未发货 后台发货输入发货单号 状态改为 已发货2，同时处理对应销售订单
	Freight decimal(10,2),					--运费
	AddressId varchar(50),					--收货地址
	MemberId varchar(50),					--会员id
	LogisticsNo varchar(50),				--物流单号
	LogisticsName varchar(50),				--物流公司
	LogisticsCode varchar(50),				--物流编码
	LogisticsTime datetime,					--发货时间
	
)
--发货单明细表
create  table tbl_DeliverOrderDetail
(
	DeliverOrderDetailId varchar(36) primary key,	--主键
	DeliverOrderId varchar(50),						--发货单号
	ProductId varchar(50),							--产品编号
	Price decimal(10,2),							--价格

)
--运费模板
CREATE TABLE tbl_ShopShipTemplates(
	ShopShipTemplatesId varchar(36) primary key,	--主键
	Free int NOT NULL,							--是否免运费
	Type int NOT NULL,							--计费类型(0代表按件数计算,1代表按重量计算)
	Title nvarchar(50) NOT NULL,				--标题
)
--模板明细
CREATE TABLE tbl_ShipFees(
	ShipFees varchar(36) primary key,				--
	ShipTempId int NOT NULL,						--模板id
	RegionId varchar(50) NOT NULL,					--区域id 市id
	StartValue decimal(10,2) NOT NULL,				--起步值
	StartFee decimal(10,2) NOT NULL,				--起步费用
	AddValue decimal(10,2) NOT NULL,				--添加值
	AddFee decimal(10,2) NOT NULL,					--添加费用
)


--产品分类
create table tbl_Category
(
	CategoryID varchar(36) primary key,
	Name nvarchar(50) NULL,
	Code nvarchar(50) NOT NULL,
	ParentID int NULL,
	CategoryPath nvarchar(128) NULL,
	Depth tinyint NULL,
	SortNum int NULL,
	ImagePath nvarchar(200) NULL,
	IsHidden tinyint NULL,
)

--产品分类
create table tbl_Product(
	ProductId varchar(36) primary key,
	ProductNO varchar(50),	--编号
	ProductUnit varchar(50),--单位
	ProductDescription text,--描述
	ProductStatus int,		--状态
	ProductCategoryId varchar(36),	
	ProductPrice decimal(10,2),
	ProductCostPrice decimal(10,2),
	ProductStock int,
	FaceImag varchar(200),
	ProductType int ,		--产品属性0 预售 1 现售
	
	
)