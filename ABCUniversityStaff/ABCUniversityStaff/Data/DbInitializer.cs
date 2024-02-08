using ABCUniversityStaff.models;

namespace ABCUniversityStaff.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ABCUniversityStaffContext context)
        {
            //// Look for any students.
            if (context.Staff.Any())
            {
                return;   // DB has been seeded
            }

            var staff = new Staff[]
            {
                new Staff{ID=2,StaffUserName="Chami321",StaffPassword="chami123",StaffLastName ="Alonso",StaffFirstName="Chami",StaffDesignation="Manager"},
        
            };

            context.Staff.AddRange(staff);
            context.SaveChanges();
        }

        }
    }
