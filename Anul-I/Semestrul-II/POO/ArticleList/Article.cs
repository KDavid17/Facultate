using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleList
{
    public class Article
    {
        public string Title { get; private set; }
        public string[] Authors { get; private set; }
        public string Content { get; private set; }
        public string[] Tags { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public DateTime ModificationDate { get; private set; }
        public int Likes { get; private set; }
        public int Dislikes { get; private set; }

        private Article()
        {

        }

        public Article(string title, string[] authors, string content, string[] tags, DateTime publicationDate, DateTime modificationDate, int likes, int dislikes)
        {
            this.Title = title;
            this.Authors = authors;
            this.Content = content;
            this.Tags = tags;
            this.PublicationDate = publicationDate;
            this.ModificationDate = modificationDate;
            this.Likes = likes;
            this.Dislikes = dislikes;
        }

        public override string ToString()
        {
            string text = "Title: " + Title + "\nAuthor(s): ";
            
            for (int i = 0; i < Authors.Length - 1; i++)
            {
                text += Authors[i] + ", ";
            }

            text += Authors[Authors.Length - 1] + "\nContent: " + Content + "\nTag(s): ";

            for (int i = 0; i < Tags.Length - 1; i++)
            {
                text += Tags[i] + ", ";
            }

            text += Tags[Tags.Length - 1] + "\nPublication Date: " + PublicationDate + "\nModification Date: " + ModificationDate 
                + "\nLikes: " + Likes + "\nDislikes: " + Dislikes + "\n"; ;

            return text;
        }
    }
}
