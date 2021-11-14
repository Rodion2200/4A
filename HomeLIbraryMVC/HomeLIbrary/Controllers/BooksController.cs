using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeLIbrary;
using HomeLIbrary.Service;

namespace HomeLIbrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository _repository;

        public BooksController(IRepository repository)
        {
            _repository = repository;
        }

        public  IActionResult Index()
        {
            return View(_repository.GetBookList());          
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,NameBook,Datebirth,Author,Contents")] Book book)
        {
            _repository.Create(book);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.GetBook(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,NameBook,Datebirth,Author,Contents")] Book book)
        {
            _repository.Update(book);
            return RedirectToAction(nameof(Index));
        }

        public  IActionResult Delete(int id)
        {
            return View(_repository.GetBook(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
