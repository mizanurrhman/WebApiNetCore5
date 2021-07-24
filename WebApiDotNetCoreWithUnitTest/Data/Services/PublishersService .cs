﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDotNetCoreWithUnitTest.Data.Models;
using WebApiDotNetCoreWithUnitTest.Data.ViewModels;

namespace WebApiDotNetCoreWithUnitTest.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                    .Select(n => new PublisherWithBooksAndAuthorsVM()
                    {
                        Name = n.Name,
                        BookAuthors = n.Books.Select(n => new BookAuthorVM()
                        {
                            BookName = n.Title,
                            BookAuthors = n.BookAuthors.Select(n => n.Author.FullName).ToList()
                        }).ToList()
                    }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher !=null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
