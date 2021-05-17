using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Polygon myPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                StrokeThickness = 1,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            PointCollection points = new PointCollection
            {
                new Point(0, 0),
                new Point(MyCanvas.Width, 0),
                new Point(MyCanvas.Width, MyCanvas.Height),
                new Point(0, MyCanvas.Height)
            };

            myPolygon.Points = points;

            MyCanvas.Children.Insert(0, myPolygon);

            PersonName.TextAlignment = TextAlignment.Center;

            ChangeElementsVisibility(Visibility.Hidden);

            BoxAgendaName.IsReadOnly = true;
            BoxActivityName.IsReadOnly = true;
            BoxActivityDescription.IsReadOnly = true;
            BoxActivityDateStart.IsReadOnly = true;
            BoxActivityDateEnd.IsReadOnly = true;
            BoxParticipantsName.IsReadOnly = true;
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text != "" && LastName.Text != "")
            {
                MyListOfPersons.Items.Add(new Person(FirstName.Text, LastName.Text));
            }
        }
        private void ButtonAddAgenda_Click(object sender, RoutedEventArgs e)
        {
            if (BoxAgendaName.Text != "")
            {
                Person helper = (Person)MyListOfPersons.SelectedItem;

                helper.AddAgenda(BoxAgendaName.Text);

                MyListOfAgendas.Items.Add(helper.GetAgenda(helper.GetNumberOfAgendas() - 1));

                BoxAgendaName.Text = "";
            }
        }

        private void ButtonAddActivity_Click(object sender, RoutedEventArgs e)
        {
            if (BoxActivityName.Text != "")
            {
                Agenda helper = (Agenda)MyListOfAgendas.SelectedItem;

                helper.AddActivity(BoxActivityName.Text, BoxActivityDescription.Text, BoxActivityDateStart.Text, BoxActivityDateEnd.Text);

                MyListOfActivities.Items.Add(helper.GetActivity(helper.GetNumberOfActivities() - 1));

                BoxActivityName.Text = "";
                BoxActivityDescription.Text = "";
                BoxActivityDateStart.Text = "";
                BoxActivityDateEnd.Text = "";
            }
        }

        private void ButtonAddParticipants_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyListOfPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyListOfAgendas.ReleaseAllTouchCaptures();

            MyListOfAgendas.Items.Clear();
            MyListOfActivities.Items.Clear();
            MyListOfParticipants.Items.Clear();

            BoxAgendaName.Text = "";
            BoxActivityName.Text = "";
            BoxActivityDescription.Text = "";
            BoxActivityDateStart.Text = "";
            BoxActivityDateEnd.Text = "";
            BoxParticipantsName.Text = "";

            BoxAgendaName.IsReadOnly = false;
            BoxActivityName.IsReadOnly = true;
            BoxActivityDescription.IsReadOnly = true;
            BoxActivityDateStart.IsReadOnly = true;
            BoxActivityDateEnd.IsReadOnly = true;
            BoxParticipantsName.IsReadOnly = true;

            Person helper;

            if (e.AddedItems[0] == null)
            {
                helper = (Person)e.RemovedItems[0];
            }
            else
            {
                helper = (Person)e.AddedItems[0];
            }


            foreach (Person item in MyListOfPersons.Items)
            {
                if (helper.Equals(item))
                {
                    for (int i = 0; i < item.GetNumberOfAgendas(); i++)
                    {
                        MyListOfAgendas.Items.Add(item.GetAgenda(i));
                    }
                }
            }

            PersonName.Text = MyListOfPersons.SelectedItem.ToString();

            if (MyListOfAgendas.Visibility == Visibility.Hidden)
            {
                ChangeElementsVisibility(Visibility.Visible);
            }
        }

        private void MyListOfAgendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyListOfActivities.Items.Clear();
            MyListOfParticipants.Items.Clear();

            BoxActivityName.Text = "";
            BoxActivityDescription.Text = "";
            BoxActivityDateStart.Text = "";
            BoxActivityDateEnd.Text = "";
            BoxParticipantsName.Text = "";

            BoxAgendaName.IsReadOnly = true;
            BoxActivityName.IsReadOnly = false;
            BoxActivityDescription.IsReadOnly = false;
            BoxActivityDateStart.IsReadOnly = false;
            BoxActivityDateEnd.IsReadOnly = false;
            BoxParticipantsName.IsReadOnly = true;

            Agenda helper;

            if (e.AddedItems[0] != null)
            {
                

                foreach (Agenda item in MyListOfAgendas.Items)
                {
                    if (helper.Equals(item))
                    {
                        for (int i = 0; i < item.GetNumberOfActivities(); i++)
                        {
                            MyListOfAgendas.Items.Add(item.GetActivity(i));
                        }
                    }
                }
            }
        }

        private void MyListOfActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MyListOfParticipants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChangeElementsVisibility(Visibility v)
        {
            TextAgendaName.Visibility = v;
            TextActivityName.Visibility = v;
            TextParticipantsName.Visibility = v;

            BoxAgendaName.Visibility = v;
            BoxActivityName.Visibility = v;
            BoxActivityDescription.Visibility = v;
            BoxActivityDateStart.Visibility = v;
            BoxActivityDateEnd.Visibility = v;
            BoxParticipantsName.Visibility = v;

            ButtonAddAgenda.Visibility = v;
            ButtonAddActivity.Visibility = v;
            ButtonAddParticipants.Visibility = v;

            TextAgendas.Visibility = v;
            TextActivites.Visibility = v;
            TextParticipants.Visibility = v;

            MyListOfAgendas.Visibility = v;
            MyListOfActivities.Visibility = v;
            MyListOfParticipants.Visibility = v;
        }
    }
}
