using GalaSoft.MvvmLight;
using Kerbal_Memorial_1._0.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace Kerbal_Memorial_1._0.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

        public ICommand ReadKerbals()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            List<CrewMember> DeadKerbals = new List<CrewMember>();
            //            string kn;
            //            bool ba;
            int ks;
            string Kerbal = "current";
            if (dlg.CheckFileExists == false)
            {
                System.IO.StreamReader PersistenceFile = new System.IO.StreamReader(dlg.FileName);
                do
                {
                    Kerbal = PersistenceFile.ReadLine();

                    //                    if (Kerbal.Contains("name") == true)
                    //                    {
                    //                        Kerbal = Kerbal.Remove(0, 10);
                    //                        kn = Kerbal;
                    //                    }

                    //                    if (Kerbal.Contains("badS") == true)
                    //                    {
                    //                        Kerbal = Kerbal.Remove(0, 10);
                    //                        ba = Boolean.Parse(Kerbal);
                    //                        DeadKerbals.Add(new CrewMember(ba));
                    //                   }

                    if (Kerbal.Contains("state") == true)
                    {
                        Kerbal = Kerbal.Remove(0, 10);
                        ks = int.Parse(Kerbal);
                        DeadKerbals.Add(new CrewMember(ks));

                    }

                } while (Kerbal.Contains("VESSEL") != true);
            }
            return ks;            
        }
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}