using ProjectEweis.Models;
using ProjectEweis.ModelView.LOVEVM;
using ProjectEweis.ModelView.POSTVM;

namespace ProjectEweis.Services.Love
{
    public interface ILove
    {
        public string ADDlove(LOVEVM lOVEVM);
        public List<LOVE_ON_Post> GetmyListLove(string UserID);
    }
}
