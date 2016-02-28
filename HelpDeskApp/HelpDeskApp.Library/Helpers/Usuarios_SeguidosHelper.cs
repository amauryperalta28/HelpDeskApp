using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskApp.Common.Models;
using HelpDeskApp.Entity;

namespace HelpDeskApp.Library.Helpers
{
    public static class Usuarios_SeguidosHelper
    {
        public static Usuarios_Seguidos ToModel(this USUARIOS_SEGUIDOS Table)
        {
            return new Usuarios_Seguidos
            {
                UserId = Table.UserId,
                UserFollowedId = Table.UserFollowedId
            };
        
        }

         public static USUARIOS_SEGUIDOS ToTable(this Usuarios_Seguidos Model)
        {
            return new USUARIOS_SEGUIDOS
            {
                UserId = Model.UserId,
                UserFollowedId = Model.UserFollowedId
            };
        
        }

         public static bool Save(Usuarios_Seguidos model)
         {
             bool result;

             using (HelpDeskApfEntities context = new HelpDeskApfEntities())
             {
                 try
                 {
                     context.USUARIOS_SEGUIDOS.Add(model.ToTable());
                     context.SaveChanges();
                     result = true;
                 }
                 catch (Exception)
                 {

                     result = false;
                 }

             }

             return result;
         }

         public static List<Usuarios_Seguidos> GetAll()
         {
             List<Usuarios_Seguidos> list;

             using (HelpDeskApfEntities context = new HelpDeskApfEntities())
             {
                 var queryResult = context.USUARIOS_SEGUIDOS.ToList();
                 list = queryResult.Count > 0 ? queryResult.Select(x=> x.ToModel()).ToList(): new List<Usuarios_Seguidos>();
             }
             return list;
         }

         //Todo: Get de Los usuarios seguidos por un usuario
         public static bool Delete(Usuarios_Seguidos rel)
         {
             bool result;
             using (var db = new HelpDeskApfEntities())
             {
                 var rs = db.USUARIOS_SEGUIDOS.Where(x => x.UserId == rel.UserFollowedId).ToList();
                 foreach (var i in rs)
                 {
                     db.USUARIOS_SEGUIDOS.Remove(i);
                 }
                 try
                 {
                     db.SaveChanges();
                     result = true;
                 }
                 catch (Exception ex)
                 {

                     result = false;
                 }


             }
             return result;
         }

         public static bool UserIsFollowed(Usuarios_Seguidos rel)
         {

             bool result;

             using (HelpDeskApfEntities context = new HelpDeskApfEntities())
             {
                 var queryResult = context.USUARIOS_SEGUIDOS.SingleOrDefault(u => u.UserFollowedId == rel.UserFollowedId && u.UserId == rel.UserId);
                 result = queryResult != null? true : false;
             }

             return result;
         }

        
    }
}
