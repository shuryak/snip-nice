using System;
using System.ComponentModel;
using System.Windows.Forms;
using Yandex.Music.Client;

namespace Winter.YandexMultiStepAuth
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<StepUserControl, UserControl>))]
    public abstract class StepUserControl : UserControl
    {
        protected new StartForm ParentForm => (StartForm)FindForm();

        protected readonly YandexMusicClient _ymClient;
        
        protected StepUserControl(YandexMusicClient ymClient, bool isFirstStep = false)
        {
            _ymClient = ymClient;

            if (!isFirstStep)
            {
                Load += HideButtonBack;
            }
        }

        private void HideButtonBack(object sender, EventArgs e)
        {
            ParentForm.BackButton.Visible = true;
        }
    }
}
