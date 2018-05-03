using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{

    public partial class Log
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Message { get; set; }

        public LogType Type { get; set; }

        public string DataAccess { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual int? CreateBy { get; set; }
        public virtual User CreateUser { get; set; }
    }

    public enum LogType
    { 
        Info,
        Error,
        Login,
        //User
        UserViewList,
        UserViewInfo,
        UserAdd,
        UserUpdate,
        UserDelete,
        //Category
        CategoryViewList,
        CategoryViewInfo,
        CategoryAdd,
        CategoryUpdate,
        CategoryDelete,
        //Post
        PostViewList,
        PostViewInfo,
        PostAdd,
        PostUpdate,
        PostDelete,
        //Tag
        TagViewList,
        TagViewInfo,
        TagAdd,
        TagUpdate,
        TagDelete,
        //Permission
        PermissionDeny,
        //Setting
        ClearCache,
        SetSetting,
    }
}
