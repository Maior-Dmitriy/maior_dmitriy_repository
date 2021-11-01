
using BonusCard.Data.Interfaces;
using BonusCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BonusCard.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork, ILogger<ClientController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Display Client form
        /// </summary>
        /// <returns>Returns empty Client form on View </returns>
        public IActionResult Index()
        {
            _logger.LogInformation("Log message in the Index() method");
            return View();
        }

        /// <summary>
        /// Create client 
        /// </summary>
        /// <param name="completedForm">Takes the completed client form that contain info about Cliend and his Card</param>
        /// <returns>Return status of a create operation on view  in Compleate() method </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]     
        public IActionResult Create(ClientWithAdress completedForm)
        {
            _logger.LogInformation("Log message in the Create() method");
            //Has number existed? 
            Client checkPhone = _unitOfWork.Client.GetAll().Where(client => client.PhoneNumber.Equals(completedForm.Client.PhoneNumber)).FirstOrDefault();

            if (ModelState.IsValid && checkPhone == null)
            {
                _logger.LogInformation("Form is not valid");
                _unitOfWork.ClientWithAdress.AddClientWithAdress(completedForm);
                _unitOfWork.ClientWithCard.AddClientWithCard(completedForm.Client);
                _unitOfWork.Complete();
                _logger.LogInformation("Changes save");
                return RedirectToAction("Compleate", checkPhone);
            }

            _logger.LogInformation("Form is not create");

            return RedirectToAction("Compleate", checkPhone);
        }

        /// <summary>
        /// Compleate status
        /// </summary>
        /// <returns>Displays creation status</returns>
        public IActionResult Compleate()
        {
            _logger.LogInformation("Log message in the Create() method");
            return View();
        }

    }
}
