//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/20 - 17:52:53
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HelpDeskApp.Common.Models
{
    [DataContract()]
    public partial class User_Followed_User
    {
        [DataMember()]
        public Int32 UserID { get; set; }

        [DataMember()]
        public Int32 UserIdFollowed { get; set; }

        [DataMember()]
        public DateTime Fecha_Creacion { get; set; }

        [DataMember()]
        public Int32 USER_FOLLOWED_USER1_UserID { get; set; }

        [DataMember()]
        public Int32 USER_FOLLOWED_USER1_UserIdFollowed { get; set; }

        [DataMember()]
        public Int32 USER_FOLLOWED_USER2_UserID { get; set; }

        [DataMember()]
        public Int32 USER_FOLLOWED_USER2_UserIdFollowed { get; set; }

        [DataMember()]
        public Int32 USUARIOS_id { get; set; }

        public User_Followed_User()
        {
        }

        public User_Followed_User(Int32 userID, Int32 userIdFollowed, DateTime fecha_Creacion, Int32 uSER_FOLLOWED_USER1_UserID, Int32 uSER_FOLLOWED_USER1_UserIdFollowed, Int32 uSER_FOLLOWED_USER2_UserID, Int32 uSER_FOLLOWED_USER2_UserIdFollowed, Int32 uSUARIOS_id)
        {
			this.UserID = userID;
			this.UserIdFollowed = userIdFollowed;
			this.Fecha_Creacion = fecha_Creacion;
			this.USER_FOLLOWED_USER1_UserID = uSER_FOLLOWED_USER1_UserID;
			this.USER_FOLLOWED_USER1_UserIdFollowed = uSER_FOLLOWED_USER1_UserIdFollowed;
			this.USER_FOLLOWED_USER2_UserID = uSER_FOLLOWED_USER2_UserID;
			this.USER_FOLLOWED_USER2_UserIdFollowed = uSER_FOLLOWED_USER2_UserIdFollowed;
			this.USUARIOS_id = uSUARIOS_id;
        }
    }
}
