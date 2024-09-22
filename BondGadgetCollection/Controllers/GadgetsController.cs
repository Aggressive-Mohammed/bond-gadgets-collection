using BondGadgetCollection.Data;
using BondGadgetCollection.Models;
using Microsoft.AspNetCore.Mvc;

namespace BondGadgetCollection.Controllers
{
    public class GadgetsController : Controller
    {
        public IActionResult Index()
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();

            GadgetDao gadgetDao = new GadgetDao();

            gadgets = gadgetDao.FetchAll();


            return View("Index", gadgets);
        }
        public IActionResult Details(int id)
        {
            GadgetDao gadgetDao = new GadgetDao();

            GadgetModel gadget = gadgetDao.FetchOne(id);

            return View("Details", gadget);
        }

        public IActionResult Create() 
        { 
            return View("GadgetForm");
        }

        public IActionResult Edit( int id)

        {
            GadgetDao gadgetDao = new GadgetDao();

            GadgetModel gadget = gadgetDao.FetchOne(id);

            return View("GadgetForm", gadget);
        }

        public IActionResult Delete(int id)

        {
            GadgetDao gadgetDao = new GadgetDao();
            gadgetDao.Delete(id);

            List<GadgetModel> gadgets = gadgetDao.FetchAll();


            return View("Index", gadgets);
        }
        public IActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            //save to the db

            GadgetDao gadgetDao = new GadgetDao();

            gadgetDao.CreateOrUpdate(gadgetModel);
            return View("Details", gadgetModel);
        }

        public IActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public IActionResult SearchForName(string searchPhrase)
        {
            GadgetDao gadgetDao = new GadgetDao();

            List<GadgetModel> searchResults = gadgetDao.SearchForName(searchPhrase);
            return View("Index", searchResults);
        }


    }
}