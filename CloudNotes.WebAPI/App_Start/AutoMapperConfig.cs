using AutoMapper;
using CloudNotes.Domain.Model;
using CloudNotes.Infrastructure;
using CloudNotes.ViewModels;
using System;
using System.Text;

namespace CloudNotes.WebAPI
{
    /// <summary>
    /// Represents the configuration to the AutoMapper framework.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            Mapper.CreateMap<CreateUserViewModel, User>()
                .ForMember(user => user.DateRegistered, opt => opt.MapFrom(m => DateTime.UtcNow))
                .ForMember(user => user.Locked, opt => opt.UseValue(false))
                .ForMember(user => user.Password, opt => opt.ResolveUsing(m => Encoding.ASCII.GetString(Convert.FromBase64String(m.Password))));

            Mapper.CreateMap<CreateNoteViewModel, Note>()
                .ForMember(note => note.DatePublished, opt => opt.MapFrom(m => DateTime.UtcNow))
                .ForMember(
                    note => note.Weather,
                    opt => opt.ResolveUsing(viewModel => (Weather)Enum.Parse(typeof(Weather), viewModel.Weather)));

            Mapper.CreateMap<UpdateNoteViewModel, Note>()
                .ForMember(note => note.ID, opt => opt.Ignore())
                .ForMember(
                    note => note.Weather,
                    opt => opt.ResolveUsing(viewModel => (Weather)Enum.Parse(typeof(Weather), viewModel.Weather)))
                .ForMember(note => note.DatePublished, opt => opt.Ignore())
                .ForMember(note => note.User, opt => opt.Ignore())
                .ForMember(note => note.DateLastModified, opt => opt.MapFrom(m => DateTime.UtcNow));

            Mapper.CreateMap<Note, NoteItemViewModel>()
                .ForMember(
                    noteItemViewModel => noteItemViewModel.DeletedString,
                    opt => opt.MapFrom(note => note.Deleted == null ? "None" : note.Deleted.ToString()))
                .ForMember(
                    noteItemViewModel => noteItemViewModel.DeletedFlag,
                    opt => opt.MapFrom(note => note.Deleted == null ? (int)DeleteFlag.None : (int)note.Deleted.Value));

            Mapper.CreateMap<Note, NoteViewModel>()
                .ForMember(viewModel => viewModel.Weather, opt => opt.ResolveUsing(note => note.Weather.ToString()))
                .ForMember(viewModel => viewModel.UserID, opt => opt.ResolveUsing(note => note.User.ID));
            
        }
    }
}