using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StaffEmployee
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private string place;

        private bool setToWork;
        private bool finishedWork;

        private int age;
        public int Age {

            get { return age; }

            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        //The beginning of the end of the day
        public string СurrentDate { get { return DateTime.Now.ToString("HH:mm:ss"); } set { } }

        public string Name {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public bool SetToWork {
            get { return setToWork; }
            set
            {
                if(setToWork == value)
                {
                    return;
                }


                setToWork = value;

                OnPropertyChanged("SetToWork");
            }
        }

        public bool FinishedWork {
            get { return finishedWork; }
            set
            {
                if(finishedWork == value)
                {
                    return;
                }
                finishedWork = value;

                OnPropertyChanged("SetToWork");
            }
        }

        public string Place {
            get { return place; }
            set
            {
                place = value;
                OnPropertyChanged("Place");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
