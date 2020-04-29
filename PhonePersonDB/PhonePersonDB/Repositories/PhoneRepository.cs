using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhonePersonDB.Models;

namespace PhonePersonDB.Repositories
{
    class PhoneRepository
    {

        public void Create(Phone phone)
        {
            using (var context = new PhonepersondbContext())
            {
                try
                {
                    context.Add(phone);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Phone> ReadPhones()
        {
            using (var context = new PhonepersondbContext())
            {
                List<Phone> phones = context.Phone.ToListAsync().Result;
                return phones;
            }
        }

        public Phone PhoneAndId(int id)
        {
            using (var context = new PhonepersondbContext())
            {
                var phones = context.Phone.FirstOrDefault(p => p.Id == id);

                return phones;
            }

        }
    }
}
