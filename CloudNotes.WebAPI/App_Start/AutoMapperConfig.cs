//  =======================================================================================================
// 
//     ,uEZGZX  LG                             Eu       iJ       vi                                              
//    BB7.  .:  uM                             8F       0BN      Bq             S:                               
//   @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
//  ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
//  v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
//  .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//   @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//    ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//      iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
// 
// 
//  Copyright 2014-2015 daxnet
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  =======================================================================================================

namespace CloudNotes.WebAPI
{
    using System;
    using System.Text;
    using AutoMapper;
    using CloudNotes.DESecurity;
    using CloudNotes.Domain.Model;
    using CloudNotes.Infrastructure;
    using CloudNotes.ViewModels;

    /// <summary>
    ///     Represents the configuration to the AutoMapper framework.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            var crypto = Crypto.CreateDefaultCrypto();
            Mapper.CreateMap<CreateUserViewModel, User>()
                .ForMember(user => user.DateRegistered, opt => opt.MapFrom(m => DateTime.UtcNow))
                .ForMember(user => user.Locked, opt => opt.UseValue(false))
                .ForMember(user => user.Password,
                    opt => opt.ResolveUsing(m => Encoding.ASCII.GetString(Convert.FromBase64String(m.Password))));

            Mapper.CreateMap<CreateNoteViewModel, Note>()
                .ForMember(note => note.DatePublished, opt => opt.MapFrom(m => DateTime.UtcNow))
                .ForMember(
                    note => note.Weather,
                    opt => opt.ResolveUsing(viewModel => (Weather) Enum.Parse(typeof (Weather), viewModel.Weather)))
                .ForMember(note => note.Description, opt => opt.ResolveUsing(
                    viewModel =>
                    {
                        var html = crypto.Decrypt(viewModel.Content);
                        return crypto.Encrypt(HtmlUtilities.ExtractDescription(html));
                    }))
                .ForMember(note => note.ThumbnailBase64, opt => opt.ResolveUsing(
                    viewModel =>
                    {
                        var html = crypto.Decrypt(viewModel.Content);
                        return HtmlUtilities.ExtractThumbnailBase64(html);
                    }));

            Mapper.CreateMap<UpdateNoteViewModel, Note>()
                .ForMember(note => note.ID, opt => opt.Ignore())
                .ForMember(
                    note => note.Weather,
                    opt => opt.ResolveUsing(viewModel => (Weather) Enum.Parse(typeof (Weather), viewModel.Weather)))
                .ForMember(note => note.DatePublished, opt => opt.Ignore())
                .ForMember(note => note.User, opt => opt.Ignore())
                .ForMember(note => note.DateLastModified, opt => opt.MapFrom(m => DateTime.UtcNow))
                .ForMember(note => note.Description, opt => opt.ResolveUsing(
                    viewModel =>
                    {
                        var html = crypto.Decrypt(viewModel.Content);
                        return crypto.Encrypt(HtmlUtilities.ExtractDescription(html));
                    }))
                .ForMember(note => note.ThumbnailBase64, opt => opt.ResolveUsing(
                    viewModel =>
                    {
                        var html = crypto.Decrypt(viewModel.Content);
                        return HtmlUtilities.ExtractThumbnailBase64(html);
                    }));

            Mapper.CreateMap<Note, NoteItemViewModel>()
                .ForMember(
                    noteItemViewModel => noteItemViewModel.DeletedString,
                    opt => opt.MapFrom(note => note.Deleted == null ? "None" : note.Deleted.ToString()))
                .ForMember(
                    noteItemViewModel => noteItemViewModel.DeletedFlag,
                    opt => opt.MapFrom(note => note.Deleted == null ? (int) DeleteFlag.None : (int) note.Deleted.Value));

            Mapper.CreateMap<Note, NoteViewModel>()
                .ForMember(viewModel => viewModel.Weather, opt => opt.ResolveUsing(note => note.Weather.ToString()))
                .ForMember(viewModel => viewModel.UserID, opt => opt.ResolveUsing(note => note.User.ID));
        }
    }
}