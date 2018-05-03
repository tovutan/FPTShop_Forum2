UPDATE  FPTShop_Forum2.dbo.Posts
SET     [Image] = '{"AvataImage":{"Original":"//fptshop.com.vn/Uploads/Originals/' + [Image] + '",'+
     '"Medium":"//fptshop.com.vn/Uploads/Mediums/' + [Image] + '",'+
     '"Thumb":"//fptshop.com.vn/Uploads/Thumbs/' + [Image] + '"},"ImageList":[]}'
WHERE   SUBSTRING([Image], 0, 3) != '{"';




--UPDATE FPTShop_Forum2.dbo.Posts
--SET [IMAGE]='{"AvataImage":{Original":"//fptshop.com.vn/Uploads/Originals/'+[Image]+'",'+
--	'"Medium":"//fptshop.com.vn/Uploads/Mediums/'+[Image]+'",'+
--	'"Thumb":"//fptshop.com.vn/Uploads/Thumbs/'+[Image]+'"},"ImageList":[]}'
--where SUBSTRING([Image],0,3)!='{"';