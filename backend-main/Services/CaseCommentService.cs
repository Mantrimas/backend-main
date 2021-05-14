using App.Data.DTOs;
using App.Data.Entities;
using App.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public class CaseCommentService : ICaseCommentService
    {
        private readonly ICaseCommentRepository _caseCommentRepository;
        public CaseCommentService(ICaseCommentRepository caseCommentRepository)
        {
            _caseCommentRepository = caseCommentRepository;
        }

        public async Task<CaseCommentDTO> GetAsync(Guid id)
        {
            var entity = await _caseCommentRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Comment not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<CaseCommentDTO>> GetByCaseIdAsync(Guid id) // get projects by user id
        {
            var entityList = _caseCommentRepository.Find(x => x.CaseId == id);
            if (entityList == null)
            {
                throw new Exception("No comments found");
            }
            var modelList = new List<CaseCommentDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }

        public async Task<IEnumerable<CaseCommentDTO>> GetAllAsync()
        {
            var query = await _caseCommentRepository.GetAllAsync();
            var entity = query.Select(entity => entity.ToModel());
            return entity;
        }

        public async Task<Guid> CreateAsync(CaseCommentDTO model)
        {
            var entity = new CaseComment()
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                CaseId = model.CaseId,
                Comment = model.Comment,
                CreatedAt = model.CreatedAt
            };

            await _caseCommentRepository.InsertAsync(entity);
            await _caseCommentRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _caseCommentRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Comment not found");
            }
            _caseCommentRepository.Delete(entity);
            await _caseCommentRepository.SaveAsync();
        }

        public async Task<CaseCommentDTO> EditAsync(CaseCommentDTO model)
        {
            var entity = await _caseCommentRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Comment not found");
            }

            entity.Id = model.Id;
            entity.UserId = model.UserId;
            entity.CaseId = model.CaseId;
            entity.Comment = model.Comment;
            entity.CreatedAt = model.CreatedAt;
            _caseCommentRepository.Update(entity);
            await _caseCommentRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
