using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SecurityDevelopment.Abstractions
{
    public interface IRepository
    {
        public JsonResult GetAll();

        public JsonResult GetById(int Id);

        public JsonResult GetByAnyStringValue(string AnyStringValue);

        public JsonResult Create(object obj);

        public JsonResult DeleteById(int Id);

        public JsonResult Update(object obj);
    }
}
