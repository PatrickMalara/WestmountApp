namespace WestmountApp
{
    public class Category
    {
        public Category(string categoryName, string[] tagKewords)
        {
            category = categoryName;
            keywords = tagKewords;
        }

        public string category;
        public string[] keywords;
    }

    public class Categories
    {
        public Category[] categories = new Category[] {
            new Category("Sports", new string[] {
                "sport",
                "sports",
                "football",
                "baseball",
                "soccer",
                "athletes",
                "athlete",
                "team"
            }),
            new Category("Club", new string[] {
                "club",
                "clubs"
            }),
            new Category("Guidance", new string[] {
                "guidance",
                "counselor"
            }),
            new Category("Co-op", new string[] {
                "coop",
                "co-op"
            })
        };

    }
}
