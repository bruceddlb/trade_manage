USE [RCHL_DB_]
GO

/****** Object:  StoredProcedure [dbo].[proc_GetRecordByPage]    Script Date: 07/24/2018 13:52:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



------------------------------------
--author:bruced
--time:2011-05-07
--descript����ҳ�洢����(Ч�ʺܸ�)
------------------------------------

CREATE PROCEDURE [dbo].[proc_GetRecordByPage]
    @pSQL      varchar(8000),          -- ����Դ��select * FROM tb��
    @keyField      varchar(255),      -- �����ֶ���
    @orderFiled varchar(20),		  -- �����ֶΣ�ע�⣺�����order by�ؼ��֣�
    @PageSize     int = 10,           -- ҳ�ߴ�,ÿҳ��ʾ����Ŀ
    @PageIndex    int = 1,            -- ҳ�룬��ǰ�ڼ�ҳ
    @OrderType    bit = 1,            -- ������������, �� 0 ֵ���򣬸�����������
    @strWhere     varchar(255) = '',   -- ��ѯ���� (ע��: ��Ҫ�� where)
    @pRecNums int output,				--��¼��
	@pRecPages int output				--��¼ҳ��
AS
SET NOCOUNT ON
BEGIN TRAN
declare @strSQL   varchar(8000)       -- �����
declare @strTmp   varchar(255)        -- ��ʱ����
declare @strOrder varchar(255)        -- ��������
declare @strCountSQL	varchar(4000) -- ���ؼ�¼����SQL
declare @totalCount   int			  -- �ܼ�¼��		
declare @Pages int					  -- ��ҳ��				
declare @Reccount int				  -- ������ʾ��ʵ����

--set @Pages=0
if @OrderType != 0
begin
    set @strTmp = '<(select min'
  	set @strOrder = ' order by [' + @keyField +'] desc '
  	if @@ERROR != 0 goto Err_Proc
end
else
begin
    set @strTmp = '>(select max'
    set @strOrder = ' order by [' + @keyField +'] asc '
    if @@ERROR != 0 goto Err_Proc
end
if(@strWhere != '')
	begin
    declare  @sqls1  nvarchar(4000)  
	set   @sqls1= 'select @totalCount = count(*)  from (' + @pSQL + ')T where'  + @strWhere
	exec sp_executesql  @sqls1,N'@totalCount int out',@totalCount output
	if @@ERROR != 0 goto Err_Proc
    end
else
    begin
    --execִ�н������@totalCount������
	declare  @sqls2  nvarchar(4000)  
	set   @sqls2= 'select @totalCount = count(*)   from   ('+@pSQL+')T'  
	exec sp_executesql  @sqls2,N'@totalCount int out',@totalCount output
	if @@ERROR != 0 goto Err_Proc
	end
	--�ܵ�ҳ��
	set @Pages = @totalCount/@PageSize
	if(@totalCount % @PageSize > 0)
		set @Pages = @Pages + 1
	if(@PageIndex<=0)
		set @PageIndex = 1
	if(@PageIndex > @Pages)
	    --����ĵ�ǰҳ�Ŵ�����ҳ������������⴦��
		set @PageIndex = @Pages	
    if(@totalCount<>0)		
		set @Reccount = (@PageIndex-1) * @PageSize	--������ʾ��ʵ����
	else
		set @Reccount=0
	set @pRecNums = @totalCount		--��¼��
	set @pRecPages = @Pages		--��¼ҳ��
	if @@ERROR != 0 goto Err_Proc
	
--����sql���
set @strSQL = 'select top ' + str(@PageSize) + ' * from ('
    + @pSQL + ')T1 where [' + @keyField + ']' + @strTmp + '(['
    + @keyField + ']) from (select top ' + str(@Reccount) + ' ['
    + @keyField + '] from (' + @pSQL + ')T2' + @strOrder + ') as tblTmp)'
    + @strOrder
    if @@ERROR != 0 goto Err_Proc
--������Ϊ��
if @strWhere != ''
    set @strSQL = 'select top ' + str(@PageSize) + ' * from ('
        + @pSQL + ')T1 where [' + @keyField + ']' + @strTmp + '(['
        + @keyField + ']) from (select top ' + str(@Reccount) + ' ['
        + @keyField + '] from (' + @pSQL + ')T2 where ' + @strWhere + ' '
        + @strOrder + ') as tblTmp) and ' + @strWhere + ' ' + @strOrder
	if @@ERROR != 0 goto Err_Proc
--��ǰҳ��Ϊ1
if @PageIndex = 1
begin
    set @strTmp =''
    if @strWhere != ''
        set @strTmp = ' where ' + @strWhere
    set @strSQL = 'select top ' + str(@PageSize) + ' * from ('
        + @pSQL + ')T' + @strTmp + ' ' + @strOrder
    if @@ERROR != 0 goto Err_Proc
end
--����������Ϊ��
if(@orderFiled<>'')
	set @strSQL='select * from ('+@strSQL+')T order by '+@orderFiled
	if @@ERROR != 0 goto Err_Proc
--���ؽ����¼����
exec (@strSQL)
if @@ERROR != 0 goto Err_Proc
OK_Proc:
	commit tran
	--ִ�з����ܼ�¼��ҳ��
	--select @totalCount as totalCount,@Pages as pages
	print 'success message:'+ @strSQL
	set nocount off
	return 0
Err_Proc:
	rollback tran
	print 'error message:'+@strSQL
	set nocount off
	return -1
/*************************************************
test:
declare @pRecNums int,@pRecPages int
EXEC [proc_GetRecordByPage]
		'select * from test_1
		 union all
		 select * from test_1
		',						-- ����Դ
		'keyid',				-- ����
		'seq asc',				-- �������
		15,						-- ҳ��С
		144570,					-- ҳ��
		1,						-- ����ʽ1��desc��0��asc
		''						-- where����eg: name like ''name146%''
	    @pRecNums  output,--�ܼ�¼
		@pRecPages  output --ҳ��
		print @pRecNums
		print @pRecPages

***************************************************/




GO


