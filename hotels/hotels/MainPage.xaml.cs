using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hotels
{
    public class Room :INotifyPropertyChanged
    {
        private int number;
        private int freePlace;     
      
        public event PropertyChangedEventHandler PropertyChanged;
        public int Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        public int FreePlace
        {
            get { return freePlace; }
            set
            {
                if (freePlace != value)
                {
                    freePlace = value;
                    OnPropertyChanged("FreePlace");
                }
            }
        }

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Room> RoomsCollection { get; set; }
        public List<Room> Rooms { get; set; }
        public Room CurrentRoom { get; set; }

        public MainPage()
        {
            InitializeComponent();              
            RoomsCollection = new ObservableCollection<Room>();
            CurrentRoom = new Room();
            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            RoomsCollection.Add(CurrentRoom);
        }
    }
}
