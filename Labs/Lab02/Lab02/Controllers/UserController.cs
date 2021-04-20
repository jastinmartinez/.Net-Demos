using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab02.Models;

namespace Lab02.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var ruleValidation = new UserValidator();
            var ruleValidationResult = ruleValidation.Validate(user);
            if (ruleValidationResult.IsValid == false)
                foreach (var ruleValidationErrorrs in ruleValidationResult.Errors)
                {
                    ModelState.AddModelError(ruleValidationErrorrs.PropertyName, ruleValidationErrorrs.ErrorMessage);
                }
            return View(user);
        }
    }
}
