﻿using System.Web.Mvc;
using System.Threading.Tasks;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;
using PairingTest.Web.Services;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : BaseController
    {

        private readonly IQuestionsService _service;

        public QuestionnaireController(IQuestionsService service)
        {
            _service = service;
        }

        public QuestionnaireController() : this(new QuestionsService())
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> All()
        {
            //new QuestionnaireViewModel()
            var result = await _service.GetQuestionsAsync();
            return BetterJson(result);
        }

        public async Task<JsonResult> Add(Question question)
        {
            if (!ModelState.IsValid)
            {
                return JsonValidationError();
            }

            var result = await _service.AddQuesitonAsync(question);

            return BetterJson(result);
        }
    }
}
