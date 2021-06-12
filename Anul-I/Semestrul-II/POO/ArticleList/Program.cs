using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArticleList
{
    class Program
    {
        static void Main(string[] args)
        {
            Article[] articleList = (Article[])GetArticleList().Clone();
            Article[] filterList;

            //filterList = FilterByAuthor(articleList, "Elon Musk");
            //filterList = FilterByTag(articleList, "Rich");
            //filterList = FilterByDate(articleList, "6/8/2021 12:00:00 AM", "6/10/2021 12:00:00 AM");
            //filterList = FilterByWeekend(articleList);

            //foreach (Article item in filterList)
            //{
            //    Console.WriteLine(item);
            //}

            //SortyByDate(articleList);
            //SortByLikes(articleList);
            //SortyByeDislikes(articleList);

            //foreach (Article item in articleList)
            //{
            //    Console.WriteLine(item);
            //}
        }

        private static void SortyByeDislikes(Article[] articleList)
        {
            Array.Sort(articleList, (x, y) => x.Dislikes.CompareTo(y.Dislikes));
        }

        private static void SortByLikes(Article[] articleList)
        {
            Array.Sort(articleList, (x, y) => x.Likes.CompareTo(y.Likes));
        }

        private static void SortyByDate(Article[] articleList)
        {
            Array.Sort(articleList, (x, y) => x.PublicationDate.CompareTo(y.PublicationDate));
        }

        private static Article[] FilterByWeekend(Article[] articleList)
        {
            return Array.FindAll(articleList, x => x.PublicationDate.DayOfWeek == DayOfWeek.Saturday || x.PublicationDate.DayOfWeek == DayOfWeek.Sunday);
        }

        private static Article[] FilterByDate(Article[] articleList, string start, string end)
        {
            return Array.FindAll(articleList, x => x.PublicationDate > DateTime.Parse(start) && x.PublicationDate < DateTime.Parse(end));
        }

        private static Article[] FilterByTag(Article[] articleList, string tag)
        {
            return Array.FindAll(articleList, x => x.Tags.Contains(tag));
        }

        private static Article[] FilterByAuthor(Article[] articleList, string author)
        {
            return Array.FindAll(articleList, x => x.Authors.Contains(author));
        }

        private static Article[] GetArticleList()
        {
            string allText = File.ReadAllText("../../Articles.txt");

            allText = allText.Replace("\r\n#\r\n", "#");

            string[] articles = allText.Split('#');
            
            Article[] articleList = (Article[])Array.CreateInstance(typeof(Article), articles.Length);

            int index = 0;

            for (int i = 0; i < articles.Length; i++)
            {
                articles[i] = articles[i].Replace("\r", "");

                string[] articleLines = articles[i].Split('\n');

                string title = articleLines[0];

                articleLines[1] = articleLines[1].Replace(", ", "#");

                string[] authors = articleLines[1].Split('#');
                string content = articleLines[2];

                articleLines[3] = articleLines[3].Replace(", ", "#");

                string[] tags = articleLines[3].Split('#');
                DateTime publicationDate = DateTime.Parse(articleLines[4]);
                DateTime modificationDate = DateTime.Parse(articleLines[5]);
                int likes = int.Parse(articleLines[6]);
                int dislikes = int.Parse(articleLines[7]);

                Article article = new Article(title, authors, content, tags, publicationDate, modificationDate, likes, dislikes);

                articleList.SetValue(article, index);

                index++;
            }

            return articleList;
        }
    }
}
