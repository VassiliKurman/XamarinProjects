using Android.Content;
using AndroidX.Room;

namespace RoomExample
{
    [Database(Entities = new Java.Lang.Class[] { Java.Lang.Class.FromType(typeof(Note))}, ExportSchema = false, Version = 1)]
    public abstract class NoteDatabase : RoomDatabase
    {
        private static readonly object LOCK = new object();
        public static readonly string DATABASE_NAME = "notes";
        private static NoteDatabase sInstance;

        public static NoteDatabase GetInstance(Context context)
        {
            if (sInstance == null)
            {
                lock (LOCK)
                {
                    sInstance = (NoteDatabase)Room.DatabaseBuilder(context.ApplicationContext,
                            Java.Lang.Class.FromType(typeof(NoteDatabase)),
                            DATABASE_NAME)
                        .Build();
                }
            }
            return sInstance;
        }

        public abstract INoteDao NoteDao();
    }
}