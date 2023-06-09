using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

[Route("api/[controller]")]
[ApiController]
public class UserListController : ControllerBase 
{
    private readonly MyDbContext _dbContext;

    public UserListController(MyDbContext context)
    {
        _dbContext = context;
    }
    


    [HttpGet("users")]
    public IActionResult GetUsersWithReserves()
    {
        var users = _dbContext.Users.ToList();

        var result = users.Select(u => new
        {
            name = u.name,
            faculty = u.facultad,
            date_last_reserve = _dbContext.Reserves
                .Where(r => r.user_id == u.id)
                .OrderByDescending(r => r.date_reserve)
                .Select(r => r.date_reserve)
                .FirstOrDefault(),
            cant_reserves_last_month = _dbContext.Reserves
                .Count(r => r.user_id == u.id && r.date_reserve >= DateTime.Now.AddMonths(-1)),
            reserves = _dbContext.Reserves
                .Where(r => r.user_id == u.id)
                .Select(r => new
                {
                    id = r.id,
                    code = r.code,
                    Book = _dbContext.Books.Where(b => b.id_book == r.book_id).Select(b => b.name).FirstOrDefault(),
                    description = _dbContext.Books.Where(b => b.id_book == r.book_id).Select(b => b.description).FirstOrDefault()
                })
                .ToList()
        }).ToList();

        return Ok(result);
    }

        [HttpGet("books")]
        public IActionResult GetBooksWithReserves()
        {
            var booksWithReserves = _dbContext.Books.Select(b => new
            {
                b.name,
                b.description,
                Reserves = _dbContext.Reserves
                    .Where(r => r.book_id == b.id_book)
                    .Select(r => new
                    {
                        r.id,
                        User = _dbContext.Users.Where(u => u.id == r.user_id).Select(u => new
                        {
                            u.name,
                            u.facultad
                        }).FirstOrDefault()
                    }).ToList()
            }).ToList();

            return Ok(booksWithReserves);
}


}