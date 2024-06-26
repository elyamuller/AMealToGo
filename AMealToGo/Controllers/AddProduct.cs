using AMealToGo.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMealToGo.Controllers
{
    public class AddProduct: ControllerBase
    {
       
          private readonly MealToGoDbContext _context;

        public AddProduct(MealToGoDbContext context)
        {
            _context = context;
        }
    }
}
