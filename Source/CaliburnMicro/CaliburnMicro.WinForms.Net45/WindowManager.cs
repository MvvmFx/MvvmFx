namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
#if WISEJ
    using Wisej.Web;
    using Window = Wisej.Web.Form;
    //using Popup = Wisej.Web.Panel;
#else
    using System.Windows.Forms;
    using Window = System.Windows.Forms.Form;
    //using Popup = System.Windows.Forms.Panel;
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
        /// <param name="rootForm">The root form.</param>
        /// <returns>The return value should denote whether the dialog result was afirmative.</returns>
        bool? ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null,
            Window rootForm = null);

        /// <summary>
        /// Shows a non-modal Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        /// <param name="rootForm">The root form.</param>
        void ShowWindow(object rootModel, object context = null, IDictionary<string, object> settings = null,
            Window rootForm = null);

#if WISEJ
        /// <summary>
        /// Shows a non-modal Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        /// <param name="rootForm">The root form.</param>
        void ShowPage(object rootModel, object context = null, IDictionary<string, object> settings = null,
            Page rootForm = null);
#endif

        /*/// <summary>
        /// Shows a popup at the current mouse position.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The view context.</param>
        /// <param name="settings">The optional popup settings.</param>
        void ShowPopup(object rootModel, object context = null, IDictionary<string, object> settings = null, Window rootForm = null);*/
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
        /// <param name="rootForm">The root form.</param>
        /// <returns>The return value should denote whether the dialog result was afirmative.</returns>
        public virtual bool? ShowDialog(object rootModel, object context = null,
            IDictionary<string, object> settings = null, Window rootForm = null)
        {
            DialogResult result = DialogResult.OK;

            Execute.OnUIThread(() =>
            {
                using (var dlg = CreateWindow(rootModel, true, context, settings, rootForm))
                {
                    if (dlg.Visible)
                        dlg.Visible = false;

                    dlg.ShowDialog();
                    result = dlg.DialogResult;
                }
            });

            if (result == DialogResult.OK || result == DialogResult.Yes)
                return true;
            if (result == DialogResult.Cancel || result == DialogResult.No)
                return false;
            return null;
        }

        /// <summary>
        /// Shows a Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        /// <param name="rootForm">The root form.</param>
        public virtual void ShowWindow(object rootModel, object context = null,
            IDictionary<string, object> settings = null, Window rootForm = null)
        {
#if WISEJ
            if (ApplicationContext.MainWindow == null && ApplicationContext.MainPage == null)
#else
            if (ApplicationContext.MainWindow == null)
#endif
            {
                var root = CreateWindow(rootModel, true, context, settings, rootForm);

                var applicationContext = new ApplicationContext(root);

                if (root.Visible)
                    root.Visible = false;

                root.ShowDialog();
            }
            else // modeless
            {
                var window = CreateWindow(rootModel, false, context, settings, rootForm);

                if (FormStartPosition.CenterParent == window.StartPosition && null != window.Owner)
                {
                    window.StartPosition = FormStartPosition.Manual;
                    window.Location =
                        new Point(
                            window.Owner.Location.X + (window.Owner.Width - window.Width) / 2,
                            window.Owner.Location.Y + (window.Owner.Height - window.Height) / 2);
                }

#if WISEJ
                window.Show();
#else
                Execute.OnUIThread(() => { window.Show(); });
#endif
            }
        }

#if WISEJ
        /// <summary>
        /// Shows a Form for the specified model.
        /// </summary>
        /// <param name="rootModel">The root model.</param>
        /// <param name="context">The context.</param>
        /// <param name="settings">The optional Form settings.</param>
        /// <param name="rootForm">The root form.</param>
        public virtual void ShowPage(object rootModel, object context = null,
            IDictionary<string, object> settings = null, Page rootForm = null)
        {
            if (ApplicationContext.MainPage == null)
            {
                var root = CreatePage(rootModel, true, context, settings, rootForm);

                var applicationContext = new ApplicationContext(root);

                if (root.Visible)
                    root.Visible = false;

                root.Show();
            }
        }
#endif

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

#if WISEJ
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
        protected virtual Page CreatePage(object rootModel, bool isDialog, object context,
            IDictionary<string, object> settings, Page rootForm = null)
        {
            Page view;
            if (rootForm != null)
                view = rootForm;
            else
                view = EnsurePage(rootModel, ViewLocator.LocateForModel(rootModel, null, null), isDialog);

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
#endif

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

                var owner = Window.ActiveForm;
                window.StartPosition = FormStartPosition.CenterParent;

                if (null != owner && window != owner)
                {
                    window.Owner = owner;
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

#if WISEJ
        /// <summary>
        /// Makes sure the view is a Form or is wrapped by one.
        /// </summary>
        /// <param name="model">The view model.</param>
        /// <param name="view">The view.</param>
        /// <param name="isDialog">if set to <c>true</c>, the Form is being shown as a dialog.</param>
        /// <returns>The original Form or a new Form embedding the "view" control.</returns>
        protected virtual Page EnsurePage(object model, object view, bool isDialog)
        {
            var page = view as Page;

            if (page == null)
            {
                page = new Page();

                var contentControl = new ContentContainer()
                {
                    Dock = DockStyle.Fill,
                    Location = new Point(0, 0),
                    TabIndex = 0,
                    Content = model
                    // when setting the Content property, the setter will locate and load the view
                };

                //window.SetValue(View.IsGeneratedProperty, true);
                page.Controls.Add(contentControl);
            }

            return page;
        }
#endif

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
#if WISEJ
            private readonly Page page;
#endif
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

#if WISEJ
            public WindowConductor(object model, Page page)
            {
                this.model = model;
                this.page = page;

                var activatable = model as IActivate;
                if (activatable != null)
                {
                    activatable.Activate();
                }

                var deactivatable = model as IDeactivate;
                if (deactivatable != null)
                {
                    page.Disposed += Closed;
                    deactivatable.Deactivated += Deactivated;
                }
            }
#endif

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