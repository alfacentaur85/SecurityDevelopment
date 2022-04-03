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

        public JsonResult GetById(int id);

        public JsonResult GetByAnyStringValue(string anyStringValue);

        public JsonResult DeleteById(int id);
    }
}
