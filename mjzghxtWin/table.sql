create database mjzglxtWin
go

use mjzglxtWin
go

create table 职工
(
工号 varchar(20) not null,
姓名 nvarchar(20) not null,
职务 nvarchar(20) not null,		--护士、收费员
密码 varchar(50) not null,
constraint pk_职工 primary key(工号)
)
go

insert into 职工 values('1001',N'小明',N'护士','1001')
insert into 职工 values('1002',N'李王',N'收费员','1002')
insert into 职工 values('1003',N'管理员',N'管理员','1003')
insert into 职工 values('1004',N'张三',N'医生','1004')
--病人信息
create table 病人
(
门诊号 varchar(20) not null,
姓名 nvarchar(20) not null,
性别 nvarchar(20) not null,		--男、女
年龄 int not null,
联系电话 varchar(12) not null,
家庭住址 nvarchar(100) null,
身份证号 nvarchar(100) not null,
既往史 nvarchar(1000) null,
现病史 nvarchar(1000) null,
过敏史 nvarchar(1000) null,
constraint pk_病人 primary key(门诊号)
)

go
create table 访客
(
就诊卡号 int not null,
身份证号 nvarchar(100) not null,
姓名 nvarchar(20) not null,
家庭住址 nvarchar(100) null default '',
联系电话 varchar(12) null default '',
密码 varchar(50) not null,
constraint pk_访客 primary key(就诊卡号)
)
insert into 访客 values(1,'12345678',N'王二',N'江苏','1111000','123')


go


--挂号表
create table 挂号
(
挂号序号 int identity(1,1) not null,
就诊卡号 int null default 0,
门诊号 varchar(20) not null,
挂号日期 datetime not null,
急诊挂号 bit default 0 not null,		--0门诊号 1急诊号
挂号科室 nvarchar(50) not null,
挂号医生 nvarchar(20) not null,
号别 nvarchar(20) not null,			--专家号、普通号
挂号费 money not null,
是否收费 bit default 0 not null,	--0未收费 1已收费
是否退号 bit default 0 not null,	--0未退号 1已退号
是否诊断 bit default 0 not null,	--0未诊断 1已诊断
constraint pk_挂号 primary key(挂号序号)
)
go


--收费表
create table 收费表
(
收费编号 int identity(1,1) not null,
就诊卡号 int null default 0,
挂号序号 int not null,
收费类别 nvarchar(50) not null,		--挂号费
收费日期 datetime not null,
收费员 nvarchar(20) not null,
收费金额 money not null,
constraint pk_收费表 primary key(收费编号)
)
go

