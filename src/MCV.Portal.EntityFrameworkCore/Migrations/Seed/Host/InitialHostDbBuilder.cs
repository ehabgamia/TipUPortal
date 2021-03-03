using MCV.Portal.EntityFrameworkCore;
using System.Linq;

namespace MCV.Portal.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly PortalDbContext _context;

        public InitialHostDbBuilder(PortalDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var ehab = _context.Persons.FirstOrDefault(p => p.EmailAddress == "ehab.yehia@MCV-eg.com");
            if (ehab == null)
            {
                _context.Persons.Add(
                    new Person.Person
                    {
                        Name = "Ehab",
                        Surname = "Yehia",
                        EmailAddress = "Ehab.Yehia@Mcv-eg.com"
                    });
            }

            var ahmad = _context.Persons.FirstOrDefault(p => p.EmailAddress == "ehab.Yehia@MCv-eg.com");
            if (ahmad == null)
            {
                _context.Persons.Add(
                    new Person.Person
                    {
                        Name = "Ahmad",
                        Surname = "Nagy",
                        EmailAddress = "Ahmad.Nagy@MCv-eg.com"
                    });
            }

            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
