using App.Data.Entities;
using System;

namespace App.Data.DTOs
{
    public static class CaseCommentExtension
    {
        public static CaseCommentDTO ToModel(this CaseComment entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CaseCommentDTO
            {
                Id = entity.Id,
                UserId = (Guid)entity.UserId,
                CaseId = entity.CaseId,
                CreatedAt = entity.CreatedAt,
                Comment = entity.Comment,
            };
        }
    }


    public class CaseCommentDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CaseId { get; set; }

        public string Comment { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
