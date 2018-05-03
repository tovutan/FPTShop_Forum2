using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class CategoryServices:BaseServices
    {
        private static CategoryServices _categoryServices;
        public static  CategoryServices GetInstance()
        {
            if (_categoryServices == null)
            {
                lock (typeof(CategoryServices))
                {
                    _categoryServices = new CategoryServices();
                }
            }
            return _categoryServices;
        }

        // lấy ra danh sách Category !IsDelete và sắp xếp theo ID

        private List<Category> _DefaultListCategory
        {
            get
            {
                return _db.Categories.Where(c => !c.IsDelete &&c.IsShow).OrderBy(c=>c.OrderDisplay).ToList();
            }
        }

        // Lấy ra List Category có ParentID theo Những mục có trên trang chủ
        
        public List<Category> GetList() 
        {
            // var _return = _DefaultListCategory.Where(c=>c.ParentID==0);
            var _return = _DefaultListCategory;
            return _return.ToList();
        }

        // Lấy ra ListCategoryChild truyền theo URL
        public List<Category> GetListChild(string catChildURL)
        {
            var _return = _DefaultListCategory.FirstOrDefault(c => c.UrlSlug.CompareTo(catChildURL) == 0);
            var parentID = _return.ID;
            var listCatChild = _DefaultListCategory.Where(c => c.ParentID == parentID).ToList();
            return listCatChild;
        }
        // Lấy ra chi tiết Category có ParentID or không có ParentID

        //public  Category GetCategory(string url,bool? haveParner=false) // cho bool? vì có lúc mình ko cần truyền tham số cho nó
        //{
        //    var kq= _DefaultListCategory.FirstOrDefault(c => c.UrlSlug == url && haveParner.HasValue ? c.ParentID.HasValue == haveParner
        //     : true
        //    );
        //    return kq;
        //}

        public Category GetCategory(string url, bool? haveParner = false) // cho bool? vì có lúc mình ko cần truyền tham số cho nó
        {

            var kq = _DefaultListCategory.FirstOrDefault(
                c => c.UrlSlug.CompareTo(url) == 0
            );
            return kq;
        }

    }
}
