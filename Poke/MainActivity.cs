using Android.App;
using Android.Widget;
using Android.OS;

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
namespace Poke
{
    [Activity(Label = "Poke", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button _buttonFind;
        private EditText _editNumber;
        private TextView _textName;
        private ImageView _imageView;
        private Pokedex _pokedex;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _pokedex = new Pokedex();

            _buttonFind = FindViewById<Button>(Resource.Id.buttonFind);
            _editNumber = FindViewById<EditText>(Resource.Id.editNumber);
            _textName = FindViewById<TextView>(Resource.Id.textName);
            _imageView = FindViewById<ImageView>(Resource.Id.imagePokemon);

            _buttonFind.Click += OnClicked;
        }

        private void OnClicked(object sender, System.EventArgs e)
        {
            if (int.TryParse(_editNumber.Text, out int number))
            {
                _textName.Text = _pokedex.GetPokemonName(number);
                _imageView.SetImageBitmap(_pokedex.GetPokemonBitmapImage(number));
            }
        }
    }
}

