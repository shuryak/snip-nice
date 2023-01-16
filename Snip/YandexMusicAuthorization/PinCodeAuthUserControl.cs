using Yandex.Music.Client;

namespace Winter
{
    public partial class PinCodeAuthUserControl : YmAuthUserControl
    {
        public PinCodeAuthUserControl(YandexMusicClient ymClient) : base(ymClient)
        {
            InitializeComponent();
        }
    }
}
