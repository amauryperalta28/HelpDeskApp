//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToModels.v3.2 (entitiesToModels.codeplex.com).
//     Timestamp: 2016/02/20 - 17:52:56
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using HelpDeskApp.Common.Models;
using HelpDeskApp.Entity;

namespace HelpDeskApp.Library.Helpers
{

    /// <summary>
    /// Assembler for <see cref="ORGANIZACION"/> and <see cref="Organizacion"/>.
    /// </summary>
    public static partial class OrganizacionHelper
    {
        /// <summary>
        /// Invoked when <see cref="ToModel"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="Organizacion"/> converted from <see cref="ORGANIZACION"/>.</param>
        static partial void OnDTO(this ORGANIZACION entity, Organizacion dto);

        /// <summary>
        /// Invoked when <see cref="ToTable"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ORGANIZACION"/> converted from <see cref="Organizacion"/>.</param>
        static partial void OnEntity(this Organizacion dto, ORGANIZACION entity);

        /// <summary>
        /// Converts this instance of <see cref="Organizacion"/> to an instance of <see cref="ORGANIZACION"/>.
        /// </summary>
        /// <param name="dto"><see cref="Organizacion"/> to convert.</param>
        public static ORGANIZACION ToTable(this Organizacion dto)
        {
            if (dto == null) return null;

            var entity = new ORGANIZACION();

            entity.Id = dto.Id;
            entity.Descripcion = dto.Descripcion;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ORGANIZACION"/> to an instance of <see cref="Organizacion"/>.
        /// </summary>
        /// <param name="entity"><see cref="ORGANIZACION"/> to convert.</param>
        public static Organizacion ToModel(this ORGANIZACION entity)
        {
            if (entity == null) return null;

            var dto = new Organizacion();

            dto.Id = entity.Id;
            dto.Descripcion = entity.Descripcion;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="Organizacion"/> to an instance of <see cref="ORGANIZACION"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ORGANIZACION> ToTables(this IEnumerable<Organizacion> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToTable()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="ORGANIZACION"/> to an instance of <see cref="Organizacion"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<Organizacion> ToModels(this IEnumerable<ORGANIZACION> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToModel()).ToList();
        }

        public static bool Save(Organizacion model)
        {
            bool result;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                

                try
                {
                    context.ORGANIZACION.Add(model.ToTable());
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

        public static List<Organizacion> GetAll()
        {
            List<Organizacion> list;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.ORGANIZACION.ToList();
                list = queryResult.Count > 0 ? ToModels(queryResult) : new List<Organizacion>();
            }
            return list;
        }

        public static Organizacion GetOrganizacionByPrimaryKey(int Id)
        {
            Organizacion Obj;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.ORGANIZACION.SingleOrDefault(a => a.Id == Id);
                Obj = ToModel(queryResult);
            }
            return Obj;

        }
    }
}
