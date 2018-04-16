using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Models.User
{
    [Serializable]
    public class UserItemModel
    {
        public string ID { get; set; }
        public string Email { get; set; }  
        #region User Info
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
