using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Graphics;
using System;

namespace SeekbarSpinnerCheck
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Spinner _spinner;
        private ImageView _btnChangeLogo;
        private CheckBox _checkBox;
        private SeekBar _seekBar;
        private TextView _progess;
        private EditText _name;

        // Synchronizing warning
        private LinearLayout _grpSynchronizing;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_activity);

            _spinner = FindViewById<Spinner>(Resource.Id.spinnerArray);
            _btnChangeLogo = FindViewById<ImageView>(Resource.Id.btnChangeLogo);
            _checkBox = FindViewById<CheckBox>(Resource.Id.checkBox);
            _grpSynchronizing = FindViewById<LinearLayout>(Resource.Id.grpSynchronizing);
            _seekBar = FindViewById<SeekBar>(Resource.Id.seekBar);
            _progess = FindViewById<TextView>(Resource.Id.progress);
            _name = FindViewById<EditText>(Resource.Id.Name);


            _grpSynchronizing.Visibility = ViewStates.Gone;


            //SeekBar 
            _seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                if (e.FromUser)
                {
                    var aux = e.Progress;
                    aux += 50;
                    _progess.Text = aux.ToString() + "%";
                }
            };


            //Name
            _name.SetSelectAllOnFocus(true);
            _name.FocusChange += (s, e) =>
            {
                if (!e.HasFocus)
                    Toast.MakeText(this, "CompanyName Update", ToastLength.Short);
            };

            // Snipper
            var adapterspinner = ArrayAdapter.CreateFromResource(this, Resource.Array.array_spinner, Android.Resource.Layout.SimpleSpinnerItem);
            adapterspinner.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner.Adapter = adapterspinner;
            _spinner.ItemSelected += (s, e) =>
            {
                Toast.MakeText(this, "SystemOfUnits Update", ToastLength.Short);
            };


            //Logo Image
            try
            {
               // var assetStream = Assets.Open("Icon.png");
               //var Logo = BitmapFactory.DecodeStream(assetStream);
               //_btnChangeLogo.SetImageBitmap(Logo);
            }
            catch (Exception)
            {
                //Toast.MakeText(this, "ERROR IMAGE", ToastLength.Short);
            }


            _checkBox.Click += (o, e) => {
                //call function
            };

        }

        private void DialogExampleEvent(object sender, EventArgs e)
        {
            // Ask to remove Sample
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this, Android.Resource.Style.ThemeMaterialDialogNoActionBar);
            alert.SetTitle("Alert");
            alert.SetMessage("Do you wanna Update?");
            alert.SetCancelable(false);

            alert.SetPositiveButton("Yes", (senderAlert, arguments) =>
            {
            });

            alert.SetNegativeButton("No", (senderAlert, arguments) =>
            {
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}