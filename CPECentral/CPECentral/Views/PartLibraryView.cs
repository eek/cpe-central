﻿#region Using directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartLibraryView : IView
    {
        Part SelectedPart { get; }
        Customer SelectedCustomer { get; }
        SearchField SearchField { get; }
        string SearchValue { get; }

        event EventHandler<PartSearchEventArgs> Search;
        event EventHandler ReloadData;
        event EventHandler<CustomerEventArgs> CustomerSelected;
        event EventHandler<PartEventArgs> PartSelected;

        void RefreshLibrary();
        void DisplayLibrary(PartLibraryViewModel viewModel);
        void DisplaySearchResults(PartLibraryViewModel viewModel);
    }

    [DefaultEvent("PartSelected")]
    public partial class PartLibraryView : ViewBase, IPartLibraryView
    {
        private readonly PartLibraryViewPresenter _presenter;
        private int _idOfPartToSelect;

        public PartLibraryView()
        {
            InitializeComponent();

            enhancedTreeViewImageList.Images.Add("CustomerIcon", Resources.CustomerIcon_16x16);
            enhancedTreeViewImageList.Images.Add("PartIcon", Resources.OpenIcon_16x16);

            if (!IsInDesignMode)
            {
                _presenter = new PartLibraryViewPresenter(this);

                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
                Session.MessageBus.Subscribe<PartAddedMessage>(PartAddedMessage_Published);
            }
        }

        #region IPartLibraryView Members

        public Part SelectedPart { get; private set; }
        public Customer SelectedCustomer { get; private set; }

        public SearchField SearchField
        {
            get
            {
                switch (searchFieldComboBox.Text)
                {
                    case "Drawing number":
                        return SearchField.DrawingNumber;
                    case "Name":
                        return SearchField.Name;
                    default:
                        return SearchField.DrawingNumber;
                }
            }
        }

        public string SearchValue
        {
            get { return searchValueTextBox.Text; }
        }

        public event EventHandler<PartSearchEventArgs> Search;

        public event EventHandler ReloadData;
        public event EventHandler<CustomerEventArgs> CustomerSelected;
        public event EventHandler<PartEventArgs> PartSelected;

        public void DisplayLibrary(PartLibraryViewModel viewModel)
        {
            DisplayModel(viewModel, false);

            if (_idOfPartToSelect != null)
                SelectPart(_idOfPartToSelect);
        }

        public void DisplaySearchResults(PartLibraryViewModel viewModel)
        {
            DisplayModel(viewModel, true);

            enhancedTreeView.ExpandAll();
        }

        #endregion

        public void RefreshLibrary()
        {
            enhancedTreeView.Nodes.Clear();
            enhancedTreeView.Nodes.Add("loading....");
            enhancedTreeView.Enabled = false;

            OnReloadData();
        }

        private void PartLibraryView_Load(object sender, EventArgs e)
        {
            searchFieldComboBox.SelectedIndex = 0;

            if (Settings.Default.LastViewedPartId > 0)
                _idOfPartToSelect = Settings.Default.LastViewedPartId;

            RefreshLibrary();
        }

        private void DisplayModel(PartLibraryViewModel viewModel, bool isSearchResult)
        {
            enhancedTreeView.Nodes.Clear();

            enhancedTreeView.Enabled = true;

            if (viewModel == null)
            {
                enhancedTreeView.Nodes.Add("Error loading library!");
                return;
            }

            if (!viewModel.Customers.Any())
            {
                if (isSearchResult)
                    enhancedTreeView.Nodes.Add("The search returned no results!");
                else
                    enhancedTreeView.Nodes.Add("There are no parts in the library!");

                return;
            }

            int partCount = 0;

            foreach (var customer in viewModel.Customers.OrderBy(c => c.Name))
            {
                var customerNode = enhancedTreeView.Nodes.Add(customer.Name);
                customerNode.ImageKey = "CustomerIcon";
                customerNode.SelectedImageKey = "CustomerIcon";
                customerNode.Tag = customer;

                var customerParts = viewModel.Parts.Where(p => p.CustomerId == customer.Id)
                                             .OrderBy(p => p.DrawingNumber);

                foreach (var part in customerParts)
                {
                    partCount++;

                    string nodeText;

                    if (isSearchResult && SearchField == SearchField.Name)
                        nodeText = part.DrawingNumber + " (" + part.Name + ")";
                    else
                        nodeText = part.DrawingNumber;

                    var partNode = customerNode.Nodes.Add(nodeText);
                    partNode.ImageKey = "PartIcon";
                    partNode.SelectedImageKey = "PartIcon";
                    partNode.ToolTipText = part.Name;
                    partNode.Tag = part;
                }
            }

            var status = "Found " + partCount + " parts";

            Session.MessageBus.Publish(new StatusUpdateMessage(status));
        }

        protected virtual void OnReloadData()
        {
            var handler = ReloadData;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnCustomerSelected(CustomerEventArgs e)
        {
            var handler = CustomerSelected;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnPartSelected(PartEventArgs e)
        {
            var handler = PartSelected;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSearch(PartSearchEventArgs e)
        {
            EventHandler<PartSearchEventArgs> handler = Search;
            if (handler != null) handler(this, e);
        }

        private void PartAddedMessage_Published(PartAddedMessage message)
        {
            _idOfPartToSelect = message.NewPart.Id;
            OnReloadData();
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (SelectedPart == message.EditedPart)
            {
                var selectedNode = enhancedTreeView.SelectedNode;

                selectedNode.Text = message.EditedPart.DrawingNumber;
                selectedNode.ToolTipText = message.EditedPart.Name;
                selectedNode.Tag = message.EditedPart;
            }
        }

        private void enhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Part)
            {
                SelectedPart = (Part) e.Node.Tag;

                _idOfPartToSelect = SelectedPart.Id;

                OnPartSelected(new PartEventArgs(SelectedPart));
            }
            else if (e.Node.Tag is Customer)
            {
                SelectedCustomer = (Customer) e.Node.Tag;
                OnCustomerSelected(new CustomerEventArgs(SelectedCustomer));
            }
        }
    
        private void SelectPart(int partId)
        {
            foreach (TreeNode customerNode in enhancedTreeView.Nodes)
            {
                foreach (TreeNode partNode in customerNode.Nodes)
                {
                    var nodePart = (Part) partNode.Tag;

                    if (nodePart.Id != partId)
                        continue;

                    enhancedTreeView.SelectedNode = partNode;
                    return;
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            enhancedTreeView.Nodes.Clear();
            enhancedTreeView.Nodes.Add("searching...");

            var args = new PartSearchArgs(SearchField, SearchValue);

            OnSearch(new PartSearchEventArgs(args));
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshLibrary();
        }

        private void searchValueTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            searchButton.PerformClick();
        }
    }

    public class PartSearchArgs
    {
        public SearchField Field { get; set; }
        public string Value { get; set; }

        public PartSearchArgs(SearchField field, string value)
        {
            Field = field;
            Value = value;
        }
    }

    public enum SearchField
    {
        DrawingNumber,
        Name
    }
}