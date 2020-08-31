using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace MicrosoftNews.Model
{
    public class News
    {
        public string Name { get; set; }
        public NewsCategory Category { get; set; }
        public string ImageFile { get; set; }
        public string Title { get; set; }
        public enum NewsCategory
        {
            MyNews,            
            Would,
            Science,
            Sports
        }

        public News(string name,NewsCategory category,string title)
        {
            Name = name;
            Category = category;
            Title = title;
            ImageFile = string.Format("/Assets/Images/{0}/{1}.jpg", category, name);
        }
        
    }
}
