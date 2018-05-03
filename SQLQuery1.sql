--select FK_column from FK_table
--WHERE FK_column NOT IN
--(SELECT PK_column from PK_table)

--alter table company drop constraint Company_CountryID_FK
--alter table company drop column CountryID


alter table Posts drop constraint LastUserModifiedID


alter table Posts drop column LastUserModifiedID


ALTER TABLE Posts
DROP CONSTRAINT  CreateBy;






DECLARE @ConstraintName nvarchar(128)
SELECT 
    @ConstraintName = KCU.CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC 
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU
    ON KCU.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG  
    AND KCU.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA 
    AND KCU.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
WHERE
    KCU.TABLE_NAME = '[Posts]' AND
    KCU.COLUMN_NAME = 'LastUserModifiedID'
IF @ConstraintName IS NOT NULL EXEC('alter table [Posts] drop  CONSTRAINT ' + @ConstraintName)


--ALTER TABLE Orders
--ADD FOREIGN KEY (PersonID) REFERENCES Persons(PersonID);

--ALTER TABLE table_name
--ADD column_name datatype;


--ALTER TABLE table_name
--DROP COLUMN column_name;

alter table Posts
drop column CreateBy

alter table Posts
add LastPostUserID nvarchar(128)

alter table Posts
alter column LastPostUserID nvarchar(128)

alter table Posts
ALTER COLUMN LastUserModifiedID nvarchar(128)

ALTER TABLE posts
alter column ISHOT BIT NULL

ALTER TABLE posts
alter column isapproved BIT NULL

 update Posts set Ishot=0 where ishot is null





delete from posts

ALTER TABLE Posts
ADD FOREIGN KEY (LastPostUserID)  REFERENCES [USER](Id);


ALTER TABLE Posts WITH NOCHECK


select distinct Posts.LastPostUserID from Posts left join [User] 
on Posts.LastPostUserID = [user].ID 
where Posts.LastPostUserID is null