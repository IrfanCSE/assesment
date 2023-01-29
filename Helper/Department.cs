using primetechmvc.DTO;

namespace primetechmvc.Helper
{
    public static class Department
    {
        static Department()
        {
            Departments = new List<CommonDropdown>
            {
                new CommonDropdown{Value=1,Label="CSE"},
                new CommonDropdown{Value=2,Label="English"},
                new CommonDropdown{Value=3,Label="Bangla"},
            };
        }

        // public static string GetDepartmentName(int Id)
        // {
        //     switch (Id)
        //     {
        //         case (int)EDepartment.CSE:
        //             return "CSE";
        //         case (int)EDepartment.English:
        //             return "English";
        //         case (int)EDepartment.Bangla:
        //             return "Bangla";
        //         default:
        //             return "N/A";
        //     }
        // }

        public static List<CommonDropdown> Departments { get; }
    }

    public static class Subject
    {
        static Subject()
        {
            Subjects = new List<CommonDropdown>
            {
                new CommonDropdown{Value=1,Label="C++",ParentId=1},
                new CommonDropdown{Value=2,Label="C Sharp",ParentId=1},
                new CommonDropdown{Value=3,Label="English One",ParentId=2},
                new CommonDropdown{Value=4,Label="Bangla one",ParentId=3},
            };
        }

        public static List<CommonDropdown> Subjects { get;}

        // public static string GetSubjectName(int Id)
        // {
        //     switch (Id)
        //     {
        //         case (int)ESubject.C_Plus:
        //             return "C++";
        //         case (int)ESubject.English_One:
        //             return "English One";
        //         case (int)ESubject.Bangla_One:
        //             return "Bangla One";
        //         default:
        //             return "N/A";
        //     }
        // }
    }

    // enum EDepartment
    // {
    //     CSE = 1, English = 2, Bangla = 3
    // }

    // enum ESubject
    // {
    //     C_Plus = 1, English_One = 2, Bangla_One = 3
    // }
}