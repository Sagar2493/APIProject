using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Implementation
{
    public class LibraryRepository: ILibraryRepository<Author>
    {
        readonly LibraryContext _libraryContext;

        public LibraryRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Author> GetAllAuthor()
        {
            return _libraryContext.Authors.ToList();
        }

        public Author GetAuthor(Guid authorId)
        {
            try
            {
                return _libraryContext.Authors.Where(e => e.AuthorId == authorId).FirstOrDefault();
            }
            catch(Exception ex)
            {
                //log exception
                return null;
            }
        }
        public Author PostAuthor(Author author)
        {
            try
            {
                if(_libraryContext!=null)
                {
                    _libraryContext.Add(author);
                    _libraryContext.SaveChanges();
                    return author;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                //log exception
                return null;
            }
        }

        public Author UpdateAuthor(Author author)
        {
            try
            {
                if (_libraryContext != null)
                {
                    //var entity = _libraryContext.Authors.FirstOrDefault(e=> e.AuthorId == id);
                    //entity.FirstName = author.FirstName;
                    //entity.LastName = author.LastName;
                    //entity.Genre = author.Genre;
                    //entity.Books = author.Books;
                    _libraryContext.Update(author);
                    _libraryContext.SaveChanges();
                    return author;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        public string DeleteAuthor(Guid authorId)
        {
            try
            {
                if (_libraryContext != null)
                {
                    var author = _libraryContext.Authors.FirstOrDefault(x => x.AuthorId== authorId);
                    if(author!=null)
                    {
                        _libraryContext.Remove(author);
                        _libraryContext.SaveChanges();                      
                    }
                 
                }
                else
                {
                    return "Record hasn't deleted properly";
                }


            }
            catch(Exception ex)
            {
                //log exception
                return ex.Message;
            }

            return "Record has deleted successfully";
        }
    }
}
