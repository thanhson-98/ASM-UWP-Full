using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_APP_v1.Entity
{
    class Song
    {
        public string name { get; set; }

        public string description { get; set; }

        public string singer { get; set; }

        public string author { get; set; }

        public string thumbnail { get; set; }

        public string link { get; set; }

        public Dictionary<string, string> Validate()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(name))
            {
                errors.Add("name", "Name is required!");
            }
            else if (name.Length < 5 || name.Length > 30)
            {
                errors.Add("name", "Name must be 5 to 30 characters!");
            }
            if (string.IsNullOrEmpty(singer))
            {
                errors.Add("Singer", "Singer is required!");
            }
            if (string.IsNullOrEmpty(description))
            {
                errors.Add("Description", "Description is required!");
            }
            if (string.IsNullOrEmpty(author))
            {
                errors.Add("Author", "Author is required!");
            }
            if (string.IsNullOrEmpty(thumbnail))
            {
                errors.Add("Thumbnail", "Thumbnail is required!");
            }
            if (string.IsNullOrEmpty(link))
            {
                errors.Add("Link", "Link is required!");
            }
            return errors;
        }
    }
}
