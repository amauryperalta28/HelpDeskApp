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
    /// Assembler for <see cref="PRIORIDAD"/> and <see cref="Prioridad"/>.
    /// </summary>
    public static partial class PrioridadHelper
    {
        /// <summary>
        /// Invoked when <see cref="ToModel"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="Prioridad"/> converted from <see cref="PRIORIDAD"/>.</param>
        static partial void OnDTO(this PRIORIDAD entity, Prioridad dto);

        /// <summary>
        /// Invoked when <see cref="ToTable"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="PRIORIDAD"/> converted from <see cref="Prioridad"/>.</param>
        static partial void OnEntity(this Prioridad dto, PRIORIDAD entity);

        /// <summary>
        /// Converts this instance of <see cref="Prioridad"/> to an instance of <see cref="PRIORIDAD"/>.
        /// </summary>
        /// <param name="dto"><see cref="Prioridad"/> to convert.</param>
        public static PRIORIDAD ToTable(this Prioridad dto)
        {
            if (dto == null) return null;

            var entity = new PRIORIDAD();

            entity.Id = dto.Id;
            entity.Descripcion = dto.Descripcion;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="PRIORIDAD"/> to an instance of <see cref="Prioridad"/>.
        /// </summary>
        /// <param name="entity"><see cref="PRIORIDAD"/> to convert.</param>
        public static Prioridad ToModel(this PRIORIDAD entity)
        {
            if (entity == null) return null;

            var dto = new Prioridad();

            dto.Id = entity.Id;
            dto.Descripcion = entity.Descripcion;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="Prioridad"/> to an instance of <see cref="PRIORIDAD"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<PRIORIDAD> ToTables(this IEnumerable<Prioridad> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToTable()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="PRIORIDAD"/> to an instance of <see cref="Prioridad"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<Prioridad> ToModels(this IEnumerable<PRIORIDAD> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToModel()).ToList();
        }

        public static bool Save(Prioridad model)
        {
            bool result;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
               

                try
                {
                    context.PRIORIDAD.Add(model.ToTable());
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

        public static List<Prioridad> GetAll()
        {
            List<Prioridad> list;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.PRIORIDAD.ToList();
                list = queryResult.Count > 0 ? ToModels(queryResult) : new List<Prioridad>();
            }
            return list;
        }

        public static Prioridad GetPrioridadByPrimaryKey(int Id)
        {
            Prioridad Obj;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.PRIORIDAD.SingleOrDefault(a => a.Id == Id);
                Obj = ToModel(queryResult);
            }
            return Obj;

        }
    }
}
