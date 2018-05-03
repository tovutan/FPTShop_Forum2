using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTShop_Forum2.Helper
{
    public static class CacheManagerHelper
    {
        private static ICacheManager<object> _cacheManager = null;
        public static ICacheManager<object> CacheManager
        {
            get
            {
                if (_cacheManager == null)
                {
                    _cacheManager = CacheFactory.FromConfiguration<object>("cacheShortTime");
                }
                return _cacheManager;
            }
        }

        // 15 phút
        public static T GetOrSet<T>(string key, CacheRegion region, System.Func<T> valueFactory, TimeoutMinutes timeoutMinutes = TimeoutMinutes.m15)
        {
            try
            {
                if (!CacheManager.Exists(key, region.ToString()))
                {
                    var item = new CacheItem<object>(key, region.ToString(), valueFactory(), ExpirationMode.Absolute, TimeSpan.FromMinutes((int)timeoutMinutes));
                    CacheManager.Add(item);
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
            return CacheManager.Get<T>(key, region.ToString());
        }

        // 15 phut
        public static T CacheGetOrSet<T>(this Controller controller, string key, CacheRegion region, System.Func<T> valueFactory,
            TimeoutMinutes timeoutMinutes = TimeoutMinutes.m15)
        {
            return GetOrSet<T>(key, region, valueFactory, timeoutMinutes);
        }

        public static bool Remove(
            string key,
            CacheRegion region
            )
        {
            return CacheManager.Remove(key, region.ToString());
        }

        public static bool CacheRemove(this Controller controller, string key, CacheRegion region)
        {
            return Remove(key, region);
        }

        public static void Remove(CacheRegion region)
        {
            CacheManager.ClearRegion(region.ToString());
        }

        public static void CacheRemove(this Controller controller, CacheRegion region)
        {
            Remove(region);
        }
    }

    #region Enum
    public enum CacheRegion
    {
        // Web
        Home,
        Category,
        ChildCategory,
        Post,
        Video,
        VideoDetail,
        Widget,
        Setting,

        // Admin
        AdminCategory,
        AdminCategoryDetail,
        AdminTag,
        AdminTagDetail,
        AdminPost,
        AdminPostDetail,
        AdminUser,
        AdminUserDetail
    }

    public enum TimeoutMinutes
    {
        m15 = 15,
        m30 = 30,
        h1 = 60,
        h5 = 300,
        d1 = 1440
    }
    #endregion
}