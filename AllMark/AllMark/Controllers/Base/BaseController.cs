using AllMark.Code.ActionFilters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AllMark.Controllers.Base
{
    [UserViewBag]
    public class BaseController: Controller
    {
        public ViewResult View(IMapper mapper, object model, Type destinationType)
        {
            var sourceType = model.GetType();
            var dto = mapper.Map(model, sourceType, destinationType);
            return View(dto);
        }

        public JsonResult Json(IMapper mapper, object model, Type destinationType)
        {
            var sourceType = model.GetType();
            var dto = mapper.Map(model, sourceType, destinationType);
            return Json(dto);
        }
    }
}
