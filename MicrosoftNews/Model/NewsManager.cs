using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MicrosoftNews.Model.News;

namespace MicrosoftNews.Model
{
    class NewsManager
    {
        private static List<News> GetNews()
        {
            var news = new List<News>();

            news.Add(new News("MyNews", News.NewsCategory.MyNews,"ban tin MyNews"));
            news.Add(new News("Science", News.NewsCategory.Science,"ban tin Science"));
            news.Add(new News("Sports", News.NewsCategory.Sports,"ban tin Sport"));
            news.Add(new News("Would", News.NewsCategory.Would,"ban tin Would"));
            return news;
        }

        public static void GetAllNews(ObservableCollection<News> news)
        {
            var allnews = GetNews();
            news.Clear();
            allnews.ForEach(p => news.Add(p));

        }
        public static void GetNewsByCategory(ObservableCollection<News> news,NewsCategory newsCategory)
        {
            var allnews = GetNews();
            var filteredNews = allnews.Where(p => p.Category == newsCategory).ToList();
            news.Clear();
            filteredNews.ForEach(p => news.Add(p));
        }
        public static void GetNewsByName(ObservableCollection<News> news,string name)
        {
            var allnews = GetNews();
            var filteredNews = allnews.Where(p => p.Name == name).ToList();
            news.Clear();
            filteredNews.ForEach(p => news.Add(p));
        }
    }
}
