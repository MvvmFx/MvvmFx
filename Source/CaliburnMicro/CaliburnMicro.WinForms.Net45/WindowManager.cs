namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
#if WEBGUI
    using Gizmox.WebGUI.Forms;
    using Window = Gizmox.WebGUI.Forms.Form;
    using NavigationWindow = Gizmox.WebGUI.Forms.Form;
    using Popup = Gizmox.WebGUI.Forms.Panel;
#elif WISEJ
    using Wisej.Web;
    using Window = Wisej.Web.Form;
    using NavigationWindow = Wisej.Web.Form;
    using Popup = Wisej.Web.Panel;
#else
    using System.Windows.Forms;
    using Window = System.Windows.Forms.Form;
    using NavigationWindow = System.Windows.Forms.Form;
    using Popup = System.Windows.Forms.Panel;
#endif

    /// <summary>
    /// A service that manages windows.
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        /// Shows a modal dialog Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional dialog settings.</param>
        /// <returns>The return value should denote whether the dialog result was afirmative.</returns>
        bool? ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null);

        /// <summary>
        /// Shows a non-modal Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        void ShowWindow(object rootModel, object context = null, IDictionary<string, object> settings = null);

        /*/// <summary>
        /// Shows a popup at the current mouse position.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The view context.</param>
        /// <param name="settings">The optional popup settings.</param>
        void ShowPopup(object rootModel, object context = null, IDictionary<string, object> settings = null);*/

        /// <summary>
        /// Shows a Form for the specified model, and that Form is supposed to be the main application form.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        void ShowMainWindow(object rootModel, object context = null, IDictionary<string, object> settings = null);
    }

    /// <summary>
    /// A service that manages windows.
    /// </summary>
    public class WindowManager : IWindowManager
    {
        /// <summary>
        /// Shows a modal dialog Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional dialog settings.</param>
        /// <returns>The return value should denote whether the dialog result was afirmative.</returns>
        public virtual bool? ShowDialog(object rootModel, object context = null,
            IDictionary<string, object> settings = null)
        {
            DialogResult result = DialogResult.OK;

            Execute.OnUIThread(() =>
            {
                using (var dlg = CreateWindow(rootModel, true, context, settings))
                {
                    dlg.ShowDialog();
                    result = dlg.DialogResult;
                }
            });

            if (result == DialogResult.OK || result == DialogResult.Yes)
                return true;
            if (result == DialogResult.Cancel || result == DialogResult.No)
                return true;
            return null;
        }

        /// <summary>
        /// Shows a Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        public virtual void ShowWindow(object rootModel, object context = null,
            IDictionary<string, object> settings = null)
        {
            NavigationWindow navWindow = null;

            if (ApplicationContext.MainWindow != null)
            {
                navWindow = ApplicationContext.MainWindow;
            }

            if (navWindow != null)
            {
                //var window = CreatePage(rootModel, context, settings);
                //navWindow.Navigate(window);
            }
            else
            {
                var window = CreateWindow(rootModel, true, context, settings);

                if (FormStartPosition.CenterParent == window.StartPosition && null != window.Owner)
                {
                    window.StartPosition = FormStartPosition.Manual;
                    window.Location =
                        new Point(
                            window.Owner.Location.X + (window.Owner.Width - window.Width)/2,
                            window.Owner.Location.Y + (window.Owner.Height - window.Height)/2);
                }

                Execute.OnUIThread(() => { window.Show(); });
            }
        }

        /*/// <summary>
        /// Shows a popup at the current mouse position.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The view context.</param>
        /// <param name="settings">The optional popup settings.</param>
        public virtual void ShowPopup(object rootModel, object context = null,
            IDictionary<string, object> settings = null)
        {
            var popup = CreatePopup(rootModel, settings);
            var view = ViewLocator.LocateForModel(rootModel, popup, context);

            popup.Child = view;
            //popup.SetValue(View.IsGeneratedProperty, true);

            ViewModelBinder.Bind(rootModel, popup, null);
            Action.SetTargetWithoutContext(view, rootModel);

            var activatable = rootModel as IActivate;
            if (activatable != null)
            {
                activatable.Activate();
            }

            var deactivator = rootModel as IDeactivate;
            if (deactivator != null)
            {
                popup.Closed += delegate { deactivator.Deactivate(true); };
            }

            popup.IsOpen = true;
            popup.CaptureMouse();
        }

        /// <summary>
        /// Creates a popup for hosting a popup window.
        /// </summary>
        /// <param name="rootModel">The model.</param>
        /// <param name="settings">The optional popup settings.</param>
        /// <returns>The popup.</returns>
        protected virtual Popup CreatePopup(object rootModel, IDictionary<string, object> settings)
        {
            var popup = new Popup();

            if (ApplySettings(popup, settings))
            {
                if (!settings.ContainsKey("PlacementTarget") && !settings.ContainsKey("Placement"))
                    popup.Placement = PlacementMode.MousePoint;
                if (!settings.ContainsKey("AllowsTransparency"))
                    popup.AllowsTransparency = true;
            }
            else
            {
                popup.AllowsTransparency = true;
                popup.Placement = PlacementMode.MousePoint;
            }

            return popup;
        }*/

        /// <summary>
        /// For the specified model, shows a Form that is supposed to be the main application form.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        public virtual void ShowMainWindow(object rootModel, object context = null,
            IDictionary<string, object> settings = null)
        {
#if !WISEJ
            if (ApplicationContext.StartupForm != null)
            {
                Window root = CreateWindow(rootModel, true, context, settings, ApplicationContext.StartupForm);
                new ApplicationContext(root);
            }
#if WINFORMS
            else
            {
                Window root = CreateWindow(rootModel, true, context, settings);
                var applicationContext = new ApplicationContext(root);
                Execute.OnUIThread(() =>
                {
                    //applicationContext.MainForm.ShowDialog();
                    Application.Run(applicationContext);
                });
            }
#endif
#endif
        }

        /// <summary>
        /// Creates a Form.
        /// </summary>
        /// <param name="rootModel">The root view model.</param>
        /// <param name="isDialog">if set to <c>true</c> the Form is a dialog.</param>
        /// <param name="context">The view context.</param>
        /// <param name="settings">The optional popup settings.</param>
        /// <param name="rootForm">The root form.</param>
        /// <returns>The created Form.</returns>
        /// <remarks>
        /// The calling method only passes the root form parameter in ShowMainWindow, when the main form already exists.
        /// This is necessary for Visual WebGUI (or Windows if the Bootstrapper is invoked after the main form creation).
        /// </remarks>
        protected virtual Window CreateWindow(object rootModel, bool isDialog, object context,
            IDictionary<string, object> settings, Window rootForm = null)
        {
            Window view;
            if (rootForm != null)
                view = rootForm;
            else
                view = EnsureWindow(rootModel, ViewLocator.LocateForModel(rootModel, null, null), isDialog);

            ViewModelBinder.Bind(rootModel, view, null);

            var haveDisplayName = rootModel as IHaveDisplayName;
            if (haveDisplayName != null && !ConventionManager.HasBinding(view, "Text"))
            {
                view.DataBindings.Add(new Binding("Text", rootModel, "DisplayName", true,
                    DataSourceUpdateMode.OnPropertyChanged));
            }

            ApplySettings(view, settings);

            new WindowConductor(rootModel, view);

            return view;
        }

        /// <summary>
        /// Makes sure the view is a Form or is wrapped by one.
        /// </summary>
        /// <param name="model">The view model.</param>
        /// <param name="view">The view.</param>
        /// <param name="isDialog">if set to <c>true</c>, the Form is being shown as a dialog.</param>
        /// <returns>The original Form or a new Form embedding the "view" control.</returns>
        protected virtual Window EnsureWindow(object model, object view, bool isDialog)
        {
            var window = view as Window;

            if (window == null)
            {
                window = new Window();

                var contentControl = new ContentContainer()
                {
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    TabIndex = 0,
                    Content = model
                    // when setting the Content property, the setter will locate and load the view
                };

                //window.SetValue(View.IsGeneratedProperty, true);
                window.Controls.Add(contentControl);

#if WEBGUI
                var owner = ApplicationContext.WebGUIActiveForm;
#else
                var owner = Window.ActiveForm;
#endif
                if (null != owner && window != owner)
                {
                    window.StartPosition = FormStartPosition.CenterParent;
                    window.Owner = owner;
                }
                else
                {
                    window.StartPosition = FormStartPosition.CenterScreen;
                }
            }
            else
            {
                var owner = InferOwnerOf(window);
                if (owner != null && isDialog)
                {
                    window.Owner = owner;
                }
                else if (owner == null)
                {
                    window.StartPosition = FormStartPosition.CenterScreen;
                }
            }

            return window;
        }

        /// <summary>
        /// Infers the owner of the Form.
        /// </summary>
        /// <param name="window">The Form to whose owner needs to be determined.</param>
        /// <returns>The Form's owner.</returns>
        protected virtual Window InferOwnerOf(Window window)
        {
            if (ApplicationContext.MainWindow == null)
            {
                return null;
            }

            var active = Application.OpenForms.Cast<Window>().FirstOrDefault();
            active = active ?? ApplicationContext.MainWindow;
            return active == window ? null : active;
        }

        private bool ApplySettings(object target, IEnumerable<KeyValuePair<string, object>> settings)
        {
            if (settings != null)
            {
                var type = target.GetType();

                foreach (var pair in settings)
                {
                    var propertyInfo = type.GetProperty(pair.Key);

                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(target, pair.Value, null);
                    }
                }

                return true;
            }

            return false;
        }

        private class WindowConductor
        {
            private bool deactivatingFromView;
            private bool deactivateFromViewModel;
            private bool actuallyClosing;
            private readonly Window view;
            private readonly object model;

            public WindowConductor(object model, Window view)
            {
                this.model = model;
                this.view = view;

                var activatable = model as IActivate;
                if (activatable != null)
                {
                    activatable.Activate();
                }

                var deactivatable = model as IDeactivate;
                if (deactivatable != null)
                {
                    view.Closed += Closed;
                    deactivatable.Deactivated += Deactivated;
                }

                var guard = model as IGuardClose;
                if (guard != null)
                {
                    view.Closing += Closing;
                }
            }

            private void Closed(object sender, EventArgs e)
            {
                view.Closed -= Closed;
                view.Closing -= Closing;

                if (deactivateFromViewModel)
                {
                    return;
                }

                var deactivatable = (IDeactivate) model;

                deactivatingFromView = true;
                deactivatable.Deactivate(true);
                deactivatingFromView = false;
            }

            private void Deactivated(object sender, DeactivationEventArgs e)
            {
                if (!e.WasClosed)
                {
                    return;
                }

                ((IDeactivate) model).Deactivated -= Deactivated;

                if (deactivatingFromView)
                {
                    return;
                }

                deactivateFromViewModel = true;
                actuallyClosing = true;
                view.Close();
                actuallyClosing = false;
                deactivateFromViewModel = false;
            }

            private void Closing(object sender, CancelEventArgs e)
            {
                if (e.Cancel)
                {
                    return;
                }

                var guard = (IGuardClose) model;

                if (actuallyClosing)
                {
                    actuallyClosing = false;
                    return;
                }

                bool runningAsync = false, shouldEnd = false;

                guard.CanClose(canClose =>
                {
                    Execute.OnUIThread(() =>
                    {
                        if (runningAsync && canClose)
                        {
                            actuallyClosing = true;
                            view.Close();
                        }
                        else
                        {
                            e.Cancel = !canClose;
                        }

                        shouldEnd = true;
                    });
                });

                if (shouldEnd)
                {
                    return;
                }

                runningAsync = e.Cancel = true;
            }
        }
    }
}