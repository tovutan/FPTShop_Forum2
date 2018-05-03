using ImageResizer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FPTShop_Forum2.Helper.Admin
{
    public static class ImageHelper
    {
        public const int ImageMinimumBytes = 512;
        public const int ImageMaximumBytes = 10485760; // 10MB

        public const string IMAGE_URL = "/Uploads/";
        public const string IMAGE_CATEGORY_FOLDER = "category";
        public const string IMAGE_TAG_FOLDER = "tag";
        public const string IMAGE_USER_FOLDER = "user";

        public const string IMAGE_ORIGINAL_Folder = "Originals";
        public const string IMAGE_THUMB_Folder = "Thumbs";
        public const string IMAGE_MEDIUMS_Folder = "Mediums";


        // Check the Isimage
        public static bool IsImage(this HttpPostedFileBase postedFile)
        {
            if (postedFile == null)
                return false;

            //Check the image Types
            if (postedFile.ContentType.ToLower() != "image/jpeg"
                && postedFile.ContentType.ToLower() != "image/pjpeg"
                && postedFile.ContentType.ToLower() != "image/gif"
                && postedFile.ContentType.ToLower() != "image/x-png"
                && postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //Check the image Extension // Kiểm tra .đuôi của hình ảnh nếu khác những cái dưới thì return false;
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
             && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
             && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
             && Path.GetExtension(postedFile.FileName).ToLower() != "jpeg")
            {
                return false;
            }

            //Attempt to read the file and check the first Bytes

            try
            {
                if (!postedFile.InputStream.CanRead)
                {
                    return false;   
                }
                if (postedFile.ContentLength < ImageMinimumBytes)
                {
                    return false;
                }
                if (postedFile.ContentLength > ImageMaximumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[512];
                postedFile.InputStream.Read(buffer, 0, 512);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            // try to instantiate new Bitmap, if .NET will throw exception 
            // we can assume that it's not  a valid image

            try
            {
                using (var bitmap = new Bitmap(postedFile.InputStream))
                {

                }
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                postedFile.InputStream.Position = 0;
            }
            return true;
        }


        // tải ảnh
        public static string UploadImage(HttpPostedFileBase image, string filePathOriginal, string fileName = null)
        {
            if (image == null || image.ContentLength == 0)
                return null;
            if (!IsImage(image))
                return null;

            //Save Image to File
            var imageExtension = Path.GetExtension(image.FileName); //trả về .
            var fileNameASCII=string.IsNullOrEmpty(fileName)?SeoHelper.GetSeName(Path.GetFileNameWithoutExtension(image.FileName)):SeoHelper.GetSeName(fileName);
            var newName = fileNameASCII+imageExtension;

            string savedFileName = Path.Combine(filePathOriginal, newName);
            Directory.CreateDirectory(filePathOriginal);

            int fileCount = 0;
            while (File.Exists(savedFileName))
            {
                fileCount++;
                newName = $"{fileNameASCII}_{fileCount}{imageExtension}";
                savedFileName = Path.Combine(filePathOriginal, newName);
            }
            image.SaveAs(savedFileName);
            return newName;
        }

        public static string ResizeImage(string filePathOriginal, string filePathResize, int maxSize)
        {
            try
            {
                var fullFileName = Path.GetFileName(filePathOriginal); // Lấy tên File dạng như abc.jpeg, a.png....
                var fileExtension = Path.GetExtension(fullFileName); // nếu là abc.jpeg thì sẽ lấy .jpeg;
                var fileName = Path.GetFileNameWithoutExtension(fullFileName); // Nếu là abc.jpeg sẽ lấy abc
                var newFileName = $"{fileName}_thumb_{maxSize}{fileExtension}";

                ResizeSettings resizeSetting = new ResizeSettings();
                resizeSetting.MaxHeight = resizeSetting.MaxWidth = maxSize;

                string resizeFilePath = Path.Combine(filePathResize, newFileName);
                if (File.Exists(resizeFilePath))
                {
                    return newFileName;
                }

                System.IO.Directory.CreateDirectory(filePathResize);
                ImageBuilder.Current.Build(filePathOriginal, resizeFilePath, resizeSetting);
                return newFileName;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static string ResizeImageThumb(string filePathOriginal, string filePathResize)
        {
            return ResizeImage(filePathOriginal, filePathResize, 192);
        }

        public static string ResizeImageMedium(string filePathOriginal, string filePathResize)
        {
            return ResizeImage(filePathOriginal, filePathResize, 640);
        }

        public static IList<string> GetImageInFolder(string path)
        {
            return Directory.GetFiles(path).Select(f => Path.GetFileName(f)).ToList();
        }
    }
}