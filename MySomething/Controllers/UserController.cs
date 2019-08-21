using DataAccessLayer;
using MySomething.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MySomething.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {

        }
        // GET: User
        public ActionResult Index()
        {
            //UserRepository rep = new UserRepository();
            //List<UserViewModel> list = new List<UserViewModel>();

            //List<User> datalist = rep.Listele();
            //string serializedStr = JsonConvert.SerializeObject(datalist);
            //list = JsonConvert.DeserializeObject<List<UserViewModel>>(serializedStr);
            return View(/*list*/);
        }

        public ActionResult AddUser()
        {
           
            UserViewModel model = new UserViewModel();
           
            return View(model);

        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel usr)
        {

            if (!ModelState.IsValid)
            {
                return View(usr);
            }
           
            User userDataModel = new User();
            string serializedStr = JsonConvert.SerializeObject(usr);
            userDataModel = JsonConvert.DeserializeObject<User>(serializedStr);

            UserRepository rep = new UserRepository();
            rep.Add(userDataModel);
            return RedirectToAction("Index");
            
        }
        public ActionResult Delete(int id)
        {
            UserRepository rep = new UserRepository();
            rep.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            UserRepository rep = new UserRepository();
            User usr = rep.Find(id);
            string usrdata = JsonConvert.SerializeObject(usr);
            UserViewModel uu = JsonConvert.DeserializeObject<UserViewModel>(usrdata);
            return View(uu);
        }
        [HttpPost]
        public ActionResult Update(UserViewModel usr)
        {
            User uu = new User();
            string usrdata = JsonConvert.SerializeObject(usr);
            uu = JsonConvert.DeserializeObject<User>(usrdata);

            UserRepository rep = new UserRepository();
            rep.Update(uu);
            return RedirectToAction("Index");
        }

        public ActionResult asd()
        {
            UserRepository rep = new UserRepository();
            List<UserViewModel> list = new List<UserViewModel>();

            List<User> datalist = rep.Listele();
            string serializedStr = JsonConvert.SerializeObject(datalist);
            list = JsonConvert.DeserializeObject<List<UserViewModel>>(serializedStr);
            return View(list);
        }
        

    }
}