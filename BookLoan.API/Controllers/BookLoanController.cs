using BookLoan.API.DTOs;
using BookLoan.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLoan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLoanController : ControllerBase
    {
        private readonly IBookLoanService _bookLoanService;

        public BookLoanController(IBookLoanService bookLoanService)
        {
            _bookLoanService = bookLoanService;
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookLoanDto dto)
        {
            await _bookLoanService.Create(dto);
            return Created(string.Empty, dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookLoanService.GetAllBookLoansActive();
            return Ok(result);
        }
        
    }
}
