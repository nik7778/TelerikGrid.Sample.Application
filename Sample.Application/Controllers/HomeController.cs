using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Sample.Application.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sample.Application.Helpers;
using Sample.Application.Entities;

namespace Sample.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRecordService _service;
        private IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IRecordService userService, IMapper mapper)
        {
            _logger = logger;
            _service = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {            
            ViewBag.Clients = _service.GetAll().Select(x => x.Client).ToList();
            ViewBag.Staff = new SelectList(_service.GetAll().DistinctBy(x => x.Staff), "Staff", "Staff");
            return View();
        }

        public ActionResult Record_Read([DataSourceRequest]DataSourceRequest request)
        {
            var source = _service.GetAll();
            DataSourceResult result = source.ToDataSourceResult(request);

            return Json(result);
        }
       
        [AcceptVerbs("Post")]
        public ActionResult Record_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Record> model)
        {
            if (model != null && ModelState.IsValid)
            {
                foreach (var item in model)
                {
                    //_userService.Update(_mapper.Map<Record>(user));
                }
            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Record_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Record> model)
        {
            if (model.Any())
            {
                foreach (var item in model)
                {
                    //_userService.Delete(user.Id);
                }
            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }
    }
}