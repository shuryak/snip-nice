using System.Windows.Forms;
using Yandex.Music.Client;

namespace Winter
{
    public abstract class YmAuthUserControl : UserControl
    {
        protected readonly YandexMusicClient _ymClient;
        
        protected void CloseParentForm()
        {
            Form form = FindForm();
            if (form == null) return;
            form.Close();
            form.Dispose();
        }

        protected YmAuthUserControl(YandexMusicClient ymClient)
        {
            _ymClient = ymClient;
        }
    }
}
