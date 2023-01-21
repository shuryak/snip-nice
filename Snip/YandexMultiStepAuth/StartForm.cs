using System;
using System.Drawing;
using System.Windows.Forms;
using Yandex.Music.Client;

namespace Winter.YandexMultiStepAuth
{
    public partial class StartForm : Form
    {
        private readonly YandexMusicClient _ymClient;
        
        private StepUserControl _lastStepUserControl;
        private StepUserControl _stepUserControl;

        public StartForm(YandexMusicClient ymClient)
        {
            InitializeComponent();
            
            _ymClient = ymClient;
            _stepUserControl = new StartUserControl(_ymClient);
            
            ChangeStep(_stepUserControl);
        }

        public void BackStep()
        {
            ChangeStep(_lastStepUserControl);
        }
        
        public void ChangeStep(StepUserControl stepUserControl)
        {
            Controls.Remove(_stepUserControl);
            _lastStepUserControl = _stepUserControl;
            _stepUserControl = stepUserControl;

            _stepUserControl.Location = new Point(12, 78);
            _stepUserControl.Size = new Size(370, 391);
            _stepUserControl.Name = "stepUserControl";
            Controls.Add(_stepUserControl);
        }
        
        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButton.Visible = false;
            LoginTextBox.Enabled = true;
            BackStep();
        }
    }
}
