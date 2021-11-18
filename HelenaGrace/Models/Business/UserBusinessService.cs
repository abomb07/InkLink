using HelenaGrace.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelenaGrace.Models.Business
{
    public class UserBusinessService
    {
        UserDataService uds = new UserDataService();

        public bool Authenticate(User user)
        {
            return uds.findUserByEmailAndPassword(user);
        }
    }
}
