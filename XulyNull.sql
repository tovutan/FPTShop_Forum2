alter table fptshop_forum3.dbo.[user]
alter column emailconfirmed bit null



alter table fptshop_forum3.dbo.[user]
alter column phonenumberconfirmed bit null

alter table fptshop_forum3.dbo.[user]
alter column twofactorenabled bit null

alter table fptshop_forum3.dbo.[user]
alter column lockoutenabled bit null

alter table fptshop_forum2.dbo.[user]
alter column accessfailedcount int null


alter table fptshop_forum3.dbo.[user]
alter column isdeleted bit null

alter table fptshop_forum3.dbo.[user]
alter column isdeleted bit null

alter table fptshop_forum2.dbo.[user]
alter column username nvarchar(300) null

alter table fptshop_forum3.dbo.[user]
alter column datecreate datetime null

alter table fptshop_forum2.dbo.category
alter column parentID INT  NULL

alter table fptshop_forum2.dbo.categories
alter column name nvarchar(400)  

alter table fptshop_forum2.dbo.categories
alter column urlslug nvarchar(450)  


alter table fptshop_forum3.dbo.POST
alter column ISHOT BIT  NULL

alter table fptshop_forum2.dbo.POST
alter column IsApproved BIT  NULL

alter table fptshop_forum3.dbo.POST
alter column CREATEBY  INT not null 


alter table fptshop_forum3.dbo.POST
alter column categoryID  INT  null 

alter table fptshop_forum2.dbo.POSTs
alter column urlslug nvarchar(400)  NULL

alter table fptshop_forum2.dbo.POST
alter column lastPostUserID INT  NULL
--Tag
alter table fptshop_forum2.dbo.tags
alter column name nvarchar(450)  



ALTER TABLE [user]
ADD AccessFailedCount bit null;
--Drop Column User
ALTER TABLE [User]
DROP COLUMN AccessFailedCount;

ALTER TABLE Post with nocheck
ADD FOREIGN KEY (LastPostUserID) REFERENCES [User](id);


ALTER TABLE  Category WITH NOCHECK
ADD CONSTRAINT  FK_Category_ID_Category_ParentID 
FOREIGN KEY  (ParentID)  REFERENCES  [Category](id);


ALTER TABLE POST WITH NOCHECK
ADD CONSTRAINT FK_Post_User_CreateBy
FOREIGN KEY (CreateBy) REFERENCES [USER](id);

ALTER TABLE POST WITH NOCHECK
ADD CONSTRAINT FK_Post_User_UpdateBy
FOREIGN KEY (UpdateBy) REFERENCES [USER](id);

ALTER TABLE pOST
DROP CONSTRAINT LastPostUser;



