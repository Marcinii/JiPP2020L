using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using UnitConverterLogic.Model;
using UnitConverterLogic.Plugins;

namespace UnitConverterWeb.Pages
{
    public class IndexModel : PageModel
    {




        LenghtConverter converter = new LenghtConverter();
        sqlconnectionEntities context = new sqlconnectionEntities();

        [BindProperty]
    public Statistic Statistic { get; set; }
        
        public void OnGet()
        {
            
        }
        
        public async Task<IActionResult> OnPost()
        {
            
            Statistic.ConvertedValue = converter.Converter(Convert.ToString(Statistic.RawValue), Statistic.UnitFrom, Statistic.UnitTo);
            //return RedirectToAction("Result");
            Statistic.DateTime = DateTime.Now;
            Statistic.Type = "Odległość";
            

            await context.AddAsync(Statistic);
            await context.SaveChangesAsync();

            return Content($"Wynik: {Statistic.ConvertedValue}");
            //return RedirectToPage("Index");
        }

    }
}
