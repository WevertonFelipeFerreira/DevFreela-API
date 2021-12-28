using System;
using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("ASP NET CORE PROJECT 1","My First project 1",1,1,10000),
                new Project("ASP NET CORE PROJECT 2","My First project 2",1,1,10000),
                new Project("ASP NET CORE PROJECT 3","My First project 3",1,1,20000)
            };
            Users = new List<User>
            {
                new User("Weverton Felipe","WevertonFelipe@gmail.com",new DateTime(1999,01,01)),
                new User("João Augusto","JoaoAugusto@gmail.com",new DateTime(2005,02,15)),
                new User("Carol Vitoria","CarolVitoria@gmail.com",new DateTime(1995,09,27))
            };
            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("SQL Server"),
                new Skill("PHP"),
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
