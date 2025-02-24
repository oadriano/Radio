using Radio.Commands;
using Radio.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Radio.ViewModel
{
    internal class MainWindowVM : INotifyPropertyChanged
    {
        private double _volume;
        private double _frequency;
        private bool _radioIsPlaying;
        private string _playButtonString;

        #region Frequencies

        private double _frequencyVier;
        private double _frequencyEnergy;
        private double _frequencyNext;
        private double _frequencyEins;
        private double _frequency21;

        private double _frequencyCalcHelp;
        private int _currentFrequencyRange;

        #endregion

        private MediaElement _mediaElement;
        private StreamUrlModel RadioStreamList;
        public RelayCommand PlayRadioCommand { get; }

        public double Volume
        {
            get => _volume;
            set
            {
                value = Math.Round(value, 0);
                if (_volume != value)
                {
                    _volume = value;
                    OnPropertyChanged();
                }
            }
        }
        public double Frequency
        {
            get => _frequency;
            set
            {
                value = Math.Round(value, 2);
                if (_frequency != value)
                {
                    _frequency = value;
                    OnPropertyChanged();
                    CheckAndUpdateFrequencyRange();
                }
            }
        }
        public bool RadioIsPlaying
        {
            get => _radioIsPlaying;
            set
            {
                if (value != _radioIsPlaying)
                {
                    _radioIsPlaying = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PlayButtonString
        {
            get => _playButtonString;
            set
            {
                if (_playButtonString != value)
                {
                    _playButtonString = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrentRadioImage
        {
            get
            {
                switch (_currentFrequencyRange)
                {
                    case 0:
                        return "pack://application:,,,/Images/vier.png";

                    case 1:
                        return "pack://application:,,,/Images/energy.png";

                    case 2:
                        return "pack://application:,,,/Images/next.png";

                    case 3:
                        return "pack://application:,,,/Images/eins.png";

                    case 4:
                        return "pack://application:,,,/Images/radio21.png";

                    default:
                        return "pack://application:,,,/Images/vier.png";
                }
            }
        }

        public MainWindowVM()
        {
            Frequency = 100.56;
            Volume = 50;
            RadioIsPlaying = false;
            PlayButtonString = "On";

            PlayRadioCommand = new RelayCommand(PlayRadio, CanPlayRadio);
            RadioStreamList = new StreamUrlModel();

            _frequencyCalcHelp = (ConstValues.MAXFREQUENCY - ConstValues.MINFREQUENCY) / RadioStreamList.StreamUrls.Count;
            _frequencyVier = ConstValues.MINFREQUENCY + _frequencyCalcHelp;
            _frequencyEnergy = ConstValues.MINFREQUENCY + 2 * _frequencyCalcHelp;
            _frequencyNext = ConstValues.MINFREQUENCY + 3 * _frequencyCalcHelp;
            _frequencyEins = ConstValues.MINFREQUENCY + 4 * _frequencyCalcHelp;
            _frequency21 = ConstValues.MINFREQUENCY + 5 * _frequencyCalcHelp;

            _currentFrequencyRange = GetFrequencyRange(Frequency);
        }

        private void PlayRadio(object parameter)
        {
            if (parameter is MediaElement mediaElement)
            {
                _mediaElement = mediaElement;

                if (RadioIsPlaying)
                {
                    PlayButtonString = "Off";
                    try
                    {
                        mediaElement.Stop();
                        mediaElement.Source = new Uri(GetRadioUrl());
                        mediaElement.Play();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Couldn't load radio stream");
                    }
                }
                else
                {
                    PlayButtonString = "On";
                    mediaElement.Stop();
                }
            }
        }

        private void UpdateRadio()
        {
            if (_mediaElement != null && RadioIsPlaying)
            {
                try
                {
                    _mediaElement.Stop();
                    _mediaElement.Source = new Uri(GetRadioUrl());
                    _mediaElement.Play();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Couldn't load radio stream");
                }
            }
        }

        private bool CanPlayRadio(object parameter) => true;

        private string GetRadioUrl()
        {
            int frequencyRange = GetFrequencyRange(Frequency);
            switch (frequencyRange)
            {
                case 0:
                    return RadioStreamList.StreamUrls[0];

                case 1:
                    return RadioStreamList.StreamUrls[1];

                case 2:
                    return RadioStreamList.StreamUrls[2];

                case 3:
                    return RadioStreamList.StreamUrls[3];

                case 4:
                    return RadioStreamList.StreamUrls[4];

                default:
                    return null;
            }
        }

        private int GetFrequencyRange(double frequency)
        {
            if (frequency >= ConstValues.MINFREQUENCY && frequency < _frequencyVier)
            {
                return 0;
            }

            else if (frequency >= _frequencyVier && frequency < _frequencyEnergy)
            {
                return 1;
            }

            else if (frequency >= _frequencyEnergy && frequency < _frequencyNext)
            {
                return 2;
            }

            else if (frequency >= _frequencyNext && frequency < _frequencyEins)
            {
                return 3;
            }

            else if (frequency >= _frequencyEins && frequency <= _frequency21)
            {
                return 4;
            }

            return -1;
        }

        private void CheckAndUpdateFrequencyRange()
        {
            int newFrequencyRange = GetFrequencyRange(Frequency);
            if (newFrequencyRange != _currentFrequencyRange)
            {
                _currentFrequencyRange = newFrequencyRange;
                OnPropertyChanged(nameof(CurrentRadioImage));
                UpdateRadio();
            }
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
