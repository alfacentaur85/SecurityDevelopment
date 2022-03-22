using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityDevelopment.Models;

namespace SecurityDevelopment.Abstractions
{
    public interface IRepositoryDebetCard : IRepository
    {
        public JsonResult Create(IReadOnlyList<DebetCard> cards);

        public JsonResult Update(IReadOnlyList<DebetCard> cards);
    }
}
