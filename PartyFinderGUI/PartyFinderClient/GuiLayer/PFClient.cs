﻿using PartyFinderClient.ControlLayer;
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
        EventControl _eventControl;
        public PFClient()
        {
            InitializeComponent();

            _eventControl = new EventControl();
        }

        

        private async void ButtonGetEvents_Click(object sender, EventArgs e)
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

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}