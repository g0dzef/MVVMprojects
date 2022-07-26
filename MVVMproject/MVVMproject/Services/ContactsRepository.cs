using MVVMproject.MVVM.Models;
using MVVMproject.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.Services
{
    public class ContactsRepository : RepositoryInMemory<Contacts>
    {
        protected override void Update(Contacts Source, Contacts Destination)
        {
            Destination.FirstName = Source.FirstName;
            Destination.LastName = Source.LastName;
            Destination.Phone = Source.Phone;
        }
    }
}
