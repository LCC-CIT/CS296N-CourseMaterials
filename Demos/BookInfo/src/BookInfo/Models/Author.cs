using System;


namespace BookInfo.Models
{
    public class Author
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public override bool Equals(object obj)
        {
                Author authorObj = obj as Author;
            if (authorObj == null)
                return false;
            else
                return Name == authorObj.Name && Birthday == authorObj.Birthday;
        }
    }
}
