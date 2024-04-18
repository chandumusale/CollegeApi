namespace CollegeApi.Models
{
    public static  class ClassRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>()
            {
                new Student()
                {
                    id = 1,
                    name = "Chandrakant",
                    email = "musale101@gmail.com",
                    phone = 9762370001




                },
                new Student()
                {
                    id = 2,
                    name = "Yash",
                    email = "yash@gmail.com",
                    phone = 7040480480

                }
            };

    }
}
