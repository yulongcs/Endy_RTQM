/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- 创建默认管理员用户
insert into [dbo].[lg_Users] values('11111111-aaaa-aaaa-aaaa-000000000001', 'admin', 'ISMvKXpXpadDiUoOSoAfww==', '', '', '', '', GETDATE())

-- 创建系统角色
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000001', 'Admin', N'系统管理员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000002', 'QualityManager', N'质量部门经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000003', 'QualityStaff', N'质量部门职员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000004', 'MCManager', N'生产部门经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000005', 'MCStaff', N'生产部门职员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000006', 'TSManager', N'技术支持部门经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000007', 'TSStaff', N'技术支持部门职员')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000008', 'PLOManager', N'PLO 经理')
insert into [dbo].[lg_Roles] values('11111111-aaaa-aaaa-aaaa-100000000009', 'PLOStaff', N'PLO 职员')

-- 为默认管理员用户分配角色
insert into [dbo].[lg_UserRoles] values('11111111-aaaa-aaaa-aaaa-000000000001', '11111111-aaaa-aaaa-aaaa-100000000001')
