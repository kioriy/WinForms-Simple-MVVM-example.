﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsBindingExample.Models;

namespace WinFormsBindingExample.Views
{
    public sealed partial class ExampleView : ViewBase
    {
        #region Private fields
        private ExampleViewModel _model;                // Local reference to the Model this View will use for Binding operations.
        #endregion

        #region Ctor
        /// <summary>
        /// Construct our ExampleView and use Dependancy Injection to use a passed Model.
        /// </summary>
        /// <param name="model">ExampleViewModel to use for Binding</param>
        public ExampleView(ExampleViewModel model = null)
        {
            // Check if a ViewModel was passed to the ctor
            if (model != null)
            {
                //Todo: Todo: Add type checking here to ensure that types of model valid only for this View type are assigend, otherwise create a default model (ExampleViewModel).
                // Assign a local reference to the model.
                _model = model;
            }
            else
            {
                // Create a new instance of the ViewModel for this specific View, as one was not provided to the ctor
                _model = new ExampleViewModel();
            }

            InitializeComponent();


            // Bind the controls for this View to their Model's properties.
            PerformBinding();
        }
        #endregion

        /// <summary>
        /// Sets up binding for the tbName and lblName controls used in this ExampleView.
        /// <para>You might want to also implement an interface that ensures all of your View types implement PerformBinding() to keep everything predictable.</para>
        /// </summary>
        public sealed override void PerformBinding()
        {
            tbName.DataBindings.Add("Text", _model, nameof(_model.Name), false, DataSourceUpdateMode.OnPropertyChanged);
            lblName.DataBindings.Add("Text", _model, nameof(_model.Name), false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
