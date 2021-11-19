using HelenaGrace.Models.Data;

namespace HelenaGrace.Models.Business
{
    public class CustomerBusinessService
    {
        CustomerDataService service = new CustomerDataService();

        public bool MakeAppointment(Appointment appointment) 
        {
            return service.addNewAppointment(appointment);
        }
    }
}
