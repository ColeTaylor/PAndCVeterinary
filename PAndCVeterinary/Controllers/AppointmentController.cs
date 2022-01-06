using Microsoft.AspNetCore.Mvc;
using PAndCVeterinary.Data;
using PAndCVeterinary.Interfaces.Appointment;
using PAndCVeterinary.Models;
using PAndCVeterinary.Providers.Appointment;

namespace PAndCVeterinary.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly IAppointmentProvider _appointmentProvider;
        public AppointmentController(IAppointmentProvider appointmentProvider)
        {
            _appointmentProvider = appointmentProvider;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Appointment> appointmentList = _appointmentProvider.GetAllAppointments();
            return View(appointmentList);
        }

        //Send User to blank create view
        public IActionResult Create()
        {
            return View();
        }

        //Take input from create view to insert new appointment
        [HttpPost]
        public IActionResult Create(Appointment input)
        {
            if (ModelState.IsValid)
            {
                _appointmentProvider.CreateAppointment(input);
                return RedirectToAction("Index");
            }
            return View(input);
        }

        //Check for existing records, if found send to Edit view
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            
            var appointmentFound = _appointmentProvider.GetAppointmentByID((int)id);
            if (appointmentFound == null)
                return NotFound();
            else
                return View(appointmentFound); 
        }


        //Take input from Edit view and submit to DB, return to index
        [HttpPost]
        public IActionResult Edit(Appointment input)
        {
            if (ModelState.IsValid)
            {
                _appointmentProvider.EditAppointment(input);
                return RedirectToAction("Index");
            }
            else
                return View(input);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var appointmentFound = _appointmentProvider.GetAppointmentByID((int)id);
            if (appointmentFound == null)
                return NotFound();
            else
                return View(appointmentFound);
        }

        //Delete the record given its ID
        [HttpPost]
        public IActionResult DeletePost(Appointment input)
        {
                _appointmentProvider.DeleteAppointment(input);
                return RedirectToAction("Index");
        }
    }
}
