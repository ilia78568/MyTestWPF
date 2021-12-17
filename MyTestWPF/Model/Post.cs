using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestWPF
{
    public class Post
    {
        private string title, body;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        public Post(string title, string body)
        {
            this.title = title;
            this.body = body;
        }

    }
}
