using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;

namespace RoomExample
{
    [Activity(Label = "NoteDetailsActivity")]
    public class NoteDetailsActivity : Activity
    {
        private Note note;
        private TextView text;
        private TextView date;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_note_details);

            ActionBar.SetDisplayHomeAsUpEnabled(true);

            text = FindViewById<TextView>(Resource.Id.noteDetailsText);
            date = FindViewById<TextView>(Resource.Id.noteDetailsDate);

            // Create your application here
            int noteId = Intent.GetIntExtra("noteId", -1);

            if(noteId == -1)
            {
                return;
            }
            await Task.Run(async () =>
            {
                // Retrieve data
                //note = NoteDatabase.GetInstance(this).NoteDao().Load(noteId);
            });

            //text.Text = note.Text;
            //date.Text = note.Timestamp.ToString();
            text.Text = $"Note id {noteId}";
            date.Text = System.DateTime.Now.ToString();
        }
    }
}