using Notation.Model;
using Notation.ViewModel.Commands;
using Notation.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notation.ViewModel
{
    public class NotesVM
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook selectedNotebook;
        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set 
            { 
                selectedNotebook = value; 
                //TODO: get notes
            }
        }

        public ObservableCollection<Note> Notes { get; set; }
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }

        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
        }

        public void CreateNotebook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New Notebook",
            };

            DatabaseHelper.Insert(newNotebook);
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New Note"
            };

            DatabaseHelper.Insert(newNote);
        }
    }
}
