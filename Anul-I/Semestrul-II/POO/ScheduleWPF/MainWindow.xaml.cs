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
            BoxParticipantsEMails.IsReadOnly = true;

            ButtonDeleteAgenda.IsEnabled = false;
            ButtonDeleteParticipant.IsEnabled = false;
            ButtonDeleteActivity.IsEnabled = false;
        }

        private void ButtonAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text != "" && LastName.Text != "" && EMail.Text != "")
            {
                MyListOfPersons.Items.Add(new Person(FirstName.Text, LastName.Text, EMail.Text));

                FirstName.Text = "";
                LastName.Text = "";
                EMail.Text = "";
            }
        }
        private void ButtonAddAgenda_Click(object sender, RoutedEventArgs e)
        {
            if (BoxAgendaName.Text != "")
            {
                Person thisPerson = (Person)MyListOfPersons.SelectedItem;

                thisPerson.AddAgenda(BoxAgendaName.Text);

                MyListOfAgendas.Items.Add(thisPerson.GetAgenda(thisPerson.GetNumberOfAgendas() - 1));
            }

            BoxAgendaName.Text = "";
            BoxParticipantsEMails.Text = "";
        }

        private void ButtonDeleteAgenda_Click(object sender, RoutedEventArgs e)
        {
            Agenda thisPersonsAgenda = (Agenda)MyListOfAgendas.SelectedItem;

            if (thisPersonsAgenda != null)
            {
                Person thisPerson = (Person)MyListOfPersons.SelectedItem;
                
                int indexToDeleteParticipant = thisPersonsAgenda.GetIndexOfParticipant(thisPerson);
                int indexToDeleteAgenda = thisPerson.GetIndexOfAgenda(thisPersonsAgenda);

                thisPersonsAgenda.DeleteParticipant(indexToDeleteParticipant);
                thisPerson.DeleteAgenda(indexToDeleteAgenda);

                MyListOfAgendas.Items.RemoveAt(MyListOfAgendas.Items.IndexOf(thisPersonsAgenda));
                MyListOfParticipants.Items.Clear();
                MyListOfActivities.Items.Clear();
            }
        }
        private void ButtonAddParticipants_Click(object sender, RoutedEventArgs e)
        {
            if (BoxParticipantsEMails.Text != "")
            {
                Agenda thisPersonsAgenda = (Agenda)MyListOfAgendas.SelectedItem;

                List<Person> thisAgendasListOfParticipants = new List<Person>();

                int numberOfParticipants = thisPersonsAgenda.GetNumberOfParticipants(), indexOfAgenda;

                for (int i = 0; i < numberOfParticipants; i++)
                {
                    thisAgendasListOfParticipants.Add(thisPersonsAgenda.GetParticipant(i));
                }

                string stringParticipants = BoxParticipantsEMails.Text;

                stringParticipants = stringParticipants.Replace(" ", "");

                string[] stringEMails = stringParticipants.Split(',');   

                foreach (Person newParticipant in MyListOfPersons.Items)
                {
                    if (stringEMails.Contains(newParticipant.EMail))
                    {
                        if ((indexOfAgenda = newParticipant.GetIndexOfAgenda(thisPersonsAgenda)) == -1)
                        {
                            newParticipant.AddAgenda(thisPersonsAgenda);

                            MyListOfParticipants.Items.Add(newParticipant);
                        }
                        else
                        {
                            if (!thisAgendasListOfParticipants.Contains(newParticipant))
                            {
                                for (int i = 0; i < numberOfParticipants; i++)
                                {
                                    newParticipant.GetAgenda(indexOfAgenda).AddParticipant(thisAgendasListOfParticipants[i]);
                                }
                                
                                MyListOfParticipants.Items.Add(newParticipant);
                            }      
                        } 
                    }
                }

                BoxParticipantsEMails.Text = "";
            }
        }

        private void ButtonDeleteParticipant_Click(object sender, RoutedEventArgs e)
        {
            Person participantToDelete = (Person)MyListOfParticipants.SelectedItem;

            if (!participantToDelete.Equals(MyListOfPersons.SelectedItem) && participantToDelete != null)
            {             
                Agenda agendaToDeleteFrom = (Agenda)MyListOfAgendas.SelectedItem;
                
                int indexToDeleteParticipant = agendaToDeleteFrom.GetIndexOfParticipant(participantToDelete);
                int indexToDeleteAgenda = participantToDelete.GetIndexOfAgenda(agendaToDeleteFrom);

                agendaToDeleteFrom.DeleteParticipant(indexToDeleteParticipant);
                participantToDelete.DeleteAgenda(indexToDeleteAgenda);

                MyListOfParticipants.Items.RemoveAt(MyListOfParticipants.Items.IndexOf(participantToDelete));
            }
        }

        private void ButtonAddActivity_Click(object sender, RoutedEventArgs e)
        {
            if (BoxActivityName.Text != "" && BoxActivityDescription.Text != "" && BoxActivityDateStart.Text != "" && BoxActivityDateEnd.Text != "")
            {
                Agenda thisAgenda = (Agenda)MyListOfAgendas.SelectedItem;

                thisAgenda.AddActivity(BoxActivityName.Text, BoxActivityDescription.Text, BoxActivityDateStart.Text, BoxActivityDateEnd.Text);

                MyListOfActivities.Items.Add(thisAgenda.GetActivity(thisAgenda.GetNumberOfActivities() - 1));

                BoxActivityName.Text = "";
                BoxActivityDescription.Text = "";
                BoxActivityDateStart.Text = "";
                BoxActivityDateEnd.Text = "";
            }
        }

        private void ButtonDeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            Agenda thisPersonsAgenda = (Agenda)MyListOfAgendas.SelectedItem;

            if (thisPersonsAgenda != null)
            {
                Activity thisAgendasActivity = (Activity)MyListOfActivities.SelectedItem;
                
                int indexOfActivity = thisPersonsAgenda.GetIndexOfActivity(thisAgendasActivity);

                if (indexOfActivity != -1)
                {
                    thisPersonsAgenda.DeleteActivity(indexOfActivity);

                    MyListOfActivities.Items.RemoveAt(MyListOfActivities.Items.IndexOf(thisAgendasActivity));
                }
            }
        }

        private void MyListOfPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region UI changes when interacting with MyListOfPersons
            MyListOfAgendas.ReleaseAllTouchCaptures();

            MyListOfAgendas.Items.Clear();
            MyListOfActivities.Items.Clear();
            MyListOfParticipants.Items.Clear();

            BoxAgendaName.Text = "";
            BoxParticipantsEMails.Text = "";
            BoxActivityName.Text = "";
            BoxActivityDescription.Text = "";
            BoxActivityDateStart.Text = "";
            BoxActivityDateEnd.Text = "";

            BoxAgendaName.IsReadOnly = false;
            BoxParticipantsEMails.IsReadOnly = true;
            BoxActivityName.IsReadOnly = true;
            BoxActivityDescription.IsReadOnly = true;
            BoxActivityDateStart.IsReadOnly = true;
            BoxActivityDateEnd.IsReadOnly = true;

            ButtonDeleteAgenda.IsEnabled = false;
            ButtonDeleteParticipant.IsEnabled = false;
            ButtonDeleteActivity.IsEnabled = false;

            PersonName.Text = MyListOfPersons.SelectedItem.ToString();

            if (MyListOfAgendas.Visibility == Visibility.Hidden)
            {
                ChangeElementsVisibility(Visibility.Visible);
            }
            #endregion

            Person thisPerson = (Person)e.AddedItems[0];

            foreach (Person personFromList in MyListOfPersons.Items)
            {
                if (thisPerson.Equals(personFromList))
                {
                    int numberOfAgendas = personFromList.GetNumberOfAgendas();

                    for (int i = 0; i < numberOfAgendas; i++)
                    {
                        MyListOfAgendas.Items.Add(personFromList.GetAgenda(i));
                    }
                }
            }
        }

        private void MyListOfAgendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region UI changes when interacting with MyListOfAgendas
            MyListOfActivities.Items.Clear();
            MyListOfParticipants.Items.Clear();

            BoxActivityName.Text = "";
            BoxActivityDescription.Text = "";
            BoxActivityDateStart.Text = "";
            BoxActivityDateEnd.Text = "";
            BoxParticipantsEMails.Text = "";

            BoxAgendaName.IsReadOnly = true;
            BoxParticipantsEMails.IsReadOnly = false;
            BoxActivityName.IsReadOnly = false;
            BoxActivityDescription.IsReadOnly = false;
            BoxActivityDateStart.IsReadOnly = false;
            BoxActivityDateEnd.IsReadOnly = false;

            ButtonDeleteAgenda.IsEnabled = true;
            ButtonDeleteParticipant.IsEnabled = false;
            ButtonDeleteActivity.IsEnabled = false;
            #endregion

            if (e.AddedItems.Count == 1)
            {
                Agenda thisAgenda = (Agenda)e.AddedItems[0];

                foreach (Agenda agendaFromList in MyListOfAgendas.Items)
                {
                    if (thisAgenda.Equals(agendaFromList))
                    {
                        int numberOfActivities = agendaFromList.GetNumberOfActivities();

                        for (int i = 0; i < numberOfActivities; i++)
                        {
                            MyListOfActivities.Items.Add(agendaFromList.GetActivity(i));
                        }

                        int numberOfParticipants = agendaFromList.GetNumberOfParticipants();

                        for (int i = 0; i < numberOfParticipants; i++)
                        {
                            MyListOfParticipants.Items.Add(agendaFromList.GetParticipant(i));
                        }
                    }
                }
            }
        }

        private void MyListOfParticipants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region UI changes when interacting with MyListOfParticipants
            ButtonDeleteAgenda.IsEnabled = false;
            ButtonDeleteParticipant.IsEnabled = true;
            ButtonDeleteActivity.IsEnabled = false;
            #endregion
        }

        private void MyListOfActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region UI changes when interacting with MyListOfActvities
            ButtonDeleteAgenda.IsEnabled = false;
            ButtonDeleteParticipant.IsEnabled = false;
            ButtonDeleteActivity.IsEnabled = true;
            #endregion
        }

        private void ChangeElementsVisibility(Visibility v)
        {
            TextAgendaName.Visibility = v;
            TextActivityName.Visibility = v;
            TextParticipantsEMails.Visibility = v;

            BoxAgendaName.Visibility = v;
            BoxActivityName.Visibility = v;
            BoxActivityDescription.Visibility = v;
            BoxActivityDateStart.Visibility = v;
            BoxActivityDateEnd.Visibility = v;
            BoxParticipantsEMails.Visibility = v;

            ButtonAddAgenda.Visibility = v;
            ButtonAddParticipants.Visibility = v;
            ButtonAddActivity.Visibility = v;

            TextAgendas.Visibility = v;
            TextActivites.Visibility = v;
            TextParticipants.Visibility = v;

            MyListOfAgendas.Visibility = v;
            MyListOfActivities.Visibility = v;
            MyListOfParticipants.Visibility = v;
        }
    }
}
