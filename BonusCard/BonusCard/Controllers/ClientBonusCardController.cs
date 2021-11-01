using BonusCard.Data.Interfaces;
using BonusCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BonusCard.Controllers
{
    public class ClientBonusCardController : Controller
    {
        private readonly ILogger<ClientBonusCardController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ClientBonusCardController(IUnitOfWork unitOfWork, ILogger<ClientBonusCardController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Search client and information about him by card ID
        /// </summary>
        /// <param name="incomingCard"></param>
        /// <returns>Information list about client</returns>
        public IActionResult SearchByCardNum(ClientBonusCard incomingCard)
        {
            _logger.LogInformation("Log message in the SearchByCardNum() method");

            ClientWithCard tempCard = _unitOfWork.ClientWithCard.SearchByCardNum(incomingCard.ClientBonusCardID);

            if (tempCard != null)
            {
                List<string> list = new List<string>()
                {
                     tempCard.Client.Name.ToString(),
                     tempCard.Client.Surname.ToString(),
                     tempCard.Client.PhoneNumber.ToString(),
                     tempCard.Card.ClientBonusCardID.ToString(),
                     tempCard.Card.Balanse.ToString()
                };
                return View(list);
            }
            else
            {
                _logger.LogInformation("SearchByCardNum() / Card is not foud");
                return RedirectToAction("NotFoundedClientWithCard", tempCard);
            }
        }

        /// <summary>
        /// Search client and information about him by client phone number
        /// </summary>
        /// <param name="incomingClient"></param>
        /// <returns>Information list about client</returns>
        public IActionResult SearchByPhoneNumber(ClientWithCard incomingClient)
        {
            _logger.LogInformation("Log message in the SearchByPhoneNumber() method");

            ClientWithCard tempCardAndClient = _unitOfWork.ClientWithCard.SearchByClientPhone(incomingClient.Client.PhoneNumber);

            if (tempCardAndClient != null)
            {
                List<string> list = new List<string>()
                {
                     tempCardAndClient.Client.Name.ToString(),
                     tempCardAndClient.Client.Surname.ToString(),
                     tempCardAndClient.Client.PhoneNumber.ToString(),
                     tempCardAndClient.Card.ClientBonusCardID.ToString(),
                     tempCardAndClient.Card.Balanse.ToString()
                };               
                return View(list);
            }

            _logger.LogInformation("SearchByPhoneNumber() / Card is not foud");
            return RedirectToAction("NotFoundedClientWithCard", tempCardAndClient);
        }

       
        /// <summary>
        /// Display manage page
        /// </summary>
        /// <returns>List of Client who have existed on bonus system</returns>
        public IActionResult ManagePage()
        {
            _logger.LogInformation("Log message in the ManagePage() method");

            IEnumerable<ClientBonusCard> cards = _unitOfWork.BonusCard.GetAllCardWithClient();
           
            return View(cards);
        }

        /// <summary>
        /// Сhecks client сard by id for diposite bonuses
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Client card and send it for update</returns>
        public IActionResult UpdateAddPage(Guid? id)
        {
            _logger.LogInformation("Log message in the UpdateAddPage() method");

            if (id == null || id == default(Guid))
            {
                _logger.LogInformation("UpdateAddPage()  id == null || id == default(Guid)");
                return NotFound();
            }

            ClientBonusCard card = _unitOfWork.BonusCard.Get(id);

            if (card == null )
            {
                _logger.LogInformation("Card is not exists");
                return NotFound();
            }

            if (!card.IsActivated)
            {
                _logger.LogInformation("Card is not activate");
                return NotFound();
            }
           
            return View(card);           
        }

        /// <summary>
        /// Add bouns to the card
        /// </summary>
        /// <param name="card">Card for update</param>
        /// <param name="addBonus">Sum of update</param>
        /// <returns>Manage page View, where will can see bonus status </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ClientBonusCard card, string addBonus)
        {
            _logger.LogInformation("Log message in the Add() method");

            if (!card.IsActivated)
            {
                _logger.LogInformation("Card is not activated");
                ModelState.AddModelError("Activated", "Card is not activated");
                ViewBag.Message = "Card is not activated";
            }

            decimal temp;

            if (!decimal.TryParse(addBonus, out temp))
            {
                _logger.LogInformation("Incorrect value entered");
                ModelState.AddModelError("Value", "Incorrect value entered");
                ViewBag.Message = "Incorrect value entered";
            }

            if (temp < 0)
            {
                _logger.LogInformation("Value isn`t be negative");
                ModelState.AddModelError("Negative", "Value isn`t be negative");
                ViewBag.Message = "Value isn`t be negative";
            }

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid");
                card.Balanse += temp;
                _unitOfWork.BonusCard.Update(card);
                _unitOfWork.Complete();
                _logger.LogInformation("Changes save");
                return RedirectToAction("ManagePage");
            }

            return View("CanNotUpBonus");
        }

        /// <summary>
        /// Сhecks client сard by id for diposite withdraw bonuses
        /// </summary>
        /// <param name="id">card ID</param>
        /// <returns></returns>
        public IActionResult UpdateGetPage(Guid? id)
        {
            _logger.LogInformation("Log message in the UpdateGetPage() method");

            if (id == null || id == default(Guid))
            {
                _logger.LogInformation("UpdateAddPage()  id == null || id == default(Guid)");
                return NotFound();
            }

            ClientBonusCard card = _unitOfWork.BonusCard.Get(id);

            if (card == null)
            {
                _logger.LogInformation("Card is not exists");
                return NotFound();
            }

            if (!card.IsActivated)
            {
                _logger.LogInformation("Card is not activate");
                return NotFound();
            }

            return View(card);
        }

        /// <summary>
        /// Withdraw bonuses
        /// </summary>
        /// <param name="card">Card for update</param>
        /// <param name="withdrawBonus">Sum update</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Get(ClientBonusCard card, string withdrawBonus)
        {
            _logger.LogInformation("Log message in the Add() method");
            if (!card.IsActivated)
            {
                _logger.LogInformation("Card is not activated");
                ModelState.AddModelError("Activated", "Card is not activated");
                ViewBag.Message = "Card is not activated";
            }

            decimal temp;

            if (!decimal.TryParse(withdrawBonus, out temp))
            {
                _logger.LogInformation("Incorrect value entered");
                ModelState.AddModelError("Value", "Incorrect value entered");
                ViewBag.Message = "Incorrect value entered";
            }

            if (temp < 0)
            {
                _logger.LogInformation("Value isn`t be negative");
                ModelState.AddModelError("Negative", "Value isn`t be negative");
                ViewBag.Message = "Value isn`t be negative";
            }

            card.Balanse -= temp;

            if (card.Balanse < 0)
            {
                _logger.LogInformation("Sum on the card is the less than withdraw sum");
                ModelState.AddModelError("Minus", "Sum on the card is the less than withdraw sum");
                ViewBag.Message = "Sum on the card is the less than withdraw sum";
            }

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid");
                _unitOfWork.BonusCard.Update(card);
                _unitOfWork.Complete();               
                _logger.LogInformation("Changes save");
                return RedirectToAction("ManagePage");
            }

            return View("CanNotUpBonus");
        }

        /// <summary>
        /// Display error msg
        /// </summary>
        /// <returns></returns>
        public IActionResult NotFoundedClientWithCard()
        {
            _logger.LogInformation("Log message in the NotFoundedClientWithCard() method");
            return View();
        }

        public IActionResult CanNotUpBonus()
        {
            _logger.LogInformation("Log message in the CanNotUpBonus() method");
            return View();
        }
    }
}
