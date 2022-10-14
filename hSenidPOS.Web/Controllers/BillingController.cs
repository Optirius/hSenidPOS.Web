using hSenidPOS.BLL.IManager;
using hSenidPOS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text.Json;

namespace hSenidPOS.Web.Controllers
{
    public class BillingController : Controller
    {

        private readonly ILogger<BillingController> _logger;
        private readonly IBillingManager  ibillingManager;

        public BillingController(ILogger<BillingController> logger, IBillingManager ibillingManager)
        {
            _logger = logger;
            this.ibillingManager = ibillingManager; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Items> GetItemsList()
        {
            return ibillingManager.GetItemsList();  
        }

        [HttpPost]
        public IActionResult SaveBill(float discount, float vat, float GrandTotal, string billInfos)
        {

            List<BillInfo> bill;
            bill = JsonSerializer.Deserialize<List<BillInfo>>(billInfos);

            ibillingManager.SaveBill(discount, vat, GrandTotal, bill);

            return RedirectToAction("Index", "Billing");
        }


    }
}
