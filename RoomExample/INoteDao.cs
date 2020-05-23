using System.Collections.Generic;

using AndroidX.Room;

namespace RoomExample
{
    [Dao]
    public interface INoteDao
    {
        [Insert(OnConflict = 0)]
        void Save(Note note);

        [Query(Value = "SELECT * FROM notes WHERE id = :noteId")]
        Note Load(int noteId);

        [Query(Value = "SELECT * FROM notes")]
        List<Note> Load();

        [Update(OnConflict = 0)]
        void Update(Note note);

        [Delete]
        void Delete(Note note);
    }
}