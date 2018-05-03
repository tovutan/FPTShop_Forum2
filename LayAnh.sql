use FPTShop_Forum2
go

-- 1. DBO.Forum_category

 SET IDENTITY_INSERT dbo.Categories OFF

 insert into dbo.Categories(ID,Name,UrlSlug,[image],[description],SEOTitle,SEOKeyword,SEODescription,
 CreateBy,UpdateBy,
ParentID,DateCreated,DateModified,OrderDisplay,IsShow,IsDelete,IsPublic)

			   select  fc.ID, fc.Name,NameAcsii,gp.Url,fc.[Description],fc.SEOTitle,fc.SEOKeyword,fc.SEODescription,
 fc.UserCreated,fc.UserModified,
 fc.ParentID,fc.DateCreated,fc.DateModified,fc.OrderDisplay,fc.IsShow,fc.IsDelete,IsPublic  --14
  FROM FPTShopVer2.dbo.Forum_Category FC
		left join  FPTShopVer2.dbo.Gallery_Picture as gp on fc.PictureID = gp.ID 


--2 DBO.Forum_PostType
SET IDENTITY_INSERT dbo.Forum_PostType ON
	insert into dbo.Forum_PostType(ID,Name,IsShow,IsDelete,DateCreate,UrlSlug)
	select ID,Name,IsShow,IsDeleted,DateCreated,NameAscii from FPTShopVer2.dbo.Forum_News_Post_Type

--3 DBO.Forum_Post
--SET IDENTITY_INSERT dbo.Forum_Post ON
--	insert into dbo.Forum_Post(ID,Title,UrlSlug,[content],[image],SEOTitle,SEOKeyword,SEODescription,[Like],[Dislike],PostTypeID
--	, CategoryID,UserID,DateCreated,DateModified,UserModified,OrderDisplay,IsApproved,IsShow,IsDelete)

--	select * from FPTShopVer2.dbo.Forum_Post as p 
--	left join FPTShopVer2.dbo.Gallery_Picture as gp on p.



--DBO.Forum_Category_Tag_Map
--SET INDENTITY_INSERT dbo.Forum_Category_Tag_Map ON
--	insert into dbo.Forum_Category_Tag_Map(ID,CategoryID,TagID)

--	select ???????????


--dbo.Forum_TagOfCategory

--SET IDENTITY_INSERT dbo.Forum_TagOfCategory ON
--insert into dbo.Forum_TagOfCategory(ID,Name,UrlSlug,[Description])
	
--	select  ???????????


-- delete dữ liệu cũ Post
 delete  from FPTShop_Forum2.dbo.Posts


--4 Thêm Post

Set IDENTITY_INSERT dbo.Posts On

	insert into dbo.Posts(
	ID,Title,UrlSlug,[CONTENT],[Image],SEOTitle,SEOKeyword,SEODescription,RelateProducts,CategoryID,CreateBy,
	DateCreate,DateModified,IsApproved,IsShow,IsDelete,Viewed,LastPostUserName,LastPostUserID,UpdateBy,LastPostDate,
	TotalPost,IsHot,[Description]
	)

	select t.id,t.Name,t.NameAscii,t.Content, gp.Folder+gp.Url ,t.SEOTitle,t.SEOKeyword,t.SEODescription,t.RelatedProducts,t.CateID,t.UserID,
	t.DateCreated,t.DateModified,t.IsAppendID,t.IsShow,t.IsDelete,t.Viewed,t.LastPostUserName,t.LastPostUserID,t.UserModifyID,t.LastPostDate,
	t.TotalPost,t.IsHot,t.Content
	 FROM FPTShopVer2.dbo.Forum_Threads as t left join FPTShopVer2.dbo.Gallery_Picture as gp on gp.ID=t.PictureID


-- Lấy dữ liệu User

SET IDENTITY_INSERT fptshop_forum2.dbo.[User] on

insert into fptshop_forum2.dbo.[user] (ID,firstname,lastname,username,PasswordHash,email,IsDeleted)

select id,firstname,lastname,username,[password],email,IsDelete 
from FPTShopVer2.dbo.Customer



update FPTShop_Forum2.dbo.Posts
set IsHot=0 where ishot is null

--5 lấy Product
SET IDENTITY_INSERT dbo.Forum_Product OFF

