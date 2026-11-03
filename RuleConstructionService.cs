using ConsultantRuleConstructor.Data;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsultantRuleConstructor
{
    internal class RuleConstructionService : IRuleConstructionService
    {
        private readonly IUnitOfWork _uow;
        private readonly AppDbContext _dbContext;

        public RuleConstructionService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public int CreateRule(RuleDto ruleDto)
        {
            var builder = new RuleBuilder();

            builder.SetName(ruleDto.Name);

            // ==================== Целевой документ ====================
            builder.SetTargetDocument(new Document() { Name = ruleDto.TargetDocument.Name });

            // ==================== Профили ====================
            builder.setResettlementProgramStatus(ruleDto.ResettlementProgramStatus);

            // ==================== Руководство ====================
            var guide = new Guide();
            guide.Message = ruleDto.Guide.Message;
            guide.Refuse = ruleDto.Guide.Refuse;
            foreach (OrganizationDto organizationDto in ruleDto.Guide.Organizations)
            {
                guide.Organizations.Add(new Organization() { Name = organizationDto.Name, Address = organizationDto.Address });
            }
            builder.SetGuide(guide);

            var rule = builder.Build();
            _dbContext.Rules.Add(rule);
            _dbContext.SaveChanges();

            //return _dbContext.Rules.Last().Id;
            return 1;
        }

        public List<RuleDto> GetAllRules()
        {
            return _dbContext.Rules
                .Include(r => r.TargetDocument)
                .Include(r => r.Guide)
                    .ThenInclude(g => g.Organizations)
                .Select(rule =>
                    new RuleDto()
                    {
                        Id = rule.Id,
                        Name = rule.Name,
                        ResettlementProgramStatus = rule.ResettlementProgramStatus,
                        TargetDocument = new DocumentDto() { Id = rule.TargetDocument.Id, Name = rule.TargetDocument.Name },
                        Guide = new GuideDto()
                        {
                            Id = rule.Guide.Id,
                            Message = rule.Guide.Message,
                            Refuse = rule.Guide.Refuse,
                            Organizations = rule.Guide.Organizations.Select(organization => new OrganizationDto()
                            {
                                Id = organization.Id,
                                Name = organization.Name,
                                Address = organization.Address
                            }).ToList()
                        }
                    }
            ).ToList();
        }

        public RuleDto? GetById(int Id)
        {
            var ruleEntity = _dbContext.Rules
                .Include(r => r.TargetDocument)
                .Include(r => r.Guide)
                    .ThenInclude(g => g.Organizations)
                .FirstOrDefault(r => r.Id == Id);

            if (ruleEntity == null) return null;

            return new RuleDto()
            {
                Id = ruleEntity.Id,
                Name = ruleEntity.Name,
                ResettlementProgramStatus = ruleEntity.ResettlementProgramStatus,
                TargetDocument = new DocumentDto() { Id = ruleEntity.TargetDocument.Id, Name = ruleEntity.TargetDocument.Name },
                Guide = new GuideDto()
                {
                    Id = ruleEntity.Guide.Id,
                    Message = ruleEntity.Guide.Message,
                    Refuse = ruleEntity.Guide.Refuse,
                    Organizations = ruleEntity.Guide.Organizations.Select(organization => new OrganizationDto()
                    {
                        Id = organization.Id,
                        Name = organization.Name,
                        Address = organization.Address
                    }).ToList()
                }
            };
        }
    }
}
