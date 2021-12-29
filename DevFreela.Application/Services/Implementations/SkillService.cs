﻿using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContext.Skills;
            var skillsViewModel = skills
                .Select(x => new SkillViewModel(x.Id, x.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