insert into dbo.Forum_Product(
ID,LabelID,BrandID,
ImageUrl,
PictureHotID,ProductTypeID,Name,NameAscii,Code,ShortDescription,[Description],PromotionInfo,
IncludeInfo,HightlightsDes,HightlightsShortDes,AttachedAccessories,Policy,Details,InfoDriver,VideoDetail,VideoRating,
Guide,Overview,OverviewVideo,Overview360,DisplayOrderSearch,DisplayOrderCategory,DisplayOrderApple,DisplayDiscount,
DisplayOrder,DisplayOrderBestSeller,DisplayOrderBestSellerType,DisplayOrderHotByCate,StockTypeID,DiscountID,SizeLength,
SizeWidth,SizeHeight,[Weight],Warranty,IsShow,IsSlide,IsHot,IsDelete,Viewed,IsShowOnHomePage,IsAllowRating,IsAllowComment,
IsPreOrder,IsShowFormIdea,IsApplyNewTemplate,CreatedOnUtc,UpdatedOnUtc,CreateBy,UpdateBy,IsComingSoon,DisplayOrderOnMobile,
SEOTitle,SEODescription,SEOKeyword,ComingSoonInfo,LinkApp,LinkLanding,IsAllowLanding,IsGetBestsellerPhone,HeaderPopupGetPhone,
ContentPopupGetPhone,PictureDetailID,Hightlights,PictureArticleID,DisplayOrderBrand,IsPaymentOnline,IsService,IsShowPreOrder,
PreOrderDateStart,PreOrderDateEnd,PricePreOrder,IsNotBusiness,IsGetPhoneGirl,TotalView,TotalOrder,IsDeals,
PictureHotCateLaptopID,GameTypeId,GameStart,GameEnd,IsUseOrderPage,LinkRedirect,IsAllowRedirect,IsShowInSearch,StatusID
)

select 
p.ID,p.LabelID,p.BrandID,gp.url,p.PictureHotID,p.ProductTypeID,p.Name,p.NameAscii,p.Code,p.ShortDescription,p.[Description],
p.PromotionInfo,p.IncludeInfo,p.HightlightsDes,p.HightlightsShortDes,p.AttachedAccessories,p.Policy,p.Details,p.InfoDriver,
p.VideoDetail,p.VideoRating,p.Guide,p.Overview,p.OverviewVideo,p.Overview360,p.DisplayOrderSearch,p.DisplayOrderCategory,
p.DisplayOrderApple,p.DisplayDiscount,p.DisplayOrder,p.DisplayOrderBestSeller,p.DisplayOrderBestSellerType,
p.DisplayOrderHotByCate,p.StockTypeID,p.DiscountID,p.SizeLength,p.SizeWidth,p.SizeHeight,p.[Weight],p.Warranty,p.IsShow,
p.IsSlide,p.IsHot,p.IsDelete,p.Viewed,p.IsShowOnHomePage,p.IsAllowRating,p.IsAllowComment,p.IsPreOrder,p.IsShowFormIdea,
p.IsApplyNewTemplate,p.CreatedOnUtc,p.UpdatedOnUtc,p.CreateBy,p.UpdateBy,p.IsComingSoon,p.DisplayOrderOnMobile,
p.SEOTitle,p.SEODescription,p.SEOKeyword,p.ComingSoonInfo,p.LinkApp,p.LinkLanding,p.IsAllowLanding,p.IsGetBestsellerPhone,
p.HeaderPopupGetPhone,p.ContentPopupGetPhone,p.PictureDetailID,p.Hightlights,p.PictureArticleID,p.DisplayOrderBrand,
p.IsPaymentOnline,p.IsService,p.IsShowPreOrder,p.PreOrderDateStart,p.PreOrderDateEnd,p.PricePreOrder,p.IsNotBusiness,
p.IsGetPhoneGirl,p.TotalView,p.TotalOrder,p.IsDeals,p.PictureHotCateLaptopID,p.GameTypeId,p.GameStart,p.GameEnd,
p.IsUseOrderPage,p.LinkRedirect,p.IsAllowRedirect,p.IsShowInSearch,p.StatusID

from FPTShopVer2.dbo.Shop_Product as p left join FPTShopVer2.dbo.Gallery_Picture as gp on p.PictureID=gp.ID



--



-- đếm 
  select count(*) ImageUrl from dbo.Forum_Product where ImageUrl is not null

  select count(*) PictureID from FPTShopVer2.dbo.Shop_Product as t where t.PictureID  is not null

  select count(*) pictureID from FPTShopVer2.dbo.Forum_Threads AS T WHERE t.PictureID IS NOT NULL

  select count(*) url from FPTShop_Forum.dbo.Forum_Post as t where t.[image] is not null
  

  --delete FPTShop_Forum2.dbo.Categories
--delete FPTShop_Forum2.dbo.Posts 
--delete FPTShop_Forum2.dbo.[User]
--delete FPTShop_Forum2.dbo.[Role]




