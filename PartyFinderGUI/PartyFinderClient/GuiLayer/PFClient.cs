using PartyFinderClient.Controllers;
using PartyFinderClient.ModelLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartyFinderClient.GuiLayer
{
    public partial class PFClient : Form
    {
        EventController _eventControl;
        public PFClient()
        {
            InitializeComponent();

            _eventControl = new EventController();
        }

        private async void UpdateListBoxEvents()
        {
            string processText = "OK";
            List<Event> fetchedEvents = await _eventControl.GetAllEvents();
            if (fetchedEvents != null)
            {
                if (fetchedEvents.Count >= 1)
                    {
                        processText = "Ok";
                    }
                    else
                    {
                        processText = "No persons found";
                    }
                }
                else
                {
                processText = "Failure: An error occurred";
        }
            labelProcessText.Text = processText;
            listBoxEvents.DataSource = fetchedEvents;
        }

        private async void ButtonGetEvents_Click(object sender, EventArgs e)
        {
                UpdateListBoxEvents();
        }

        public async void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event selEvent = (Event)listBoxEvents.SelectedItem;
            if (selEvent is not null)
            {
                DisplayProduct(selEvent);

                buttonDeleteEvent.Enabled = true;
            }
            else
            {
                buttonDeleteEvent.Enabled=false;
            }
        }

        private async void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            Event eventToDelete = listBoxEvents.SelectedItem as Event;
      
            await _eventControl.DeleteEvent(eventToDelete);

            UpdateListBoxEvents();
        }

        private void labelProcessText_Click(object sender, EventArgs e)
        {

        }

      

        private void DisplayProduct(Event displayedEvent)
        {
            textBoxEventName.Text = displayedEvent.EventName;
            textBoxEventId.Text = displayedEvent.Id.ToString();
            textBoxHolder.Text = displayedEvent.ProfileID.ToString();
            //textBoxLocation.Text = displayedEvent.Location;
            textBoxCapacity.Text = displayedEvent.EventCapacity.ToString();
            textBoxStartTime.Text = displayedEvent.StartDateTime.ToString();
            textBoxEndTime.Text = displayedEvent.EndDateTime.ToString();
            textBoxDescription.Text = displayedEvent.Description;
        }

        private void textBoxEndTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxStartTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCapacity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEventId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEventName_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /*private async void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event selectedEvet = await _eventControl.
        }*/
    }
}
