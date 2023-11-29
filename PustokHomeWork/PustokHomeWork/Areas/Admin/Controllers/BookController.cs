using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokHomeWork.Data;
using PustokHomeWork.Models;

namespace PustokHomeWork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View(_dbContext.Books.Include(book => book.Tags).ToList());
        }

        [HttpPost]
        public IActionResult UpdateBook(BookModel updatedBook)
        {
            var authors = _dbContext.Authors.ToList();
            var tags = _dbContext.Tags.ToList();
            ViewBag.Authors = authors;
            ViewBag.Tags = tags;



            BookModel oldBook = _dbContext.Books.Include(x=>x.Tags).FirstOrDefault(x=>x.Id == updatedBook.Id);

            if(oldBook == null)
            {
                return BadRequest();
            }

            if (updatedBook.TagIds == null || updatedBook.TagIds.Count == 0 || !updatedBook.TagIds.All(x => tags.Any(tag => tag.Id == x)))
            {
                ModelState.AddModelError("TagIds", "Tag error");
                return View("Update", model: oldBook);
            }

            if (updatedBook?.AuthorId == null || !authors.Any(x => x.Id == updatedBook?.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Invalid Author");
                return View("Update", model: oldBook);
            }


            if (!ModelState.IsValid)
            {

                return View("Update", model: oldBook);
            }

            var selectedTags = _dbContext.Tags.Where(t => updatedBook.TagIds.Contains(t.Id)).ToList();

            var removedTags = oldBook.Tags.Where(tag => !selectedTags.Any(st => st.Id == tag.Id)).ToList();
            foreach (var removedTag in removedTags)
            {
                oldBook.Tags.Remove(removedTag);
            }

            var addedTags = selectedTags.Where(st => !oldBook.Tags.Any(tag => tag.Id == st.Id)).ToList();
            foreach (var addedTag in addedTags)
            {
                oldBook.Tags.Add(addedTag);
            }

            _dbContext.SaveChanges();


            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            var authors = _dbContext.Authors.ToList();
            var tags = _dbContext.Tags.ToList();

            ViewBag.Authors = authors;
            ViewBag.Tags = tags;


            BookModel existBook = _dbContext.Books.FirstOrDefault(x => x.Id == id);

            if(existBook == null)
            {
                return BadRequest();
            }

            return View(existBook);

        }

        public IActionResult Create()
        {
            ViewBag.Authors = _dbContext.Authors.ToList();
            ViewBag.Tags = _dbContext.Tags.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            BookModel? model = _dbContext.Books.FirstOrDefault(x => x.Id == id);

            if(model != null)
            {

                _dbContext.Books.Remove(model);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateBook(BookModel newBook)
        {
            var authors = _dbContext.Authors.ToList();
            var tags = _dbContext.Tags.ToList();
            ViewBag.Authors = authors;
            ViewBag.Tags = tags;

            if(newBook.TagIds == null || newBook.TagIds.Count == 0 || !newBook.TagIds.All(x=>tags.Any(tag=>tag.Id == x)))
            {
                ModelState.AddModelError("TagIds", "Tag error");
            }

            if(newBook?.AuthorId == null || !authors.Any(x=>x.Id == newBook?.AuthorId))
            {
                ModelState.AddModelError("AuthorId", "Invalid Author");
            }


            if (!ModelState.IsValid)
            {
             
                return View("Create");
            }

            var selectedTags = _dbContext.Tags.Where(t => newBook.TagIds.Contains(t.Id)).ToList();

            newBook.Tags = new List<TagModel>();
            foreach (var tag in selectedTags)
            {
                newBook.Tags.Add(tag);
            }

                _dbContext.Books.Add(newBook);
                _dbContext.SaveChanges();

            return RedirectToAction("Index");
            
        }




    }
}
