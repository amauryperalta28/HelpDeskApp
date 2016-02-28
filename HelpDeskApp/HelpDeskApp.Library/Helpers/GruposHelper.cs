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
    /// Assembler for <see cref="GRUPOS"/> and <see cref="Grupos"/>.
    /// </summary>
    public static partial class GruposHelper
    {
        /// <summary>
        /// Invoked when <see cref="ToModel"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="Grupos"/> converted from <see cref="GRUPOS"/>.</param>
        static partial void OnDTO(this GRUPOS entity, Grupos dto);

        /// <summary>
        /// Invoked when <see cref="ToTable"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="GRUPOS"/> converted from <see cref="Grupos"/>.</param>
        static partial void OnEntity(this Grupos dto, GRUPOS entity);

        /// <summary>
        /// Converts this instance of <see cref="Grupos"/> to an instance of <see cref="GRUPOS"/>.
        /// </summary>
        /// <param name="dto"><see cref="Grupos"/> to convert.</param>
        public static GRUPOS ToTable(this Grupos dto)
        {
            if (dto == null) return null;

            var entity = new GRUPOS();

            entity.Id = dto.Id;
            entity.Descripcion = dto.Descripcion;
            entity.Fecha_Creacion = DateTime.Now;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="GRUPOS"/> to an instance of <see cref="Grupos"/>.
        /// </summary>
        /// <param name="entity"><see cref="GRUPOS"/> to convert.</param>
        public static Grupos ToModel(this GRUPOS entity)
        {
            if (entity == null) return null;

            var dto = new Grupos();

            dto.Id = entity.Id;
            dto.Descripcion = entity.Descripcion;
            dto.Fecha_Creacion = entity.Fecha_Creacion;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="Grupos"/> to an instance of <see cref="GRUPOS"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<GRUPOS> ToTables(this IEnumerable<Grupos> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToTable()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="GRUPOS"/> to an instance of <see cref="Grupos"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<Grupos> ToModels(this IEnumerable<GRUPOS> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToModel()).ToList();
        }

        public static bool Save(Grupos model)
        {
            bool result;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                

                try
                {
                    context.GRUPOS.Add(model.ToTable());
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

        public static List<Grupos> GetAll()
        {
            List<Grupos> list;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.GRUPOS.ToList();
                list = queryResult.Count > 0 ? ToModels(queryResult) : new List<Grupos>();
            }
            return list;
        }

        public static Grupos GetGrupoByPrimaryKey(int Id)
        {
            Grupos Obj;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.GRUPOS.SingleOrDefault(a => a.Id == Id);
                Obj = ToModel(queryResult);
            }
            return Obj;

        }

    }
}
