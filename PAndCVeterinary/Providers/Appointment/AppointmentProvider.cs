using Microsoft.Data.SqlClient;
using PAndCVeterinary.Data;
using PAndCVeterinary.Interfaces.Appointment;

namespace PAndCVeterinary.Providers.Appointment
{
    public class AppointmentProvider : IAppointmentProvider
    {
        private readonly DatabaseContext _dbContext;
        public AppointmentProvider(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Models.Appointment> GetAllAppointments()
        {
            IEnumerable<Models.Appointment> appointmentList = _dbContext.Appointment;
            return appointmentList;
        }

        public void CreateAppointment(Models.Appointment input)
        {
            using (var appointmentTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Appointment.Add(input);
                    _dbContext.SaveChanges();
                    appointmentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    appointmentTransaction.Rollback();
                    throw;
                }
            }
        }

        public Models.Appointment GetAppointmentByID(int id)
        {
            var appointmentFromID = _dbContext.Appointment.FirstOrDefault(x => x.Id == id);
            return appointmentFromID;
        }

        public void EditAppointment(Models.Appointment input)
        {
            using (var appointmentTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Appointment.Update(input);
                    _dbContext.SaveChanges();
                    appointmentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    appointmentTransaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteAppointment(Models.Appointment input)
        {
            using (var appointmentTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Appointment.Remove(input);
                    _dbContext.SaveChanges();
                    appointmentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    appointmentTransaction.Rollback();
                    throw;
                }
            }
        }
    }
}
