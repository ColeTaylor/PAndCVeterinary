namespace PAndCVeterinary.Interfaces.Appointment
{
    public interface IAppointmentProvider
    {
        IEnumerable<Models.Appointment> GetAllAppointments();
        void CreateAppointment(Models.Appointment input);
        Models.Appointment GetAppointmentByID(int id);
        void EditAppointment(Models.Appointment input);
        void DeleteAppointment(Models.Appointment input);
    }
}
