using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecurityDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace SecurityDevelopment.Abstractions
{
    public interface IRepositoryPerson : IRepository
    {
        public JsonResult Create(IReadOnlyList<Person> persons);

        public JsonResult Update(IReadOnlyList<Person> cards);
    }
}
